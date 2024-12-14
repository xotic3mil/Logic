using Logic.Factories;
using Logic.Models;

namespace Logic.Tests.Factories;

public class UserFactory_test
{
    [Fact]
    public void Create_ShouldReturnUser() 
    {

        //act
        var result = UserFactory.Create();

        //assert
        Assert.NotNull(result);
        Assert.IsType<User>(result);


    }
}
