using E_commerce_.netcore.Domain.Common;


namespace E_commerce_.netcore.Domain.Entities
{
    public  class Category:EntityBase
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
