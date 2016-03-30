using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uc_History : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Write("<meta http-equiv=\"Refresh\"content=\"300\">");
            Response.Write(LoadHistory());
        }
    }
    string LoadHistory()
    {
        string header = "<div style='color: White; font-style:italic; background-color: #428BCA; margin-top:-2px; padding:5px 5px 5px 5px; cursor: pointer;'><marquee direction='left' onmouseover='this.stop();' onmouseout='this.start();'>";
        string footer = "</marquee></div>";
        string result = "";
        string tmp = "";


        tmp += "<b>Nhà cung cấp:</b> Administrator vừa thêm 1 nhà cung cấp mới: [ Ngày: 01/12/2015; Nhà cung cấp: Triệu Đình Đa - Tiên Cát;] - [ vào 08:16:12]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        tmp += "<b>Nhà cung cấp:</b> Administrator vừa thêm 1 nhà cung cấp mới: [ Ngày: 01/12/2015; Nhà cung cấp: Triệu Đình Đa - Tiên Cát;] - [ vào 08:16:12]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        tmp += "<b>Nhà cung cấp:</b> Administrator vừa thêm 1 nhà cung cấp mới: [ Ngày: 01/12/2015; Nhà cung cấp: Triệu Đình Đa - Tiên Cát;] - [ vào 08:16:12]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        tmp += "<b>Nhà cung cấp:</b> Administrator vừa thêm 1 nhà cung cấp mới: [ Ngày: 01/12/2015; Nhà cung cấp: Triệu Đình Đa - Tiên Cát;] - [ vào 08:16:12]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        tmp += "<b>Nhà cung cấp:</b> Administrator vừa thêm 1 nhà cung cấp mới: [ Ngày: 01/12/2015; Nhà cung cấp: Triệu Đình Đa - Tiên Cát;] - [ vào 08:16:12]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        tmp += "<b>Nhà cung cấp:</b> Administrator vừa thêm 1 nhà cung cấp mới: [ Ngày: 01/12/2015; Nhà cung cấp: Triệu Đình Đa - Tiên Cát;] - [ vào 08:16:12]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        tmp += "<b>Nhà cung cấp:</b> Administrator vừa thêm 1 nhà cung cấp mới: [ Ngày: 01/12/2015; Nhà cung cấp: Triệu Đình Đa - Tiên Cát;] - [ vào 08:16:12]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";

        return result = header + tmp + footer;
    }
}