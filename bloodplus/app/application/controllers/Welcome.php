<?php
defined('BASEPATH') OR exit('No direct script access allowed');
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\SMTP;
use PHPMailer\PHPMailer\Exception;

require 'lib/Exception.php';
require 'lib/PHPMailer.php';
require 'lib/SMTP.php';

class Welcome extends CI_Controller 
{
	public function index()
	{
  		$date=date_default_timezone_set("Asia/Kolkata");
    	date_default_timezone_get();
     	$today_date=date("Y-m-d H:i:s");   

        $this->load->database();
        
        $sql = 'SELECT 
        			contact, 
        			availability,
        			date 
        		FROM 
				'.db_schema.'.donor 
        		WHERE
        			availability NOT IN ("Available","Fake","Inappropriate")';

		$unAvailableDonors = $this->db->query($sql)->result_array();

	    $currentDate = new DateTime($today_date);

     	foreach ($unAvailableDonors as $donor) 
     	{
     		$updatedOn = new DateTime($donor['date']);
		    $interval = $currentDate->diff($updatedOn);
	        $donorStatus = strtolower($donor['availability']); 
		        
	        switch($donorStatus)
			{
				case 'not well':
				case 'out of station':
					if($interval->d>2)
						$this->makeDonorAvailable($donor['contact']);
				break;

				case 'unreachable':
				case 'other':
				case 'more':
					if($interval->h>2)
						$this->makeDonorAvailable($donor['contact']);
				break;

				case 'four':
					if($interval->m>=4)
						$this->makeDonorAvailable($donor['contact']);
				break;

				case 'nine':
					if($interval->m>=9)
						$this->makeDonorAvailable($donor['contact']);
				break;
				
			}

     	}

	}


	public function makeDonorAvailable($contact)
	{
	   	$data = array('availability' => "Available" ,
	  					'date' => date("Y-m-d H:i:s"));
	   	$this->db->where(db_schema.'.contact', $contact)->update(db_schema.'.donor',$data); 
	}

	public function stateList()
	{
        $this->setCORS();
        $this->load->database();
		$this->db->select('*');
		$db = db_schema.'.states';
		$this->db->from($db);
        $query = $this->db->get();

        $tem = $query->result_array();
       
		foreach ($tem as $row)
		{
		        $data[]=array('id'=>$row['id'],'name'=>$row['name']); 
		}

        if($data)
	   	{
	          	$status_array = array(
					'status' => 1,
					'status_message' => 'State List',
					'stateList' => $data
					);
			echo json_encode($status_array );
			return json_encode($status_array );
		}	
		else
		{
				$status_array = array(
					'status' => 0, 
					'status_message' => 'Sorry, No Match Found.'
					);
			echo json_encode($status_array);
			return json_encode($status_array);
		}
	}

	public function cityList()
	{
        $this->setCORS();
		$content=file_get_contents('php://input');
		$obj = json_decode($content, true);
		$state_id=$obj[0]['state_id'];

		$db = db_schema.'.cities';
		$this->db->select('*');
		$this->db->from($db);
		$this->db->where('state_id', $state_id);
		$query = $this->db->get();
		$tem = $query->result_array();

		$tem = $query->result_array();

		foreach ($tem as $row)
		{
		        $data[]=array('id'=>$row['id'],'name'=>$row['name']); 
		}

		if($data)
			{
		      	$status_array = array(
					'status' => 1,
					'status_message' => 'city List',
					'stateList' => $data
					);
			echo json_encode($status_array );
			return json_encode($status_array );
		}	
		else
		{
				$status_array = array(
					'status' => 0, 
					'status_message' => 'Sorry, No Match Found.'
					);
			echo json_encode($status_array);
			return json_encode($status_array);
		}
	}

