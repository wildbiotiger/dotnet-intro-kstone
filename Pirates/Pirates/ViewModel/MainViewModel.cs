using System.Collections.ObjectModel;

namespace Pirates
{
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
        public ObservableCollection<PirateNames> Pirates { get; set; }
        
        //Method to add pirate names to listbox
        public void AddPirates(string newPirate)
        {
            Pirates.Add(new PirateName { Name = newPirate });
        }
        //Method to remove pirate names from listbox
        public void RemovePirate(int losePirate)
        {
            Pirates.RemoveAt(losePirate);
        }
    }
}
