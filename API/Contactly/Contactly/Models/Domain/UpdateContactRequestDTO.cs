namespace Contactly.Models.Domain
{
    public class UpdateContactRequestDTO
    {
       
        public required string Name { get; set; }

        public string? Email { get; set; }

        public string Phone { get; set; }

        public bool Favorite { get; set; }
    }
}
