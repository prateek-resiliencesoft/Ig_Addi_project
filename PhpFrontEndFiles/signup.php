<? session_start();

$_SESSION['admin_login_user'];
?>

<html lang="en"><head>

    <title>Registration | Automatic Viral</title>

    <meta name="viewport" content="width=450, initial-scale=0.3">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">


    <meta name="title" content="Registration | Automatic Viral">

    <link rel="canonical" href="">
    <link href="css/style.css" rel="stylesheet" type="text/css">
    <link href="css/css.css" rel="stylesheet" type="text/css">

    <link href="favicon.ico?1" rel="shortcut icon" type="image/vnd.microsoft.icon">
    <link href="static/icons/fav16x16.png?1" rel="icon" sizes="16x16">
    <link href="static/icons/fav32x32.png?1" rel="icon" sizes="32x32">

    <script src="js/ticket.js" async="" type="text/javascript"></script><script src="js/analytics.js" async=""></script><script src="js/mixpanel-2.js" async="" type="text/javascript"></script><script type="text/javascript" src="js/jquery-2.js"></script>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/jscommon.js"></script>

    <!-- start Mixpanel -->
    <script type="text/javascript">
        (function(f,b){if(!b.__SV){var a,e,i,g;window.mixpanel=b;b._i=[];b.init=function(a,e,d){function f(b,h){var a=h.split(".");2==a.length&&(b=b[a[0]],h=a[1]);b[h]=function(){b.push([h].concat(Array.prototype.slice.call(arguments,0)))}}var c=b;"undefined"!==typeof d?c=b[d]=[]:d="mixpanel";c.people=c.people||[];c.toString=function(b){var a="mixpanel";"mixpanel"!==d&&(a+="."+d);b||(a+=" (stub)");return a};c.people.toString=function(){return c.toString(1)+".people (stub)"};i="disable track track_pageview track_links track_forms register register_once alias unregister identify name_tag set_config people.set people.set_once people.increment people.append people.track_charge people.clear_charges people.delete_user".split(" ");
            for(g=0;g<i.length;g++)f(c,i[g]);b._i.push([a,e,d])};b.__SV=1.2;a=f.createElement("script");a.type="text/javascript";a.async=!0;a.src="//cdn.mxpnl.com/libs/mixpanel-2.2.min.js";e=f.getElementsByTagName("script")[0];e.parentNode.insertBefore(a,e)}})(document,window.mixpanel||[]);
        mixpanel.init("88eed657d0d071846e4cadf93f7ce30c");
        function clearform()
        {
            document.getElementById("email").value=""; //don't forget to set the textbox id
            document.getElementById("password").value="";
        }




        $("document").ready(function(){
            //alert("hello");
            $("#loginMsg").hide();
            clearform();
           // $("#signup").reset();
            //alert("loginMsg");
            // $("#registerMsg").hide();
            // alert("registerMsg");


            $("#signup").submit(function(){
                //alert("hello1234");
                $("#loginMsg").hide();
                var uname = $("#username").val();
                // alert(uname);

                var data = {
                    "action": "registration"
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

                             window.location.href="payment.php";
                        }else
                        {

                           // window.location.href="signup.php";
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

            <a class="logo" href=""></a>


            <div class="menu">
                <ul class="nav">


                    <li><a href="">home</a></li>
                    <li class="delim"></li>                        <li><a href="pricing">pricing</a></li>
                    <li class="delim"></li>                        <li><a href="faq">faqs</a></li>
                    <li class="delim"></li>                        <li><a href="http://support.automaticviral.com/">support</a></li>

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
                <div class="tab  completed">
                    <div class="icon">
                    </div>
                    <div class="title">Add Instagram Account</div>
                </div>
                <div class="tab  completed active" "="">
                <div class="icon">
                    <div></div>
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
    <form id="signup" class="box-form" action="signup.php" method="POST">

        <div class="head">
            <h2>Create an Account</h2>
            Please fill out all of the following fields to create an account
        </div>

        <div class="inputs">

            <div class="icon-input push-bottom">
                <div class="icon ico-user"><div class=""></div></div>

                <input placeholder="Username" name="username" id="username" type="text">            </div>

            <div class="icon-input push-bottom">
                <div class="icon ico-envelope"><div></div></div>
                <input placeholder="EmailAddress" name="email" id="email" type="text">            </div>

            <div class="icon-input-inline passwds">

                <div class="icon-input">
                    <div class="icon ico-key"><div></div></div>
                    <input placeholder="Password" id="password" name="password" type="password">
                </div>

                <div class="icon-input">
                    <div class="icon ico-key"><div></div></div>
                    <input placeholder="Confirm" name="password2" type="password">
                </div>

            </div>

<!--            <input name="agree" value="1" type="hidden">-->

            <div class="agree-text">By clicking the button below, I acknowledge that I have read and agree to the <a target="terms_page" href="terms">Terms &amp; Conditions</a>.</div>


        </div>

        <div class="submit-section">
            <input name="IGScreenname" id="IGScreenname" type="hidden">
            <input id="submit" value="Agree &amp; Register" class="round" type="submit">
            <a class="link" href="login.php?loc=reg">Already have an account?</a>
        </div>

    </form>

    <div id="add-acc-overview">
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

<script>

    $(function() {
        $('#register-account-form').submit(function() {
            if($('#register-account-form').data('sent') == 1) {
                return false;
            }
            $('#register-account-form').data('sent', 1);
            return true;
        });
    });

    mixpanel.track("Confirmed IG Account", {
        "id" : 44291,
        "name" : "test"
    });

</script>
<div id="footer">
    <div class="wrap">
        <div class="left">
            Copyright © 2014 AutomaticViral. All Rights Reserved.
        </div>
        <div class="right">
            <ul>
                <li><a href="">home</a></li>
                <li><a href="">pricing</a></li>
                <li><a href="">faq</a></li>
                <li><a href="terms">terms</a></li>
                <li><a href="">support</a></li>
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