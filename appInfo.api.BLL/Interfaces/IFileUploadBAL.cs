using appInfo.api.common.models;
using Azure.Storage.Blobs.Models;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
namespace appInfo.API.BLL.Interfaces
{
    public interface IFileUploadBAL
    {
     //    ImageUploadResult UploadFiles(IFormFile files);

        Task<BlobResponseDto>UploadFiles(IFormFile files);


    }
}