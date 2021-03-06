using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Soccer.Server.FutDb;

namespace Soccer.Server
{
    public class LeaguesFunction
    {
		private readonly IFutService futService;

		public LeaguesFunction(IFutService futService)
		{
			this.futService = futService;
		}

        [FunctionName("Leagues")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Leagues")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Functions Leagues Start");
            var leagues = await futService.GetLeagues();
            return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(leagues));
        }
    }
}
