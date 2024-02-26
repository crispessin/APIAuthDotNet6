using Domain.Validations;

namespace Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }


        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);
        }

        public Purchase(int Id, int productId, int personId)
        {
            DomainValidationException.When(Id < 0, "Id deve ser informado!");
            Id = Id;
            Validation(productId, personId);
        }

        public void Edit(int Id, int productId, int personId)
        {
            DomainValidationException.When(Id < 0, "Id deve ser informado!");
            Id = Id;
            Validation(productId, personId);
        }

        private void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId <= 0, "Id produto deve ser informado!");
            DomainValidationException.When(personId <= 0, "Id pessoa deve ser informado");

            PersonId = personId;
            ProductId = productId;
            Date = DateTime.Now;
        }
    }
}
