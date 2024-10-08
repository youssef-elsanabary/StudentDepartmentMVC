using System.ComponentModel.DataAnnotations;

namespace FirstProject
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required,Length(3,30)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
