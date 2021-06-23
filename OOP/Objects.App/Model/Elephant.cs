namespace Objects.App.Model
{
    public class Elephant : Animal
    {
        public Elephant(int weight,int age)
        {
            NumberOfLegs = 4;
            Weight = weight;
            Age = age;
            HasTail = true;
        }
    }
}