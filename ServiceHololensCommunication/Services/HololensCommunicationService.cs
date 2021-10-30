using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHololensCommunication.Services
{
    public class HololensCommunicationService
    {
        private static HololensCommunicationService _instance;
        private Boolean _hololensConnectionStatus;
        private int _idProcedimiento; 

        public static HololensCommunicationService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new HololensCommunicationService();
            }
            return _instance;
        }

        public Boolean ConnectHololens()
        {
            _hololensConnectionStatus = true;
            return true;

        }

        public Boolean DisconnectHololens() {
            _hololensConnectionStatus = false;
            return true;
        }

        public Boolean HololensConnectionStatus() {
            return _hololensConnectionStatus;
        }

        public int ObtainProcedureData() {
            return _idProcedimiento;
        }

        public void SetProcedureData(int IdProcedimiento) {
            _idProcedimiento = IdProcedimiento;
        }
    }
}
