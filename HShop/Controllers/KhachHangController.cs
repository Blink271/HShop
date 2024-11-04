using AutoMapper;
using HShop.Data;
using HShop.Helpers;
using HShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HShop.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly Hshop2023Context db;
        private readonly IMapper _mapper;

        public KhachHangController(Hshop2023Context context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(RegisterVM model, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var khachhang = _mapper.Map<KhachHang>(model);
                    khachhang.RandomKey = MyUtil.GenerateRandomKey();
                    khachhang.MaKh = model.MaKh.ToMd5Hash(khachhang.RandomKey);
                    khachhang.HieuLuc = true;
                    khachhang.VaiTro = 0;

                    if (Hinh != null)
                    {
                        khachhang.Hinh = MyUtil.UpLoadHinh(Hinh, "KhachHang");
                    }

                    db.Add(khachhang);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                return RedirectToAction("Index", "HangHoa");
            }

            return View();
        }
    }
}
