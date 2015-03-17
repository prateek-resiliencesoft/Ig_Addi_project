<?php

function httpGet($url)
{
    $ch = curl_init();
    curl_setopt($ch,CURLOPT_URL,$url);
    curl_setopt($ch,CURLOPT_RETURNTRANSFER,true);

    $output=curl_exec($ch);

    curl_close($ch);
    return $output;
}

$UserProfileData = httpGet("https://api.instagram.com/v1/users/966258514/?client_id=d699b2681e2644479f4b97b76b2bda33");

//$jsonData = '{"meta":{"code":200},"data":{"username":"vivankapoor","bio":"amit@gmail.comNice to see people happy","website":"http:\/\/www.google.com","profile_picture":"https:\/\/instagramimages-a.akamaihd.net\/profiles\/profile_966258514_75sq_1389425502.jpg","full_name":"Vivan Kapoor","counts":{"media":77,"followed_by":229,"follows":1430},"id":"966258514"}}';
$phpArray = json_decode($UserProfileData);
//print_r($phpArray);
echo $phpArray->data->username.'</br>';
echo $phpArray->data->full_name.'</br>';
echo $phpArray->data->profile_picture.'</br>';
echo $phpArray->data->counts->media.'</br>';
echo $phpArray->data->counts->followed_by.'</br>';
echo $phpArray->data->counts->follows.'</br>';

//echo "End";
////set POST variables
//$url = 'http://52.10.69.137/stripeapi.aspx';
//$fields = array(
//    'card' => '4242424242424242',
//    'exprmonth' => '10',
//    'expryear' => '2016',
//    'cvc' => '199',
//    'plan'=>'9',
//    'instagramuser'=>'test'
//);
//
////url-ify the data for the POST
////$field_string = http_build_query($fields);
//
////open connection
//$ch = curl_init();
//
////set the url, number of POST vars, POST data
//curl_setopt($ch,CURLOPT_URL, $url);
//curl_setopt($ch,CURLOPT_POST, 1);
//curl_setopt($ch,CURLOPT_POSTFIELDS, $fields);
//
////execute post
//$result = curl_exec($ch);
////print_r($result);
//
////close connection
//curl_close($ch);