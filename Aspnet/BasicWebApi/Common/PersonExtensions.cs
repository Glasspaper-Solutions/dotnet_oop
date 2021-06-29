using BasicWebApi.Data;

namespace BasicWebApi.Common
{
    public static class PersonExtensions
    {
        public static PersonEntity ToEntity(this Person domain)
        {
            return new PersonEntity
            {
                Name = domain.Name,
                Age = domain.Age
            };
        }
    }
}