using BasicWebApi.Common;
using BasicWebApi.Contracts.V1;
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
            var createModel = new PersonCreateModel
            {
                Name = "test",
                Age = 213
            };

            var domain = createModel.ToDomain();
            
            // giving the data to data layer
            // doing data operations like save to database
            var entity = domain.ToEntity();
            
            //back to domain layer
            var domainResponse = entity.ToDomain();
            
            // give viewModel here - back as http response here
            var viewModel = domainResponse.ToViewModel();

        }
        
        // createModel - viewModel (V1)
        // domainModel
        // entityModel
    }
}