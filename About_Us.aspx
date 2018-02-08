<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="About_Us.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
               <!-- About Us -->
        <header style="text-align:center"><h1>About Us</h1></header>

<br />
    <!-- Table for pics & contact info -->
      <div>
        <table style="text-align:center" align="center">
            <tbody><tr>
                <td>
                    <img style="height:100%; width:75%" alt="Justin Gochenaur" class="auto-style1" src="images/justin.png"/>
                </td>
                <td>

                    <img style="height:100%; width:75%" alt="Cameron Weiler" class="auto-style2" src="images/cameron.png"/>

                </td>
                <td>

                    <img style="height:100%; width:75%" alt="Trey Recher" class="auto-style3" src="images/trey.png"/>

                </td>
            </tr>
            <tr>
                <td>
                    <!-- Add font awesome icons -->
                    <!--Justin Profil-->
                        <a href="https://www.facebook.com/justin.gochenaur" class="fa fa-facebook"></a>
                        <a href="#" class="fa fa-twitter"></a>
                        <a href="https://www.linkedin.com/in/justingochenaur/" class="fa fa-linkedin"></a>
                        <a href="#" class="fa fa-google"></a>
                </td>
                <td>
                    <!-- Cam Profile-->
                        <a href="https://www.facebook.com/cam.weiler.3" class="fa fa-facebook"></a>
                        <a href="#" class="fa fa-twitter"></a>
                        <a href="https://www.linkedin.com/in/cameron-weiler-86723888/" class="fa fa-linkedin"></a>
                        <a href="#" class="fa fa-google"></a>
                </td>
                <td>
                    <!--The boy Trey's shiaaat -->
                        <a href="#" class="fa fa-facebook"></a>
                        <a href="#" class="fa fa-twitter"></a>
                        <a href="https://www.linkedin.com/in/trey-recher-27372813a/" class="fa fa-linkedin"></a>
                        <a href="#" class="fa fa-google"></a> 
           <!-- hey justin -->
                </td>
               
            </tr>
                <tr><td></td></tr>
                <tr><td></td></tr>

        </tbody></table>
        </div>
          <div style="text-align:center; padding-left:300px; padding-right:300px">
              <h3>Louis' Pharmacy has been around for nearly thirty years providing service to all the locals in the Lancaster, Pennsylvania area. We pride ourselves on 
                        quality and being efficient. We all have been in need, and those needs all need satisfied to some degree. Many of folks in the area come to us and we continue
                        to satisfy them over and over. We never leave anyone out high and dry. We compete to be the best, and we will no settle for less. Come on in if you need your meds
                        filled or anything else you think you may need. We are here Sunday through Friday 9:00 AM to 5:00 PM.</h3>
          </div>
  
          <div id="map" style="width:100%;height:525px"></div>

<script>
    function myMap() {
        var myCenter = new google.maps.LatLng(40.0379, -76.3055);
        var mapCanvas = document.getElementById("map");
        var mapOptions = { center: myCenter, zoom: 12 };
        var map = new google.maps.Map(mapCanvas, mapOptions);
        var marker = new google.maps.Marker({ position: myCenter });
        marker.setMap(map);
        var marker = new google.maps.Marker({
            position: myCenter,
            animation: google.maps.Animation.BOUNCE
        });

        marker.setMap(map);
        var infowindow = new google.maps.InfoWindow({
            content: "IF YOU YOU NEED IT, YOU KNOW WHERE WE ARE!"
        });

        infowindow.open(map, marker);
    }
</script>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAP4pLAk77a5zv26XIQyAyhYtYZPnqgtaE&callback=myMap"></script>

</asp:Content>

