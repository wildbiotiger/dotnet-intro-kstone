using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pirates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //adding the textbox info to pirates collection by clicking add button
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).AddPirates(TextBox.Text);
        }

        //clearing textbox by hitting the enter key
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox.Clear();
            }
        }
        //adding the textbox info to pirates collection by hitting enter


        //removing highlighted pirate from listbox and collection by clicking remove button
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).RemovePirates(ListBox.SelectedIndex);
        }

        private void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                ((MainViewModel)DataContext).RemovePirates(ListBox.SelectedIndex);
        }

        private void EnterAdd(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
                ((MainViewModel)DataContext).AddPirates(TextBox.Text);

        }

        private void EnterClear(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                TextBox.Clear();
            }

        }








        //removing highlighted pirate from listbox and collectin by hitting delete key



    }

}







