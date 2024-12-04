using Services.Interfaces;
using CsvHelper;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Services.DTOs;

namespace Services.Service
{
    public class ProductCSVReader : IFileCSVReader<ProductDTO>
    {
        public async Task<List<ProductDTO>> ReadFileCSVAsync(IFormFile file)
        {
            var reader = new StreamReader(file.OpenReadStream());
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var productos = await csv.GetRecordsAsync<ProductDTO>().ToListAsync();
            return productos;
        }
    }
}
