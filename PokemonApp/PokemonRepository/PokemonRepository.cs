using PokemonDB;
using System.Collections.Generic;
using System.Linq;

namespace PokemonRepository
{
    // Business layer sees this
    public class PokemonModel 
    {
        public int Id { get; set; }
        public string Character { get; set; }
        public string Finish { get; set; }
        public string Set { get; set; }
        public string CardCondition { get; set; }
        public int Grade { get; set; }
        public string URL { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int YearManufactured { get; set; }
        public decimal SoldPrice { get; set; }
        public System.DateTime DateSold { get; set; }
    }

    public class PokemonRepository
    {
        public PokemonModel Add(PokemonModel pokemonModel)
        {

            // Convert the repository model to the database model
            var pokemonDb = ToDbModel(pokemonModel);

            // database manager connection
            DatabaseManager.Instance.Pokemon.Add(pokemonDb);
            DatabaseManager.Instance.SaveChanges();

            pokemonModel = new PokemonModel
            {
                Grade = pokemonDb.PokemonGrade,
                CreatedDate = pokemonDb.PokemonCreatedDate,
                Finish = pokemonDb.PokemonFinish,
                Id = pokemonDb.PokemonId,
                Character = pokemonDb.PokemonCharacter,
                Set = pokemonDb.PokemonSet,
                CardCondition = pokemonDb.PokemonCardCondition,
                YearManufactured = (int)pokemonDb.PokemonYearManufactured,
                URL = pokemonDb.PokemonURL,
                SoldPrice = (decimal)pokemonDb.PokemonSoldPrice,
                DateSold = (System.DateTime)pokemonDb.PokemonDateSold,
            };
            return pokemonModel;
        }

        // gets the entire records and map to the repository model
        public List<PokemonModel> GetAll() 
        {
            // Use .Select() to map the database pokemons to PokemonModel
            var items = DatabaseManager.Instance.Pokemon
              .Select(t => new PokemonModel
              {
                  Grade = t.PokemonGrade,
                  CreatedDate = t.PokemonCreatedDate,
                  Finish = t.PokemonFinish,
                  Id = t.PokemonId,
                  Character = t.PokemonCharacter,
                  Set = t.PokemonSet,
                  CardCondition = t.PokemonCardCondition,
                  YearManufactured = (int)t.PokemonYearManufactured,
                  URL = t.PokemonURL,
                  SoldPrice = (decimal)t.PokemonSoldPrice,
                  DateSold = (System.DateTime)t.PokemonDateSold,
              }).ToList();

            return items;
        }

        public bool Update(PokemonModel pokemonModel)
        {
            var original = DatabaseManager.Instance.Pokemon.Find(pokemonModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(pokemonModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int PokemonId)
        {
            var items = DatabaseManager.Instance.Pokemon
                                .Where(t => t.PokemonId == PokemonId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Pokemon.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Pokemon ToDbModel(PokemonModel pokemonModel)
        {
            var pokemonDb = new Pokemon
            {
                PokemonGrade = pokemonModel.Grade,
                PokemonCreatedDate = pokemonModel.CreatedDate,
                PokemonFinish = pokemonModel.Finish,
                PokemonId = pokemonModel.Id,
                PokemonCharacter = pokemonModel.Character,
                PokemonSet = pokemonModel.Set,
                PokemonCardCondition = pokemonModel.CardCondition,
                PokemonYearManufactured = pokemonModel.YearManufactured,
                PokemonURL = pokemonModel.URL,
                PokemonSoldPrice = pokemonModel.SoldPrice,
                PokemonDateSold = pokemonModel.DateSold,
            };

            return pokemonDb;
        }
    }
}