class Program
{
    static void Main()
    {
        // Pole typu IDriveable[]
        IDriveable[] driveables = new IDriveable[150];

        // Naplnění pole objekty typu Car, Motorcycle a Truck s různými Id
        for (int i = 0; i < 50; i++)
        {
            driveables[i] = new Car(i + 1, 4);
            driveables[i + 50] = new Motorcycle(i + 51, i % 2 == 0);
            driveables[i + 100] = new Truck(i + 101, 5000 + i * 100);
        }

        // Cyklus, který zavolá metodu Drive() na každém objektu v kolekci
        foreach (var vehicle in driveables)
        {
            vehicle.Drive();
        }

        // Pole typu Vehicle[]
        Vehicle[] vehicles = new Vehicle[60];

        // Naplnění pole objekty typu Car, Motorcycle a Truck s různými Id
        for (int i = 0; i < 30; i++)
        {
            vehicles[i] = new Car(i + 1, 4);
            vehicles[i + 30] = new Motorcycle(i + 31, i % 2 == 0);
            vehicles[i + 50] = new Truck(i + 51, 5000 + i * 100);
        }

        // Cyklus, který zavolá abstraktní a virtuální metody pro každý objekt
        foreach (var vehicle in vehicles)
        {
            vehicle.StartEngine();
            vehicle.StopEngine();

            // Zjištění typu a volání specifických metod
            if (vehicle is Truck truck)
            {
                truck.LoadCargo();  // Volání specifické metody pro Truck
            }
        }
    }
}
