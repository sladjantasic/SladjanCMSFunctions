using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace SladjanCMSFunctions
{
    public static class GetAllFromCosmos
    {
        [FunctionName("GetAllFromCosmos")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "cosmosdevices")] HttpRequest req,
            [CosmosDB(
                    databaseName: "DeviceCatalog",
                    collectionName: "Devices",
                    ConnectionStringSetting = "CosmosConnection",
                    SqlQuery = "SELECT * FROM c"
            )] IEnumerable<dynamic> cosmosdb,
            ILogger log)
        {
            log.LogInformation("Requested item(s) found");

            string id = req.Query["id"];
            var result = cosmosdb.Where(e => e.id == id).FirstOrDefault();
            result ??= cosmosdb;

            return new OkObjectResult(result);
        }
    }
}
