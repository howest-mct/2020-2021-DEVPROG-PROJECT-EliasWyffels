using Heartstone.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
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
        public static async Task<string> ConvertImgToUrl(string Image)
        {
            var client = new RestClient("https://api.imgur.com/3/image");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Client-ID 2400cb3fc4ad10c");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("image", Image);
            IRestResponse response = client.Execute(request);
            string json = response.Content;
            Root account = JsonConvert.DeserializeObject<Root>(json);
            return account.data.link;
        }



        //public static async Task<string> ConvertImgToUrl(string Image)
        //{
        //    string url = "https://api.imgur.com/3/image";

        //    using (HttpClient client = GetClient2())
        //    {
        //        var parameters = new Dictionary<string, string> { { "image", Image } };
        //        string json = JsonConvert.SerializeObject(parameters);
        //        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        //        var response = await client.PostAsync(url, content);
        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            var test = response.Content;
        //            return "alles ok";
        //        }
        //        else
        //        {
        //            string errorMsg = $"Unsuccesful POST to url: {url}, object: {json}";
        //            throw new Exception(errorMsg);
        //            return "oepsie";
        //        }
        //    }
        //}

        //private static HttpClient GetClient2()
        //{
        //    HttpClient httpclient = new HttpClient();
        //    httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
        //    httpclient.DefaultRequestHeaders.Add("Authorization", "Client-ID 2400cb3fc4ad10c");
        //    return httpclient;
        //}


        public static async Task SendToDatabase(Card c)
        {
            string url = "https://hearstonecards.azurewebsites.net/api/submitcard";
            using (HttpClient client = GetClient2())
            {
                string mechanicsList = "";
                if (c.mechanics != null)
                {
                    foreach (Mechanic i in c.mechanics)
                    {
                        mechanicsList = mechanicsList + "," + i.name;
                    }
                    mechanicsList = mechanicsList.Substring(1);
                }
                else
                {
                    mechanicsList = "No mechanics";
                }
                var parameters = new Dictionary<string, string>
                {
                    { "name", c.name },
                    { "type", c.type },
                    { "rarity", c.rarity },
                    { "cost", c.cost },
                    { "playerclass", c.playerClass },
                    { "mechanics", mechanicsList },
                    { "afbeelding", c.afbeelding }
                };
                string json = JsonConvert.SerializeObject(parameters);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var test = response.Content;
                }
                else
                {
                    string errorMsg = $"Unsuccesful POST to url: {url}, object: {json}";
                    throw new Exception(errorMsg);
                }
            }
        }

        private static HttpClient GetClient2()
        {
            HttpClient httpclient = new HttpClient();
            httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
            return httpclient;
        }
        public static async Task<List<Card>> GetCustomCards()
        {
            using (HttpClient client = GetClient2())
            {
                string url = $"https://hearstonecards.azurewebsites.net/api/getallcards";
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
    }
}
