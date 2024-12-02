using System.Net.Http.Headers;
using OrbDataModels;
using OrbDataModels.BLL;
using OrbDataModels.DAL;

string connectionString = "Server=localhost;Database=orb_db;User ID=lewisjhannah;Password=precious5;Port=3306;";

OrbBLL orbBLL = new OrbBLL(connectionString);

Console.WriteLine("List of States:");
var states = orbBLL.GetAllStates();
foreach (var state in states)
{
    Console.WriteLine(state.StateName);
}

Console.WriteLine("List of Counties in PA:");
var counties = orbBLL.GetCountiesByState(39);
foreach (var county in counties)
{
    Console.WriteLine(county.CountyName);
}

var orb = orbBLL.GetOrbsByStateCounty(39, 2417);
Console.WriteLine(orb.CountyHomepage);