using MasterNet.Application.Photos;
using Microsoft.AspNetCore.Http;

namespace MasterNet.Application.Interface;

public interface IPhotoService
{
    Task<PhotoUploadResult> AddPhoto(IFormFile file);
    Task<String> DeletePhoto(string publicId);
}