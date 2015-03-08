<?php
/**
 * Created by PhpStorm.
 * User: DIGICOM
 * Date: 03/07/2015
 * Time: 5:39 PM
 */

session_start();
unset($_SESSION["planid"]);
unset($_SESSION["amount"]);
unset($_SESSION["likescount"]);
unset($_SESSION["user"]);
unset($_SESSION["admin_login_user"]);
unset($_SESSION["login_user"]);
header("location:login.php");