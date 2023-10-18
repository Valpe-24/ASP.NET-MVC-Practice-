using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string StartDate {  get; set; }
        public string Subjects { get; set; }

    }
}