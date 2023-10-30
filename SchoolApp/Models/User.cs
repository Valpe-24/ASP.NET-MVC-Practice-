using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SchoolApp.Utils;
using System.Text.RegularExpressions;

namespace SchoolApp.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }



        public bool validateName()
        {
            Regex nameRegex = new Regex(@"^[A-Za-z]{3,}$");
            return !string.IsNullOrEmpty(Name) && nameRegex.IsMatch(Name);
        }

        public bool validateLastName()
        {
            Regex lastnameRegex = new Regex(@"^[A-Za-z]{3,}$");
            return !string.IsNullOrEmpty(Lastname) && lastnameRegex.IsMatch(Lastname);
        }

        public bool validateUsername()
        {
            Regex userRegex = new Regex(@"^[a-zA-Z0-9]{5,8}$");
            return !string.IsNullOrEmpty(Username) && userRegex.IsMatch(Username);
        }

        public bool validatePassword()
        {
            Regex passRegex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$");
            return !string.IsNullOrEmpty(Password) && passRegex.IsMatch(Password) && Password.Equals(ConfirmPassword);
        }

        public bool validateEmail()
        {
            Regex emailRegex = new Regex(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$");
            return !string.IsNullOrEmpty(Email) && emailRegex.IsMatch(Email);   
        }

        public bool validateRole()
        {
            return Role == UserRole.student || Role == UserRole.teacher;
        }



    }
}