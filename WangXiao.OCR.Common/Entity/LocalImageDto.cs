using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCe.OCR.Common.BaiduEntity
{
    public class LocalImageDto
    {
        /// <summary>
        /// 图像数据，base64编码后进行urlencode，
        /// 要求base64编码和urlencode后大小不超过4M，
        /// 最短边至少15px，最长边最大4096px,支持jpg/png/bmp格式，当image字段存在时url字段失效
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }
        /// <summary>
        /// 图片完整URL，URL长度不超过1024字节
        /// ，URL对应的图片base64编码后大小不超过4M，
        /// 最短边至少15px，最长边最大4096px,
        /// 支持jpg/png/bmp格式，当image字段存在时url字段失效，
        /// 不支持https的图片链接
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 图像数据，base64编码后进行urlencode，要求base64编码和urlencode后大小不超过4M，
        /// 最短边至少15px，最长边最大4096px,支持jpg/png/bmp格式，当image字段存在时url字段失效
        /// </summary>
        [JsonProperty("detect_direction")]
        public string DetectDirection { get; set; }
        /// <summary>
        /// 图像数据，base64编码后进行urlencode，要求base64编码和urlencode后大小不超过4M，
        /// 最短边至少15px，最长边最大4096px,支持jpg/png/bmp格式，当image字段存在时url字段失效
        /// </summary>
        [JsonProperty("detect_language")]
        public string DetectLanguage { get; set; }

        /// <summary>
        /// 是否返回识别结果中每一行的置信度(精确版)
        /// </summary>
        [JsonProperty("probability")]
        public string Probability { get; set; }
    }
}
