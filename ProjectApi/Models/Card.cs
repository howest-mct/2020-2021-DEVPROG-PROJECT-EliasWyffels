using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectApi.Models
{
    public class Mechanic
    {
        public string name { get; set; }
    }
    public class Card
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public string cost { get; set; }
        public string artist { get; set; }
        public string playerClass { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public string afbeelding { get; set; }

        public Card()
        {

        }

    }
}
