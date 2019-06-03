using System;

namespace Pirate
{ 
    /// <summary>
    /// Class for observable collection Pirates
    /// </summary>
    public class Pirates
    {
        /// <summary>
        /// String for Observable Collection
        /// </summary>
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
