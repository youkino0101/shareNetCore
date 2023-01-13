using System.ComponentModel.DataAnnotations;

namespace NguyenThanhQuan_QLThongTin_MVC.Models
{
    public class Huyen
    {
        [Key]
        public int IdHuyen { get; set; }
        [Required(ErrorMessage = "Trường Huyện không được để trống")]
        [Display(Name = "Tên Huyện")]
        public string TenHuyen { get; set; }
        [Display(Name = "Mã Tỉnh")]
        public int IdTinh { get; set; }
        public Tinh Tinh { get; set; }
    }
}
