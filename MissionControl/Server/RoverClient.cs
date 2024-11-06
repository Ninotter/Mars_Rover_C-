using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MissionControl.Server
{
    internal class RoverClient : TcpClient
    {
        protected int _id = 0;
        protected string _name = "";

        public int ID => _id; 

        public string Name => _name;

        public RoverClient(int id, string name)
        {
            _id = id;
            _name = name;
        }
    }
}
