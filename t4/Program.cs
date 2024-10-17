using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class Worker
{
    public int Number { get; set; }
    public string Position { get; set; }
    public int Experience { get; set; }
    public double Salary { get; set; }
    public string Surname { get; set; }
}

class Program
{
    static void Main()
    {
        List<Worker> workers;
        using (StreamReader r = new StreamReader("Zavod.json"))
        {
            string json = r.ReadToEnd();
            workers = JsonConvert.DeserializeObject<List<Worker>>(json);
        }

        foreach (var worker in workers)
        {
            Console.WriteLine($"Номер цеху: {worker.Number}");
            Console.WriteLine($"Посада: {worker.Position}");
            Console.WriteLine($"Стаж роботи: {worker.Experience}");
            Console.WriteLine($"Заробітна плата: {worker.Salary}");
            Console.WriteLine($"Прізвище: {worker.Surname}");
            Console.WriteLine();
        }


        Console.WriteLine("Введіть прізвище для пошуку: ");
        string inputSurname = Console.ReadLine();

        var workerBySurname = workers.FirstOrDefault(w => w.Surname == inputSurname);
        if (workerBySurname != null)
        {
            Console.WriteLine($"Номер цеху: {workerBySurname.Number}");
            Console.WriteLine($"Посада: {workerBySurname.Position}");
            Console.WriteLine($"Стаж роботи: {workerBySurname.Experience}");
            Console.WriteLine($"Заробітна плата: {workerBySurname.Salary}");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Робітника не знайдено.");
            Console.WriteLine();
        }


        Console.WriteLine("Введіть номер цеху для обчислення середньої зарплати: ");
        int workshopNumber = int.Parse(Console.ReadLine());

        var averageSalary = workers
            .Where(w => w.Number == workshopNumber)
            .Average(w => w.Salary);

        Console.WriteLine($"Середня заробітна плата в цеху {workshopNumber}: {averageSalary}");
    }
}
