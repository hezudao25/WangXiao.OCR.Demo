using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangXiao.TesseractOCRPlugin;


namespace WangXiao.OCR.Common
{
    /// <summary>
    /// Tesseract-ocr
    /// </summary>
    public class Tesseract 
    {
        private TesseractOCR _TessOCR;
        public Tesseract(string tesseractlanguage)
        {          
           // _TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High); 英文
            _TessOCR = new TesseractOCR(tesseractlanguage, TesseractOCR.Quality.High);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgpath">图片绝对路劲</param>
        /// <param name="tessdata">为语言包存放的绝对路径</param>
        /// <returns></returns>
        public string Transformation(string imgpath)
        {
            string text = _TessOCR.OCRimage(imgpath);          
            return text;
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="imgpath">图片绝对路劲</param>
        ///// <param name="tessdata">为语言包存放的绝对路径</param>
        ///// <returns></returns>
        //public static string Transformation(string imgpath, string tessdata)
        //{
        //    var img = new Bitmap(imgpath);    //需要识别的图片           
        //    var ocr = new TesseractEngine(tessdata, "chi_sim", EngineMode.Default);    //使用chi_sim中文语言包做测试
        //    var page = ocr.Process(img);
        //    string text = page.GetText();
        //    page.Dispose();
        //    return text;
        //}


        #region hidden
        ///// <summary>
        ///// 图片颜色区分，剩下白色和黑色
        ///// </summary>
        ///// <param name="image"></param>
        ///// <returns></returns>
        //private Bitmap PreprocesImage(Bitmap image)
        //{
        //    //You can change your new color here. Red,Green,LawnGreen any..
        //    Color actualColor;
        //    //make an empty bitmap the same size as scrBitmap
        //    image = ResizeImage(image, image.Width * 5, image.Height * 5);
        //    //image.Save(@"D:\UpWork\OCR_WinForm\Preprocess_Resize.jpg");

        //    Bitmap newBitmap = new Bitmap(image.Width, image.Height);
        //    for (int i = 0; i < image.Width; i++)
        //    {
        //        for (int j = 0; j < image.Height; j++)
        //        {
        //            //get the pixel from the scrBitmap image
        //            actualColor = image.GetPixel(i, j);
        //            // > 150 because.. Images edges can be of low pixel colr. if we set all pixel color to new then there will be no smoothness left.
        //            if (actualColor.R > 23 || actualColor.G > 23 || actualColor.B > 23)//在这里设置RGB
        //                newBitmap.SetPixel(i, j, Color.White);
        //            else
        //                newBitmap.SetPixel(i, j, Color.Black);
        //        }
        //    }
        //    return newBitmap;
        //}

        ///// <summary>
        ///// 调整图片大小和对比度
        ///// </summary>
        ///// <param name="image"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <returns></returns>
        //private Bitmap ResizeImage(Image image, int width, int height)
        //{
        //    var destRect = new Rectangle(0, 0, width, height);
        //    var destImage = new Bitmap(width, height);

        //    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution * 2);//2,3
        //                                                                                      //image.Save(@"D:\UpWork\OCR_WinForm\Preprocess_HighRes.jpg");

        //    using (var graphics = Graphics.FromImage(destImage))
        //    {
        //        graphics.CompositingMode = CompositingMode.SourceOver;
        //        graphics.CompositingQuality = CompositingQuality.HighQuality;
        //        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //        using (var wrapMode = new ImageAttributes())
        //        {
        //            wrapMode.SetWrapMode(WrapMode.Clamp);
        //            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        //        }
        //    }

        //    return destImage;
        //}
        #endregion
    }
}
