<%@ Page Title="Quy đổi hàng hóa" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeFile="QuyDoi.aspx.cs" Inherits="QuyDoi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="up4" runat="server">
        <ContentTemplate>
            <div style="margin: 0px 5px;">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <i aria-hidden="true" class="glyphicon glyphicon-user"></i><b>Bảng quy đổi thành phẩm
                            sang hàng hóa</b>
                        <asp:TextBox ID="txtKeyword" MaxLength="50" runat="server" CssClass="form-control"
                            Style="width: 380px;" placeholder="Nhập tên hàng hóa"></asp:TextBox>
                        <span class="btn-group">
                            <asp:LinkButton ID="btnXem" runat="server" CssClass="btn btn-success" OnClick="btnXem_Click"> 
                            <i aria-hidden="true" class="glyphicon glyphicon-search"></i> Tìm kiếm
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnRefesh" runat="server" CssClass="btn btn-success" OnClick="btnRefesh_Click"> 
                            <i aria-hidden="true" class="glyphicon glyphicon-refresh"></i> Làm mới
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnPrint" runat="server" CssClass="btn btn-success" OnClick="btnPrint_Click"> 
                            <i aria-hidden="true" class="glyphicon glyphicon-download-alt"></i> Xuất Excel
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-success" OnClientClick="return confirm('Bạn chắc chắn muốn lưu ?')"
                                OnClick="btnSave_Click"> 
                                 <i aria-hidden="true" class="glyphicon glyphicon-check"></i> Lưu lại
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-success" OnClientClick="return confirm('Bạn chắc chắn muốn lưu ?')"
                                OnClick="btnUpdate_Click"> 
                                 <i aria-hidden="true" class="glyphicon glyphicon-check"></i> Cập nhật
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-success" OnClick="btnCancel_Click"> 
                                 <i aria-hidden="true" class="glyphicon glyphicon-remove-circle"></i> Hủy bỏ
                            </asp:LinkButton>
                        </span>
                    </div>
                    <div style="width: 99.5%; margin-top: 5px;">
                        <div style="background-image: url(resource/img/content.png); background-repeat: repeat;">
                            <div>
                                <table class="bang_nhap" width="100%">
                                    <tr>
                                        <td width="33%">
                                            <span>Hàng hóa</span><br />
                                            <asp:DropDownList CssClass="dropbox" Width="99.5%" data-toggle="tooltip" data-original-title="Chọn hàng hóa"
                                                DataTextField="TenHH" DataValueField="ID" ID="dlHangHoa" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="33%">
                                            <span>Từ ngày</span><br />
                                            <asp:TextBox ID="txtTuNgay" runat="server" CssClass="form-control"></asp:TextBox>
                                            <cc1:CalendarExtender PopupPosition="BottomLeft" ID="CalendarExtender1" runat="server"
                                                TargetControlID="txtTuNgay" Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td width="33%">
                                            <span>Đến ngày</span><br />
                                            <asp:TextBox ID="txtDenNgay" runat="server" CssClass="form-control"></asp:TextBox>
                                             <cc1:CalendarExtender PopupPosition="BottomLeft" ID="CalendarExtender4" runat="server"
                                                TargetControlID="txtDenNgay" Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="33%">
                                            <span>Thành phẩm</span><br />
                                            <asp:DropDownList CssClass="dropbox" Width="99.5%" data-toggle="tooltip" data-original-title="Chọn thành phẩm"
                                                DataTextField="TenThanhPham" DataValueField="ID" ID="dlThanhPham" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="33%">
                                            <span>Đơn vị tính</span><br />
                                               <asp:DropDownList CssClass="dropbox" Width="99.5%" data-toggle="tooltip" data-original-title="Chọn đơn vị tính"
                                                DataTextField="TenDonViTinh" DataValueField="ID" ID="dlDonViTinh" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="33%">
                                            <span>Số lượng</span><br />
                                            <asp:TextBox ID="txtSoLuong" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%; margin: 5px;" class="wrapper">
                        <asp:GridView ID="gvQuyDoi" runat="server" CellPadding="4" BorderColor="#CCCCCC"
                            BackColor="Transparent" ForeColor="#333333" GridLines="Both" Width="99.5%" AutoGenerateColumns="false"
                            OnRowCommand="gvQuyDoi_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Thao tác">
                                    <ItemTemplate>
                                        <div style="margin-top: 3px;">
                                            <asp:ImageButton ID="imgxoa" runat="server" Width="26px" Height="27px" ImageUrl="~/resource/img/del-24-24.png"
                                                OnClientClick="return confirm('Bạn chắc chắn muốn xóa ?')" CommandArgument='<%#Eval("ID")%>'
                                                Text="Xóa" CommandName="Del" />
                                            &nbsp;<asp:ImageButton ID="imgselect" runat="server" Width="26px" Height="27px" ImageUrl="~/resource/img/edit24-24.png"
                                                CommandArgument='<%#Eval("ID")%>' Text="Sửa" CommandName="Select" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Hàng hóa" DataField="TenHH" />
                                <asp:BoundField HeaderText="Từ ngày" DataField="TuNgay" />
                                <asp:BoundField HeaderText="Đến ngày" DataField="DenNgay" />
                                <asp:BoundField HeaderText="Thành phẩm" DataField="TenThanhPham" />
                                <asp:BoundField HeaderText="Số lượng" DataField="SoLuong" />
                                <asp:BoundField HeaderText="Đơn vị tính" DataField="TenDonViTinh" />
                            </Columns>
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#DFF0D8" Font-Bold="True" Height="30px" Font-Size="Medium"
                                CssClass="rowheight" ForeColor="Black" Font-Names="Times New Roman" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="Transparent" ForeColor="#333333" CssClass="rowheight" Font-Names="Times New Roman" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </div>
                </div>
                <asp:HiddenField ID="hdID" runat="server" />
                <asp:HiddenField ID="hdPage" runat="server" />
            </div>
            <div style="margin: 5px; overflow: hidden;" class="btn-group ftKLNVKD">
                <asp:LinkButton ID="btnFirst" runat="server" Font-Bold="true" Width="70px" BackColor="#f76c2c"
                    CssClass="btn btn-warning" OnClick="btnFirst_Click"> 
                            <i aria-hidden="true" class="glyphicon glyphicon-fast-backward"></i> Đầu
                </asp:LinkButton>
                <asp:LinkButton ID="btnPre" runat="server" Font-Bold="true" Width="80px" BackColor="#f76c2c"
                    CssClass="btn btn-warning" OnClick="btnPre_Click"> 
                            <i aria-hidden="true" class="glyphicon glyphicon-step-backward"></i> Trước
                </asp:LinkButton>
                <asp:LinkButton ID="btnNext" runat="server" Font-Bold="true" Width="70px" BackColor="#f76c2c"
                    CssClass="btn btn-warning" OnClick="btnNext_Click"> 
                            <i aria-hidden="true" class="glyphicon glyphicon-step-forward"></i> Sau
                </asp:LinkButton>
                <asp:LinkButton ID="lbPage" runat="server" Font-Bold="true" Width="70px" BackColor="#f76c2c"
                    CssClass="btn btn-warning"> 
                </asp:LinkButton>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
