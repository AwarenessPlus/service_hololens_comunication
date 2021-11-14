using System;
using Xunit;
using ServiceHololensCommunication.Controllers;
using ServiceHololensCommunication.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace ServiceTest
{
    public class HololensCommunicationControllerTest
    {
        Mock<IHololensCommunicationService> hololensCommunicationServiceMock;
        HololensCommunicationController _controller; 
        public HololensCommunicationControllerTest() { 
            hololensCommunicationServiceMock = new Mock<IHololensCommunicationService>(); 
            _controller = new HololensCommunicationController(hololensCommunicationServiceMock.Object);       
        }

        [Fact] public void ok_GetHealthStatus_withResults() { 
            IActionResult okResult = _controller.GetHealth(); 
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact] public void ok_ConnectHololens_withResults() {
            hololensCommunicationServiceMock.Setup(p => p.ConnectHololens()).Returns(true);
            ObjectResult okResult = (ObjectResult)_controller.ConnectHololens(); 
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
            Assert.Equal("Hololens connected",okResult.Value);
        }
        [Fact] public void ok_DisConnectHololens_withResults() {
            hololensCommunicationServiceMock.Setup(p => p.DisconnectHololens()).Returns(true);
            ObjectResult okResult =(ObjectResult) _controller.DisconnectHololens(); 
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
            Assert.Equal("Hololens disconnected", okResult.Value);
        }
        [Fact] public void ok_ConnectionStatus_withResultsTrue() {
            hololensCommunicationServiceMock.Setup(p => p.HololensConnectionStatus()).Returns(true); 
            ObjectResult okResult = (ObjectResult)_controller.HololensConnectionStatus(); 
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult); Assert.NotNull(okResult);
            Assert.Equal(true, okResult.Value); 
        }
        [Fact] public void ok_ConnectionStatus_withResultsFalse() { 
            hololensCommunicationServiceMock.Setup(p => p.HololensConnectionStatus()).Returns(false); 

            ObjectResult okResult = (ObjectResult)_controller.HololensConnectionStatus();
            Assert.IsType<OkObjectResult>(okResult); Assert.NotNull(okResult); 
            Assert.Equal(false, okResult.Value); }
        [Fact] public void ok_SetProcedureData_posted() { 
            int newDataProcedure = 125;
            hololensCommunicationServiceMock.Setup(p => p.SetProcedureData(newDataProcedure)).Returns(newDataProcedure);
            ObjectResult okResult = (ObjectResult)_controller.SetProcedureData(newDataProcedure);

            Assert.IsType<AcceptedResult>(okResult); 
            Assert.NotNull(okResult); 
            Assert.Equal(newDataProcedure, okResult.Value);
        }

       [Fact]
        public void ok_obtainProcedureData_withResults()
        {
            int newDataProcedure = 245;
            hololensCommunicationServiceMock.Setup(p => p.ObtainProcedureData()).Returns(newDataProcedure);
            ObjectResult okResult = (ObjectResult)_controller.ObtainProcedureData();
            Assert.IsType<OkObjectResult>(okResult);
            Assert.NotNull(okResult);
            Assert.Equal(newDataProcedure, okResult.Value);
        }
    }
}
