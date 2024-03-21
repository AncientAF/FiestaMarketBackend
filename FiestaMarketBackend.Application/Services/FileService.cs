using FiestaMarketBackend.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Services
{
    public class FileService
    {
        private readonly string _rootPath;
        private readonly string _requestPath;

        public FileService(string rootPath, string requestPath)
        {
            _rootPath = rootPath;
            _requestPath = requestPath;
        }

        public async Task<List<Image>> AddImages(List<IFormFile> images)
        {
            List<Image> addedImages = new();

            foreach (FormFile image in images)
            {
                string name = new string(Path.GetFileNameWithoutExtension(image.FileName)).Replace(' ', '-');
                name = name + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(image.FileName);
                string path = Path.Combine(_rootPath, "Images", name);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                var url = _requestPath + "/Images/" + name;
                var addedImage = new Image { Id = Guid.NewGuid(), Path = path, Url = url};
                addedImages.Add(addedImage);
            }

            return addedImages;
        }

        public void DeleteImages(List<Image> images)
        {
            foreach (var image in images)
                File.Delete(image.Path);
        }

    }
}
