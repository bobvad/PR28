using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR28_Degtinnikov.Modell
{
    public class Arenda_GameComp
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public string FIOClients { get; set; }
        public Arenda_GameComp(int id,DateTime dateTime,string FIOClients)
        {
            this.Id = id;
            this.dateTime = dateTime;
            this.FIOClients = FIOClients;
        }
    }
}
