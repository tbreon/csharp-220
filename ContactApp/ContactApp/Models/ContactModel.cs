using System;
using AutoMapper; // Exercise 2 NuGet Package Installed and called here
using System.ComponentModel; // add this for validation

namespace ContactApp.Models
{
    public class ContactModel : IDataErrorInfo, INotifyPropertyChanged
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

        // add the validation code here
        private string characterError { get; set; }
       
        // Exercise 1 - validation for email
        private string finishError { get; set; }

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
                }

                return null;
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

        // Exercise 1 - Validation for Finish Error
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
        internal ContactModel Clone()
        {
            return (ContactModel)this.MemberwiseClone();
        }

        // Exercise 2 - Automapper Configuration
        private static readonly MapperConfiguration
          config = new MapperConfiguration(cfg => cfg.
          CreateMap<ContactRepository.ContactModel, ContactModel>()
          .ReverseMap());

        private static IMapper mapper = config.CreateMapper();

        // Exercise 2 - Cont. use the mapper 
        // Returning the Repository version of the UI Model
        // Going from Model to Repository
        public ContactRepository.ContactModel ToRepositoryModel()
        {
            // Exercise 2 under Delete - do not call field by field
            //  use Automapper to call on the data

            //var repositoryModel = new ContactRepository.ContactModel
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

            var repositoryModel = mapper.Map<ContactRepository.ContactModel>(this);

            return repositoryModel;
            
        }

        // Exercise 2 - Cont. use the mapper 
        // Returning the UI version of the Repository Model
        // Going from Respository to UI Model
        public static ContactModel ToModel(ContactRepository.ContactModel repositoryModel)
        {
            //var contactModel = new ContactModel
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

            var contactModel = mapper.Map<ContactModel>(repositoryModel);

            return contactModel;


        }
    }
}