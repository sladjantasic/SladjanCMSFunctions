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
        [FunctionName("GetAllFromCosmos")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [CosmosDB(
                    databaseName: "DeviceCatalog",
                    collectionName: "Devices",
                    ConnectionStringSetting = "CosmosConnection",
                    Id = "{Query.Id}"
            )] dynamic cosmosdb,
            ILogger log)
        {
            log.LogInformation("Requested item found");
            return new OkObjectResult(cosmosdb);
        }
    }
}