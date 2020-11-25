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
using System.Collections.Generic;

namespace ProjectApi
{
    public static class Function3
    {
        [FunctionName("Function3")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getallcards")] HttpRequest req,
            ILogger log)
        {
            string connectionString = Environment.GetEnvironmentVariable("AzureStorage");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            CloudTable table = cloudTableClient.GetTableReference("cardsHeartstone");

            TableQuery<CardEntity> rangeQuery = new TableQuery<CardEntity>();

            var queryResult = await table.ExecuteQuerySegmentedAsync<CardEntity>(rangeQuery, null);
            List<Card> cards = new List<Card>();

            foreach (var reg in queryResult.Results)
            {
                cards.Add(new Card()
                {
                    cardId = reg.RowKey,
                    name = reg.name,
                    type = reg.type,
                    rarity = reg.rarity,
                    cost = reg.cost,
                    playerClass = reg.playerClass,
                    mechanics = reg.mechanics,
                    artist = reg.PartitionKey,
                    afbeelding = reg.afbeelding
                });
            }
            return new OkObjectResult(cards);
        }
    }
}
