using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        //[Display(Name = "Логин")]
        public string Login { get; set; }
        //[UIHint("Password")]
        //[Display(Name = "Пароль")]
        public string Password { get; set; }
        //[UIHint("Password")]
        //[Display(Name = "Подтверждение пароля")]
        //public string СheckPassword { get; set; }
    }
}