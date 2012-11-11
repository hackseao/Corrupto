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
        UpdateStatus();
    }

    protected void btnStart_Click(object sender, EventArgs e)
    {
        Scheduler.Start();
        UpdateStatus();
    }
    protected void btnStop_Click(object sender, EventArgs e)
    {
        Scheduler.Stop();
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        lblOutput.Text = "Status: " + Scheduler.ToggledOn.ToString();
    }
}