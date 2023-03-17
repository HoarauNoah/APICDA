using Microsoft.EntityFrameworkCore;

namespace APICDA.Models
{
    public class Category
    {
        private Guid _id;
        private string _name;

        public Guid id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
    }
}
