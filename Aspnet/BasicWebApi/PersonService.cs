using System.Linq;
using System.Collections.Generic;

namespace BasicWebApi
{
    public class PersonService
    {

        private readonly List<Person> _people = new List<Person>();

        public Person GetByName(string name)
        {
            return _people
            .Where(x => x.Name.ToLower() == name.ToLower())
            .FirstOrDefault();
        }

        public IEnumerable<Person> GetAll()
        {
            return _people;
        }

        public Person CreateNewPerson(Person person)
        {
            var personAlreadyExists = GetByName(person.Name) != null;

            if(personAlreadyExists)
            {
                return null;
            }

            _people.Add(person);
            return person;
        }

        public Person UpdatePerson(Person person)
        {
            var personAlreadyExists = GetByName(person.Name) != null;
            
            if(!personAlreadyExists)
            {
                return null;
            }


            for(int x = 0; x < _people.Count; x ++)
            {
                var element = _people[x];
                if(element.Name == person.Name)
                {
                    _people[x] = person;
                }
            }


            return person;
        }

        public Person DeleteByName(string name)
        {
            var personExists = GetByName(name) != null;
            
            if(!personExists)
            {
                return null;
            }

            var person = _people
            .FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            //remove person from people list
            _people.Remove(person);

            return person;
        }
    }
}