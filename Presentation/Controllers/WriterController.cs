using FinalTest.Core.Contract.Facade;
using FinalTest.Core.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Helper;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
    public static string API_LINK = "https://localhost:44377/";
        private readonly IWriterFacade writerFacade;

        public WriterController(IWriterFacade writerFacade)
        {
            this.writerFacade = writerFacade;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ResponseViewModel<IEnumerable<WriterDTO>> model = new ResponseViewModel<IEnumerable<WriterDTO>>();
            try
            {

                var resultdata = writerFacade.GetAll().ToList();

                foreach (var item in resultdata) { 
                    item.WriterPicture= API_LINK+"images/writer/" +item.WriterPicture;
                }
                model.Data = resultdata;
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            ResponseViewModel<WriterDTO> model = new ResponseViewModel<WriterDTO>();
            try
            {
                model.Data = writerFacade.getById(id);
            }
            catch (Exception ex)
            {

                model.AddError("نویسنده وجود ندارد");
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPost]
        [Route("PostWriter")]
        public IActionResult PostWriter([FromForm]WriterDTO writer, [FromForm]IFormFile WriterPictureFile)
        {
            ResponseViewModel<int> model = new ResponseViewModel<int>();
            try
            {
                if (writer.WriterPicture == null) { writer.WriterPicture = "empty"; }
                if (writer.BirthDayDate == null || writer.BirthDayDate.Year<1780|| DateHelper.GetAge(writer.BirthDayDate) < 18)
                {
                    model.AddError("Your Writer Under 18 years old!");
                }
                else
                {
                    string filename = FileUpload.UploadedWriterImage(WriterPictureFile);
                    writer.WriterPicture = filename;
                    model.Data = writerFacade.Add(writer);
                    return Created($"/api/Writer/{model.Data}", model);
                }
            }
            catch (Exception ex)
            {
                model.AddError(ex.InnerException.ToString());

            }
            return BadRequest(model);

        }


        [HttpPut]
        [Route("Edit/{Writer}")]
        public IActionResult EditWriter(WriterDTO writer)
        {
            if (writer.WriterId == 0)
            {
                return BadRequest("Id Not Found");
            }
            writerFacade.Update(writer);
            return Ok(writer);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteWriter(int id)
        {

            var writer = writerFacade.getById(id);
            writerFacade.Remove(writer);
            return Ok($"/api/writer/Delete/{writer}");
        }

    }
}

