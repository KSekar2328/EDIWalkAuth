namespace EDIWalks.Models.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class AddRegionRequestDto
    {
        [Required(ErrorMessage = "Name is required"),
         MaxLength(100, ErrorMessage = "Length exists")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required"),
         MinLength(3, ErrorMessage = "Code should have 3 char"),
         MaxLength(3, ErrorMessage = "Code shouldn't have more than 3 char")]
        public string Code { get; set; }
    }
}
