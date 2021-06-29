using BasicWebApi.Data;

namespace BasicWebApi.Common
{
    public static class PersonEntityExtensions
    {
        public static Person ToDomain(this PersonEntity entity)
        {
            return new Person
            {
                Name = entity.Name,
                Age = entity.Age
            };
        }
    }
}