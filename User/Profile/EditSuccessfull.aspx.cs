using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Profile_EditSuccessfull : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String check = Convert.ToString(Request.QueryString["Check"]);
        if (check == "true")
        {
            trueSuccess.Visible = true;
            falseMessage.Visible = false;
        }
        else
        {
            trueSuccess.Visible = false;
            falseMessage.Visible = true;
        }
    }
}