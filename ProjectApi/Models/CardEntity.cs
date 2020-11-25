using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectApi.Models
{
    public class CardEntity : TableEntity
    {
        public CardEntity()
        {

        }
        public CardEntity(string Artist, string Cardid)
        {
            this.PartitionKey = Artist;
            this.RowKey = Cardid;
        }

        public string name { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public string cost { get; set; }
        public string playerClass { get; set; }
        public string mechanics { get; set; }
        public string afbeelding { get; set; }
    }
}

