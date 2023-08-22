namespace TasteTrove.API.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public CreateUserDTO(string name , string email)
        {
            Name = name;
            Email = email;
        }
    }
}
