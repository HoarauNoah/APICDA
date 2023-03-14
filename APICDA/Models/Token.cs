namespace APICDA.Models
{
    public class Token
    {
        private DateTime _ExpirationDate;
        private string tokenValue;
        private bool reader;
        private bool writer;

        public DateTime ExpirationDate { get => _ExpirationDate;}
        public string TokenValue { get => tokenValue;}
        public bool Reader { get => reader; set => reader = value; }
        public bool Writer { get => writer; set => writer = value; }
    }
}
