using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuyDoi : System.Web.UI.Page
{
    QLBHDataContext db = new QLBHDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnCancel_Click(sender, e);
        }
    }
    void loadGridView()
    {
        //gvQuyDoi.DataSource = from x in db.tbl_QuiDois
        //                         orderby x.TenDonViTinh ascending
        //                         select new { x.ID, x.TenDonViTinh };
        //gvQuyDoi.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //tbl_QuyDoi ncc = new tbl_QuyDoi();
        //ncc.TenDonViTinh = txtTenDonViTinh.Text.Trim();

        //db.tbl_QuyDois.InsertOnSubmit(ncc);
        //db.SubmitChanges();
        //btnCancel_Click(sender, e);
        //GetMess("Lưu thành công", "");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //var ncc = (from x in db.tbl_QuyDois
        //           where x.ID.Equals(hdID.Value.Trim())
        //           select x).FirstOrDefault();
        //if (ncc != null)
        //{
        //    ncc.TenDonViTinh = txtTenDonViTinh.Text.Trim();

        //    db.SubmitChanges();
        //    btnCancel_Click(sender, e);
        //    GetMess("Lưu thành công", "");
        //}
        //else
        //    GetMess("Dữ liệu không tồn tại", "");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        loadGridView();
        Reset();
        LoadDonViTinh(dlDonViTinh);
        LoadThanhPham(dlThanhPham);
        LoadHangHoa(dlHangHoa);
        hdPage.Value = "1";
        lbPage.Text = "Trang 1";
        btnSave.Visible = true;
        btnUpdate.Visible = false;
    }
    void LoadDonViTinh(DropDownList dl)
    {
        dl.Items.Clear();
        dl.DataSource = from x in db.tbl_DonViTinhs
                        orderby x.TenDonViTinh
                        select new { x.ID, x.TenDonViTinh };
        dl.DataBind();
        dl.Items.Insert(0, new ListItem("Chọn đơn vị tính", ""));
        dl.SelectedIndex = 0;
    }
    void LoadThanhPham(DropDownList dl)
    {
        dl.Items.Clear();
        dl.DataSource = from x in db.tbl_ThanhPhams
                        orderby x.TenThanhPham
                        select new { x.ID, x.TenThanhPham };
        dl.DataBind();
        dl.Items.Insert(0, new ListItem("Chọn thành phẩm", ""));
        dl.SelectedIndex = 0;
    }
    void LoadHangHoa(DropDownList dl)
    {
        dl.Items.Clear();
        dl.DataSource = from x in db.tbl_HangHoas
                        orderby x.TenHH
                        select new { x.ID, x.TenHH };
        dl.DataBind();
        dl.Items.Insert(0, new ListItem("Chọn hàng hóa", ""));
        dl.SelectedIndex = 0;
    }

    void Reset()
    {
        hdID.Value = "";
        dlHangHoa.SelectedIndex = 0;
        dlThanhPham.SelectedIndex = 0;
        dlDonViTinh.SelectedIndex = 0;
        txtSoLuong.Text = "";
        txtTuNgay.Text = "";
        txtDenNgay.Text = "";
    }
    protected void btnXem_Click(object sender, EventArgs e)
    {
        if (txtKeyword.Text.Trim().Equals(""))
            loadGridView();
        else
        {
            //gvQuyDoi.DataSource = from x in db.tbl_QuyDois
            //                         where x.TenDonViTinh.Contains(txtKeyword.Text.Trim())
            //                         orderby x.TenDonViTinh ascending
            //                         select new { x.ID, x.TenDonViTinh };
            //gvQuyDoi.DataBind();
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    private void GetMess(string gstMess, string gstLink)
    {
        if (gstLink == "")
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('" + gstMess + "')", true);
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('" + gstMess + "');window.location.href='" + gstLink + "'", true);

    }
    protected void btnRefesh_Click(object sender, EventArgs e)
    {
        txtKeyword.Text = "";
        loadGridView();
    }

    protected void gvQuyDoi_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Del"))
        {
            //var ncc = (from x in db.tbl_QuyDois
            //           where x.ID.Equals(e.CommandArgument.ToString())
            //           select x).FirstOrDefault();
            //if (ncc != null)
            //{
            //    db.tbl_QuyDois.DeleteOnSubmit(ncc);
            //    db.SubmitChanges();
            //    btnCancel_Click(sender, e);
            //    GetMess("Xóa thành công", "");
            //}
            //else
            //    GetMess("Dữ liệu không tồn tại", "");
        }
        else
            if (e.CommandName.Equals("Select"))
            {
                //Reset();
                //var ncc = (from x in db.tbl_QuyDois
                //           where x.ID.Equals(e.CommandArgument.ToString())
                //           select x).FirstOrDefault();
                //if (ncc != null)
                //{

                //    txtTenDonViTinh.Text = ncc.TenDonViTinh;

                //    hdID.Value = ncc.ID.ToString();
                //    btnSave.Visible = false;
                //    btnUpdate.Visible = true;
                //}
                //else
                //{
                //    GetMess("Dữ liệu không tồn tại", "");
                //}
            }
    }
    protected void btnPre_Click(object sender, EventArgs e)
    {
        int pg = 0;
        if (hdPage.Value.Trim().Equals(""))
            pg = 1;
        else pg = int.Parse(hdPage.Value.Trim());

        if (pg > 1)
            pg = int.Parse(hdPage.Value.Trim()) - 1;
        else pg = 1;
        hdPage.Value = pg.ToString();
        lbPage.Text = "Trang " + hdPage.Value;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        int pg = 0;
        if (hdPage.Value.Trim().Equals(""))
            pg = 1;
        else pg = int.Parse(hdPage.Value.Trim()) + 1;
        hdPage.Value = pg.ToString();
        lbPage.Text = "Trang " + hdPage.Value;
    }
    protected void btnFirst_Click(object sender, EventArgs e)
    {
        hdPage.Value = "1";
        lbPage.Text = "Trang " + hdPage.Value;
    }
}