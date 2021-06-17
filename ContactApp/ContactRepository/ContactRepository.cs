using ContactDB;
using System.Collections.Generic;
using System.Linq;

namespace ContactRepository
{
    // Business layer sees this
    public class ContactModel 
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

    public class ContactRepository
    {
        public ContactModel Add(ContactModel contactModel)
        {

            // Convert the repository model to the database model
            var contactDb = ToDbModel(contactModel);

            // database manager connection
            DatabaseManager.Instance.Contact.Add(contactDb);
            DatabaseManager.Instance.SaveChanges();

            contactModel = new ContactModel
            {
                Grade = contactDb.PokemonGrade,
                CreatedDate = contactDb.PokemonCreatedDate,
                Finish = contactDb.PokemonFinish,
                Id = contactDb.PokemonId,
                Character = contactDb.PokemonCharacter,
                Set = contactDb.PokemonSet,
                CardCondition = contactDb.PokemonCardCondition,
                YearManufactured = (int)contactDb.PokemonYearManufactured,
                URL = contactDb.PokemonURL,
                SoldPrice = (decimal)contactDb.PokemonSoldPrice,
                DateSold = (System.DateTime)contactDb.PokemonDateSold,
            };
            return contactModel;
        }

        // gets the entire records and map to the repository model
        public List<ContactModel> GetAll() 
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Contact
              .Select(t => new ContactModel
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

        public bool Update(ContactModel contactModel)
        {
            var original = DatabaseManager.Instance.Contact.Find(contactModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(contactModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int PokemonId)
        {
            var items = DatabaseManager.Instance.Contact
                                .Where(t => t.PokemonId == PokemonId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Contact.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Contact ToDbModel(ContactModel contactModel)
        {
            var contactDb = new Contact
            {
                PokemonGrade = contactModel.Grade,
                PokemonCreatedDate = contactModel.CreatedDate,
                PokemonFinish = contactModel.Finish,
                PokemonId = contactModel.Id,
                PokemonCharacter = contactModel.Character,
                PokemonSet = contactModel.Set,
                PokemonCardCondition = contactModel.CardCondition,
                PokemonYearManufactured = contactModel.YearManufactured,
                PokemonURL = contactModel.URL,
                PokemonSoldPrice = contactModel.SoldPrice,
                PokemonDateSold = contactModel.DateSold,
            };

            return contactDb;
        }
    }
}