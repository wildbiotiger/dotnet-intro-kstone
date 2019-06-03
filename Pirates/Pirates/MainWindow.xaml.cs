using System;
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
        /// <summary>
        /// class for Mainwindow code 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// add the textbox info to pirates collection by clicking add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click_1(object sender, RoutedEventArgs e)
        {
            if ((InsertBox.Text == String.Empty || ShipBox.Text == String.Empty || HomeBox.Text == String.Empty))
                {
                MessageBox.Show("Enter Pirate Name Please.", "Error");
            }
            else
            {
                ((MainViewModel)DataContext).AddPirates((InsertBox.Text), (ShipBox.Text), HomeBox.Text);
                InsertBox.Clear();
                ShipBox.Clear();
                HomeBox.Clear();
            } 
        }

        /// <summary>
        /// add pirates to listbox by hitting enter key on keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterAdd(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (string.IsNullOrWhiteSpace(InsertBox.Text))
                {
                    MessageBox.Show("Enter Pirate Name Please.", "Error");
                }

                else ((MainViewModel)DataContext).AddPirates((InsertBox.Text), ShipBox.Text, HomeBox.Text);
            }
        }

        /// <summary>
        /// choose a pirate with combo box and have it display in textblock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameBoxClick(object sender, SelectionChangedEventArgs e)
        {
            Pirates Person = NameBox.SelectedItem as Pirates;
            if (Person !=null)
            {
                NameBlock.Content = "Name:"+" "+Person.Name;
                ShipBlock.Content = "Ship:"+" "+Person.Ship;
                PortBlock.Content = "Port:"+" "+Person.homePort;
            }            
        }

        /// <summary>
        /// remove pirate from listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).RemovePirates(NameBox.SelectedIndex);
            NameBlock.Content = " ";
            ShipBlock.Content = " ";
            PortBlock.Content = " ";
        }

        /// <summary>
        /// Hit the delete key to remove a pirate from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                ((MainViewModel)DataContext).RemovePirates(NameBox.SelectedIndex);
                NameBlock.Content = " ";
                ShipBlock.Content = " ";
                PortBlock.Content = " ";
        }

        /// <summary>
        /// checks textbox for being empty and inputs pirate information if not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if ((InsertBox.Text == String.Empty || ShipBox.Text == String.Empty || HomeBox.Text == String.Empty))         
                {
                    MessageBox.Show("Enter Pirate Information Please.", "Error");
                }               
                else ((MainViewModel)DataContext).AddPirates((InsertBox.Text), ShipBox.Text, HomeBox.Text);
            }
        }
    }
}