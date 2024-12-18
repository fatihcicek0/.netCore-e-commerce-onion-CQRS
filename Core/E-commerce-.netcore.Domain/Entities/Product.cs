using E_commerce_.netcore.Domain.Common;



namespace E_commerce_.netcore.Domain.Entities
{
    public class Product:EntityBase
    {
        public Product() { }
        public Product(string name,decimal Price,decimal discount,string description,int categoryId)
        {
            this.Name = name;
            this.Price = Price;
            this.Discount = discount;
            this.Description = description;
            this.CategoryId = categoryId;

        }  
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool IsOnSale { get; set; }
        public Category Category { get; set; }
    }
}
