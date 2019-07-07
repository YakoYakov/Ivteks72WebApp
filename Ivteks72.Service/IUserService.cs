namespace Ivteks72.Service
{
    using Ivteks72.Domain;

    public interface IUserService
    {
        string GetUserIdByUsername(string userName);
    }
}
