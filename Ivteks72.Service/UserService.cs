namespace Ivteks72.Service
{
    using System.Linq;
    using Ivteks72.Data;
    using Ivteks72.Domain;

    public class UserService : IUserService
    {
        private readonly Ivteks72DbContext context;

        public UserService(Ivteks72DbContext context)
        {
            this.context = context;
        }

        public string GetUserIdByUsername(string userName)
        {
            var userId = this.context.ApplicationUsers
                .Where(user => user.UserName == userName)
                .Select(user => user.Id)
                .FirstOrDefault();

            return userId;
        }
    }
}
