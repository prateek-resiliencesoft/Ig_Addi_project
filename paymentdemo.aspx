<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paymentdemo.aspx.cs" Inherits="SocialPanel.paymentdemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <!-- The required Stripe lib -->
<script type="text/javascript" src="https://js.stripe.com/v2/"></script>
 
<!-- jQuery is used only for this example; it isn't required to use Stripe -->
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
 
<script type="text/javascript">
    // This identifies your website in the createToken call below
    Stripe.setPublishableKey('pk_test_YcwwONdMD7MlZryTd2yspFGq');
    var stripeResponseHandler = function (status, response) {
        var $form = $('#payment-form');
        if (response.error) 
        {
            // Show the errors on the form
            $form.find('.payment-errors').text(response.error.message);
            $form.find('button').prop('disabled', false);
        }
        else
        {
            // token contains id, last4, and card type
            var token = response.id;

            alert(token);


           

        alert(token);

        alert(token);

        // Insert the token into the form so it gets submitted to the server
        $form.append($('<input type="hidden" name="stripeToken" />').val(token));
        // and re-submit
        $form.get(0).submit();

        Stripe.api_key = "sk_test_gAWnAmOPFQ36viazsbLk43VB"
        // (Assuming you're using express - expressjs.com)
        // Get the credit card details submitted by the form
        //var stripeToken = request.body.stripeToken;



        Stripe.customers.create({
            source: stripeToken,
            plan: "testingdemo",
            email: "payinguser@example.com"
        }, function (err, customer) {
            // ...
        });

    }
};
    jQuery(function ($) {
        $('#payment-form').submit(function (e) {
            var $form = $(this);
            // Disable the submit button to prevent repeated clicks
            $form.find('button').prop('disabled', true);
            Stripe.card.createToken($form, stripeResponseHandler);
            // Prevent the form from submitting with the default action
            return false;
        });
    });
</script> 

</head>
<body>
     <form action="" method="POST" id="payment-form">
<span class="payment-errors"></span>
 
<div class="form-row">
<label>
<span>Card Number</span>
<input type="text" size="20" data-stripe="number" value="4242424242424242"/>
</label>
</div>
 
<div class="form-row">
<label>
<span>CVC</span>
<input type="text" size="4" data-stripe="cvc" value="899"/>
</label>
</div>
 
<div class="form-row">
<label>
<span>Expiration (MM/YYYY)</span>
<input type="text" size="2" data-stripe="exp-month" value="10"/>
</label>
<span> / </span>
<input type="text" size="4" data-stripe="exp-year" value="15"/>
</div>
 
<button type="submit">Submit Payment</button>
</form>
</body>
</html> 