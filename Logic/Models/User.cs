namespace Logic.Models;

public  class User
{
    public string Id { get; set; } = null!;
    public string MobilePhone { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string Municipality { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";
}
