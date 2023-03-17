using Microsoft.EntityFrameworkCore;
namespace APICDA.Models
{
    public class Product
    {
        private int id;
        private string name;
        private string description;
        private Category category;
        private float price;
        private int stock;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public Category Category { get => category; set => category = value; }
        public float Price { get => price; set => price = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
