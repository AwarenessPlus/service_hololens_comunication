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
        private readonly IHololensCommunicationService _hololensCommunicationService;

        public HololensCommunicationController(IHololensCommunicationService hololensCommunicationService)
        {
            _hololensCommunicationService = hololensCommunicationService;
        }

        public HololensCommunicationController()
        {
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
                _hololensCommunicationService.ConnectHololens();
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
                _hololensCommunicationService.DisconnectHololens();
                _hololensCommunicationService.SetProcedureData(0);
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
            return Ok(_hololensCommunicationService.HololensConnectionStatus());
        }

        [Route("api/hololens-communication-service/obtain-procedure-data")]
        [HttpGet]
        public IActionResult ObtainProcedureData()
        {
            return Ok(_hololensCommunicationService.ObtainProcedureData());
        }

        [Route("api/hololens-communication-service/set-procedure-data")]
        [HttpPost]
        public IActionResult SetProcedureData(int IdProcedure)
        {
            try {
                int number=_hololensCommunicationService.SetProcedureData(IdProcedure);
                return Accepted(number);

            } catch {

                return NotFound();

            }
        }
    }
}
