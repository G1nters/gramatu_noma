using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

public class LibraryContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=library.db");
}

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // "admin" or "user"
}

public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsAvailable { get; set; } = true;
}

public class Reservation
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
    [ForeignKey("Book")]
    public int BookId { get; set; }
    public Book Book { get; set; }
    public DateTime ReservationDate { get; set; } = DateTime.Now;
    public bool IsReturned { get; set; } = false;
}

public class Authentication
{
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }

    public static User RegisterUser(string name, string email, string password, string role = "user")
    {
        using (var db = new LibraryContext())
        {
            if (db.Users.Any(u => u.Email == email))
                throw new Exception("User with this email already exists.");

            var user = new User
            {
                Name = name,
                Email = email,
                PasswordHash = HashPassword(password),
                Role = role
            };

            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }
    }

    public static User LoginUser(string email, string password)
    {
        using (var db = new LibraryContext())
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                throw new Exception("Invalid email or password.");
            
            return user;
        }
    }
}

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var user = Authentication.LoginUser(EmailTextBox.Text, PasswordBox.Password);
            MessageBox.Show("Login successful! Welcome " + user.Name);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}

public partial class RegisterWindow : Window
{
    public RegisterWindow()
    {
        InitializeComponent();
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Authentication.RegisterUser(NameTextBox.Text, EmailTextBox.Text, PasswordBox.Password);
            MessageBox.Show("Registration successful!");
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}

