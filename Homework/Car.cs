namespace Car.cs
{
    // Třída reprezentující auto
    public class Car
    {
        // Vlastnosti (properties)
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }

        // Konstruktor, který inicializuje všechny vlastnosti
        public Car(string brand, string model, int year, int mileage)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
        }

        // Metoda pro přidání kilometrů
        public void Drive(int kilometers)
        {
            Mileage += kilometers;
        }

        // Metoda pro zobrazení informací o autě
        public void DisplayCarInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year: {Year}, Mileage: {Mileage} km");
        }
    }
}
