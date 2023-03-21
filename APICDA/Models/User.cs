using System.ComponentModel.DataAnnotations;

namespace APICDA.Models
{
    public class User
    {
        private Guid _id;
        private string _login;
        private string _password;
        //private bool _isAdmin;

        [Key]
        public Guid id
        {
            get { return _id; }
        }
        public string login { get => _login; set => _login = value; }
        public string password { get => _password; set => _password = value; }
        //public bool isAdmin { get => _isAdmin; set => _isAdmin = value; }
    }
}
