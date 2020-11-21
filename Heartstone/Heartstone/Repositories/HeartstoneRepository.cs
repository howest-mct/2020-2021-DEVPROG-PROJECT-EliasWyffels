using Heartstone.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Heartstone.Repositories
{
    public static class HeartstoneRepository
    {
        private const string key = "a1d89ce9aemshbf9e450c11e9732p15d45fjsn3bad1f763cb5";

        public static async Task<List<Card>> GetCardsClass(string clas)
        {
            using (HttpClient client = GetClient())
            {
                string url = $"https://omgvamp-hearthstone-v1.p.rapidapi.com/cards/classes/{clas}";
                try
                {
                    string json = await client.GetStringAsync(url);
                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<List<Card>>(json);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        private static HttpClient GetClient()
        {
            HttpClient httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpclient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "omgvamp-hearthstone-v1.p.rapidapi.com");
            httpclient.DefaultRequestHeaders.Add("X-RapidAPI-Key", key);
            return httpclient;
        }
    }
}
