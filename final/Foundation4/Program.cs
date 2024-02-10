using System;
using System.Collections.Generic;

// Abstraction with YouTube Videos: This program will track YouTube videos and their comments. It will include classes for Video and Comment, with Video being responsible for storing information such as title, author, duration, and comments of a video.

// Encapsulation with Online Ordering: This program will manage an online product ordering system for a company. It will consist of classes for Product, Customer, Address, and Order, with responsibilities like calculating the total order cost, generating packing labels, shipping labels, and determining shipping costs based on the customer's location.

//Inheritance with Event Planning: This program will assist an event planning company in organizing and marketing events. It will feature a base Event class and derived classes for different event types like Lectures, Receptions, and Outdoor Gatherings, each with specific event details and marketing messages.

//Polymorphism with Exercise Tracking: This program will serve as an exercise tracking app for a fitness center, supporting activities such as Running, Stationary Bicycles, and Swimming. It will utilize polymorphism to calculate and display information such as distance, speed, and pace for each activity type.



class Program
{
    static void Main(string[] args)
    {
        // Program 1: Abstraction with YouTube Videos
        var videos = new List<Video>
        {
            new Video("Video 1", "Author 1", 120),
            new Video("Video 2", "Author 2", 180),
            new Video("Video 3", "Author 3", 150)
        };

        videos[0].AddComment("User1", "Nice video!");
        videos[0].AddComment("User2", "Great content!");
        videos[1].AddComment("User3", "Interesting topic!");

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"Comment by {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }

        // Program 2: Encapsulation with Online Ordering
        var order1 = new Order();
        order1.Products.Add(new Product { Name = "Product1", ProductId = "1", Price = 10, Quantity = 2 });
        order1.Products.Add(new Product { Name = "Product2", ProductId = "2", Price = 20, Quantity = 1 });
        order1.Customer = new Customer
        {
            Name = "John Doe",
            Address = new Address { Street = "123 Main St", City = "Anytown", State = "CA", Country = "USA" }
        };

        Console.WriteLine($"Packing Label:\n{order1.GetPackingLabel()}\nShipping Label:\n{order1.GetShippingLabel()}\nTotal Price: ${order1.CalculateTotalPrice()}");

        // Program 3: Inheritance with Event Planning
        Event lecture = new Lecture
        {
            Title = "Lecture Title",
            Description = "Lecture Description",
            Date = DateTime.Now.AddDays(7),
            Time = "10:00 AM",
            Location = new Address { Street = "456 Elm St", City = "Othertown", State = "NY", Country = "USA" },
            Speaker = "Speaker Name",
            Capacity = 100
        };

        Event reception = new Reception
        {
            Title = "Reception Title",
            Description = "Reception Description",
            Date = DateTime.Now.AddDays(14),
            Time = "7:00 PM",
            Location = new Address { Street = "789 Oak St", City = "AnotherTown", State = "TX", Country = "USA" },
            RSVP = "example@example.com"
        };

        Event outdoorGathering = new OutdoorGathering
        {
            Title = "Outdoor Gathering Title",
            Description = "Outdoor Gathering Description",
            Date = DateTime.Now.AddDays(21),
            Time = "2:00 PM",
            Location = new Address { Street = "101 Pine St", City = "YetAnotherTown", State = "FL", Country = "USA" },
            WeatherForecast = "Sunny"
        };

        Console.WriteLine("Lecture Full Details:\n" + lecture.GetFullDetails());
        Console.WriteLine("\nReception Short Description:\n" + reception.GetShortDescription());
        Console.WriteLine("\nOutdoor Gathering Standard Details:\n" + outdoorGathering.GetStandardDetails());

        // Program 4: Polymorphism with Exercise Tracking
        var activities = new List<Activity>
        {
            new Running { Date = DateTime.Now.AddDays(-3), DurationInMinutes = 30, DistanceInMiles = 3.0 },
            new Cycling { Date = DateTime.Now.AddDays(-2), DurationInMinutes = 40, SpeedInMph = 15 },
            new Swimming { Date = DateTime.Now.AddDays(-1), DurationInMinutes = 45, Laps = 20 }
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comments.Add(new Comment { CommenterName = commenterName, Text = text });
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }
}

class Product
{
    public string Name { get; set; }
    public string ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public Order()
    {
        Products = new List<Product>();
    }

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in Products)
        {
            totalPrice += product.Price * product.Quantity;
        }
        return totalPrice + (Customer.IsInUSA() ? 5 : 35);
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in Products)
        {
            label += $"{product.Name}, {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return Customer.GetFormattedAddress();
    }
}

