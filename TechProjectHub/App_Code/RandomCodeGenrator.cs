using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace TechProjectHub.App_Code
{
    public class RandomCodeGenrator
    {
        string Code = "";
        public int GetOTP()
        {
            Random r = new Random();
            int n, x;
            x = r.Next(1, 10);
            if (x % 2 == 0)
                n = r.Next(1000, 9999);
            else
                n = r.Next(10000, 99999);

            return n;


        }
        internal string GetCaptchaCode()
        {
            char ch;
            Code = "";
            Random r = new Random();
            ch = (char)r.Next(65, 90);
            Code = Code + ch;
            ch = (char)r.Next(49, 57);
            Code = Code + ch;
            ch = (char)r.Next(97, 122);
            Code = Code + ch;
            ch = (char)r.Next(100, 120);
            Code = Code + ch;
            ch = (char)r.Next(51, 56);
            Code = Code + ch;
            ch = (char)r.Next(70, 88);
            Code = Code + ch;
            int n = r.Next(1, 20);
            if (n > 10)
            {
                ch = (char)r.Next(105, 122);
                Code = Code + ch;
            }
            return Code;
        }
        internal string[] GetCaptchaImgAndCode()
        {
            SolidBrush sb = new SolidBrush(Color.Blue);
            Pen maroonPen = new Pen(Color.Maroon);
            Font f = new Font("Cursive", 11, FontStyle.Strikeout);
            Bitmap bmp = new Bitmap(150, 26);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Aquamarine);
            g.DrawRectangle(maroonPen, 4, 3, 145, 20);
            string captcha = GetCaptchaCode();
            g.DrawString(captcha, f, sb, 25, 5);
            g.Flush();
            string FileName = Path.GetRandomFileName() + ".jpg";
            string FolderPath = HttpContext.Current.Server.MapPath("/Content/Captcha");
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
            bmp.Save(FolderPath + "/" + FileName, ImageFormat.Jpeg);
            string[] arr = new string[2];
            arr[0] = FileName;
            arr[1] = captcha;
            return arr;
        }
    }
}