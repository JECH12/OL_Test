using Microsoft.AspNetCore.Http;
using OL_TEST.DTOs;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Enum;
using Type = Services.Enum.Type;

namespace Services.Service
{
    public class LoadCSV : ILoadCSV
    {
        private readonly IFileCSVReader<ClientDTO> _clientCSVReader;
        private readonly IFileCSVReader<ProductDTO> _productCSVReader;

        public LoadCSV(IFileCSVReader<ClientDTO> clientCSVReader, IFileCSVReader<ProductDTO> productCSVReader)
        {
            _clientCSVReader = clientCSVReader;
            _productCSVReader = productCSVReader;
        }

        public async Task<ResponseDTO<List<T>>> LoadCSVFile<T>(IFormFile file, string type)
        {
            try
            {
                if (System.Enum.TryParse<Type>(type, true, out var entityType))
                {
                    object result = entityType switch
                    {
                        Type.Clients => await _clientCSVReader.ReadFileCSVAsync(file),
                        Type.Products => await _productCSVReader.ReadFileCSVAsync(file),
                        _ => throw new ArgumentException("Tipo de archivo no válido.")
                    };
                

                    if (result is List<T> typedResult)
                    {
                        return new ResponseDTO<List<T>>
                        {
                            StatusCode = StatusCodes.Status200OK,
                            Message = "Archivo procesado con éxito.",
                            Result = typedResult
                        };
                    }
 
                }
                throw new InvalidCastException($"No se puede convertir el resultado al tipo esperado: {typeof(T)}.");
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<T>>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = $"Error al procesar el archivo: {ex.Message}",
                    Result = null
                };
            }
        }
    }
}
