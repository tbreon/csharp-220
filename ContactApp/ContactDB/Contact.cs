using System;
using System.Collections.Generic;

namespace ContactDB
{
    public partial class Contact
    {
        public int PokemonId { get; set; }
        public string PokemonCharacter { get; set; }
        public string PokemonFinish { get; set; }
        public string PokemonSet { get; set; }
        public string PokemonCardCondition { get; set; }
        public int PokemonGrade { get; set; }
        public string PokemonURL { get; set; }
        public DateTime PokemonCreatedDate { get; set; }
        public int? PokemonYearManufactured { get; set; }
        public decimal? PokemonSoldPrice { get; set; }
        public DateTime? PokemonDateSold { get; set; }
    }
}