// Definição da classe Address
class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    // Método para obter o endereço formatado
    public string GetFormattedAddress()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }

    // Método para verificar se o endereço está nos EUA
    public bool IsInUSA()
    {
        return Country == "USA";
    }
}

// Definição da classe Customer
class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; } // Propriedade Address do tipo Address

    // Método para obter o endereço formatado
    public string GetFormattedAddress()
    {
        // Verifica se o endereço é nulo antes de chamar o método GetFormattedAddress
        return Address != null ? Address.GetFormattedAddress() : "No address available";
    }

    // Método para verificar se o cliente está nos EUA
    public bool IsInUSA()
    {
        // Verifica se o endereço é nulo antes de chamar o método IsInUSA
        return Address != null && Address.IsInUSA();
    }
}



abstract class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public Address Location { get; set; }

    public abstract string GetFullDetails();
    public abstract string GetShortDescription();
    public abstract string GetStandardDetails();
}

class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public override string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nLocation: {Location.GetFormattedAddress()}\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Lecture - {Title}, {Date.ToShortDateString()}";
    }

    public override string GetStandardDetails()
    {
        return $"Title: {Title}\nDate: {Date}\nTime: {Time}\nLocation: {Location.GetFormattedAddress()}";
    }
}

class Reception : Event
{
    public string RSVP { get; set; }

    public override string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nLocation: {Location.GetFormattedAddress()}\nRSVP: {RSVP}";
    }

    public override string GetShortDescription()
    {
        return $"Reception - {Title}, {Date.ToShortDateString()}";
    }

    public override string GetStandardDetails()
    {
        return $"Title: {Title}\nDate: {Date}\nTime: {Time}\nLocation: {Location.GetFormattedAddress()}";
    }
}

class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public override string GetFullDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nLocation: {Location.GetFormattedAddress()}\nWeather Forecast: {WeatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Outdoor Gathering - {Title}, {Date.ToShortDateString()}";
    }

    public override string GetStandardDetails()
    {
        return $"Title: {Title}\nDate: {Date}\nTime: {Time}\nLocation: {Location.GetFormattedAddress()}";
    }
}

abstract class Activity
{
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract string GetSummary();
}

class Running : Activity
{
    public double DistanceInMiles { get; set; }

    public override double GetDistance()
    {
        return DistanceInMiles;
    }

    public override double GetSpeed()
    {
        return DistanceInMiles / (DurationInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return DurationInMinutes / DistanceInMiles;
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Running ({DurationInMinutes} min) - Distance {DistanceInMiles} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Cycling : Activity
{
    public double SpeedInMph { get; set; }

    public override double GetDistance()
    {
        return SpeedInMph * (DurationInMinutes / 60.0);
    }

    public override double GetSpeed()
    {
        return SpeedInMph;
    }

    public override double GetPace()
    {
        return 60 / SpeedInMph;
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Cycling ({DurationInMinutes} min): Distance {GetDistance()} miles, Speed: {SpeedInMph} mph, Pace: {GetPace()} min per mile";
    }
}

class Swimming : Activity
{
    public int Laps { get; set; }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (DurationInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return DurationInMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Swimming ({DurationInMinutes} min): Distance {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}
