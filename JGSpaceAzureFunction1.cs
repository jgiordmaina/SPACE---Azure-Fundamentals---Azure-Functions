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
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req, string rpsInput)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string responseMessage = string.IsNullOrEmpty(rpsInput)
                ? "No input detected - Please add {\"rpsInput\": \"rock\" }"
                : $"You chose \"{rpsInput}\".";

                string[] validInputs = { "rock", "paper", "scissors" };
                string computerChoice = validInputs[new Random().Next(validInputs.Length)];

                string result;
                if (rpsInput == computerChoice)
                {
                    result = "It's a tie!";
                }
                else if ((rpsInput == "rock" && computerChoice == "scissors") ||
                         (rpsInput == "paper" && computerChoice == "rock") ||
                         (rpsInput == "scissors" && computerChoice == "paper"))
                {
                    result = "You win!";
                }
                else
                {
                    result = "You lose!";
                }

                responseMessage += $" The computer chose {computerChoice}. Result: {result}";
            return new OkObjectResult(responseMessage);
        }
    }
}
