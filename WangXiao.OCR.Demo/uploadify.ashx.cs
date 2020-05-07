using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using WangXiao.OCR.Common;

namespace WangXiao.OCR.Euploadify
{
    /// <summary>
    /// uploadify 的摘要说明
    /// </summary>
    public class uploadify : IHttpHandler
    {
        protected string text = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            HttpPostedFile file = context.Request.Files["file"];
            string folder = context.Request["path"],
                id = context.Request["id"],
                value = context.Request["id"];
            string uploadPath = HttpContext.Current.Server.MapPath(folder) + "\\";

            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                   String fileName = file.FileName.Substring(file.FileName.LastIndexOf("\\")+1, file.FileName.Length - 1 - file.FileName.LastIndexOf("\\"));
                ///取到当前时间的年、月、日、分、秒和毫秒的值，并使用字符串格式把它们组合成一个字符串
               // String fileTime = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString()
               // + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString()
               // + DateTime.Now.Millisecond.ToString();
               // String src = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1, file.FileName.Length - file.FileName.LastIndexOf(".") - 1).ToLower();
               //string fileName = fileTime + "." + src;
                file.SaveAs(uploadPath + fileName);
                
                string text = "";
                try
                {
                    IImageToText imageToText = new ImageToText();
                    OcrType ocrType = OcrType.Baidu;
                    if (!string.IsNullOrWhiteSpace(System.Configuration.ConfigurationManager.AppSettings["OCR_TYPE"]))
                    {
                        ocrType = (OcrType)int.Parse(System.Configuration.ConfigurationManager.AppSettings["OCR_TYPE"]);
                    }
                    text = imageToText.Transformation(uploadPath + fileName, ocrType);
                }
                catch(Exception ex) { Console.WriteLine(ex.ToString()); }

                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                context.Response.Write("{ \"id\": \"" + id + "\", \"status\": true, \"message\": \"上传成功!\", \"value\": \"" + fileName + "\", \"text\": \""+ Until.string2Json(text) + "\" }");
            }
            else
            {
                context.Response.Write("{ \"id\": null, \"status\": false, \"message\"上传失败!\", \"value\": null, \"text\": null }");
            }
        }
   
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}