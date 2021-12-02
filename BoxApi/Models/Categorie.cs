namespace BoxApi.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Stock_Categories> Stock_Categories { get; set; }
    }
}
