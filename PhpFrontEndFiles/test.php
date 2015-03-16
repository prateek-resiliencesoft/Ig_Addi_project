


<?php
/*ini_set('mysql.connect_timeout', 300);
ini_set('default_socket_timeout', 300);
$server   = '184.154.247.140:2083';
$database = "welikeu7_autolike";
$username = "welikeu7_autolk";
$password = "Password1";

$mysqlConnection = mysql_connect("localhost", $username, $password);

if (!$mysqlConnection)
{
    echo "Please try later.";

    //if (!mysql_ping($mysqlConnection)) {
        //here is the major trick, you have to close the connection (even though its not currently working) for it to recreate properly.
      //  mysql_close($conn);
     //   $conn = mysql_connect($server, $username, $password);
     //   mysql_select_db('db',$conn);
     //   echo "Please try later1111.";
  //  }
}
else
{
    echo "connected.";
   // mysql_connect($server, $username, $password);
   // mysql_select_db($database, $mysqlConnection);
}
*/?>



<?php
$hostname = "localhost";
$dbname	= "welikeu7_autolike";
$username = "welikeu7_autolk";
$password = "Password1";

try {
    $dbh = new PDO("mysql:host=$hostname;dbname=$dbname", $username, $password);
    echo "Connected to database"; // check for connection
	$uname='prateek';
	$password='1';
	 $result = $dbh->prepare("select * from tblLogin where username=:username and password=:password");

        $result->bindParam(':username', $uname);
        $result->bindParam(':password', $password);

        $result->execute();
        $rows = $result->rowCount();//  fetch(PDO::FETCH_NUM);
		$return = $result->fetch(PDO::FETCH_OBJ);
		 if ($rows == 1) {
          echo  $_SESSION['login_user']= $uname;
		echo	$_SESSION['IGScreenname']=$return->IGScreenname;
		
		
			$planid = $dbh->prepare("select * from tblpayment where username=:username");
			$planid->bindParam(':username', $uname);
			$planid->execute();
			$plan_id = $planid->fetch(PDO::FETCH_OBJ);
			$pid=$plan_id->planid;
			
			if($pid==1)
			{
			$_SESSION['planid']=1;
			$_SESSION['amount']=15;
			$_SESSION['likescount']=100;
			echo $pid;
			}
			else if($pid==2)
			{
			 $_SESSION['planid']=2;
			$_SESSION['amount']=22;
			$_SESSION['likescount']=250;
			echo $pid;
			}
			else if($pid==3)
			{
			$_SESSION['planid']=3;
			$_SESSION['amount']=35;
			$_SESSION['likescount']=500;
			echo $pid;
			}
			
			}
			else
			{
			echo 'false';
			}
}
catch(PDOException $e)
{
    echo $e->getMessage();
}
?>