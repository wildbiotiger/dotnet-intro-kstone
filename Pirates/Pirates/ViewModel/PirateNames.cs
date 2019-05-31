using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirate
{ 
    /// <summary>
    /// Class for observable collection Pirates
    /// </summary>
    public class Pirates
    {
       
        ///String for Observable Collection
        public string Name { get; set; }
        public string Ship { get; set; }
        public string homePort { get; set; }
        public string Assignments
        {
            get
            {
                return String.Format("Name: {0}" + "\n" + "Ship: {1}" + "\n" + "Home Port: {2}", this.Name, this.Ship, this.homePort);
            }
        }
    }
}
