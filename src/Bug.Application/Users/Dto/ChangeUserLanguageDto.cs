using System.ComponentModel.DataAnnotations;

namespace Bug.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}