<?php
$hostname = "localhost"; 
$username = "a9ac9256_admin";
$password = "Sid_8611";
$db="a9ac9256_helpinghands_db";
$dbhandle = mysql_connect($hostname, $username, $password) or die("Unable to connect to MYSERVER");
mysql_select_db($db, $dbhandle);
?>

