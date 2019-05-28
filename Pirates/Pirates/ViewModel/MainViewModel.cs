using System.Collections.ObjectModel;

namespace Pirate
{
    /// <summary>
    /// MainViewModel for Pirates application
    /// </summary>
    public class MainViewModel
    {
        public MainViewModel()
        {
            //creates observable collection
            Pirates = new ObservableCollection<PirateName>
            {
                new PirateName {Name = "Davy Jones"},
                new PirateName {Name = "Black Beard"},
            };
        }

        public static MainViewModel DataContext { get; set; }
        public ObservableCollection<PirateName> Pirates { get; set; }

        //new method for shorthand adding pirate names from collection
        public void AddPirates(string newPirate)
        {
            Pirates.Add(new PirateName { Name = newPirate });
        }

        //new method for shorthand removing pirate names from collection
        public void RemovePirates(int losePirate)
        {
            Pirates.RemoveAt(losePirate);
        }
    }

}