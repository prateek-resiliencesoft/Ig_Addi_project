<?
session_start();
$_SESSION['user'];
// database connection
$dbhost = "localhost";
$dbname	= "welikeu7_autolike";
$dbuser	= "welikeu7_autolk";
$dbpass	= "Password1";

$con = new PDO("mysql:host=$dbhost;dbname=$dbname",$dbuser,$dbpass);


extract($_POST);

//set POST variables
$url = 'http://52.10.69.137/stripeapi.aspx';
$fields = array(
    'card' => $_POST['CardNo'],


    'exprmonth' => $_POST['Expirymonth'],
    'expryear' => $_POST['Expiryyear'],
    'cvc' => $_POST['CVC'],
    'plan'=>$_POST['Plan'],
    'instagramuser'=>$_POST['IGusername']

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
print_r($result);

//close connection
curl_close($ch);

echo $result;
$username=$_SESSION['user'];
$customerid= 'cus_5oX7nyg8ESWOC711';
$planid = $_POST['Plan'];
$amount=1;
$date = date('Y-m-d');



$strQuery = "insert into tblpayment (`username`,`customerid`,`planid`,`amount`,`date`)
            VALUES (:username,:customerid,:planid,:amount,:date)";


$result1 = $con->prepare($strQuery);

$result1->bindParam(':username', $username);
$result1->bindParam(':customerid', $customerid);
$result1->bindParam(':planid', $planid);
$result1->bindParam(':amount', $amount);
$result1->bindParam(':date', $date);



$result1->execute();

