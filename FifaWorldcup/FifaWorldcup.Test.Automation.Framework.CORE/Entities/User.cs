namespace FifaWorldcup.entities
{
    public class User
    {
        private readonly string _name;
        private readonly string _email;
        private readonly string _password;

        public string[] DataUser { get; private set; }

        public User(string name, string email, string password)
        {
            this._name = name;
            this._email = email;
            this._password = password;
            DataUser = new[] { this._name, this._email, this._password };
        }
    }
}