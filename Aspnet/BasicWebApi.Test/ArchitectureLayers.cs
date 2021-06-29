using BasicWebApi.Common;
using Xunit;

namespace BasicWebApi.Test
{
    public class ArchitectureLayers
    {
        [Fact]
        public void LayersExample()
        {
            // http request incoming
            // createModel here
            
            
            var domain = new Person
            {
                Name = "test",
                Age = 123
            };
            
            // giving the data to data layer
            var entity = domain.ToEntity();
            
            // doing data operations like save to database

            var response = entity.ToDomain();
            
            
            // give viewModel here - back as http response here

        }
        
        // createModel - viewModel (V1)
        // domainModel
        // entityModel
    }
}