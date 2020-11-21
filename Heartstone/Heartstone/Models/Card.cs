using System;
using System.Collections.Generic;
using System.Text;

namespace Heartstone.Models
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
        public int cost { get; set; }
        public string faction { get; set; }
        public string artist { get; set; }
        public string playerClass { get; set; }
        public List<Mechanic> mechanics { get; set; }
    }
}
