using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR28_Degtinnikov.Modell
{
    public class Comp_Clubs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime WorkHours { get; set; }
        public Comp_Clubs(int id, string name, string address, DateTime workHours)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.WorkHours = workHours;
        }
    }
}
