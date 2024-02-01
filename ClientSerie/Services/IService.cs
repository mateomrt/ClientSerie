using ClientSerie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSerie.Services
{
    internal interface IService
    {
        Task<List<Serie>> GetSeriesAsync(string nomControleur);
        Task<Serie> GetSerieAsync(string nomControleur, int id);

        Task<bool> PostSerieAsync(string nomControleur, Serie serie);

        Task<bool> PutSerieAsync(string nomControleur, Serie serie);

        Task<bool> DeleteSerieAsync(string nomControleur, int id);




    }
}