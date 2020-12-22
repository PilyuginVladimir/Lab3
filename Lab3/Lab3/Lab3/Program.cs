using System;
using System.Collections.Generic;
public class Program
{
    public static void Main(string[] args)
    {
        var list = new List<Worker>
                {
                    new WorkerFix(476, "Надяработник1"),
                    new WorkerFix(865, "Викторработник2"),
                    new WorkerFix(411, "Сергейработник3"),
                    new WorkerFix(2557, "Виталийработник4"),
                    new WorkerFix(3266, "Зинаработник5")

                };
        list.Sort();
        foreach (var worker in list)
        {
            Console.WriteLine(worker);
        }
    }
}
internal abstract class Worker : IComparable<Worker>
{
    public string Name { get; protected set; }
    public abstract decimal Salary { get; set; }

    public int CompareTo(Worker other)
    {
        int comp = Salary.CompareTo(other.Salary);
        if (comp == 0)
        {
            return Name.CompareTo(other.Name);
        }
        return comp;
    }
    public override string ToString()
    {
        return string.Format("Name: {0}, Salary: {1}", Name, Salary);
    }
}
internal class WorkerFix : Worker
{
    private decimal _salary;

    public WorkerFix(decimal salary, string name)
    {
        _salary = salary;
        Name = name;
    }
    public override decimal Salary
    {
        get { return _salary; }
        set { _salary = value; }
    }
}
internal class WorkerTax : Worker
{
    private decimal _hourRate;

    public WorkerTax(decimal hourRate, string name)
    {
        _hourRate = hourRate;
        Name = name;
    }
    public override decimal Salary
    {
        get { return 20.8m * 8 * _hourRate; }
        set { _hourRate = value / (20.8m * 8); }
    }
}