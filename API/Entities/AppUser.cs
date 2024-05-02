namespace API.Entities;

public class AppUser {

    public int Id { get; set; } // entity framework needs these to be public so it can get and set these things in our db

    public string UserName { get; set;} 

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; } // 'dotnet ef migrations add UserPasswordAdded'
    // check migrations by going to Data/Migrations
    // then update the database with 'dotnet ef database update'
    // then check database by going to 

}