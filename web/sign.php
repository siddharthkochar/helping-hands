<!DOCTYPE html>
<html lang="en">
<head>
  <title>Helping Hands</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
 	<link href="assets/css/new_window.css" rel="stylesheet">


  
  
</head>
<body>

<div class="top1">
 <div id="top"> <h2 style="line-height:1.5em;">Please Fill The Form To Join Us..</h2></div>
<div class="top2">
  <form role="form" action="signc.php" method="post" >
  <div class="form-group font">
  <label for="usr">Name:</label>
  <input required type="text" class="form-control" id="usr" name="name">
</div>

  <div class="form-group font">
  <label for="usr">Email:</label>
  <input required type="text" class="form-control" id="usr" name="email">
</div>

    <div class="form-group font">
      <label for="sel1">Gender</label>
      <select required class="form-control" id="sel1" name="gender">
        <option value="Male">Male</option>
		<option value="Female">Female</option>
      </select>
   </div>
   


<div class="form-group font">
      <label for="sel1">Blood Group</label>
      <select required class="form-control" id="sel1" name="bg">
             <option value="A+">A+</option>
		<option value="A-">A-</option>
             <option value="B+">B+</option>
		<option value="B-">B-</option>
             <option value="AB+">AB+</option>
		<option value="AB-">AB-</option>
          <option value="O+">O+</option>
              <option value="O-">O-</option>
      </select>
   </div>

  <div class="form-group font">
      <label for="sel1">Dob</label>
     <input required type="date" class="form-control" id="usr" name="dob">
   </div>
   
   
   <div class="form-group font">
      <label for="sel1">Occupation</label>
     <input required type="text" class="form-control" id="usr" name="paisa">
   </div>
   
   <div class="form-group font">
  <label for="comment">Address</label>
  <textarea class="form-control txt" rows="4" id="comment" name="address"></textarea>
</div>
   
  <div class="form-group font">
  <label for="usr">Contact:</label>
  <input required type="number" class="form-control" id="usr" name="contact" min="6999999999" max="9999999999">
</div>
   <div align="center">
		<button type="submit" class="btn" >Submit</button>
 <button type="reset" class="btn" >Reset</button> 
 <button class="btn" onclick="javascript:window.close();">Close</button> 
 </div>
   </form>
</div>
</div>
</body>
</html>
