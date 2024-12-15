

namespace Book.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vytvoření objektu třídy Car
            Car car1 = new Car("Porsche", "GT3-911", 2009, 25340);
            Car car2 = new Car("Ferrari", "Monza SP1", 2018, 10356);

            // Použití metod třídy Car
            car1.DisplayCarInfo();
            car2.DisplayCarInfo();
            car1.Drive(100);
            car2.Drive(200);
            car1.DisplayCarInfo();
            car2.DisplayCarInfo();

            Console.WriteLine();

            // Vytvoření objektu třídy Book
            Book book1 = new Book("Harry Potter And The Philosopher's Stone", "J.K. Rowling", 429);
            Book book2 = new Book("1984", "George Orwell", 328);

            // Použití metod třídy Book
            book1.DisplayProgress();
            book2.DisplayProgress();
            book1.Read(50);
            book2.Read(100);
            book1.DisplayProgress();
            book2.DisplayProgress();
        }
    }
}
