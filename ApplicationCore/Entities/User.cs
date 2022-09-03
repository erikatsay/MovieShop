namespace ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email{ get; set; }
    public string FirstName{ get; set; }
    public string HashedPassword{ get; set; }
    public Boolean? IsLocked { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }= null!;
    public string ProfilePictureUrl { get; set; } = null!;
    public string Salt { get; set; }

    public ICollection<UserRole> RolesOfUser { get; set; }
    public ICollection<Review> Reviews { get; set; }
}