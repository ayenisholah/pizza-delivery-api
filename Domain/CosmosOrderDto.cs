using System;
using Cosmonaut.Attributes;
using Newtonsoft.Json;

namespace DeliveryAPI.Domain
{
    [CosmosCollection("orders")]
    public class CosmosOrderDto
    { 
        [CosmosPartitionKey]
        [JsonProperty("id")]
        public string Id { get; set; }
        public decimal Amount { get; set; }

    }
}
