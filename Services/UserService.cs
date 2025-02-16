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
    }
}