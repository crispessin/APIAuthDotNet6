using Domain.Entities;

namespace Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic Generator(User user);
    }
}
