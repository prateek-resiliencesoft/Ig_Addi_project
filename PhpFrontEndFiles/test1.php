<?php
//set POST variables
$url = 'http://52.10.69.137/stripeapi.aspx';
$fields = array(
    'card' => '4242424242424242',
    'exprmonth' => '10',
    'expryear' => '2016',
    'cvc' => '199',
    'plan'=>'9',
    'instagramuser'=>'test'
);

//url-ify the data for the POST
//$field_string = http_build_query($fields);

//open connection
$ch = curl_init();

//set the url, number of POST vars, POST data
curl_setopt($ch,CURLOPT_URL, $url);
curl_setopt($ch,CURLOPT_POST, 1);
curl_setopt($ch,CURLOPT_POSTFIELDS, $fields);

//execute post
$result = curl_exec($ch);
//print_r($result);

//close connection
curl_close($ch);