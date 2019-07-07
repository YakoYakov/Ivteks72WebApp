namespace Ivteks72.Service
{
    using Ivteks72.Domain;

    public interface IUserService
    {
        ApplicationUser GetUserById(string id);
    }
}
