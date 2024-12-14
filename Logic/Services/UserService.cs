using Logic.Helpers;
using Logic.Interfaces;
using Logic.Models;
using Logic.Repositories;
using System.Diagnostics;
using System.Text.Json;

namespace Logic.Services
{
    public class UserService(IFileRepository fileRepository) : IUserService
    {
        private readonly IFileRepository _fileRepository = fileRepository;
        private List<User> _users = [];

        public bool CreateUser(User user)
        {
            user.Id = IdGenerator.GenerateUniqueId();
             _users.Add(user);

            var result = _fileRepository.SaveDataToFile(_users);
            return result;
        }

        public bool UpdateUser(User updatedUser) 
        {
            _users = _fileRepository.GetDataFromFile<List<User>>() ?? new List<User>();

            var userIndex = _users.FindIndex(user => user.Id == updatedUser.Id);
            if (userIndex == -1) 
            {
             return false;
            }

            _users[userIndex] = updatedUser;

            return _fileRepository.SaveDataToFile(_users);
        }

        public bool RemoveUser(string userId)
        {
            _users = _fileRepository.GetDataFromFile<List<User>>() ?? new List<User>();

            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return false;
            }

            _users.Remove(user);

            return _fileRepository.SaveDataToFile(_users);
        }

        public IEnumerable<User> GetAllUsers()
        {
             _users = _fileRepository.GetDataFromFile<List<User>>();
            return _users;
        }
    }
}
