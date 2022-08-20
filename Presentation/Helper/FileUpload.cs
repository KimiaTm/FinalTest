using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;

namespace Presentation.Helper
{
    public static class FileUpload
    {
        public static string UploadedWriterImage(IFormFile file)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    //Getting file name
                    var fileName = Path.GetFileName(file.FileName);

                    //Assigning Unique FileName(GUID)
                    var MyUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting File Extension
                    var fileExtention = Path.GetExtension(fileName);

                    //Concatenating File +FileExtention
                    var newFileName = string.Concat(MyUniqueFileName, fileExtention);

                    //Combines two string into a path
                    var filePath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Writer")).Root + $@"\{newFileName}";


                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                    return newFileName;

                }

            }
            return null;
        }
    }
}
