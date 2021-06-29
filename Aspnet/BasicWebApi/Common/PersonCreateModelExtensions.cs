using System;
using BasicWebApi.Contracts.V1;

namespace BasicWebApi.Common
{
    public static class PersonCreateModelExtensions
    {
        public static Person ToDomain(this PersonCreateModel createModel)
        {
            if (createModel.Name is null) throw new ArgumentNullException(nameof(createModel.Name));
            if (createModel.Age is null) throw new ArgumentNullException(nameof(createModel.Age));
            return new Person(createModel.Name,createModel.Age.Value);
        }
    }
}