<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SocialPanel.User.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login page</title>
   

    <link href="css/stile.css" rel="stylesheet" type="text/css" />
<%--<!-- ICONE FONT --><link rel="stylesheet" href="icon-css/css/font-awesome.min.css"><!-- / ICONE FONT -->--%>

    <script src="js/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="js/apertura.js" type="text/javascript"></script>


</head>
<body>
    <form id="form1" runat="server">
<div style="
  height:100px;
  left:50%;
  margin-left:-300px;
  margin-top:0px;
  position:absolute;
  top:0;
  width:595px;
  background-image:url(img/header-int.jpg);
  background-repeat:no-repeat;
  margin-top:20px;
"></div>


<div id="intro-def">


    <h1 style="margin:0px; padding:0px;"><asp:Label ID="lblLoginWithSocial" 
            runat="server" Text="Login With Social"></asp:Label> </h1>
     <a href="InstagramCallback.aspx" title="Instagram Login"><img src="img/IGsign-in.png" alt="Instagram" width="300" height="120" border="0" /></a>    
    
    <div style="display:block; float:left; margin:20px 0 0 4px;">
        
  
    
  
    </div>

</div>

<div id="banner-home"></div>

<!-- FOOTER -->
<footer>
<ul>
<%--<li><a href="copyright.htm"><i class="icon-hand-right"></i> versione italiana <i class="icon-flag"></i></a></li>
<li><a href="about.htm">About</a></li>
<li><a href="contact.htm">Contact</a></li>
<li><a href="privacy.htm">Privacy</a></li>
<li class="worldhashtag-footer">Worldhashtag.com social page:</li>
<li><a href="http://www.twitter.com" target="_blank" title="Twitter Fan Page!"><i class="icon-twitter"></i> twitter</a></li>
<li><a href="http://www.facebook.com" target="_blank" title="Facebook Fan Page!"><i class="icon-facebook"></i> facebook</a></li>
--%>
</ul>
</footer>

    </form>
</body>
</html>
