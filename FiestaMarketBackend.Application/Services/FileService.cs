using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using Microsoft.AspNetCore.Http;

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

        public async Task<Result<List<Image>, Error>> AddImages(List<IFormFile> images)
        {
            List<Image> addedImages = new();

            try
            {
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
                    var addedImage = new Image { Id = Guid.NewGuid(), Path = path, Url = url };
                    addedImages.Add(addedImage);
                }
            }
            catch (Exception)
            {
                return Result.Failure<List<Image>, Error>(Error.Failure("FileService.ErrorAddingImages", "Error adding images"));
            }

            return Result.Success<List<Image>, Error>(addedImages);
        }

        public UnitResult<Error> DeleteImages(List<Image> images)
        {
            try
            {
                foreach (var image in images)
                    File.Delete(image.Path);

                return UnitResult.Success<Error>();
            }
            catch (Exception)
            {
                return UnitResult.Failure(Error.Failure("FileService.ErrorDeletingImages", "Error deleting images"));
            }
        }

    }
}
