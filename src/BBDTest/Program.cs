// See https://aka.ms/new-console-template for more information
using System.Globalization;
using BBDTest.Models;

Console.WriteLine("Hello, World!");

DateOnly date = DateOnly.Parse("17/05/2025", new CultureInfo("en-GB"));
Console.WriteLine(date);
SearchCriteria searchCriteria = new SearchCriteria();
searchCriteria.CheckIn = date;
Console.WriteLine(searchCriteria.CheckIn);