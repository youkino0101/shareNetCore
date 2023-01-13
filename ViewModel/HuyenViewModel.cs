using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NguyenThanhQuan_QLThongTin_MVC.ViewModel
{
    public class HuyenViewModel
    {
        [Required(ErrorMessage = "Trường Huyện không được để trống")]
        [Display(Name = "Tên Huyện")]
        public string TenHuyen { get; set; }
        [Required(ErrorMessage = "Mã không được để trống")]
        [Display(Name = "Mã Tỉnh")]
        public int IdTinh { get; set; }

        [Display(Name = "Tên Tỉnh")]
        public int TenTinh { get; set; }

    }
}
