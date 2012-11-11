using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Corrupto.Logic;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblOutput.Text = "Status: " + Scheduler.ToggledOn.ToString();
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        Scheduler.Start();
    }
    protected void btnStop_Click(object sender, EventArgs e)
    {
        Scheduler.Stop();
    }
}