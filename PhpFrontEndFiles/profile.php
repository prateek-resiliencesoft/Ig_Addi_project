<? session_start();


if(empty($_SESSION['login_user'])) 
{ header("Location:login.php");}

 ?>
<html lang="en"><head>

    <title>Profile | WeLikeU</title>

    <meta name="viewport" content="width=450, initial-scale=0.3">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">


    <meta name="title" content="Profile | WeLikeU">

   <link rel="canonical" href="#">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/css.css" rel="stylesheet" type="text/css">

  <!--    <link href="http://automaticviral.com/favicon.ico?1" rel="shortcut icon" type="image/vnd.microsoft.icon">
    <link href="http://automaticviral.com/static/icons/fav16x16.png?1" rel="icon" sizes="16x16">
    <link href="http://automaticviral.com/static/icons/fav32x32.png?1" rel="icon" sizes="32x32">-->

    <script src="js/ticket.js" async="" type="text/javascript"></script><script src="js/analytics.js" async=""></script><script src="js/mixpanel-2.js" async="" type="text/javascript"></script><script type="text/javascript" src="js/jquery-2.js"></script>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/jscommon.js"></script>

    <!-- start Mixpanel -->
    <script type="text/javascript">
        (function(f,b){if(!b.__SV){var a,e,i,g;window.mixpanel=b;b._i=[];b.init=function(a,e,d){function f(b,h){var a=h.split(".");2==a.length&&(b=b[a[0]],h=a[1]);b[h]=function(){b.push([h].concat(Array.prototype.slice.call(arguments,0)))}}var c=b;"undefined"!==typeof d?c=b[d]=[]:d="mixpanel";c.people=c.people||[];c.toString=function(b){var a="mixpanel";"mixpanel"!==d&&(a+="."+d);b||(a+=" (stub)");return a};c.people.toString=function(){return c.toString(1)+".people (stub)"};i="disable track track_pageview track_links track_forms register register_once alias unregister identify name_tag set_config people.set people.set_once people.increment people.append people.track_charge people.clear_charges people.delete_user".split(" ");
            for(g=0;g<i.length;g++)f(c,i[g]);b._i.push([a,e,d])};b.__SV=1.2;a=f.createElement("script");a.type="text/javascript";a.async=!0;a.src="//cdn.mxpnl.com/libs/mixpanel-2.2.min.js";e=f.getElementsByTagName("script")[0];e.parentNode.insertBefore(a,e)}})(document,window.mixpanel||[]);
        mixpanel.init("88eed657d0d071846e4cadf93f7ce30c");

        $("document").ready(function(){
            function GetParameterValues(param) {
                var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                for (var i = 0; i < url.length; i++) {
                    var urlparam = url[i].split('=');
                    if (urlparam[0] == param) {
                        return urlparam[1];
                    }
                }
            }




                var Id = GetParameterValues('id');
                $("#id").val(Id);
                // alert(Id);
                var data = {
                    "action": "profile"};
                if(Id != null)
                {
                    var query_data = {
                        "id": Id
                    };

                    data = $(this).serialize() + "&" + $.param(data)+ "&" + $.param(query_data);

                }else {
                    data = $(this).serialize() + "&" + $.param(data);
                }
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "signupDetails.php", //Relative or absolute path to response.php file
                    data: data,
                    success: function(data) {
                        data = eval(data);

                        $('#IGScreenname').val(data[0].IGScreenname);

                    },
                    error: function(xhr, desc, err) {

                        // $("#loginMsg").show();
                        //$("#loginMsg").html(err);
                    }
                });
                return false;


        });




    </script>
    <!-- end Mixpanel -->

    <!--
    <style type="text/css">
        .av-alert-bar {
            text-align:center;
            height:32px;
            line-height:32px;
            background:#c64f38;
            color:#fff;
            font-size:15px;
            font-weight:400;
            border-bottom:1px solid #555;
        }

    </style>
    -->

    <link href="css/groove.css" type="text/css" rel="stylesheet"></head>

<body>

<div id="main">


    <div id="overlay"></div>
    <div id="modal-container"></div>

    <div id="topbar">
	
	
	
	
    <br class="clear">
	
	
        <div class="wrap">

            <a class="logo" href="#"></a>


            <div class="menu">
                <ul class="nav">


                    <li><a href="">home</a></li>
                 <!--    <li class="delim"></li>                        <li><a href="">pricing</a></li>
                    <li class="delim"></li>                        <li><a href="">faqs</a></li>-->
