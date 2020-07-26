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
    public static class SaveToCosmos
    {
        [FunctionName("SaveToCosmos")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "cosmosdevices")] HttpRequest req,
            [CosmosDB(
                    databaseName: "DeviceCatalog",
                    collectionName: "Devices",
                    ConnectionStringSetting = "CosmosConnection"
            )] out dynamic cosmosdb,
            ILogger log)
        {
            cosmosdb = new StreamReader(req.Body).ReadToEnd();
            log.LogInformation("Saved item to CosmosDB");

            return new OkResult();
        }
    }
}
