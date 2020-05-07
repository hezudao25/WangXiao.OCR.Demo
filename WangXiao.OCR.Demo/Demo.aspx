<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="WangXiao.OCR.Demo.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="css/Style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div class="main_left left_ntop" id="content">
  <div class="house_list" id="list">
              <div class="house_tab"><a class="house_img"><img src="/upload/10.jpg" class="selector"></a><div class="house_txt"> <textarea><%=text %></textarea><div class="house_price"><b><input type="checkbox" name="ku" value=""></b>选择</div></div> </div>      
   </div>
        </div>
    </form>
</body>
</html>
