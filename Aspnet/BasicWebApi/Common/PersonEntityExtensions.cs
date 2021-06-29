using BasicWebApi.Data;

namespace BasicWebApi.Common
{
    public static class PersonEntityExtensions
    {
        public static Person ToDomain(this PersonEntity entity)
        {
            return new Person(entity.Name,entity.Age);
        }
    }
}