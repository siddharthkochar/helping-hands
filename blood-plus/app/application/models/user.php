<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class User extends CI_Model {
 
   public function __construct()
   {
    parent::__construct();
   }
   
  public function getDonors($citycode,$bloodgroup)
  {
    $citycode = $citycode;
    $bloodgroup = $bloodgroup;

          $this->db->select('*');
          $this->db->from('persondetail');
          $this->db->where('citycode', $citycode);
          $this->db->where('bloodgroup', $bloodgroup);
          $this->db->where('status', "Active"); 
          $query = $this->db->get();
          $tem = $query->result_array();

          for ($i=0; $i < $query->num_rows(); $i++) {
              $donors_history[] = array($tem[$i]['name'],$tem[$i]['bloodgroup'], $tem[$i]['contactnumber'], $tem[$i]['group_name']);
          }

          if($tem)
            return $donors_history;

          else
            return "";
   }

  public function getStatus($status,$contactnumber)
  {
    $status = $status;
    $contactnumber = $contactnumber;
    $this->load->database();
     $date=date_default_timezone_set("Asia/Kolkata");
     date_default_timezone_get();
     $date_status=date("Y-m-d H:i:s");   


    $data = array(
       'status' => $status ,
       'date' => $date_status 
      );

    $query=  $this->db->where('contactnumber', $contactnumber)->update('persondetail',$data); 

    if($query)
       return $query;

    else
       return "";
   }

}
?>