<!--                    <li class="delim"></li>                        <li><a href="">support</a></li>-->
                    <li class="delim"></li>                        <li><a href="settings.php?id=1">Settings</a></li>
                    <b style="color:#000;"><?php if(!empty($_SESSION['login_user'])) {echo $_SESSION['login_user'];} ?></b>
                    <li class="login-btn">

                        <a href="logout.php">logout</a>
                    </li>



                </ul>
            </div>
            <br class="clear">
        </div>
    </div>


    <form id="show" class="box-form" action="profile.php" method="POST">

 <div class="right-col">
        <h2 class="blue">Account Information</h2>
		<img />
		Instagram user :-<?php echo $_SESSION['admin_login_user']; ?>
		Followers:- 
		Likes:-
		Post:-
		
		</br></br></br></br></br></br>
		
	<h2 class="blue">Plan Details</h2>
	My Plan 
	<?php echo $_SESSION['planid']; ?>
	<select name="Plans">
  <option value="1" <?php if($_SESSION['planid']==1){echo 'selected';} ?> >100
Likes/Picture $15/MO

</option> 
  <option value="2" <?php if($_SESSION['planid']==2){echo 'selected';} ?> >250
Likes/Picture $22/MO</option>
  <option value="3" <?php if($_SESSION['planid']==3){echo 'selected';} ?> > 500
Likes/Picture $35/MO

</option>
</select>
	

 <div class="submit-section">
            <input value="Update Plan" class="round" type="submit">
        </div>


         <!--   <div class="icon-input">
                <div class="icon ico-ig"><div class=""></div></div>

                <input id="IGScreenname" name="IGScreenname" type="text" readonly="readonly">
            </div> -->



    </form>

   <!-- <div id="add-acc-overview">
        <h2>Overview</h2>
        <div class="s1">Instagram membership</div>
        <div class="s2">
            <div class="cash">1</div>
            100 Likes/Picture
            &nbsp;
            <div class="gh"></div>
        </div>

        <div class="ttxt">
            <div class="thick"></div>
            <div class="t">Automatic Likes</div>
        </div>

        <div class="ttxt">
            <div class="thick"></div>
            <div class="t">Instant Delivery</div>
        </div>

        <div class="ttxt">
            <div class="thick"></div>
            <div class="t">Money Back Guaranteed</div>
        </div>

        <div class="s3">
            Total
            <div class="cash">1</div>
        </div>

    </div>
    <br class="clear">

</div>
-->

<script>
    mixpanel.track("Plan chosen", {
        "id" : 1,
        "count" : 100    });
</script>
<div id="footer">
    <div class="wrap">
        <div class="left">
            Copyright © 2015 WeLikeU. All Rights Reserved.
        </div>
        <div class="right">
            <ul>
               <li><a href="http://welikeu.com">home</a></li>
                    <li><a href="http://welikeu.com">pricing</a></li>
                 <!--    <li><a href="http://welikeu.com">faq</a></li>
                    <li><a href="http://welikeu.com">terms</a></li>
                    <li><a href="http://welikeu.com">support</a></li> -->
            </ul>
        </div>
        <br class="clear">
    </div>
</div>

<script>
    (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
        (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
        m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
    })(window,document,'script','//www.google-analytics.com/analytics.js','ga');
    ga('create', 'UA-54469444-1', 'auto');
    ga('send', 'pageview');
</script>

<script>
    //<![CDATA[
    (function() {var s=document.createElement('script');
        s.type='text/javascript';s.async=true;
        s.src=('https:'==document.location.protocol?'https':'http') +
        '://automaticviral.groovehq.com/widgets/b35735f2-1583-4c0c-9ad7-66b6821a7def/ticket.js'; var q = document.getElementsByTagName('script')[0];q.parentNode.insertBefore(s, q);})();
    //]]>
</script>


</div><div class="closed right undefined " id="groove-feedback" style="display: block;"><div id="groove-button">  <a class="" id="gw-back-button" href="#" onclick="GrooveWidget.backClicked(); return false;">Back</a>  <a id="gw-header" href="#" onclick="GrooveWidget.toggle(); return false;"><span id="gw-header-content">Click here for help</span></a></div><div class="iframe">  <iframe id="groove-iframe" name="groove-iframe" allowtransparency="true" scrolling="no" style="min-height: 70px;" src="css/init.htm" frameborder="0" height="402">  </iframe></div><div id="gw-footer">  <a href="http://www.groovehq.com/" target="_blank">Powered by Groove</a></div></div></body></html>