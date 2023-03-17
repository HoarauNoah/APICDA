namespace APICDA.Models
{
    public class Supplier
    {
        private Guid _id;
        private string _name;
        private string _address;
        private string _phoneNumber;
        private string _email;

        public Guid id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
        public string address { get => _address; set => _address = value; }
        public string phoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string email { get => _email; set => _email = value; }
    }
}
