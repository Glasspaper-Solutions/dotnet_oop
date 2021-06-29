using System.Threading.Tasks;
using Xunit;

namespace BasicWebApi.Test
{
    public class AsyncAwaitTests
    {
        [Fact]
        public async Task Example()
        {
            // wait 1 seconds for the first fake1
            var fake1 = await FakeLongTask();
            // then wait another 1 seconds for the second fake(2)
            var fake2 = await FakeLongTask();
        }
        
        [Fact]
        public async Task Example_Parallel()
        {
            // start task
            var fake1 =  FakeLongTask();
            // start another task
            var fake2 =  FakeLongTask();
            
            // wait 1 ish seconds for both to complete
            await Task.WhenAll(fake1, fake2);
        }
        

        private async Task<string> FakeLongTask()
        {
            await Task.Delay(1000); // wait 1 seconds
            return "hello world"; // then return the string
        }
    }
}