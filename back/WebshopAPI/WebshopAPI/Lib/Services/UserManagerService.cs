using WebshopAPI.Lib.Database;
using WebshopAPI.Lib.Exceptions;

namespace WebshopAPI.Lib.Services
{
    public class UserManagerService
    {

        public UserManagerService()
        {

        }

        public async Task UpdateUser(User user, string currentUser)
        {
            using (SQL sql = new SQL())
            {
                if (!sql.Users.Any(a => a.Email == user.Email))
                {
                    throw new UserNotFoundException();
                }

                User oldUser = sql.Users.Single(a => a.Email == user.Email);
                ObjectValidatorService<User> usr = new ObjectValidatorService<User>(user);
                usr.IsValid();
                string logEntry = $"Felhasználó módosítás.\r\nRégi adatok:\r\n{oldUser.Dump()}\r\n\r\nÚj adatok:\r\n{user.Dump()}";

                oldUser.Name = user.Name;
                oldUser.Description = user.Description;
                oldUser.Enabled = user.Enabled;
                oldUser.UserType = user.UserType;

                await sql.SaveChangesAsync();
                await logEntry.WriteLogAsync(currentUser);
            }
        }

        public async Task CreateUser(User user)
        {
            using (SQL sql = new SQL())
            {
                if (sql.Users.Any(a => a.Email == user.Email))
                {
                    throw new EmailRegisteredException();
                }
                await sql.Users.AddAsync(user);
                await sql.SaveChangesAsync();
            }
        }


    }
}
