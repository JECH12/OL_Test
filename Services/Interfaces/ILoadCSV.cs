using Microsoft.AspNetCore.Http;
using OL_TEST.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILoadCSV
    {
        Task<ResponseDTO<List<T>>> LoadCSVFile<T>(IFormFile file, string type);
    }
}
