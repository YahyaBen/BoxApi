namespace BoxApi.Models
{
    public class OStock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Profendeur { get; set; }
        public double Hauteur { get; set; }
        public double Largeur { get; set; }
        public ICollection<Stock_Categories> Stock_Categories { get; set; }
        public ICollection<Commande> Commandes { get; set; }

    }
}
