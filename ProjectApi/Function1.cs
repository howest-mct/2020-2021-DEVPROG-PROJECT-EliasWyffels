using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos.Table;
using ProjectApi.Models;

namespace ProjectApi
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = "submitcard")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Card reg = JsonConvert.DeserializeObject<Card>(requestBody);
            string memchanicsstring = "";
            if (reg.mechanics != null)
            {
                
                foreach (Mechanic item in reg.mechanics)
                {
                    memchanicsstring = memchanicsstring + "," + item.name;
                }
                memchanicsstring = memchanicsstring.Substring(1);
            }
            else
            {
                memchanicsstring = null;
            }

            string cardguid = Guid.NewGuid().ToString();
            CardEntity rn = new CardEntity(reg.artist,cardguid)
            {
                name = reg.name,
                type = reg.type,
                rarity = reg.rarity,
                cost = reg.cost,
                playerClass = reg.playerClass,
                mechanics = memchanicsstring,
                afbeelding = reg.afbeelding
            };

            string connectionString = Environment.GetEnvironmentVariable("AzureStorage");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            CloudTable table = cloudTableClient.GetTableReference("cardsHeartstone");
            await table.CreateIfNotExistsAsync();

            TableOperation insertOperation = TableOperation.Insert(rn);
            await table.ExecuteAsync(insertOperation);


            return new OkObjectResult(reg);


        }
    }
}
