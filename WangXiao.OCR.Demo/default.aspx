<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WangXiao.OCR.Demo._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript" src="js/jquery-2.1.1.min.js"></script>
<link rel="stylesheet" type="text/css" href="/js/Huploadify.css?v=4"/>
<script type="text/javascript" src="/js/jquery.Huploadify.js"></script>
     <link rel="stylesheet" href="js/layui/css/layui.css"> 
    <script src="JS/layer/layer.js"></script>
    <link href="css/Style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        $(function () {
            var lay = 0;
            loadUploadify(1);  

            $('body').on("click", "#list>div>a", function (e) {
                layer.open({
                    type: 1,
                    title: "图片",
                    area: ['890px', '500px'],
                    content: "<img src=" + $(this).attr("data-img") + ">"
                });
            });
        });
        function loadUploadify(j) {
            $('#uploadfileQueue' + j).Huploadify({
                auto: true,
                fileTypeExts: '*.jpg;*.png;*.gif;*.bmp',
                multi: true,
                queueSizeLimit:10, // 控制上传个数 待实现
                formData: { key: 123456, key2: 'vvvv' },
                fileSizeLimit: 20480,
                showUploadedPercent: true,//是否实时显示上传的百分比，如20%
                showUploadedSize: true,
                removeTimeout: 9999999,
                uploader: '/uploadify.ashx?path=/upload',
                onUploadStart: function () {

                    //alert('开始上传');
                },
                onInit: function () {
                    //alert('初始化');
                    //$("#list").html(""); 
                },
                onUploadComplete: function (file, data, response) {
                    var da = eval("(" + data + ")");
                    var dd = da.value; var text = da.text;
                    // dd = dd.replace("||", "||\n");
                    //    $("#wen" + j).html(dd);
                    $("#PdtPicture" + j).val($("#PdtPicture" + j).val() + dd + "\n");
                    $("#list #loading").hide();
                    var htmlli = '<div class="house_tab"><a data-img="/upload/' + dd + '" class="house_img"><img src="/upload/' + dd + '" class="selector" >';
                    htmlli += '</a><div class="house_txt"> <textarea>' + text + '</textarea><div class="house_price">';
                    htmlli += '<b><input type="checkbox" name="ku" value="' + text + '" /></b>选择</div></div> </div>  ';
                    $("#list").append(htmlli);

                    

                   
                },
                onUploadAllComplete: function (files) {                 
                     layer.open({
                        type: 1,
                        title: "图片转文字",
                        area: ['890px', '500px'],
                        btn: '导入库',
                        content: $('#content'), //这里content是一个DOM，注意：最好该元素要存放在body最外层，否则可能被其它的相对元素所影响
                        yes: function (index, layero) {
                            //do something
                           // console.log($(layero).findall("input[type=checkbox]:checked").attr("value"));
                           
                            var values = "";
                            var i = 0;
                            $(layero).find("input:checkbox[name='ku']:checked").each(function () {
		                                     
                                values += this.value + "<br>";
                                i++;
                            });
                            if (i > 3) { layer.msg("选择不能超过3个！"); }
                            else {
                                layer.msg(values, function () {
                                   layer.close(index); //如果设定了yes回调，需进行手工关闭
                                });
                            }
                            
                        }
                    });
                },
                onDelete: function (file) {
                    console.log('删除的文件：' + file);
                    console.log(file);
                }
            });
          
        
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h1>OCR Demo</h1>
        <div>
            <asp:TextBox ID="PdtPicture1" TextMode="MultiLine" CssClass="input" Height="50px" Width="250px" runat="server" Visible="false" />                
                
            <span class="Validform_checktip" id="uploadfileQueue1">支持格式：jpg\png\pdf，大小控制在3M以内</span>
        </div>

    <div class="main_left left_ntop" style="display:none; " id="content">
  <div class="house_list" id="list">
       <div class="house_tab" id="loading"><p style="text-align:center;margin-top:100px;">正在加载......</p></div>             
   </div>
        </div>

    </form>

</body>
</html>
