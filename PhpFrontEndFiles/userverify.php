

<html lang="en"><head>

    <title>Registration | WeLikeU</title>

    <meta name="viewport" content="width=450, initial-scale=0.3">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">


    <meta name="title" content="Registration | WeLikeU">

  <link rel="canonical" href="http://automaticviral.com/register/add">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/css.css" rel="stylesheet" type="text/css"> 

     <!-- <link href="http://automaticviral.com/favicon.ico?1" rel="shortcut icon" type="image/vnd.microsoft.icon">
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

            $("#loginMsg").hide();



            $("#add-instagram-account-form").submit(function(){
                alert("hello1234");
                $("#loginMsg").hide();


                var data = {
                    "action": "userverify"
                };
                data = $(this).serialize() + "&" + $.param(data);



                $.ajax({
                    type: "POST",
                    dataType: "json",
                    url: "signupDetails.php", //Relative or absolute path to response.php file
                    data: data,
                    success: function(data, status) {
                        if(data=="Success")
                        {
                            $("#loginMsg").show();
                            $("#loginMsg").html("You are already registered with us.");
                        }else
                        {

                            window.location.href="signup.php";
                           // alert("unsuccess");
                        }
                    },
                    error: function(xhr, desc, err) {

                       // $("#loginMsg").show();
                        //$("#loginMsg").html(err);
                    }
                });
                return false;
            });

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
        <div class="wrap">

            <a class="logo" href="#"></a>


            <div class="menu">
                <ul class="nav">


                    <li><a href="">home</a></li>
                    <li class="delim"></li>                        <li><a href="">pricing</a></li>
                  <!--  <li class="delim"></li>                        <li><a href="">faqs</a></li>
                    <li class="delim"></li>                        <li><a href="">support</a></li> -->

                    <li class="login-btn">
                        <a href="login.php">login</a>
                    </li>



                </ul>
            </div>
            <br class="clear">
        </div>
    </div>

    <div id="register-tabs">
        <div class="wrap">
            <div class="tabs-container">
                <div class="tab  completed active">
                    <div class="icon">
                    </div>
                    <div class="title">Add Instagram Account</div>
                </div>
                <div class="tab " "="">
                <div class="icon">
                    <div>2</div>
                </div>
                <div class="title">Register</div>
            </div>
            <div class="tab ">
                <div class="icon">
                    <div>3</div>
                </div>
                <div class="title">Billing Information</div>
            </div>
        </div>
    </div>
</div>
<div class="content wrap">

    <div class="add-alert"></div>
    <form id="add-instagram-account-form" class="box-form" action="userverify.php" method="POST">


        <div class="head">
            <h2 class="no-margin">Enter your Instagram username</h2>
        </div>

        <div class="inputs">
            <div id="loginMsg" class="alert alert-danger">

            </div>

            <div class="icon-input">
                <div class="icon ico-ig"><div class=""></div></div>

                <input placeholder="@username" name="IGScreenname" type="text">
            </div>

        </div>

        <div class="submit-section">
            <input value="add an account" class="round" type="submit">
        </div>

    </form>

    <div id="add-acc-overview">
        <h2>Overview</h2>
        <div class="s1">Instagram membership</div>
		<div class="s2">
            <div class="cash">
		<?php 
		session_start();
		$_SESSION['planid'];
		$_SESSION['amount'];
		$_SESSION['likescount'];
 $planid = $_GET['id'];
 
if($planid==1)
{
     $_SESSION['planid']=1;
	 $_SESSION['amount']=15;
	 $_SESSION['likescount']=100;
            echo "$15</div>100 Likes/Picture";
            
		}
		else if ($planid==2)
		{
		 $_SESSION['planid']=2;
		  $_SESSION['amount']=22;
		  $_SESSION['likescount']=250;
		echo "$22</div>250 Likes/Picture";
		}
		else if ($planid==3)
		{
		 $_SESSION['planid']=3;
		 $_SESSION['amount']=35;
		 $_SESSION['likescount']=500;
		echo "$35</div>500 Likes/Picture";
		}
		else{
		header("location:pricing.php");
		}
		
		?>
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
            <div class="cash">$<?php session_start(); echo $_SESSION['amount']; ?></div>
        </div>

    </div>
    <br class="clear">

</div>


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
                <li><a href="">home</a></li>
                <li><a href="">pricing</a></li>
                <li><a href="">faq</a></li>
                <li><a href="">terms</a></li>
                <li><a href="">support</a></li>
            </ul>
        </div>
        <br class="clear">
    </div>
</div>




</div></body></html>