	//For new User Registration..
	public function registration()
	{
        $this->setCORS();
		$content=file_get_contents('php://input');
		$obj = json_decode($content, true);
		
		$name=$obj[0]['name'];
		$age=$obj[0]['age'];
		$gender=$obj[0]['gender'];
		$citycode=$obj[0]['citycode'];
		$bloodgroup=$obj[0]['bloodgroup'];
		$contactnumber=$obj[0]['contactnumber'];
		$group=$obj[0]['group'];
		$status=$obj[0]['status'];

		$sql=$this->db->query("SELECT contactnumber from ".db_schema.".persondetail where contactnumber='$contactnumber' and citycode='$citycode' ");
		$counter=0;

		$state_data=[];
		if ($sql->num_rows() >=1)
		{    $counter=1;
			$arrayName = array(
				
				'status' => 0, 
				'error_message'=>'This Mobile No. is already registered for same city. Please register with different Mobile No.'
			);
			echo json_encode($arrayName);
			die();
		}
		
		if ($counter==0) {
		
	    $data=array(
				    'name'=>$name,
				    'age'=>$age,
				    'gender'=>$gender,
        			 'citycode'=>$citycode,
				    'bloodgroup'=>$bloodgroup,
				    'contactnumber'=>$contactnumber,
				    'group_name' => $group,
				    'status'=> $status
			);
			$registered	=	$this->db->insert(db_schema.'.persondetail',$data);
			
			if($registered){
					$status_array = array(
						'status' => 1, 
						'status_message'=>'Welcome to the family..You are Successfully Registered.'
					);
                                        
					echo json_encode($status_array);
					die();
			}
			else{
					$status_array = array(
						'status' => 0, 
						'status_message'=>'Could not registered, may be duplicate entry.'
					);
					echo json_encode($status_array);
					return json_encode($status_array);
					die();
			}	
		}
	}

	public function registerDonor()
	{
        $this->setCORS();
		$content=file_get_contents('php://input');
		$obj = json_decode($content, true);
		
		$name=$obj[0]['name'];
		$age=$obj[0]['age'];
		$gender=$obj[0]['gender'];
		$state=$obj[0]['state'];
		$city=$obj[0]['city'];
		$bloodgroup=$obj[0]['bloodgroup'];
		$contact=$obj[0]['contact'];
	
		$sql=$this->db->query("SELECT contact from ".db_schema.".donor where contact='$contact' and city='$city' ");
		if ($sql->num_rows()>=1)
		{    
			$arrayName = array(
				'status' => 0, 
				'error_message'=>'This Mobile No. is already registered for same city. Please register with different Mobile No.'
			);
			echo json_encode($arrayName);
			return json_encode($arrayName);
		} else {
	    	$data = array(
				    'name'=>$name,
				    'age'=>$age,
				    'gender'=>$gender,
        			'state'=>$state,
        		    'city'=>$city,
				    'bloodgroup'=>$bloodgroup,
				    'contact'=>$contact
			);
			$registered	= $this->db->insert(db_schema.'.donor',$data);
			
			if($registered) {
					$status_array = array(
						'status' => 1,
						'status_message'=>'Welcome to the family..You are Successfully Registered.'
					);
			} else {
					$status_array = array(
						'status' => 0, 
						'status_message'=>'Could not registered, may be duplicate entry.'
					);
			}
			echo json_encode($status_array);
			return json_encode($status_array);
		}
	}

	public function search()
	{
        $this->setCORS();
		$content=file_get_contents('php://input');
		$obj = json_decode($content, true);
		$citycode = $obj[0]['citycode'];
		$bloodgroup = $obj[0]['bloodgroup'];

		$donors = array();
		$this->db->order_by('id', 'RANDOM');
		$this->db->limit(1);
		$this->db->select('*');
		$this->db->from(db_schema.'.persondetail');
		$this->db->where('citycode', $citycode);
		$this->db->where('bloodgroup', $bloodgroup);
		$this->db->where('status', "Active"); 
		$query = $this->db->get();
		$tem = $query->result_array();

		for ($i=0; $i < $query->num_rows(); $i++) {
		$donor_detail[] = array($tem[$i]['name'],$tem[$i]['bloodgroup'], $tem[$i]['contactnumber'], $tem[$i]['citycode']);
		}

		if($tem)
		{
		$status_array = array(
		'status' => 1,
		'status_message' => 'Match Found',
		'donorsDetail' => $donor_detail
		);
		echo json_encode($status_array );
		return json_encode($status_array );
		}	
		else
		{
		$status_array = array(
		'status' => 0, 
		'status_message' => 'Sorry, No Match Found.'
		);
		echo json_encode($status_array);
		return json_encode($status_array);
		}
	}

