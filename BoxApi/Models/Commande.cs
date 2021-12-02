namespace BoxApi.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public Box Box { get; set; }
        public ICollection<OStock> OStocks { get; set; }

    }
}
