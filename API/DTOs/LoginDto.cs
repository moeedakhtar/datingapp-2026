using System;
using System.Security.AccessControl;

namespace API.DTOs;

public class LoginDto
{
    public string Email { get; set; } ="";
    public string password { get; set; } = "";

}
