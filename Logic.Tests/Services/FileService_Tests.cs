using Logic.Interfaces;
using Moq;

namespace Logic.Tests.Services;

public class FileService_Tests
{

    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IFileService _fileService;

    public FileService_Tests() 
    {
        _fileServiceMock = new Mock<IFileService>();
        _fileService = _fileServiceMock.Object;
    }

    [Fact]
    public void SaveContentToFile_ShouldReturnTrue_WhenSuccess() 
    {

        // Arrange
        _fileServiceMock.Setup(fileService => fileService.SaveContentToFile(It.IsAny<string>())).Returns(true);

        // Act
        var result = _fileService.SaveContentToFile("");

        // Assert
        Assert.True(result);
    }


    [Fact]
    public void GetContentFromFile_ShouldReturnString_WhenSuccess()
    {

        // Arrange
        _fileServiceMock.Setup(fileService => fileService.GetContentFromFile()).Returns("Validate");

        // Act
        var result = _fileService.GetContentFromFile();

        // Assert
        Assert.Equal("Validate", result);
    }

}
