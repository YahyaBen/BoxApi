﻿namespace BoxApi.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public ICollection<OStock> OStocks { get; set;}
    }
}
