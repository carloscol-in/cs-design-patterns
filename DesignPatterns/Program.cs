// See https://aka.ms/new-console-template for more information
using DesignPatterns.StatePattern;

var customerContext = new CustomerContext();

Console.WriteLine(customerContext.GetState());
customerContext.Request(100);
Console.WriteLine(customerContext.GetState());

customerContext.Request(10);
Console.WriteLine(customerContext.GetState());

customerContext.Request(100);
Console.WriteLine(customerContext.GetState());