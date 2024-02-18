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
}
