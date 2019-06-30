using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleNavGrid
{
    public partial class Default : System.Web.UI.Page
    {
        static string sTable;
        string conStrg = "Data Source=.\\sqlexpress;Initial Catalog=Test;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.ConnectionString = conStrg;
            if (IsPostBack && sTable != "" && sTable != null)
            {
                // autogenerate 
                SqlDataSource1.SelectCommand = "select * from " + sTable;
                SqlDataSource1.DeleteCommand = "delete " + sTable + " where id=@id";
                SqlDataSource1.UpdateCommand = "update " + sTable + " set para1=@para1 where id=@id";
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            sTable = TreeView1.SelectedValue;
            loaddata();
        }

        void loaddata()
        {
            SqlDataSource1.SelectCommand = "select * from " + sTable;
            SqlDataSource1.DataBind();
            GridView1.DataBind();
        }
    }
}