using Microsoft.AspNetCore.Http;

namespace Services.Interfaces
{
    public interface IFileCSVReader<T>
    {
        Task<List<T>> ReadFileCSVAsync(IFormFile archivo);
    }
}
