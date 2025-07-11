using System;

namespace financial.Models 
{

internal class Account
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public DateTime birthDate { get; set; }
    public bool? gender { get; set; } = null;
    public string password { get; set; }


    public Account(string firstName, string lastName, string email, DateTime birthDate, bool? gender, string password)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.birthDate = birthDate;
        this.gender = gender;
        this.password = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public override string ToString() => id;
} }
