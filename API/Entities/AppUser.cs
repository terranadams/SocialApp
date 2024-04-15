namespace API.Entities;

public class AppUser {

    public int Id { get; set; } // entity framework needs these to be public so it can get and set these things in our db
    public string UserName { get; set;} 
}