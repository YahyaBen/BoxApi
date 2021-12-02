namespace BoxApi.Models
{
    public class Stock_Categories
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int StockID { get; set; }
        public OStock Stock { get; set; }
        public Categorie Categorie { get; set; }
    }
}
