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
        private string _afbeelding;
        public string cardId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public string cost { get; set; }
        public string artist { get; set; }
        public string playerClass { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public string afbeelding
        {
            get
            {
                if (cardId.Length < 10)
                {
                    return "https://art.hearthstonejson.com/v1/render/latest/enUS/512x/" + cardId + ".png";
                }
                else
                {
                    return _afbeelding;
                }

            }
            set
            {
                _afbeelding = value;
            }
        }
    }
}
