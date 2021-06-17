using System;
using AutoMapper; // Exercise 2 NuGet Package Installed and called here
using System.ComponentModel; // add this for validation

namespace PokemonApp.Models
{
    public class PokemonModel : IDataErrorInfo, INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Character { get; set; }
        public string Finish { get; set; }
        public string Set { get; set; }
        public string CardCondition { get; set; }
        public int Grade { get; set; }
        public int YearManufactured { get; set; }
        public string URL { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal SoldPrice { get; set; }
        public DateTime DateSold { get; set; }

        private string characterError { get; set; }
       
        private string finishError { get; set; }

        private string setError { get; set; }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo interface
        public string Error => "Never Used";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Character":
                        {
                            CharacterError = "";

                            if (Character == null || string.IsNullOrEmpty(Character))
                            {
                                CharacterError = "Character cannot be empty.";
                            }
                            else if (Character.Length > 12)
                            {
                                CharacterError = "Character cannot be longer than 12 characters.";
                            }

                            return CharacterError;
                        }
                    // add other cases as needed

                    case "Finish":
                        {
                            FinishError = "";

                            if (Finish == null || string.IsNullOrEmpty(Finish))
                            {
                                FinishError = "Finish cannot be empty.";
                            }
                            else if (Finish.Length > 12)
                            {
                                FinishError = "Finish cannot be longer than 12 characters.";
                            }

                            return FinishError;
                        }

                    case "Set":
                        {
                            SetError = "";

                            if (Set == null || string.IsNullOrEmpty(Set))
                            {
                                SetError = "Set cannot be empty.";
                            }
                            else if (Set.Length > 12)
                            {
                                SetError = "Set cannot be longer than 12 characters.";
                            }

                            return SetError;
                        }
                }

                return null;
            }
        }

        public string SetError
        {
            get
            {
                return setError;
            }
            set
            {
                if (setError != value)
                {
                    setError = value;
                    OnPropertyChanged("CharacterError");
                }
            }
        }

        public string CharacterError
        {
            get
            {
                return characterError;
            }
            set
            {
                if (characterError != value)
                {
                    characterError = value;
                    OnPropertyChanged("CharacterError");
                }
            }
        } 

        public string FinishError
        {
            get
            {
                return finishError;
            }
            set
            {
                if (finishError != value)
                {
                    finishError = value;
                    OnPropertyChanged("FinshError");
                }
            }
        } // this is the end of code for email validation error message

        //====================

        // Exercise 2 - Fix update so background behaves correctly
        // adding Clone() method
        // so both objects do not point to the same data
        internal PokemonModel Clone()
        {
            return (PokemonModel)this.MemberwiseClone();
        }

        // Exercise 2 - Automapper Configuration
        private static readonly MapperConfiguration
          config = new MapperConfiguration(cfg => cfg.
          CreateMap<PokemonRepository.PokemonModel, PokemonModel>()
          .ReverseMap());

        private static IMapper mapper = config.CreateMapper();

        // Exercise 2 - Cont. use the mapper 
        // Returning the Repository version of the UI Model
        // Going from Model to Repository
        public PokemonRepository.PokemonModel ToRepositoryModel()
        {
            // Exercise 2 under Delete - do not call field by field
            //  use Automapper to call on the data

            //var repositoryModel = new PokemonRepository.PokemonModel
            //{
            //    Age = Age,
            //    CreatedDate = CreatedDate,
            //    Email = Email,
            //    Id = Id,
            //    Name = Name,
            //    Notes = Notes,
            //    PhoneNumber = PhoneNumber,
            //    PhoneType = PhoneType
            //};

            var repositoryModel = mapper.Map<PokemonRepository.PokemonModel>(this);

            return repositoryModel;
            
        }

        // Exercise 2 - Cont. use the mapper 
        // Returning the UI version of the Repository Model
        // Going from Respository to UI Model
        public static PokemonModel ToModel(PokemonRepository.PokemonModel repositoryModel)
        {
            //var pokemonModel = new PokemonModel
            //{
            //    Age = respositoryModel.Age,
            //    CreatedDate = respositoryModel.CreatedDate,
            //    Email = respositoryModel.Email,
            //    Id = respositoryModel.Id,
            //    Name = respositoryModel.Name,
            //    Notes = respositoryModel.Notes,
            //    PhoneNumber = respositoryModel.PhoneNumber,
            //    PhoneType = respositoryModel.PhoneType
            //};

            var pokemonModel = mapper.Map<PokemonModel>(repositoryModel);

            return pokemonModel;


        }
    }
}