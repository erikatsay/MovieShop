using System.Security.Authentication.ExtendedProtection;

namespace ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

public class Role
{
    public int Id { get; set; }
    
    [MaxLength(20)]
    public int Name { get; set; }
    
}