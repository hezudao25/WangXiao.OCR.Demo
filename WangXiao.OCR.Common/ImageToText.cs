
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangXiao.OCR.Common
{
    public class ImageToText : IImageToText
    {

        /// <summary>
        /// 返回转换结果
        /// </summary>
        /// <param name="imgpath">图片路劲</param>
        /// <param name="ocrType">OCR模式，默认为百度</param>
        /// <param name="tesseractlanguage">如果是tesseract，注明语言chi_sim是中文，eng是英文，其他的是自定义</param>
        /// <returns></returns>
        public string Transformation(string imgpath, OcrType ocrType=OcrType.Baidu, string tesseractlanguage= "chi_sim")
        {
            string result = string.Empty;
            if(ocrType == OcrType.Baidu)
            {
                if (CustomCache.Exists("Baidu" + imgpath))
                {
                    result = CustomCache.Get<string>("Baidu" + imgpath);
                }
                else
                {
                    result = BaiduOCR.Transformation(imgpath);
                    CustomCache.add("Baidu" + imgpath, result);
                }
            }
            else if(ocrType==OcrType.Google)
            {
                result = new Tesseract(tesseractlanguage).Transformation(imgpath);
            }
            return result;
        }
    }

    public enum OcrType
    {
        /// <summary>
        /// 百度OCR接口
        /// </summary>
        Baidu,   //
        /// <summary>
        /// 指谷歌开源的Tesseract-OCR
        /// </summary>
        Google
    }
}
