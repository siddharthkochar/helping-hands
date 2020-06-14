<?php 
include('dbconnection.php');
$a=$_REQUEST['name'];
$b=$_REQUEST['email'];
$c=$_REQUEST['gender'];
$j=$_REQUEST['bg'];
$d=$_REQUEST['dob'];
$e=$_REQUEST['paisa'];
$f=$_REQUEST['address'];
$g=$_REQUEST['contact'];
$h=date('d-m-Y @ h:i:s');
$i=$_SERVER['REMOTE_ADDR'];
$q=mysql_query("insert into sign(name, email, gender,bg, dob, accupation, address, contact, dat, ip) values('$a', '$b', '$c','$j', '$d', '$e', '$f', '$g', '$h', '$i')");
if($q)
{

echo "<script>alert('Thank You For Join With Us');</script>";	
echo "<script>window.close(); </script>";
 

}

?>