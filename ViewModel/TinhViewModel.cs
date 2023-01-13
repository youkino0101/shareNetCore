using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NguyenThanhQuan_QLThongTin_MVC.ViewModel
{
    public class TinhViewModel
    {
        [Required(ErrorMessage = "Trường Tỉnh không được để trống")]
        [Display(Name = "Tên Tỉnh")]
        public string TenTinh { get; set; }
    }
}
