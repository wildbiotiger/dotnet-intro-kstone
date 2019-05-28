using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pirate
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
        //removing highlighted pirate from listbox and collection by clicking remove button
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).RemovePirates(ListBox.SelectedIndex);
        }
        //removing highlighted pirate from listbox and collection by hitting delete on keyboard
        private void ListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                ((MainViewModel)DataContext).RemovePirates(ListBox.SelectedIndex);
        }
        //Add pirates to listbox by hitting enter on keyboard
        private void EnterAdd(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ((MainViewModel)DataContext).AddPirates(TextBox.Text);
        }
        //clearing textbox by hitting enter on keyboard
        private void EnterClear(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox.Clear();
            }
        }
    }
}
