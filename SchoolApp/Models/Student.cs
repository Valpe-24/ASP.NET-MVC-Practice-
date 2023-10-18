using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SchoolApp.Utils;

namespace SchoolApp.Models
{
    public class Student
    {
        public int Id { get; set; } 
        public string EnrollmentDate { get; set; }
        public string Courses {  get; set; }

        public Grade Grade { get; set; }
        
    }
}