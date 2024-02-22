using System;
using System.Collections.Generic;

public class Employee
{
    private string name;
    private int id;
    private decimal salary;

    public string Name 
    {
        get { return name; }
        set { name = value; }
    }

    public int Id 
    {
        get { return id; }
        set { id = value; }
    }

    public decimal Salary 
    {
        get { return salary; }
        set { salary = value; }
    }

    public Employee(string name, int id, decimal salary)
    {
        Name = name;
        Id = id;
        Salary = salary;
    }
}

public class FullTimeEmployee : Employee
{
    private decimal annualSalary;

    public decimal AnnualSalary 
    {
        get { return annualSalary; }
        set { annualSalary = value; }
    }

    public FullTimeEmployee(string name, int id, decimal salary, decimal annualSalary) 
        : base(name, id, salary)
    {
        AnnualSalary = annualSalary;
    }

    public decimal CalculateAnnualSalary()
    {
        return AnnualSalary;
    }
}

public class PartTimeEmployee : Employee
{
    private int hoursWorked;
    private decimal hourlySalary;

    public int HoursWorked 
    {
        get { return hoursWorked; }
        set { hoursWorked = value; }
    }

    public decimal HourlySalary 
    {
        get { return hourlySalary; }
        set { hourlySalary = value; }
    }

    public PartTimeEmployee(string name, int id, decimal salary, int hoursWorked, decimal hourlySalary) 
        : base(name, id, salary)
    {
        HoursWorked = hoursWorked;
        HourlySalary = hourlySalary;
    }

    public decimal CalculateMonthlySalary()
    {
        return HoursWorked * HourlySalary;
    }
}

public class Department
{
    private string departmentName;
    private List<Employee> employees;

    public string DepartmentName 
    {
        get { return departmentName; }
        set { departmentName = value; }
    }

    public Department(string departmentName)
    {
        DepartmentName = departmentName;
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void RemoveEmployee(Employee employee)
    {
        employees.Remove(employee);
    }

    public void DisplayEmployees()
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"Name: {employee.Name}, ID: {employee.Id}, Salary: {employee.Salary}");
        }
    }

    public Employee FindEmployeeById(int id)
    {
        return employees.Find(e => e.Id == id);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Department department = new Department("Engineering");
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Employees");
            Console.WriteLine("2. Add New Employee");
            Console.WriteLine("3. Remove Employee");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nEmployees:");
                    department.DisplayEmployees();
                    break;
                case "2":
                    AddEmployee(department);
                    break;
                case "3":
                    RemoveEmployee(department);
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddEmployee(Department department)
    {
        Console.Write("\nEnter employee name: ");
        string name = Console.ReadLine();
        Console.Write("Enter employee ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter employee salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Select type of employee:");
        Console.WriteLine("1. Full Time");
        Console.WriteLine("2. Part Time");
        Console.Write("Enter choice: ");
        string employeeTypeChoice = Console.ReadLine();

        switch (employeeTypeChoice)
        {
            case "1":
                Console.Write("Enter employee's annual salary: ");
                decimal annualSalary = decimal.Parse(Console.ReadLine());
                department.AddEmployee(new FullTimeEmployee(name, id, salary, annualSalary));
                Console.WriteLine("Full Time Employee added successfully.");
                break;
            case "2":
                Console.Write("Enter employee's hours worked: ");
                int hoursWorked = int.Parse(Console.ReadLine());
                Console.Write("Enter employee's hourly salary: ");
                decimal hourlySalary = decimal.Parse(Console.ReadLine());
                department.AddEmployee(new PartTimeEmployee(name, id, salary, hoursWorked, hourlySalary));
                Console.WriteLine("Part Time Employee added successfully.");
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    static void RemoveEmployee(Department department)
    {
        department.DisplayEmployees(); // Display employees first
        Console.Write("\nEnter employee ID to remove: ");
        int id = int.Parse(Console.ReadLine());

        // Find the employee to remove
        Employee employeeToRemove = department.FindEmployeeById(id);

        if (employeeToRemove != null)
        {
            department.RemoveEmployee(employeeToRemove);
            Console.WriteLine("Employee removed successfully.");
        }
        else
        {
            Console.WriteLine("Employee with the given ID not found.");
        }
    }
}
