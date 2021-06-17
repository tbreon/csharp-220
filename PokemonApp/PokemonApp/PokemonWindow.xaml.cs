using PokemonApp.Models;
using System;
using System.Windows;

namespace PokemonApp
{
    /// <summary>
    /// Interaction logic for PokemonWindow.xaml
    /// </summary>
    public partial class PokemonWindow : Window
    {
        public PokemonWindow()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public PokemonModel Pokemon { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Pokemon = new PokemonModel();

            //Pokemon.Name = uxName.Text;
            //Pokemon.Email = uxEmail.Text;

            //if (uxHome.IsChecked.Value)
            //{
            //    Pokemon.PhoneType = "Home";
            //}
            //else
            //{
            //    Pokemon.PhoneType = "Mobile";
            //}

            //Pokemon.PhoneNumber = uxPhoneNumber.Text;

            ////Pokemon.Age = 0;
            ////Exercise 1 - connect age to slider (name is uxAgeSlider from Xaml)
            //Pokemon.Age = (int)uxAgeSlider.Value;

            //Pokemon.Notes = uxNotes.Text;
            //Pokemon.CreatedDate = DateTime.Now;

            //// This is the return value of ShowDialog( ) below
            //DialogResult = true;
            //Close();

            // for update we use a new code to do data binding with our xaml

            /*if (uxHome.IsChecked.Value)
            {
                Pokemon.PhoneType = "Home";
            }
            else
            {
                Pokemon.PhoneType = "Mobile";
            }*/

            DialogResult = true;
            Close();

        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }

        // add here for update
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Pokemon != null)
            {
                /*if (Pokemon.PhoneType == "Home")
                {
                    uxHome.IsChecked = true;
                }
                else
                {
                    uxMobile.IsChecked = true;
                }*/
                uxSubmit.Content = "Update";
            }
            else
            {
                Pokemon = new PokemonModel();
                Pokemon.CreatedDate = DateTime.Now;
            }

            uxGrid.DataContext = Pokemon;
        }

    }
}