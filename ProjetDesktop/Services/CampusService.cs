using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProjetDesktop.Model;

namespace ProjetDesktop.Services
{
    public class CampusService
    {
        /*
         Lister les campus
         */
        public async Task<List<Campus>> GetServices()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("campus");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Campus>>(data);
                }
                else
                {
                    throw new Exception("La requête GET a échoué.");
                }
            }
        }

        /*
         Ajouter un campus les campus
         */
        public async Task<Campus> AjoutCampus(Campus campus)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(campus);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("campus", content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Campus>(data);
                }
                else
                {
                    throw new Exception("La requête POST a échoué.");
                }
            }
        }

        /*
         Modifier un campus
         */

        public async Task<Campus> UpdateCampus(int id, Campus campus)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(campus);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync($"campus/{id}", content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Campus>(data);
                }
                else
                {
                    throw new Exception("La requête PUT a échoué.");
                }
            }
        }

        /*
         Supprimer un campus
         */
        public async Task<bool> SupprimerCampus(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.DeleteAsync($"campus/{id}");
                return response.IsSuccessStatusCode;
            }
        }

    }
}
