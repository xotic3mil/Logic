using Logic.Helpers;
using Logic.Interfaces;
using Logic.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Logic.Services
{
    public class UserService(IFileService fileService) : IUserService
    {
        private readonly IFileService _fileService = fileService;
        private List<User> _users = [];

        public bool CreateUser(User user)
        {
            user.Id = IdGenerator.GenerateUniqueId();
             _users.Add(user);

            var result = SaveDataToFile();
            return result;
        }

        public bool UpdateUser(User updatedUser) 
        {
            GetDataFromFile();

            var userIndex = _users.FindIndex(user => user.Id == updatedUser.Id);
            if (userIndex == -1) 
            {
             return false;
            }

            _users[userIndex] = updatedUser;

            return SaveDataToFile();
        }

        public bool RemoveUser(string userId)
        {
            GetDataFromFile();

            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return false;
            }

            _users.Remove(user);

            return SaveDataToFile();
        }

        public IEnumerable<User> GetAllUsers()
        {
            GetDataFromFile();
            return _users;
        }

        public bool SaveDataToFile() 
        {
            try
            {
                var json = JsonSerializer.Serialize(_users);
                _fileService.SaveContentToFile(json);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public bool GetDataFromFile()
        {

            try
            {
                var json = _fileService.GetContentFromFile();
                if (!string.IsNullOrEmpty(json))
                {
                    _users = JsonSerializer.Deserialize<List<User>>(json)!;
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                _users = [];
            }

            return false;
        }
    }
}
