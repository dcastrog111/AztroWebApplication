using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

using AztroWebApplication.Models;
using AztroWebApplication.Data;

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
    }
}