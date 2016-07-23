using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrainingRoomApp.Pages
{
    public partial class RegisterRoom : System.Web.UI.Page
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string TrainingID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = int.Parse(Request.QueryString["UserId"]);
            UserName = Request.QueryString["UserName"];
            TrainingID = Request.QueryString["TrainingID"];
        }
    }
}