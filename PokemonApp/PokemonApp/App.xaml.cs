using System.Windows;

namespace PokemonApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static PokemonRepository.PokemonRepository pokemonRepository;

        static App()
        {
            pokemonRepository = new PokemonRepository.PokemonRepository();
        }

        public static PokemonRepository.PokemonRepository PokemonRepository
        {
            get
            {
                return pokemonRepository;
            }
        }

    }
}