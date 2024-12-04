using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ClientCSVReader : IFileCSVReader<ClientDTO>
    {
        public async Task<List<ClientDTO>> ReadFileCSVAsync(IFormFile file)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";", // Cambia esto si usas otro delimitador
                PrepareHeaderForMatch = args => args.Header.ToLower(), // Normaliza encabezados
            });


            // Configurar el formato de fecha
            csv.Context.TypeConverterOptionsCache.GetOptions<DateTime>().Formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };

            var clients = new List<ClientDTO>();
            await foreach (var record in csv.GetRecordsAsync<ClientDTO>())
            {
                clients.Add(record);
            }

            return clients;
        }
    }
}
