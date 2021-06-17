using PokemonDB;

namespace PokemonRepository
{
    public class DatabaseManager
    {
        private static readonly PokemonContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new PokemonContext();
        }

        // Provide an accessor to the database
        public static PokemonContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}