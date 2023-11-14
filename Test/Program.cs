using RequestLibrairie;
using System.Data.SqlClient;
using Test.Class;

string connectionString = "Server=GOS-VDI202\\TFTIC ;Database=NetflaskDB;User Id=nico; Password=123;";


SqlConnection sqlConnection = new SqlConnection(connectionString);

RequestDatabase requestDatabase = new RequestDatabase();

var recup = requestDatabase.GetData(connectionString, "movies");

foreach (var data in recup)
{
    Console.WriteLine(data);
}

//Director d = new Director()
//{
//    first_name = "jean",
//    last_name = "michel",
//    birthdate = DateTime.Now,
//};
object[] values = new object[] { "jean", "michel", "2000-01-01" };
requestDatabase.SetData(connectionString, "directors", values);