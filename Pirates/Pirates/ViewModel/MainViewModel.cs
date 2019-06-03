using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Pirate
{
    /// <summary>
    /// MainViewModel for Pirates application
    /// </summary>
    public class MainViewModel
    {
        public MainViewModel()
        {

            ///creates observable collection
            Pirates = new ObservableCollection<Pirates>
            {
                new Pirates {Name = "Davy Jones", Ship = "Flying Dutchmen", homePort = "Tortuga"},
                new Pirates {Name = "James Kirk", Ship = "Enterprise", homePort = "Earth"},
                new Pirates {Name = "Doctor", Ship = "Tardis", homePort = "Gallifrey" },
                new Pirates {Name = "Han Solo", Ship = "Millinenum Falcon", homePort = "Endor"}                
            };
        }

        public static MainViewModel DataContext { get; set; }
        public ObservableCollection<Pirates> Pirates { get; set; }

        /// <summary>
        /// new method for shorthand adding pirate profile from collection
        /// </summary>
        /// <param name="newPirate"></param>
        /// <param name="newBoat"></param>
        /// <param name="newPort"></param>
        public void AddPirates(string newPirate, string newBoat, string newPort)
        {
            Pirates.Add(new Pirates { Name = newPirate, Ship = newBoat, homePort = newPort });
            
        }

        /// <summary>
        /// method for new pirate
        /// </summary>
        /// <param name="newPerson"></param>
        public void AddPerson(string newPerson)
        {
            Pirates.Add(new Pirates { Name = newPerson });
        }

        /// <summary>
        /// method to add new ship to collection
        /// </summary>
        /// <param name="newShip"></param>
        public void AddShip(string newShip)
        {
            Pirates.Add(new Pirates { Ship = newShip});
        }

        /// <summary>
        /// method to add new home port to collection
        /// </summary>
        /// <param name="newLanding"></param>
        public void AddPort( string newLanding)
        {
            Pirates.Add(new Pirates { homePort = newLanding });
        }

        /// <summary>
        /// new method for shorthand removing pirate names from collection
        /// </summary>
        /// <param name="losePirate"></param>
        public void RemovePirates(int losePirate)
        {
            Pirates.RemoveAt(losePirate);
        }                     
    }
}