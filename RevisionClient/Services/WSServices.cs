using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

using RevisionClient.Models;

namespace RevisionClient.Services
{
    public class WSService
    {
        private readonly HttpClient HttpClient;

        public WSService(string url)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://localhost:7259//api/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<Pilote>> GetSerieAsync(string nomControleur)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<List<Pilote>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Pilote> GetASerieAsync(Pilote serie)
        {
            var response = await HttpClient.GetAsync("Pilotes/" + serie.PiloteId);

            if (response.IsSuccessStatusCode)
            {
                var serieFromResponse = await response.Content.ReadAsAsync<Pilote>();
                return serieFromResponse;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> PostSerieAsync(Pilote pilote)
        {
            var response = await HttpClient.PostAsJsonAsync("Pilotes", pilote);
           

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutSerieAsync(Pilote pilote)
        {
            var response = await HttpClient.PutAsJsonAsync("Pilotes/" + pilote.PiloteId, pilote);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteSerieAsync(Pilote serie)
        {
            var response = await HttpClient.DeleteAsync("Pilotes/" + serie.PiloteId);
            return response.IsSuccessStatusCode;
        }








    }
}
