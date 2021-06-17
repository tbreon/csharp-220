using PokemonApp.Models;
using System.Linq;
using System.Windows;
using System.ComponentModel; // added
using System.Windows.Controls; // added
using System.Windows.Documents; //added

namespace PokemonApp

{
    public partial class MainWindow : Window
    {

        private GridViewColumnHeader listViewSortCol = null; // added for exercise
        private SortAdorner listViewSortAdorner = null;      // added for exercise

        private PokemonModel selectedPokemon;


        public MainWindow()
        {
            InitializeComponent();

            LoadPokemons();
        }

        private void LoadPokemons()
        {
            var pokemons = App.PokemonRepository.GetAll();

            uxPokemonList.ItemsSource = pokemons
                .Select(t => PokemonModel.ToModel(t))
                .ToList();

            // OR
            //var uiPokemonModelList = new List<PokemonModel>();
            //foreach (var repositoryPokemonModel in pokemons)
            //{
            //    This is the .Select(t => ... )
            //    var uiPokemonModel = PokemonModel.ToModel(repositoryPokemonModel);
            //
            //    uiPokemonModelList.Add(uiPokemonModel);
            //}

            //uxPokemonList.ItemsSource = uiPokemonModelList;
        }

        // add this method for doing updates
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new PokemonWindow();
            
            // Exercise 2 for update - fix this to call on Clone()
            window.Pokemon = selectedPokemon.Clone();

            if (window.ShowDialog() == true)
            {
                App.PokemonRepository.Update(window.Pokemon.ToRepositoryModel());
                LoadPokemons();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedPokemon != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new PokemonWindow();

            if (window.ShowDialog() == true)
            {
                var uiPokemonModel = window.Pokemon;

                var repositoryPokemonModel = uiPokemonModel.ToRepositoryModel();

                App.PokemonRepository.Add(repositoryPokemonModel);

                // OR
                //App.PokemonRepository.Add(window.Pokemon.ToRepositoryModel());

                LoadPokemons();
            }
        }        


        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxPokemonList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxPokemonList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        // Important Method: detect if selection has been made
        private void uxPokemonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPokemon = (PokemonModel)uxPokemonList.SelectedValue;

            // Exercise 1 under Delete - fix the context menu
            uxContextFileDelete.IsEnabled = (selectedPokemon != null);

        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.PokemonRepository.Remove(selectedPokemon.Id);
            selectedPokemon = null;
            LoadPokemons();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedPokemon != null);
        }

        // Exercise 1 - Update double-clicking on a pokemon will bring up the update Pokemon window
        private void uxPokemonList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // call on this FileChange Click function with two null parameters
            uxFileChange_Click(sender, null);

        }
    }
}
