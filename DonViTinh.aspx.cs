using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DonViTinh : System.Web.UI.Page
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
        gvDonViTinh.DataSource = from x in db.tbl_DonViTinhs
                                 orderby x.TenDonViTinh ascending
                                 select new { x.ID, x.TenDonViTinh };
        gvDonViTinh.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        tbl_DonViTinh ncc = new tbl_DonViTinh();
        ncc.TenDonViTinh = txtTenDonViTinh.Text.Trim();

        db.tbl_DonViTinhs.InsertOnSubmit(ncc);
        db.SubmitChanges();
        btnCancel_Click(sender, e);
        GetMess("Lưu thành công", "");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        var ncc = (from x in db.tbl_DonViTinhs
                   where x.ID.Equals(hdID.Value.Trim())
                   select x).FirstOrDefault();
        if (ncc != null)
        {
            ncc.TenDonViTinh = txtTenDonViTinh.Text.Trim();

            db.SubmitChanges();
            btnCancel_Click(sender, e);
            GetMess("Lưu thành công", "");
        }
        else
            GetMess("Dữ liệu không tồn tại", "");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        loadGridView();
        Reset();
        hdPage.Value = "1";
        lbPage.Text = "Trang 1";
        btnSave.Visible = true;
        btnUpdate.Visible = false;
    }
    void Reset()
    {
        hdID.Value = "";
        txtTenDonViTinh.Text = "";

        txtGhiChu.Text = "";
    }
    protected void btnXem_Click(object sender, EventArgs e)
    {
        if (txtKeyword.Text.Trim().Equals(""))
            loadGridView();
        else
        {
            gvDonViTinh.DataSource = from x in db.tbl_DonViTinhs
                                     where x.TenDonViTinh.Contains(txtKeyword.Text.Trim())
                                     orderby x.TenDonViTinh ascending
                                     select new { x.ID, x.TenDonViTinh };
            gvDonViTinh.DataBind();
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

    protected void gvDonViTinh_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Del"))
        {
            var ncc = (from x in db.tbl_DonViTinhs
                       where x.ID.Equals(e.CommandArgument.ToString())
                       select x).FirstOrDefault();
            if (ncc != null)
            {
                db.tbl_DonViTinhs.DeleteOnSubmit(ncc);
                db.SubmitChanges();
                btnCancel_Click(sender, e);
                GetMess("Xóa thành công", "");
            }
            else
                GetMess("Dữ liệu không tồn tại", "");
        }
        else
            if (e.CommandName.Equals("Select"))
            {
                Reset();
                var ncc = (from x in db.tbl_DonViTinhs
                           where x.ID.Equals(e.CommandArgument.ToString())
                           select x).FirstOrDefault();
                if (ncc != null)
                {

                    txtTenDonViTinh.Text = ncc.TenDonViTinh;

                    hdID.Value = ncc.ID.ToString();
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                }
                else
                {
                    GetMess("Dữ liệu không tồn tại", "");
                }
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