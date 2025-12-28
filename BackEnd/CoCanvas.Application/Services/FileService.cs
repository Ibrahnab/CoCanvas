//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CoCanvas.Application.Services
//{
//    public class FileService
//    {
//        private readonly string _root = "wwwroot";
//        public FileService() { 
        
//        }


//        public FileStream GetImage(Guid guid)
//        {
//            var filePath = Path.Combine(_env.ContentRootPath, "wwwroot/images", fileName);

//            if (!System.IO.File.Exists(filePath))
//                //return NotFound();
//                null;
//            var image = System.IO.File.OpenRead(filePath);
//            return File(image, "image/jpeg");
//        }
//    }
//}