	public function searchDonor()
	{
        $this->setCORS();
		$content=file_get_contents('php://input');
		$obj = json_decode($content, true);
		$city = $obj[0]['city'];
		$bloodgroup = $obj[0]['bloodgroup'];

		$donors = array();
		$this->db->order_by('id', 'RANDOM');
		$this->db->limit(1);
		$this->db->select('*');
		$this->db->from(db_schema.'.donor');
		$this->db->where('city', $city);
		$this->db->where('bloodgroup', $bloodgroup);
		$this->db->where('availability', "Available"); 
		$query = $this->db->get();
		$tem = $query->result_array();

		for ($i=0; $i < $query->num_rows(); $i++) {
		$donor_detail[] = array($tem[$i]['name'],$tem[$i]['bloodgroup'], $tem[$i]['contact'], $tem[$i]['city']);
		}

		if($tem)
		{
		$status_array = array(
		'status' => 1,
		'status_message' => 'Match Found',
		'donorsDetail' => $donor_detail
		);
		echo json_encode($status_array );
		return json_encode($status_array );
		}	
		else
		{
		$status_array = array(
		'status' => 0, 
		'status_message' => 'Sorry, No Match Found.'
		);
		echo json_encode($status_array);
		return json_encode($status_array);
		}
	}
		 
	public function setDonorStatus()
	{
        $this->setCORS();
		$content=file_get_contents('php://input');
		$obj = json_decode($content, true);
		$donors=array();
		$status = $obj[0]['status'];
		$number = $obj[0]['contact'];
		
	    $this->load->database();
	    $date=date_default_timezone_set("Asia/Kolkata");
	    date_default_timezone_get();
	    $date_status=date("Y-m-d H:i:s");   


	    $data = array(
	       'availability' => $status ,
	       'date' => $date_status 
	      );

	    $query = $this->db->where(db_schema.'.contact', $number)->update(db_schema.'.donor',$data); 

	    if($query)
		{
          	$status_array = array(
				'status' => 1,
				'status_message' => 'Enter details to search again.',
				);
		echo json_encode($status_array );
		return json_encode($status_array );
		}	
		else
		{
			$status_array = array(
				'status' => 0, 
				'status_message' => 'No Match Found'
				);
		echo json_encode($status_array);
		return json_encode($status_array);
		}
	}
    
    public function setStatus()
	{
		$this->setCORS();
        $content=file_get_contents('php://input');
		$obj = json_decode($content, true);
		$donors = array();
		$status = $obj[0]['status'];
		$number = $obj[0]['contactnumber'];

	    $this->load->database();
	    $date=date_default_timezone_set("Asia/Kolkata");
	    date_default_timezone_get();
	    $date_status=date("Y-m-d H:i:s");   


	    $data = array(
	       'status' => $status,
	       'date' => $date_status 
	      );

	    $query = $this->db->where(db_schema.'.contactnumber', $number)->update(db_schema.'.persondetail',$data); 

	    if($query)
		{
          	$status_array = array(
				'status' => 1,
				'status_message' => 'Enter details to search again.',
				);
		echo json_encode($status_array );
		return json_encode($status_array );
		}	
		else
		{
			$status_array = array(
				'status' => 0, 
				'status_message' => 'No Match Found'
				);
		echo json_encode($status_array);
		return json_encode($status_array);
		}
    }
    
