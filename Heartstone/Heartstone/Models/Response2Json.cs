using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heartstone.Models
{
        public class Data
        //klasse voor de afbeeldinglink te krijgen uit de responsebody voor onze custom cards
        {
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
        }

        public class Root
        {
        public Data data { get; set; }
        }
    }
    

