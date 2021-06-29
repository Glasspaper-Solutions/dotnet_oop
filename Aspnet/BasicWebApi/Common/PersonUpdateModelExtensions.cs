using System;
using BasicWebApi.Contracts.V1;

namespace BasicWebApi.Common
{
    public static class PersonUpdateModelExtensions
    {
        public static Person ToDomain(this PersonUpdateModel updateModel)
        {
            if (updateModel.Name is null) throw new ArgumentNullException(nameof(updateModel.Name));
            if (updateModel.Age is null) throw new ArgumentNullException(nameof(updateModel.Age));
            
            return new Person(updateModel.Name,updateModel.Age.Value);
        }
    }
}