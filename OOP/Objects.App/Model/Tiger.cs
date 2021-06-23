namespace Objects.App.Model
{
    public class Tiger : Animal
    {
        public Tiger(int weight,int age)
        {
            NumberOfLegs = 4;
            Weight = weight;
            Age = age;
            IsCarnivore = true;
            HasTail = true;
        }
    }
}