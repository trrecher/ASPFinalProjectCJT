﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Pharmacy.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 400px;
            width: 651px;
            margin-left: 0px;
            margin-top: 128px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        
            <div class="icon-block-inner" style="height: 417px;">
                            <div class="icon-block">
                        <div class="icon-block-headers"> <div class="desc"> <div style="text-align:center">
                            <p class="icon_p_height">Are you a Physician?</p>
                    <br />  <br />  <br />  <br />
                        <p>New Phyisican? No worries, if you are new with us we'll get you setup in no time.</p>
                    </div></div></div><br />
                    <a href="Add_Physician.aspx" target="" class="icon-block-cta">Add Physician Now</a><br />
                </div>
                            <div class="icon-block">
                        <div class="icon-block-headers"><div class="desc"><div style="text-align:center">
                            <p class="icon_p_height">
                            Prescriptions                            </p>
                    <br />  <br />  <br />  <br />
                        <p>We make adding, updating and deleting prescriptions at Louis’s easy. Simply click here and follow the next steps.</p>
                    </div></div></div><br />

                    <a href="Add_Prescription.aspx" target="" class="icon-block-cta">Prescriptions </a><br />
                </div>   
                            <div class="icon-block">
                        <div class="icon-block-headers"><div class="desc"> <div style="text-align:center">
                            <p class="icon_p_height">
                                For Physicans                            </p>
                     <br/>  <br />  <br />  <br />
                        <p>Physicians can add new patients to our Pharmacy Database here:</p>
                    </div></div></div><br />
                    <a href="Add_Patient.aspx" target="" class="icon-block-cta">Add Patient</a><br />
                </div>
 </div><br /><br /><br />
   <div>
         <table style="text-align:center" align="center">
       <tr> 
               <td><p>
        <img alt="Big Pharma" src="pics/151.jpg" class="auto-style1" draggable="true"/>
                    </p>
               </td>  
  
       </tr>
                
</table></div>
                     <!--slideshow-->
<div class="slider" id="main-slider" ><!-- outermost container element -->
	<div class="slider-wrapper" ><!-- innermost wrapper element -->

		<img src="http://s3.amazonaws.com/production_images.servicenoodle.com/images/9227/full/Kilgores_pic_3.jpg?1299683138" alt="First" class="slide" style="height:150px;" /><!-- slides -->
		<img src="https://vwhs.org/wp-content/uploads/2017/10/ASHC_Full-1024x292.jpg" alt="Second" class="slide"style="height:150px" />
		<img src="https://vwhs.org/wp-content/uploads/2016/02/Pharmacist.jpg" alt="Third" class="slide" style="height:150px" />
	</div>
</div>



</asp:Content>


