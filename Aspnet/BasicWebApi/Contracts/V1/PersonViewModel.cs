namespace BasicWebApi.Contracts.V1
{
    public class PersonViewModel
    {
        public PersonViewModel(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
    }
}