namespace SuperStoreV.Entities
    {
    public class Product
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string PictureUrl { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int QuantityInStock { get; set; }

        public Product()
            {
            }

        public Product(int id, string name, string description, long price, string pictureUrl, string type, string brand, int quantityInStock)
            {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            PictureUrl = pictureUrl;
            Type = type;
            Brand = brand;
            QuantityInStock = quantityInStock;
            }
        }
    }
