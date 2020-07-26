using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SladjanCMSFunctions
{
    public static class GetOneFromCosmos
    {
        [FunctionName("GetOneFromCosmos")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "cosmosdevice")] HttpRequest req,
            [CosmosDB(
                    databaseName: "DeviceCatalog",
                    collectionName: "Devices",
                    ConnectionStringSetting = "CosmosConnection",
                    Id = "{Query.id}"
            )] dynamic cosmosdb,
            ILogger log)
        {
            log.LogInformation("Requested item found");


            return new OkObjectResult(cosmosdb);
        }
    }
}
