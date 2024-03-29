﻿using ClientSerie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientSerie.Services
{
    public class WSService : IService
    {
        private readonly HttpClient httpClient;

        public WSService(string uri)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(uri);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Serie>> GetSeriesAsync(string nomControleur)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Serie>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Serie> GetSerieAsync(string nomControleur, int id)
        {
            try
            {
                string lien = string.Concat(nomControleur,"/",id);
                return await httpClient.GetFromJsonAsync<Serie>(lien);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> PostSerieAsync(string nomControleur, Serie serie)
        {
            try
            {
                var response =  await httpClient.PostAsJsonAsync(nomControleur, serie);
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PutSerieAsync(string nomControleur,int id, Serie serie)
        {
            try
            {
                string lien = string.Concat(nomControleur, "/", id);
                var response = await httpClient.PutAsJsonAsync(lien, serie);
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSerieAsync(string nomControleur, int id)
        {
            try
            {
                string lien = string.Concat(nomControleur, "/", id);
                var response = await httpClient.DeleteAsync(lien);
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}