using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using AztroWebApplication.Models;
using AztroWebApplication.Data;
using System.Reflection;

namespace AztroWebApplication.Repositories{
    public class UserRepository{

        //Instancio el contexto para usarlo en el constructor
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext){
            this.dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await dbContext.User.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await dbContext.User.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> CreateUser(User user)
        {
            var newUser = dbContext.User.Add(user);
            await dbContext.SaveChangesAsync();
            return newUser.Entity;
        }

        public async Task<User?> UpdateUser(int id, User user)
        {
            var userToBeUpdate = await this.GetUserById(id);
            if(userToBeUpdate == null) return null;

            user.Id = userToBeUpdate.Id;

            var userUpdated = UpdateObject(userToBeUpdate, user);

            // userToUpdate.Name = user.Name;
            // userToUpdate.Age = user.Age;
            // userToUpdate.Email = user.Email;

            dbContext.User.Update(userUpdated);
            await dbContext.SaveChangesAsync();
            return userToBeUpdate;
        }

        private static T UpdateObject<T>(T current, T newObject)
        {
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                var newValue = prop.GetValue(newObject);
                if(newValue == null || string.IsNullOrEmpty(newValue.ToString())){
                    continue;
                }
                prop.SetValue(current, newValue);
            }
            return current;
        }
    }
}