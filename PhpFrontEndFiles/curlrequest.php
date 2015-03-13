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
    'plan'=>$_SESSION['planid'],
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
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

//execute post
$result = curl_exec($ch);

$obj = json_decode($result);
$type=$obj->{'Type'};
$cusid= $obj->{'Message'};

//close connection
curl_close($ch);

//echo $result;
if	($type=="success")
{
$username=$_SESSION['user'];
$customerid= $cusid;
$planid = $_SESSION['planid'];

$amount=$_SESSION['amount']; 

$date = date('Y-m-d');

$result = $con->prepare("select * from tblpayment where username=:username");

        $result->bindParam(':username', $username);


        $result->execute();
        $rows = $result->rowCount();
		$strQuery;
			if ($rows == 1) {
		$strQuery = "update tblpayment set customerid =:customerid,planid=:planid,amount=:amount,date=:date where username=:username";
		



            
}		
		
		else
		{
		$strQuery = "insert into tblpayment (`username`,`customerid`,`planid`,`amount`,`date`)
            VALUES (:username,:customerid,:planid,:amount,:date)";



		
		}
$result1 = $con->prepare($strQuery);

$result1->bindParam(':username', $username);
$result1->bindParam(':customerid', $customerid);
$result1->bindParam(':planid', $planid);
$result1->bindParam(':amount', $amount);
$result1->bindParam(':date', $date);



$result1->execute();

echo json_encode("success");
}
else
{
echo json_encode("failer");
}

