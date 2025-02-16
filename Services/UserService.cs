using AztroWebApplication.Data;
using AztroWebApplication.Repositories;
using AztroWebApplication.Models;

namespace AztroWebApplication.Services{
    public class UserService{
        private readonly UserRepository userRepository;

        public UserService(ApplicationDbContext context)
        {
            userRepository = new UserRepository(context);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await userRepository.GetAllUsers();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);
        }
    }
}