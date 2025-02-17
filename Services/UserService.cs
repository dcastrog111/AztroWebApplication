using AztroWebApplication.Data;
using AztroWebApplication.Repositories;
using AztroWebApplication.Models;

namespace AztroWebApplication.Services{
    public class UserService{

        private const int minimumAge  = 18;

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

        public async Task<User> CreateUser(User user)
        {

            if(user.Age < minimumAge )
            {
                throw new Exception("User must be at least 18 years old");
            }

            return await userRepository.CreateUser(user);
        }

        public async Task<User?> DeleteUser(int id){
            
            return await userRepository.DeleteUser(id);
        }

        public async Task<User?> UpdateUser(int id, User user)
        {
            return await userRepository.UpdateUser(id, user);
        }
    }
}