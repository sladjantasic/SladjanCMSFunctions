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

namespace SladjanCMSFunctions
{
    public static class GetAllDevicesFromTableStorage
    {
        [FunctionName("GetAllDevicesFromTableStorage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "tabledevices")] HttpRequest req,
            [Table("Devicess", "Device")] IEnumerable<dynamic> items,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(items);
        }
    }
}
