<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true"
    CodeFile="NhaCungCap.aspx.cs" Inherits="NhaCungCap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Insert() {
            $('#myModal').modal();
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="up4" runat="server">
        <ContentTemplate>
            <div style="margin: 0px 5px;">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <i aria-hidden="true" class="glyphicon glyphicon-user"></i><b> Danh sách nhà cung cấp</b>
                        <%-- <asp:DropDownList CssClass="dropbox" Width="300px" data-toggle="tooltip" data-original-title="Chọn chi nhánh"
                            DataTextField="TenChiNhanh" DataValueField="IDs" ID="dlChiNhanhLoc" runat="server">
                        </asp:DropDownList>--%>
                        <asp:TextBox ID="txtKeyword" MaxLength="50" runat="server" CssClass="form-control"
                            Style="width: 380px;" placeholder="Nhập tên nhà cung cấp"></asp:TextBox>
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
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-success" 
                            OnClientClick="return confirm('Bạn chắc chắn muốn lưu ?')" OnClick="btnSave_Click"> 
                                 <i aria-hidden="true" class="glyphicon glyphicon-check"></i> Lưu lại
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="btn btn-success"
                            OnClientClick="return confirm('Bạn chắc chắn muốn lưu ?')"  OnClick="btnUpdate_Click"> 
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
                                        <td colspan="2">
                                            <span>Tên nhà cung cấp</span><br />
                                            <asp:TextBox ID="txtTenNhaCungCap" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td width="25%">
                                            <span>Công ty</span><br />
                                            <asp:TextBox ID="txtTenCongTy" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td width="25%">
                                            <span>Email</span><br />
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%">
                                            <span>Số điện thoại</span><br />
                                            <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td width="25%">
                                            <span>Địa chỉ</span><br />
                                            <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td width="25%">
                                            <span>Mã số thuế</span><br />
                                            <asp:TextBox ID="txtMaSoThue" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td width="25%">
                                            <span>Ghi chú</span><br />
                                            <asp:TextBox ID="txtGhiChu" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%; margin: 5px;" class="wrapper">
                        <asp:GridView ID="gvNCC" runat="server" CellPadding="4" BorderColor="#CCCCCC" BackColor="Transparent"
                            ForeColor="#333333" GridLines="Both" Width="99.5%" AutoGenerateColumns="false"
                            OnRowCommand="gvNCC_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Thao tác">
                                    <ItemTemplate>
                                    <div style="margin-top:3px;">
                                        <asp:ImageButton ID="imgxoa" runat="server" Width="26px" Height="27px" ImageUrl="~/resource/img/del-24-24.png"
                                            OnClientClick="return confirm('Bạn chắc chắn muốn xóa ?')" CommandArgument='<%#Eval("ID")%>'
                                            Text="Xóa" CommandName="Del" />
                                         &nbsp;<asp:ImageButton ID="imgselect" runat="server" Width="26px" Height="27px" ImageUrl="~/resource/img/edit24-24.png"
                                            CommandArgument='<%#Eval("ID")%>' Text="Sửa" CommandName="Select" />
                                            </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Tên nhà cung cấp" DataField="TenNCC" />
                                <asp:BoundField HeaderText="Công ty" DataField="CongTy" />
                                <asp:BoundField HeaderText="Địa chỉ" DataField="DiaChi" />
                                <asp:BoundField HeaderText="Số điện thoại" DataField="SDT" />
                                <asp:BoundField HeaderText="Mã số thuế" DataField="MST" />
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
                    CssClass="btn btn-warning"> 
                            <i aria-hidden="true" class="glyphicon glyphicon-fast-backward"></i> Đầu
                </asp:LinkButton>
                <asp:LinkButton ID="btnPre" runat="server" Font-Bold="true" Width="80px" BackColor="#f76c2c"
                    CssClass="btn btn-warning"> 
                            <i aria-hidden="true" class="glyphicon glyphicon-step-backward"></i> Trước
                </asp:LinkButton>
                <asp:LinkButton ID="btnNext" runat="server" Font-Bold="true" Width="70px" BackColor="#f76c2c"
                    CssClass="btn btn-warning"> 
                            <i aria-hidden="true" class="glyphicon glyphicon-step-forward"></i> Sau
                </asp:LinkButton>
                <input type="button" id="lbPage" class="btn btn-warning" value="Trang 1" style="font-weight: bold;
                    background-color: #f76c2c;" />
            </div>
            <input type="hidden" value="1" id="hdCurPage" />
            <div id="ModalThongBao" class="modal fade" role="dialog">
                <div class="modal-dialog" style="width: 400px; margin-top: 135px;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                &times;</button>
                            <h4 class="modal-title">
                                Xóa nhà cung cấp</h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lbThongBao" Text="" runat="server"></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <span class="btn-group">
                                <button type="button" id="btnXoa" class="btn btn-success">
                                    <i aria-hidden="true" class="glyphicon glyphicon-check"></i>Đồng ý</button>
                                <button type="button" id="btnCan" class="btn btn-primary" data-dismiss="modal">
                                    <i aria-hidden="true" class="glyphicon glyphicon-remove-circle"></i>Đóng lại</button>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
