using System;
//Write classes for events, one class which exposes an event and another which handles the event.
//1)    Create a class to pass as an argument for the event handlers
//2) Set up the delegate for the event
//3)    Declare the code for the event
//4)    Create code the will be run when the event occurs
//5)    Associate the event with the event handler
namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Speak speak = new Speak();
            Person person = new Person();

            speak.SomeEvent += person.Speaking;
            speak.MySpeak("Hello, How are you ?");
        }
    }
}

public class CustomEvent : EventArgs
{
    public string message;
    public CustomEvent(string message)
    {
        this.message = message;
    }
}

public delegate void CustomDelegate(object sender, CustomEvent customeEvent);

public class Speak
{
    public event CustomDelegate SomeEvent;

    public void MySpeak(string message)
    {
        if (SomeEvent != null)
            SomeEvent(this, new CustomEvent(message));
    }
}

public class Person
{
    public void Speaking(object sender, CustomEvent customeEvent)
    {
        Console.WriteLine($"Person Speaking that : {customeEvent.message}");
    }
}