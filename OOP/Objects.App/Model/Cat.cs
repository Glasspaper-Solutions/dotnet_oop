namespace Objects.App.Model
{
    public class Cat : Animal
    {
        public string Name { get; set; }

        public Cat(string name,int age, int weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
            NumberOfLegs = 4;
            IsCarnivore = true;
            HasTail = true;
        }
    }
}