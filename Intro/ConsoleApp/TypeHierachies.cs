namespace ConsoleApp
{

    class Car
    {
        public Car(int speed,string type)
        {
            this.Type = type;
            this.Speed = speed;
        }

        public int Speed { get; set; }
        public string Type { get; set; }
    }

    class TestClass
    {
        public void Test()
        {
            Car myVolvo = new Car(100,"Volvo");
            object myHonda = new Car(70,"Honda");
            var myLambo = new Car(300,"Lamborghini");
            
        }
    }
}