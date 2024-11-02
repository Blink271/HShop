using HShop.Data;
using HShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using HShop.Helpers;

namespace HShop.Controllers
{
    public class CartController : Controller
    {
        private readonly Hshop2023Context db;

        public CartController(Hshop2023Context context) => db = context;

        public List<CartItem> CartItems => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
        public IActionResult Index()
        {
            return View(CartItems);
        }

        public IActionResult AddToCart(int id, int quantity = 1)
        {
            var giohang = CartItems;
            var item = giohang.SingleOrDefault(p => p.MaHH == id);
            if (item == null)
            {
                var hanghoa = db.HangHoas.SingleOrDefault(p => p.MaHh == id);
                if (hanghoa == null)
                {
                    TempData["Message"] = $"Không tìm thấy hàng hóa có mã {id}";
                    return Redirect("/404");
                }
                item = new CartItem
                {
                    MaHH = hanghoa.MaHh,
                    TenHH = hanghoa.TenHh,
                    DonGia = hanghoa.DonGia ?? 0,
                    Hinh = hanghoa.Hinh ?? "",
                    SoLuong = quantity
                };
                giohang.Add(item);
            }
            else
            {
                item.SoLuong += quantity;
            }

            HttpContext.Session.Set(MySetting.CART_KEY, giohang);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
        {
            var giohang = CartItems;

            var item = giohang.SingleOrDefault(p => p.MaHH == id);

            if(item != null)
            {
                giohang.Remove(item);
                HttpContext.Session.Set(MySetting.CART_KEY, giohang);
            }

            return RedirectToAction("Index");
        }
    }
}
