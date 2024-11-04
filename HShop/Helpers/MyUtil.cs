using System.Text;

namespace HShop.Helpers
{
    public class MyUtil
    {
        public static string UpLoadHinh(IFormFile Hinh, string folder)
        {
            try
            {

                var fullpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, Hinh.FileName);
                using (var myfiles = new FileStream(fullpath, FileMode.CreateNew))
                {
                    Hinh.CopyTo(myfiles);
                };
                return Hinh.FileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
            public static string GenerateRandomKey(int length = 5)
            {
                var pattern = @"qwertyuiopasdfghjklQWERTYUIOPASDFGHJKL!@#$%";
                var random = new Random();
                var sb = new StringBuilder();

                for (int i = 0; i < length; i++)
                {
                    sb.Append(pattern[random.Next(0, pattern.Length)]);
                }
                return sb.ToString();
            }

        }
    }
