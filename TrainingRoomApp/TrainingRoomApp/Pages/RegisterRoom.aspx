<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterRoom.aspx.cs" Inherits="TrainingRoomApp.Pages.RegisterRoom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <script src="../Resources/JS/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="../Resources/JS/jquery-ui-1.10.4.custom.min.js" type="text/javascript"></script>
    <link href="../Resources/Styles/jquery-ui-1.10.4.custom.min.css" rel="stylesheet"type="text/css" />
    <link href="../Resources/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Resources/JS/bootstrap.js" type="text/javascript"></script>

    <script type="text/javascript">
        var UserID = '<%= UserId %>';
        var UserName = '<%= UserName%>';
        var TrainingID = '<%= TrainingID %>';


        $(document).ready(function () {
            //alert(" Welcome "+UserID+"   "+UserName);
            fnGetReviews();
            $("#lblUserID").text(" Welcome " + UserID + "   " + UserName);
            $("#txtFromDate").datepicker({
                minDate: new Date(),
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                onClose: function (selectedDate) {
                    $("#txtToDate").datepicker("option", "minDate", selectedDate);
                }
            });

            $("#txtToDate").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                changeYear: true
                //                onClose: function (selectedDate) {
                //                    $("#txtFromDate").datepicker("option", "maxDate", selectedDate);
                //                }
            });


        });
        function fnGetRoomAvailability(msg) {
            $.ajax({
                url: "../Handlers/GetRoomAvailability.ashx",
                data: {
                    TrainingRoomID: TrainingID,
                    FromDate: $("#txtFromDate").val(),
                    ToDate: $("#txtToDate").val()
                },
                dataType: "json",
                cache: false,
                success: function (msg) {
                    if (msg == 0) {
                        // alert("Available");                        
                        fnAddBookingDetails();
                    }
                    else {
                        fnGetRoomUnAvailability();
                    }
                },
                error: function (response) { alert("Please Select Dates"); }
            });
        }
        function fnAddBookingDetails() {
            $.ajax({
                url: "../Handlers/AddBookingDetails.ashx",                
                data: {
                    UserID: UserID,
                    TrainingRoomID: TrainingID,
                    FromDate: $("#txtFromDate").val(),
                    ToDate: $("#txtToDate").val()
                },                
                cache: false,
                success: function () {
                    alert("Booking Successful!");
                },
                error: function (response) { alert("Booking Failed"); }
            });
        }
        function fnGetRoomUnAvailability() {
            $.ajax({
                url: "../Handlers/GetRoomAvailability.ashx",                
                data: {
                    TrainingRoomID: TrainingID,
                    FromDate: $("#txtFromDate").val(),
                    ToDate: $("#txtToDate").val()
                },
                dataType: "json",                
                cache: false,
                success: OnComplete,
                error: function (response) { alert("error"); }
            });
        }
        function OnComplete(msg) {
            $("#tblBookedList").html("");
            var strTableHeading = "<tr><th colspan='3'><b>This Training Room is already booked for the below dates By <b></th></tr>";
            $("#tblBookedList").append(strTableHeading);
            strTableHeading = "<tr><td>UserID</td><td>From</td><td>To</td></tr><tr>";
            $("#tblBookedList").append(strTableHeading);
            $.each(msg, function (i, data) {

                var strBookedList = "<td>" +
                                      data +
                                    "</td>";
                $("#tblBookedList").append(strBookedList);

            });
            strTableHeading = "</tr>";
            $("#tblBookedList").append(strTableHeading);
        }
        function fnAddReviews() {
            $.ajax({
                url:"../Handlers/AddReviews.ashx",
                data: {
                    UserID: UserID,
                    Reviews:$("#txtReviews").val()                 
                },
                cache: false,
                success: function () {
                    alert("Posting Successful!");
                },
                error: function (response) { alert("Posting Failed"); }
            });
        }
        function fnGetReviews() {
            $.ajax({
                url:"../Handlers/GetReviews.ashx",
                data: {
                },
                dataType: "json",
                cache: false,
                success:OnCompleteGetReviews ,
                error: function (response) { alert("error"); }
            });
        }
        function OnCompleteGetReviews(msg) {
            $("#tblReviewList").html("");
            var strTableHeading = "<tr><th colspan='2'><b>Previous Reviews: <b></th></tr>";
            $("#tblReviewList").append(strTableHeading);            
            $.each(msg, function (i, data) {

                var strBookedList = "<tr>"+"<td>" +
                                      data.UserID +
                                    "</td>" + "<td>" +
                                      data.Reviews +
                                    "</td>" + "<tr>";
                $("#tblReviewList").append(strBookedList);
            });          
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <!-- IMPORTANT - Please read the following comments carefully before you start designing your page.
          This is the parent DIV which has the required Height and Width attributes set. 
          DO NOT REMOVE the DIV element.
          DO NOT MODIFY the Height and Width attributes.         
          You can either change or remove the 'background-color' attribute, as well as rename the ID of the DIV  -->
    <div id="divMain" style="width:962px;height:727px;background-image: url('../Resources/Images/img2.jpg');overflow:hidden;">
    <div id="content" style="height:100%;width:50%;float:left; text-align: left; color:White;">
       
      <div style=" margin-top:3%;margin-right:2%;"><a href="AppHome.aspx" style="color:White;font-size:medium;">Home</a></div>
      <marquee behavior="alternate"><span id="lblUserID"></span></marquee> 
    <table id="tblRegister" style="margin-top:5%; margin-left:5%;"> 
    <tr><th colspan="2" align="center"><b>Please Select The Dates For Booking Your Training Room</b></th></tr> 
    <tr></tr>     
    <tr>
    <td>From Date:</td>
    <td><input type="text" id="txtFromDate" /></td>  
    </tr>
    <tr>
    <td>To Date:</td>
    <td><input type="text" id="txtToDate" /></td>
    </tr>
    <tr>
    <td align="right" colspan="2"><input class="btn btn-large btn-info " type="button" id="btnBook" value="Book" onclick="javascript:fnGetRoomAvailability();"/></td>
    </tr>
    </table>
    <table class="table" id="tblBookedList" style="width:50%; border-color:White; margin-left:25%;" border="1";></table>
    </div>
    <div id="reviewList" style="height:100%;width:30%; margin-right: 1%; margin-top:5%; background-color:transparent;text-align: right;float:right;overflow:auto;color:White;"> 
          <table  id="tblReviews" style="font-size:small;">    
            <tr><th>Give your comment about our app:</th></tr>  
            <tr><td><textarea rows="5"; cols="2"; id="txtReviews"></textarea></td></tr> 
            <tr><td><input type="button" class="btn btn-large btn-info" value="POST" id="btnPost" onclick="javascript:fnAddReviews();"/></td></tr>    
           </table>      
           <table id="tblReviewList" class="table  table-bordered" style="overflow:scroll"></table>  
           </div>    
    </div>
    </form>
</body>
</html>
