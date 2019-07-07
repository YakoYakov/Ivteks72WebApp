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

        public ApplicationUser GetUserById(string id)
        {
            var userFromDb = this.context.ApplicationUsers.FirstOrDefault(user => user.Id == id);

            return userFromDb;
        }
    }
}
