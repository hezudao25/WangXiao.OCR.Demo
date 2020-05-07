
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangXiao.OCR.Common
{
    public interface IImageToText
    {
        /// <summary>
        /// 图片转换
        /// </summary>
        /// <param name="imgpath"></param>
        /// <param name="ocrType">OCR类型</param>
        /// <returns></returns>
        string Transformation(string imgpath, OcrType ocrType = OcrType.Baidu, string tesseractlanguage = "chi_sim");
    }
}
