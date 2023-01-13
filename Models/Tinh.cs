using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NguyenThanhQuan_QLThongTin_MVC.Models
{
    public class Tinh
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Trường Tỉnh không được để trống")]
        [Display(Name = "Tên Tỉnh")]
        public string TenTinh { get; set; }
        public ICollection<Huyen> Huyens { get; set; }
    }
}
