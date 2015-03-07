


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
}
catch(PDOException $e)
{
    echo $e->getMessage();
}
?>