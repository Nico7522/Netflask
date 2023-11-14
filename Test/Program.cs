using RequestLibrairie;
using System.Data.SqlClient;

string connectionString = "Server=GOS-VDI202\\TFTIC ;Database=NetflaskDB;User Id=nico; Password=123;";


SqlConnection sqlConnection = new SqlConnection(connectionString);

RequestDatabase requestDatabase = new RequestDatabase();

var recup = requestDatabase.GetData(connectionString, "movies");

foreach (var data in recup)
{
    Console.WriteLine(data);
}