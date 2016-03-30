using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NhaCungCap : System.Web.UI.Page
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
        gvNCC.DataSource = from x in db.tbl_NCCs
                           orderby x.TenNCC ascending
                           select new { x.ID, x.TenNCC,x.CongTy, x.DiaChi, x.SDT, x.MST };
        gvNCC.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        tbl_NCC ncc = new tbl_NCC();
        ncc.CongTy = txtTenCongTy.Text.Trim();
        ncc.Email = txtEmail.Text.Trim();
        ncc.DiaChi = txtDiaChi.Text.Trim();
        ncc.GhiChu = txtGhiChu.Text.Trim();
        ncc.MST = txtMaSoThue.Text.Trim();
        ncc.SDT = txtDienThoai.Text.Trim();
        ncc.TenNCC = txtTenNhaCungCap.Text.Trim();
        db.tbl_NCCs.InsertOnSubmit(ncc);
        db.SubmitChanges();
        btnCancel_Click(sender, e);
        GetMess("Lưu thành công","");
    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        var ncc = (from x in db.tbl_NCCs
                   where x.ID.Equals(hdID.Value.Trim())
                   select x).FirstOrDefault();
        if (ncc != null)
        {
            ncc.CongTy = txtTenCongTy.Text.Trim();
            ncc.Email = txtEmail.Text.Trim();
            ncc.DiaChi = txtDiaChi.Text.Trim();
            ncc.GhiChu = txtGhiChu.Text.Trim();
            ncc.MST = txtMaSoThue.Text.Trim();
            ncc.SDT = txtDienThoai.Text.Trim();
            ncc.TenNCC = txtTenNhaCungCap.Text.Trim();
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
        btnSave.Visible = true;
        btnUpdate.Visible = false;
    }
    void Reset()
    {
        hdID.Value = "";
        txtTenCongTy.Text = "";
        txtEmail.Text = "";
        txtDiaChi.Text = "";
        txtGhiChu.Text = "";
        txtMaSoThue.Text = "";
        txtDienThoai.Text = "";
        txtTenNhaCungCap.Text = "";
    }
    protected void btnXem_Click(object sender, EventArgs e)
    {
        if (txtKeyword.Text.Trim().Equals(""))
            loadGridView();
        else
        {
            gvNCC.DataSource = from x in db.tbl_NCCs where x.TenNCC.Contains(txtKeyword.Text.Trim())
                               orderby x.TenNCC ascending
                               select new { x.ID, x.TenNCC, x.CongTy, x.DiaChi, x.SDT, x.MST };
            gvNCC.DataBind();
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
    protected void EditRow_Click(object sender, EventArgs e)
    {
        
    }
    protected void RemoveRow_Click(object sender, EventArgs e)
    {
        
    }
    protected void gvNCC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Del"))
        {
            var ncc = (from x in db.tbl_NCCs
                       where x.ID.Equals(e.CommandArgument.ToString())
                       select x).FirstOrDefault();
            if (ncc != null)
            {
                db.tbl_NCCs.DeleteOnSubmit(ncc);
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
                var ncc = (from x in db.tbl_NCCs
                           where x.ID.Equals(e.CommandArgument.ToString())
                           select x).FirstOrDefault();
                if (ncc != null)
                {
                    
                    txtTenCongTy.Text = ncc.CongTy;
                    txtDiaChi.Text = ncc.DiaChi;
                    txtDienThoai.Text = ncc.SDT;
                    txtEmail.Text = ncc.Email;
                    txtGhiChu.Text = ncc.GhiChu;
                    txtMaSoThue.Text = ncc.MST;
                    txtTenNhaCungCap.Text = ncc.TenNCC;
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
}