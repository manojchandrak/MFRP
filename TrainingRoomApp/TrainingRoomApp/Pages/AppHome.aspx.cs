using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTS.OneCognizant.Platform.CoreServices;
using CTS.OneC.Platform.CoreServices.FormRedirectionUrl;

namespace TrainingRoomApp.Pages
{
    public partial class AppHome : PageBase
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                /*----------------------------------------------------------------------------
                 * DO NOT USE HttpContext to get the User information.
                 * ALWAYS USE UserContext to get the User information.
                 * SAMPLE CODE is provided below for your reference on using the UserContext
                 * ---------------------------------------------------------------------------
                 */
                //UserContext usr = UserContext.GetUserContext();
                //Register RegisterObj = new Register();
                UserId = 397898; //usr.CurrentUser.UserId;
                UserName = "Vamshhi"; //usr.CurrentUser.FirstName;
                bool isAssociate = true; //usr.CurrentUser.IsNonAssociate;
                

                /* ---------------------------------------------------------------------------
                 * URL Redirection usage details
                 * ---------------------------------------------------------------------------
                 */
                /*-------Sample values ---------*/
                //int GlobalAppid = 1;
                //string Appurl = "";
                //string Urltype = "";

                //RedirectionUrl obj = new RedirectionUrl();
                //List<Output> objLst = new List<Output>();
                //objLst = obj.FormRedirectionUrl(GlobalAppid, Appurl, Urltype, DateTime.Now);

            }

            catch (UserContextException uex)
            {
                // Handle User Context exception here
                // Handle User URL Redirection exception here
            }
            catch (Exception ex)
            {
                // Handle other exceptions here
            }
        }
    }
}