using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YunCe.OCR.Common.BaiduEntity
{
    /// <summary>
    /// 本地图片文字识别响应数据实体
    /// </summary>
    public class LocalImageResponseEntity
    {
        /// <summary>
        /// 图像方向，当detect_direction=true时存在。- -1:未定义，- 0:正向，- 1: 逆时针90度，- 2:逆时针180度，- 3:逆时针270度
        /// </summary>
        [JsonProperty("direction")]
        public int Direction { get; set; }
        /// <summary>
        /// 唯一的log id，用于问题定位
        /// </summary>
        [JsonProperty("log_id")]
        public UInt64 LogId { get; set; }
        /// <summary>
        /// 识别结果数组
        /// </summary>
        [JsonProperty("words_result")]
        public List<WordsResult> WordsResult { get; set; }
        /// <summary>
        /// 识别结果数，表示words_result的元素个数
        /// </summary>
        [JsonProperty("words_result_num")]
        public UInt32 WordResultNum { get; set; }
        
        /// <summary>
        /// 识别结果中每一行的置信度值，包含average：行置信度平均值，variance：行置信度方差，min：行置信度最小值
        /// </summary>
        [JsonProperty("probability")]
        public object Probability { get; set; }
    }
    public class WordsResult
    {
        /// <summary>
        /// 识别结果字符串
        /// </summary>
        [JsonProperty("words")]
        public string words { get; set; }
    }
}
