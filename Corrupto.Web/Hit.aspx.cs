using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Corrupto.Logic;

public partial class Hit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            System.Diagnostics.Debug.WriteLine(String.Format("[{0}] Hit!", DateTime.Now.TimeOfDay.ToString()));

            if(Scheduler.ToggledOn && !CorruptoInstance.InstanceActive)
            {
                System.Diagnostics.Debug.WriteLine(String.Format("[{0}] Executing...", DateTime.Now.TimeOfDay.ToString()));
                var instance = new CorruptoInstance();
                instance.Execute();
            }
        //}
        //catch
        //{
        //    // HACK
        //}
        //finally
        //{
            Scheduler.Schedule();
        //}
    }
}