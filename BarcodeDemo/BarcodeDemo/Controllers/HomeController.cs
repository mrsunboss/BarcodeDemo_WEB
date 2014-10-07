using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarcodeLib;
using System.Drawing;
using System.Drawing.Imaging;
namespace BarcodeDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public void Barcode(string sn = null)
        {
            Response.ContentType = "image/gif";
            Barcode bc = new Barcode();
            bc.IncludeLabel = true;//顯示文字標籤
            bc.LabelFont = new Font("Verdana", 9f);//文字標籤字型與大小
            bc.Width = 300;//寬度
            bc.Height = 100;//高度
            Image img = bc.Encode(TYPE.CODE39, sn, bc.Width, bc.Height);//產生影像
            img.Save(Response.OutputStream, ImageFormat.Gif);
            Response.End();
        }
    }
}