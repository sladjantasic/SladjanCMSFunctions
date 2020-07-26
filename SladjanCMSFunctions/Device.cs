using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SladjanCMSFunctions
{
    public class Device : TableEntity
    {

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Connection status")]
        public bool IsConnected { get; set; }
    }
}
