Namespace Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {



        var random = new Random();
        var names = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Edward", "Fiona", "George", "Hannah", "Ian", "Julia" };
        var students = new List<Student>();

        // Vytvoření seznamu studentů
        for (int i = 0; i < 100; i++)
        {
            var student = new Student
            {
                Name = names[random.Next(names.Count)] + i,
                Age = random.Next(18, 25),
                Grades = new List<int> { random.Next(20, 100), random.Next(50, 100), random.Next(70, 100) }
            };
            students.Add(student);
        }

        // 3. a) Použití metody Select k získání seznamu jmen všech studentů
        var studentNames = students.Select(s => s.Name).ToList();
        Console.WriteLine("Seznam jmen studentů:");
        studentNames.ForEach(name => Console.WriteLine(name));

        // 3. b) Použití metody Where k filtrování studentů, kteří mají alespoň jednu známku vyšší než 90
        var studentsWithHighGrades = students.Where(s => s.Grades.Any(grade => grade > 90)).ToList();
        Console.WriteLine("\nStudenti s alespoň jednou známkou vyšší než 90:");
        studentsWithHighGrades.ForEach(s => Console.WriteLine(s.Name));

        // 3. c) Použití metody Any k ověření, zda existuje student, který má všechny známky vyšší než 80
        var allGradesAbove80 = students.Any(s => s.Grades.All(grade => grade > 80));
        Console.WriteLine("\nExistuje student s všemi známkami vyššími než 80? " + allGradesAbove80);

        // 3. d) Použití metody SelectMany k získání seznamu všech známek všech studentů
        var allGrades = students.SelectMany(s => s.Grades).ToList();
        Console.WriteLine("\nVšechny známky všech studentů:");
        allGrades.ForEach(grade => Console.WriteLine(grade));

        // 3. e) Použití metody OrderBy k seřazení studentů podle věku
        var studentsOrderedByAge = students.OrderBy(s => s.Age).ToList();
        Console.WriteLine("\nStudenti seřazení podle věku:");
        studentsOrderedByAge.ForEach(s => Console.WriteLine($"{s.Name}, Věk: {s.Age}"));
    }
        public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get; set; }
    }

}

