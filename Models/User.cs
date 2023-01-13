using System.ComponentModel.DataAnnotations;

namespace NguyenThanhQuan_QLThongTin_MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
