namespace Objects.App.Model
{
    public class Spider : Animal
    {
        public Spider(int weight,int age)
        {
            NumberOfLegs = 8;
            Weight = weight;
            Age = age;
            IsCarnivore = true;
        }
    }
}