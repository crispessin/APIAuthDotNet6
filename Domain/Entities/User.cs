using Domain.Validations;
using System.Globalization;

namespace Domain.Entities
{
    public class User
    {
        public User(string email, string password)
        {
            Validation(email, password);
        }

        public  User(int id, string email, string password)
        {
            DomainValidationException.When(id <= 0, "Id deve ser informado");
            Id = id;
            Validation(email, password);
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private void Validation(string email, string password)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(password), "Password deve ser informado");

            Email = email;
            Password = password;
        }
    }
}
