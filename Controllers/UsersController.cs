using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenThanhQuan_QLThongTin_MVC.Data;
using NguyenThanhQuan_QLThongTin_MVC.Models;
using NguyenThanhQuan_QLThongTin_MVC.ViewModel;

namespace NguyenThanhQuan_QLThongTin_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly QLThongTinDbContext _context;

        public UsersController(QLThongTinDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult Login()
        {
              return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInput login)
        {
            if (ModelState.IsValid)
            {
                var result = _context.Users.FirstOrDefault(x => x.Username == login.Username);
                if (result != null)
                {
                    if (result.Password == login.Password)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Tên Đăng Nhập Hoặc Mật Khẩu Không Chính Xác!!!");
                }
                ModelState.AddModelError(string.Empty, "Tên Đăng Nhập Hoặc Mật Khẩu Không Chính Xác!!!");
            }
            return View(login);
        }

    }
}
