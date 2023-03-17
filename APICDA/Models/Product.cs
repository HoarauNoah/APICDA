using Microsoft.EntityFrameworkCore;
using APICDA.Data;
namespace APICDA.Models
{
    public class Product
    {
        private Guid _id;
        private string _name;
        private string _description;
        private Category _category;
        private float _price;
        private int _stock;
        private Supplier _supplier;
        public string name { get => _name; set => _name = value; }
        public string description { get => _description; set => _description = value; }
        public Category category { get => _category; set => _category = value; }
        public float price { get => _price; set => _price = value; }
        public int stock { get => _stock; set => _stock = value; }
        public Guid id { get => _id; set => _id = value; }
        public Supplier supplier { get => _supplier; set => _supplier = value; }
    }
}


