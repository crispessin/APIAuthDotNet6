using Domain.Repositories;

namespace Domain.FiltersDb
{
    public class PersonFilterDB : PageBaseRequest 
    {
        public string? Name { get; set; }
    }
}
