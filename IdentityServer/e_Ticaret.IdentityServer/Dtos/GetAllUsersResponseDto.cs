using e_Ticaret.IdentityServer.Models;

namespace e_Ticaret.IdentityServer.Dtos;

public class GetAllUsersResponseDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    public static GetAllUsersResponseDto ConvertToResponse(ApplicationUser applicationUser)
    {
        return new GetAllUsersResponseDto()
        {
            Id = applicationUser.Id,
            Name = applicationUser.Name,
            Surname = applicationUser.Surname,
            UserName = applicationUser.UserName,
            Email = applicationUser.Email,
        };
    }
}
