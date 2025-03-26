// See https://aka.ms/new-console-template for more information
using GenAI;

Console.WriteLine("Hello, World!");
ReadDocGenAI textInputSample = new ReadDocGenAI();
try
{
    var res = textInputSample.TextInput();
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}
