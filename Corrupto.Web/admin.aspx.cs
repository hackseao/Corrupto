using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Corrupto.Logic;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnExecute_Click(object sender, EventArgs e)
    {
        CorruptoInstance instance = new CorruptoInstance();
        instance.Execute(new CorruptoExecutionState());
        lblLastExecutionTime.Text = String.Format("Last execution time: ", DateTime.Now.ToLongTimeString());
    }
}