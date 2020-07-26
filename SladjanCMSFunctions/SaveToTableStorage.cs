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
    public static class SaveToTableStorage
    {
        [FunctionName("SaveToTableStorage")]
        [return: Table("Devicess")]
        public static async Task<Device> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "tabledevices")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject<Device>(requestBody);

            data.PartitionKey = "Device";
            data.RowKey = Guid.NewGuid().ToString();
      

            return data;
        }
    }
}
