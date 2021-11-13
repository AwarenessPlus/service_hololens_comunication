using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHololensCommunication.Services
{
    public interface IHololensCommunicationService
    {

        public bool ConnectHololens();

        public Boolean DisconnectHololens();

        public Boolean HololensConnectionStatus();
        public int ObtainProcedureData();

        public int SetProcedureData(int IdProcedimiento);
    }
}
