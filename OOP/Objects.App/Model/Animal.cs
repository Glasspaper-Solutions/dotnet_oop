namespace Objects.App.Model
{
    public abstract class Animal
    {
        public int Age { get; set; }
        public int NumberOfLegs { get; set; }
        public bool IsCarnivore { get; set; }
        public int Weight { get; set; }
        public bool HasTail { get; set; }
    }
}