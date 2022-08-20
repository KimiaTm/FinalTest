using FinalTest.Core.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceHost.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHost.Controllers
{
    public class WriterController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:44377/api/Writer";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<IEnumerable<WriterDTO>>>(res);

            return View(json);
        }
        public async Task<IActionResult> LoadData()
        {
            var url = "https://localhost:44377/api/Writer";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<IEnumerable<WriterDTO>>>(res);

            return Json(json.Data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WriterDTO writer, IFormFile WriterPictureFile,string BirthDayDate)
        {

            var data = new MultipartFormDataContent();
            data.Headers.ContentType.MediaType = "multipart/form-data";

            data.Add(new StreamContent(WriterPictureFile.OpenReadStream()), "WriterPictureFile", WriterPictureFile.FileName);
            data.Add(new StringContent(writer.WriterId+""), "WriterId");
            data.Add(new StringContent(writer.WriterName), "WriterName");
            data.Add(new StringContent(BirthDayDate+""),"BirthDayDate" );

            var url = "https://localhost:44377/api/Writer/PostWriter";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            //form.Add(new ByteArrayContent(WriterPictureFile.OpenReadStream()., 0, file_bytes.Length), "profile_pic", "hello1.jpg");
            var result = await response.Content.ReadAsStringAsync();

            return Content(result);
        }

        public async Task<IActionResult> Get(int id)
        {
            var url = $"https://localhost:44377/api/Writer/{id}";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<WriterDTO>>(res);

            return Json(json);
        }
        public async Task<IActionResult> EditWriter(int id)
        {
            var url = $"https://localhost:44377/api/Writer/{id}";

            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync(url);

            var json = JsonConvert.DeserializeObject<ResponseViewModel<WriterDTO>>(res);

            return Json(json);
        }
        [HttpPost]
        public async Task<IActionResult> EditWriter(WriterDTO writer)
        {
            var json = JsonConvert.SerializeObject(writer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"https://localhost:44377/api/Writer/Edit/{writer}";

            HttpClient client = new HttpClient();

            var response = await client.PutAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();

            return RedirectToAction("index");
        }
        public async Task<IActionResult> DeleteWriter(int id)
        {

            var url = $"https://localhost:44377/api/Writer/Delete/{id}";

            HttpClient client = new HttpClient();

            var res = await client.DeleteAsync(url);

            return RedirectToAction("index", res);
        }
    }
    }
