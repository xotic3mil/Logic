using Logic.Helpers;

namespace Logic.Tests.Helpers
{
    public class IdGenerator_Tests
    {
        [Fact]

        public void GenerateUniqueId_ShouldReturnGuidAsString() 
        {

            // Act
            var result = IdGenerator.GenerateUniqueId();

            // Assert
            Assert.True(Guid.TryParse(result, out _));


        }

    }
}
