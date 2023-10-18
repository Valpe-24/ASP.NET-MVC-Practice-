using MongoDB.Driver;
using SchoolApp.Models;
using System.Configuration;


public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;


        var client = new MongoClient(connectionString);
        _database = client.GetDatabase("school");

    }
    public IMongoCollection<User> User => _database.GetCollection<User>("user");
    public IMongoCollection<Student> Student => _database.GetCollection<Student>("student");
    public IMongoCollection<Teacher> Teacher => _database.GetCollection<Teacher>("teacher");
    public IMongoCollection<Contacts> Contact => _database.GetCollection<Contacts>("contacts");
    public IMongoCollection<Address> Address => _database.GetCollection<Address>("address");


}
