using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class JGSpaceAzureFunction1
    {
        private readonly ILogger<JGSpaceAzureFunction1> _logger;

        public JGSpaceAzureFunction1(ILogger<JGSpaceAzureFunction1> logger)
        {
            _logger = logger;
        }

        [Function("JGSpaceAzureFunction1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions! - JG");
        }
    }
}
