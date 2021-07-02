using System.IO;
using Microsoft.AspNetCore.Http;

namespace UserLogin.Models
{
    public interface IFormFile
    {
        string ContentType { get; set; }
        string ContentDisposition { get; set; }
        IHeaderDictionary Headers { get; set; }
        long Length { get; set; }
        string Name { get; set; }
        string FileName { get; set; }
        Stream OpenReadStream();
        void CopyTo(Stream target);
    }
}