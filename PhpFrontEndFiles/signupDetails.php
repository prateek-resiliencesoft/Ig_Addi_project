
    <?php
    session_start();
    // database connection
    $dbhost = "localhost";
    $dbname	= "welikeu7_autolike";
    $dbuser	= "welikeu7_autolk";
    $dbpass	= "Password1";

    $con = new PDO("mysql:host=$dbhost;dbname=$dbname",$dbuser,$dbpass);
    if($_POST['action'] == "registration") {

    $responseMessage = '';


    global $con;

    //$username = $_POST['IGScreenname'];
    //echo json_encode($username);
  $IGusername=$_SESSION['admin_login_user'];
    $user = $_POST['username'];
    $password = $_POST['password'];
    $email = $_POST['email'];
        $Status='Active';
    $created_date = date('Y-m-d');




    if(!empty($_POST['username']))
    {
    $responseMessage = "Enter username";
    }


    if(!empty($_POST['password']))
    {
    $responseMessage = "Enter Password";
    }

    if(!empty($_POST['email']))
    {
    $responseMessage = "Enter Email";
    }




    try {


   // $check=$con->prepare("SELECT Username FROM tblUser WHERE Username = :username");
  //  $check->bindparam(':username', $username);
  //  $check->execute();
  //  $no=$check->rowCount();

   // if ($no>0) {

   // $responseMessage = "Username already Exist....Please use another Username";
    //}
    //else{
   // if (strlen($password)<6 || strlen($password)>25)
   // {
   // $responseMessage= "Password Length must be between 6 to 25 characters";
   // }
   // else
    //{

    $strQuery = "insert into tblLogin (`IGScreenname`,`username`,`password`,`Status`,`date`,`email`)
            VALUES (:IGusername,:username,:password,:status,:created_date,:email)";


    $result = $con->prepare($strQuery);

        $result->bindParam(':IGusername', $IGusername);
        $result->bindParam(':username', $user);
        $result->bindParam(':password', $password);
      $result->bindParam(':status', $Status);
     $result->bindParam(':created_date', $created_date);
        $result->bindParam(':email', $email);


    $result->execute();

    //$responseMessage = "Error Code : " .$result->errorCode() . '<br><br>';
    //echo json_encode($responseMessage);
    $rows = $result->rowCount();

    if ($rows == 1) {
   // $_SESSION['login_user'] = $username; // Initializing Session
    $responseMessage = "Success";
        $_SESSION['user']=$user;
    } else {
    $responseMessage = "This  Email Id is already exist...Please use valid  Email Id.";
    }

  //  }
    //register user
  //  }

    } catch (PDOException $e) {
    $responseMessage = 'Query failed' . $e->getMessage();
    }
    echo json_encode($responseMessage);

    }



    if($_POST['action'] == "userverify") {

        $responseMessage = '';
        global $con;

        $username = $_POST['IGScreenname'];



        $result = $con->prepare("select * from tblLogin where IGScreenname=:username");

        $result->bindParam(':username', $username);


        $result->execute();
        $rows = $result->rowCount();//  fetch(PDO::FETCH_NUM);

        if ($rows == 1) {
             // Initializing Session

           //header("location: profile.php"); // Redirecting To Other Page
            $responseMessage = "Success";
        } else {
            $responseMessage = "user not registered";
            $_SESSION['admin_login_user']= $username;
        }

        echo json_encode($responseMessage);
    }



    if($_POST['action'] == "login") {

        $uname = $_POST['username'];
        $password = $_POST['password'];
        $responseMessage = '';

        if(!empty($_POST['username']))
        {
            $responseMessage = "Enter Username";
        }
        if(!empty($_POST['password']))
        {
            $responseMessage = "Enter Password";
        }

        global $con;

        $result = $con->prepare("select * from tblLogin where username=:username and password=:password");

        $result->bindParam(':username', $uname);
        $result->bindParam(':password', $password);

        $result->execute();
        $rows = $result->rowCount();//  fetch(PDO::FETCH_NUM);
		$return = $result->fetch(PDO::FETCH_OBJ);
        if ($rows == 1) {
            $_SESSION['login_user']= $uname;
			$_SESSION['admin_login_user']=$return->IGScreenname;
			
			//get Plan id
			$planid = $con->prepare("select * from tblpayment where username=:username");
			$planid->bindParam(':username', $uname);
			$planid->execute();
			$plan_id = $planid->fetch(PDO::FETCH_OBJ);
			$pid=$plan_id->planid;
			
			if($pid==1)
			{
			$_SESSION['planid']=1;
			$_SESSION['amount']=15;
			$_SESSION['likescount']=100;
			//echo $pid;
			}
			else if($pid==2)
			{
			 $_SESSION['planid']=2;
			$_SESSION['amount']=22;
			$_SESSION['likescount']=250;
			//echo $pid;
			}
			else if($pid==3)
			{
			$_SESSION['planid']=3;
			$_SESSION['amount']=35;
			$_SESSION['likescount']=500;
			//echo $pid;
			}
			
			// Initializing Session
            // header("location:../ user/useralbums.php". $_POST['username']); // Redirecting To Other Page

            //  header( 'Location:../user/useralbums.php'.'?'.$_SESSION['login_user']) ;
            $responseMessage = "Success";
            // require_once('../user/useralbums.php');

        } else {
            $responseMessage = "Username or Password is invalid";
        }

        echo json_encode($responseMessage);
    }



    if($_POST['action'] == "update") {

        $responseMessage = '';
        global $con;

        $id = $_POST['id'];
        $pass=$_POST['password'];



        $result = $con->prepare("update tblLogin set password=:pass where id=:id");

        $result->bindParam(':id', $id);
        $result->bindParam(':pass', $pass);


        $result->execute();
        $rows = $result->rowCount();//  fetch(PDO::FETCH_NUM);

        if ($rows == 1) {
            // Initializing Session

            //header("location: profile.php"); // Redirecting To Other Page
            $responseMessage = "Password Updated Successfully.";
        } else {
            $responseMessage = "Password not updated.";

        }

        echo json_encode($responseMessage);
    }


    if($_POST['action'] == "profile") {

        $responseMessage = '';
        global $con;

        $Id = $_POST['id'];



        $result = $con->prepare("select * from tblLogin where id=:Id");

        $result->bindParam(':Id', $Id);


        $result->execute();
        $data = $result->fetchAll();
        echo json_encode($data);
    }






