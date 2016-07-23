<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppHome.aspx.cs" Inherits="TrainingRoomApp.Pages.AppHome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Resources/JS/jquery-1.4.1.min.js" type="text/javascript"></script>
 
    <script src="../Resources/JS/bootstrap.js" type="text/javascript"></script>
    <link href="../Resources/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var UserID = '<%= UserId %>';
        var UserName = '<%= UserName%>';

        $(document).ready(function () {
            $("#lblUser").text(" Welcome " + UserName + " , " + UserID);
            fnGetLocation();
            fnBookedDetails();
            //alert(UserId);
        });
        function fnGetLocation(msg) {
            $.ajax({
                url: "../Handlers/GetLocation.ashx",
                data: {},
                dataType: "json",
                cache: false,
                success: function (msg) {
                    $("#ddlLocation").html('');
                    $("#ddlLocation").append("<option id=0>Please Select...</option>");

                    $.each(msg, function (i, data) {
                        $("#ddlLocation").append("<option id='" + data.LocationID + "'>" + data.LocationName + "</option>");
                    });
                      
                },
                error: function (response) { alert("error"); }
            });
            
        }
        function fnGetCampus(msg) {
            $.ajax({
                url: "../Handlers/GetCampus.ashx",
                data: {LocationName:$("#ddlLocation").children(":selected").val()
                },
                dataType: "json",
                cache: false,
                success: function (msg) {
                    $("#ddlCampus").html('');
                    $("#ddlCampus").append("<option id=0>Please Select...</option>");

                    $.each(msg, function (i, data) {
                        $("#ddlCampus").append("<option id='" + data.CampusID + "'>" + data.CampusName + "</option>");
                    });
                    
                },
                error: function (response) { alert("error"); }
            });
        }
        function fnGetTrainingRoomDetails() {
            $.ajax({
                url: "../Handlers/GetTrainingRoomDetails.ashx",
                data: {
                    LocationName: $("#ddlLocation").children(":selected").val(),
                    CampusName: $("#ddlCampus").children(":selected").val()
                },
                dataType: "json",
                 cache: false,
                success:OnCompleteGetTRoomDetails,                  
                error: function (response) { alert("error"); }
            });
        }
        function OnCompleteGetTRoomDetails(msg) {
                  $("#tblTrainingRoomDetails").html("");
            var strTRoomList = "<tr><td><b>ROOM ID</b></td><td><b>ROOM NAME</b></td><td><b>FLOOR</b></td><td><b>BLOCK</b></td><td><b>REGISTER</b></td></tr>";
            $("#tblTrainingRoomDetails").append(strTRoomList);
            $.each(msg, function (i, data) {
                var strTList = "<tr>" +
                                    "<td>" +
                                        data.TrainingRoomID +
                                    "</td>" +
                                    "<td>" +
                                        data.TrainingRoomname +
                                    "</td>" +
                                    "<td>" +
                                        data.Floornumber +
                                    "</td>" +
                                    "<td>" +
                                        data.Block +
                                    "</td>" + "<td>" + "<input type='button' class='btnRegister'  value='Register' id ='" + data.TrainingRoomID + "'/>" + "</td>" +
                                      
                                 "</tr>";
                $("#tblTrainingRoomDetails").append(strTList);
            });
        }
        $('.btnRegister').live('click', function () {
            window.location = "RegisterRoom.aspx?UserId="+UserID+"&UserName="+UserName+"&TrainingID="+$(this).attr('id')+"";
        });        
        
        function fnBookedDetails(msg) {
            $.ajax({
                url: "../Handlers/GetBookedDetails.ashx",
                data: {
                    UserID: UserID
                },
                dataType: "json",
                cache: false,
                success: function (msg) {
                    if (msg == 0) {
                        alert("No Booking History Available");
                    }
                    else {
                        OnCompleteGetBookedDetails(msg);
                    }
                },
                error: function (response) { alert("error"); }
            });
         
        }
        function OnCompleteGetBookedDetails(msg) {
            $("#tblBookedList").html("");
            var strbookedRoomList = "<tr><th colspan='3'><h5>You booked the following Training Rooms:</h5></th></tr>";
            var headings = "<tr><td><b>ROOM ID</b></td><td><b>FROM DATE</b></td><td><b>TO DATE</b></td><td><b>CANCEL</b></td></tr>";
            $("#tblBookedList").append(strbookedRoomList);
            $("#tblBookedList").append(headings);
            $.each(msg, function (i, data) {
                var strBList = "<tr>" +
                                    "<td>" +
                                        data.TrainingRoomID +
                                    "</td>" +
                                    "<td>" +
                                        data.fromdate +
                                    "</td>" +
                                    "<td>" +
                                        data.todate +
                                    "</td>" +
                                     "<td>" + "<input type='button' style='background-clor:red;'  class='btnDelete' value='x' id ='" + data.SlotID + "'/>" + "</td>" +
                                 "</tr>";
                $("#tblBookedList").append(strBList);
            });
        }
        $('.btnDelete').live('click', function () {
            $.ajax({
                url: "../Handlers/DeleteBookingDetails.ashx",
                data: {
                    SlotID: $(this).attr('id')
                },
                cache: false,
                success: function (response) {
                    alert("Cancelled");
                    window.location = "AppHome.aspx";

                },
                error: function (response) { alert("error"); }
            });
        });

    </script>
   <%-- "<td>" + "<input type='button' class='btnDelete' value='Cancel Booking' id ='" + data.TrainingRoomID + "C'/>" + "</td>"--%>
</head>
<body>
    <form id="form1" runat="server">
        <!-- IMPORTANT - Please read the following comments carefully before you start designing your page.
              This is the parent DIV which has the required Height and Width attributes set. 
              DO NOT REMOVE the DIV element.
              DO NOT MODIFY the Height and Width attributes.         
              You can either change or remove the 'background-color' attribute, as well as rename the ID of the DIV  -->
        <div id="divMain" style="width:962px;height:727px;background-image: url('../Resources/Images/img1.jpg'); overflow:hidden;text-align: center;">
         <h1>Check Training Rooms Availability</h1>   
         <marquee behavior="alternate"><span id="lblUser"></span> </marquee>
         <div id="content" style="background-color:transparent;height:95%;width:40%;float:left; text-align: right;overflow:auto">
         
    <table id="tblUserContextList" ></table>
    <table class="table table-hover table-bordered" id="tblLocation"border="1">
           <tr><td>Select Location:</td>
           <td><select id="ddlLocation" onchange="javascript:fnGetCampus();" > </select></td></tr>
           <tr>
           <td>Select Campus:</td>
           <td><select id="ddlCampus" onchange="javascript:fnGetTrainingRoomDetails();"></select></td>
           </tr>     
           </table>
           <table id="tblTrainingRoomDetails" class="table table-hover"></table>          

           </div> 
           <div id="bookedList" style="height:100%;width:40%; margin-right: 1%;background-color:transparent;float:right;overflow:auto;"> 
          <table id="tblBookedList" style="font-size:small;">               
           </table>        
           </div>          
                             
        </div>
 
    </form>
    
</body>
</html>

