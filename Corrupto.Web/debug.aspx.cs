using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Corrupto.Twitter;

public partial class debug : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TwitterProvider p = new TwitterProvider();
        var messages = p.GetDirectMessages();
        decimal lastId = messages.Last().Id;
        var messages2 = p.GetDirectMessages(lastId);
    }
}