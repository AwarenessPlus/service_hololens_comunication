using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceHololensCommunication.Services;

namespace ServiceHololensCommunication.Controllers
{
    [ApiController]

    public class HololensCommunicationController : Controller
    {
        private readonly HololensCommunicationService HololensCommunicationService;

        public HololensCommunicationController(HololensCommunicationService hololensCommunicationService)
        {
            HololensCommunicationService = hololensCommunicationService;
        }

        [Route("api/hololens-communication-service/health-status")]
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok("Service connected");
        }

        [Route("api/hololens-communication-service/connect-hololens")]
        [HttpGet]
        public IActionResult ConnectHololens()
        {
            try
            {
                HololensCommunicationService.ConnectHololens();
                return Ok("Hololens connected");
            }
            catch {
                return NotFound("It wasn't posible connect the hololens. Try again");
            }
            
        }

        [Route("api/hololens-communication-service/disconnect-hololens")]
        [HttpGet]
        public IActionResult DisconnectHololens()
        {
            try
            {
                HololensCommunicationService.DisconnectHololens();
                HololensCommunicationService.SetProcedureData(0);
                return Ok("Hololens disconnected");
            }
            catch
            {
                return NotFound("It wasn't posible disconnect the hololens. Try again");
            }

        }

        [Route("api/hololens-communication-service/hololens-connection-status")]
        [HttpGet]
        public IActionResult HololensConnectionStatus()
        {
            return Ok(HololensCommunicationService.HololensConnectionStatus());
        }

        [Route("api/hololens-communication-service/obtain-procedure-data")]
        [HttpGet]
        public IActionResult ObtainProcedureData()
        {
            return Ok(HololensCommunicationService.ObtainProcedureData());
        }

        [Route("api/hololens-communication-service/set-procedure-data")]
        [HttpPost]
        public IActionResult SetProcedureData(int IdProcedure)
        {
            try {
                HololensCommunicationService.SetProcedureData(IdProcedure);
                return Accepted();

            } catch {

                return NotFound();

            }
        }
    }
}
