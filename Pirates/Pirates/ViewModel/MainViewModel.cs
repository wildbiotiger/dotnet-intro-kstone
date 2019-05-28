using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Pirates
{
    public class MainViewModel
    {
        public MainViewModel()
        {

            Pirates = new ObservableCollection<PirateNames>
            {


                new PirateNames {Name = "Davy Jones"},
                new PirateNames {Name = "Black Beard"},

            };
        }



        public static MainViewModel DataContext { get; set; }
        public ObservableCollection<PirateNames> Pirates { get; set; }

        public void AddPirates(string newPirate)
        {
            Pirates.Add(new PirateNames { Name = newPirate });
        }

        public void RemovePirates(int losePirates)
        {
            Pirates.RemoveAt(losePirates);
        }
    }

}
