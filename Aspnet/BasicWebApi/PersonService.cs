using System.Linq;
using System.Collections.Generic;
using BasicWebApi.Data;
using System.Threading.Tasks;
using BasicWebApi.Common;

namespace BasicWebApi
{
    public class PersonService
    {
        private readonly PersonDbContext _db;
        private readonly IDateTimeProvider _dateTimeProvider;

        public PersonService(PersonDbContext dbContext, IDateTimeProvider dateTimeProvider)
        {
            _db = dbContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Person> GetByName(string name)
        {
            var entity = _db.PersonSet
                .Where(x => x.Name.ToLower() == name.ToLower())
                .ToList()
                .FirstOrDefault();

            if (entity == null)
            {
                return null;
            }

            return new Person
            {
                Name = entity.Name,
                Age = entity.Age
            };
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return _db.PersonSet.Select(x => new Person
            {
                Name = x.Name,
                Age = x.Age
            }).ToList();
        }

        public async Task<Person> CreateNewPerson(Person person)
        {
            var personAlreadyExists = await GetByName(person.Name) != null;

            if (personAlreadyExists)
            {
                return null;
            }

            var newPerson = new PersonEntity
            {
                Name = person.Name,
                Age = person.Age,
                CreatedDateTime = _dateTimeProvider.Now(),
                ModifiedDateTime = _dateTimeProvider.Now()
            };
            _db.PersonSet.Add(newPerson);
            await _db.SaveChangesAsync();
            //_people.Add(person);
            return person;
        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var personAlreadyExists = await GetByName(person.Name) != null;

            if (!personAlreadyExists)
            {
                return null;
            }

            var entity = _db.PersonSet.FirstOrDefault(x => x.Name.ToLower() == person.Name.ToLower());

            entity.Name = person.Name;
            entity.Age = person.Age;

            _db.PersonSet.Update(entity);
            await _db.SaveChangesAsync();
            // for(int x = 0; x < _people.Count; x ++)
            // {
            //     var element = _people[x];
            //     if(element.Name == person.Name)
            //     {
            //         _people[x] = person;
            //     }
            // }


            return person;
        }

        public async Task<Person> DeleteByName(string name)
        {
            var personExists = await GetByName(name) != null;

            if (!personExists)
            {
                return null;
            }

            var entity = _db.PersonSet.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            _db.PersonSet.Remove(entity);
            await _db.SaveChangesAsync();

            // var person = _people
            // .FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            // //remove person from people list
            // _people.Remove(person);

            return new Person
            {
                Name = entity.Name,
                Age = entity.Age
            };
        }
    }
}