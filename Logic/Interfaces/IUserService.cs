using Logic.Models;

namespace Logic.Interfaces;

public interface IUserService
{
    bool CreateUser(User user);
    IEnumerable<User> GetAllUsers();

    public bool UpdateUser(User updatedUser);

    public bool RemoveUser(string userId);
}
