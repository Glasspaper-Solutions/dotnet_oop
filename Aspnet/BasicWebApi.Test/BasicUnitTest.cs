using FluentAssertions;
using Xunit;

namespace BasicWebApi.Test
{

    public class BasicUnitTest
    {
        public BasicUnitTest()
        {
            
        }

        [Fact]
        public void TwoAddOne_ShouldBe_Three()
        {
            var x = 1;
            var y = 2;
            
            var result = x+y;

            result.Should().Be(3);
        }
        
        
        [Fact]
        public void True_ShouldAlwaysBe_True()
        {
           bool b = true;

           b.Should().Be(true); 
        }      
    }
}