using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace FiestaMarketBackend.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<Result<List<Image>, Error>> AddImages(List<IFormFile> images);
        UnitResult<Error> DeleteImages(List<Image> images);
    }
}