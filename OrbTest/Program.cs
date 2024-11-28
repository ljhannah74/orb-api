using System.Net.Http.Headers;
using OrbDataModels;
using OrbDataModels.BLL;

string connectionString = "Server=localhost;Database=orb_db;User ID=lewisjhannah;Password=precious5;Port=3306;";

ResourceBLL resourceBLL = new ResourceBLL(connectionString);

Console.WriteLine("List of States:");
var states = resourceBLL.GetAllStates();
foreach (var state in states)
{
    Console.WriteLine(state.StateName);
}