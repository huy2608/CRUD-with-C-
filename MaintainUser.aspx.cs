using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDWebForm
{
    public partial class MaintainUser : System.Web.UI.Page
    {

        UserInfoData data = new UserInfoData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            gvUserInfoList.DataSource = data.getUserList();
            gvUserInfoList.DataBind();
        }

        protected void gvUserInfoList_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow selectedRow = gvUserInfoList.Rows[e.NewSelectedIndex];
            txtUsername.Text = selectedRow.Cells[1].Text;
            txtPassword.Text = selectedRow.Cells[2].Text;
            txtFullname.Text = selectedRow.Cells[3].Text;
            txtPhone.Text = selectedRow.Cells[4].Text;
            txtRole.Text = selectedRow.Cells[5].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dynamic u = new UserInfo()
            {
                username = txtUsername.Text,
                password = txtPassword.Text,
                fullname = txtFullname.Text,
                phone = txtPhone.Text,
                role = txtRole.Text,
            };
            data.InsertUserInfo(u);
            LoadData();
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            dynamic u = new UserInfo()
            {
                username = txtUsername.Text,
                password = txtPassword.Text,
                fullname = txtFullname.Text,
                phone = txtPhone.Text,
                role = txtRole.Text,
            };
            data.UpdateUserInfo(u);
            LoadData();
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            dynamic u = new UserInfo()
            {
                username = txtUsername.Text,
            };
            data.DeleteUserInfo(u);
            LoadData();
        }
    }
}