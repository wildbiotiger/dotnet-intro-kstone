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

        ///new method for shorthand adding pirate profile from collection
        public void AddPirates(string newPirate, string newBoat, string newPort)
        {
            Pirates.Add(new Pirates { Name = newPirate, Ship = newBoat, homePort = newPort });
            
        }

        /// method for new pirate
         public void AddPerson(string newPerson)
        {
            Pirates.Add(new Pirates { Name = newPerson });
        }

        /// method to add new ship to collection        
        public void AddShip(string newShip)
        {
            Pirates.Add(new Pirates { Ship = newShip});
        }

        /// method to add new home port to collection
        public void AddPort( string newLanding)
        {
            Pirates.Add(new Pirates { homePort = newLanding });
        }
        
        ///new method for shorthand removing pirate names from collection
        public void RemovePirates(int losePirate)
        {
            Pirates.RemoveAt(losePirate);
        }

        ///method to remove ship from collection
        public void RemoveShip(int loseShip)
        {
            Pirates.RemoveAt(loseShip);
        }        
    }
}