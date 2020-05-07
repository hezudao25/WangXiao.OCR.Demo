using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WangXiao.OCR.Common;

namespace WangXiao.OCR.Demo
{
    public partial class Demo : System.Web.UI.Page
    {
        protected string text = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //IImageToText imageToText = new Tesseract();
            IImageToText imageToText = new ImageToText();
            string imgpath = Server.MapPath("/upload/10.jpg");
            // text = imageToText.Transformation(imgpath, OcrType.Baidu);
            OcrType ocrType = OcrType.Baidu;
            if(!string.IsNullOrWhiteSpace(System.Configuration.ConfigurationManager.AppSettings["OCR_TYPE"]))
            {
                ocrType = (OcrType)int.Parse(System.Configuration.ConfigurationManager.AppSettings["OCR_TYPE"]);
            }

            text = imageToText.Transformation(imgpath, ocrType);

        }
    }
}