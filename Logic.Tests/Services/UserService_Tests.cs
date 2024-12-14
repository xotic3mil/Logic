using Logic.Interfaces;
using Logic.Models;
using Logic.Services;
using Moq;

namespace Logic.Tests.Services;

public class UserService_Tests
{

    private readonly Mock<IFileRepository> _fileRepositoryMock;
    private readonly IUserService _userService;


    public UserService_Tests() 
    {

        _fileRepositoryMock = new Mock<IFileRepository>();
        _userService = new UserService(_fileRepositoryMock.Object);
    }

    [Fact]

    public void CreateUser_ShouldReturnTrue_WhenSuccess() 
    {

        // Arrange
        var user = new User() { Id = "c2c0c613-7545-46d3-8487-6606416c69c9", FirstName = "Emil" };
        var users = new List<User>() { user };

        _fileRepositoryMock.Setup(fileRepository => fileRepository.SaveDataToFile(users)).Returns(true);

        // Act
        var result = _userService.CreateUser(user);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UpdateUser_ShouldReturnTrue_WhenSuccess()
    {
        // Arrange
        var userId = "existing-user-id";
        var updatedUser = new User { Id = userId, FirstName = "Updated User" };
        var users = new List<User>
    {
        new User { Id = userId, FirstName = "Test User" }
    };

        _fileRepositoryMock.Setup(fileRepository => fileRepository.GetDataFromFile<List<User>>()).Returns(users);
        _fileRepositoryMock.Setup(fileRepository => fileRepository.SaveDataToFile(It.IsAny<List<User>>())).Returns(true);

        // Act
        var result = _userService.UpdateUser(updatedUser);

        // Assert
        Assert.True(result);
        _fileRepositoryMock.Verify(fileRepository => fileRepository.SaveDataToFile(It.Is<List<User>>(user => user[0].FirstName == "Updated User")), Times.Once);
    }


    [Fact]
    public void RemoveUser_ShouldReturnTrue_WhenSuccess()
    {
        // Arrange
        var userId = "existing-user-id";
        var users = new List<User>
    {
        new User { Id = userId, FirstName = "Test User" }
    };

        _fileRepositoryMock.Setup(fileRepository => fileRepository.GetDataFromFile<List<User>>()).Returns(users);
        _fileRepositoryMock.Setup(fileRepository => fileRepository.SaveDataToFile(It.IsAny<List<User>>())).Returns(true);

        // Act
        var result = _userService.RemoveUser(userId);

        // Assert
        Assert.True(result);
        _fileRepositoryMock.Verify(fileRepository => fileRepository.SaveDataToFile(It.Is<List<User>>(u => u.Count == 0)), Times.Once);
    }
}