    public function sendFeedback()
    {
        $mail = new PHPMailer(true);

        try {
            //Server settings
            $mail->isSMTP();                                            // Send using SMTP
            $mail->Host       = 'smtp.gmail.com';                    // Set the SMTP server to send through
            $mail->SMTPAuth   = true;                                   // Enable SMTP authentication
            $mail->Username   = 'helpinghandsrpr@gmail.com';                     // SMTP username
            $mail->Password   = 'zeazmxghmnmwmknz';                               // SMTP password
            $mail->SMTPSecure = PHPMailer::ENCRYPTION_STARTTLS;         // Enable TLS encryption; `PHPMailer::ENCRYPTION_SMTPS` encouraged
            $mail->Port       = 587;                                    // TCP port to connect to, use 465 for `PHPMailer::ENCRYPTION_SMTPS` above

            //Recipients
            $mail->setFrom('helpinghandsrpr@gmail.com', 'Feedback');
            $mail->addAddress('helpinghandsrpr@gmail.com', 'Feedback');     // Add a recipient

            // Content
            $mail->isHTML(true);                                  // Set email format to HTML
            $mail->Subject = 'Feedback';
			
			$this->setCORS();
			$content=file_get_contents('php://input');
			$obj = json_decode($content, true);
			$name = $obj['name'];
			$contactnumber = $obj['contactnumber'];
			$msg = $obj['msg'];
			$email_message = "Mobile Number  ".$contactnumber." \n"."Name  ".$name." \n"."Message ".'"'.$msg.'"'." \n";
			
            $mail->Body    = $email_message;
            $mail->send();
            
			$statusArrayMessage = array(
					'status' => 1, 
					'status_message' => "Your Feedback has been receieved. Thank you!"
					);

			echo json_encode($statusArrayMessage);
			return json_encode($statusArrayMessage);
		
        } catch (Exception $e) {
			$status_array = array(
					'status' => 0, 
					'status_message' => "Feedback not processed. Please try again."
					);
			echo json_encode($status_array);
			return json_encode($status_array);
        }
    }
	
	public function sendFeedback1()
	{
        $this->setCORS();
		$content=file_get_contents('php://input');
		$obj = json_decode($content, true);
		$name = $obj['name'];
		$contactnumber = $obj['contactnumber'];
		$msg = $obj['msg'];
        
		
		$this->load->library('email');
		$config = array();
        $config['protocol'] = "smtp";
		$config['smtp_host']='smtp.gmail.com';
        $config['smtp_port'] = 587;
		$config['smtp_user'] = 'helpinghandsrpr@gmail.com';
		$config['smtp_pass'] = '9826600940';
//      $config['smtp_host'] = "localhost";
//		$config['smtp_user'] = "emailuser@helpinghandscg.in";
//		$config['smtp_pass'] = "helpinghands@123";
		$config['mailtype'] = 'html';
        $config['charset']  = 'utf-8';
        $config['newline']  = "\r\n";
        $config['wordwrap'] = TRUE;        
        $this->email->initialize($config);
		
	    $this->email->to("helpinghandsrpr@gmail.com");
		$this->email->from("emailuser@helpinghandscg.in");
		$this->email->subject("Feedback");
        $email_message = "Mobile Number  ".$contactnumber." \n"."Name  ".$name." \n"."Message ".'"'.$msg.'"'." \n";

		$this->email->message($email_message);
		
       	$result = $this->email->send();
		$this->email->print_debugger();

        if($result)
		{
			$statusArrayMessage = array(
					'status' => 1, 
					'status_message' => "Your Feedback has been receieved. Thank you!"
					);

			echo json_encode($statusArrayMessage);
			return json_encode($statusArrayMessage);
		}
		else
		{
			$status_array = array(
					'status' => 0, 
					'status_message' => "Feedback not processed. Please try again."
					);
			echo json_encode($status_array);
			return json_encode($status_array);
		}

	}

    public function setCORS() {
        header('Content-type: application/json');
        header("Access-Control-Allow-Origin: *");
        header("Access-Control-Allow-Methods: *");
		header('Access-Control-Max-Age: 180');
        header("Access-Control-Allow-Headers: Content-Type, Content-Length, Accept-Encoding");
    }
}
?>