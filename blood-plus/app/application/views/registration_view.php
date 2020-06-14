<!DOCTYPE html>
<html>
<head>
  <title></title>
</head>
<body>
<div class="form_title">Sign Up</div>
 <?php echo validation_errors(); ?>
 <?php echo form_open("Welcome/registration"); ?>

  <p>
  <label for="user_name">User Name :</label>
  <input type="text" id="user_name" name="user_name"/>
  </p>
 
  <p>
  <label for="age">Your Age :</label>
  <input type="number" id="age" name="age"/>
  </p>
 
  <p>
  <label for="gender">Gender :</label>
  <select name="gender">
      <option value="male">Male</option>
      <option value="female">Female</option>
    </select>
  </p>
 
  <p>
  <label for="citycode">City Code :</label>
  <input type="number" id="citycode" name="citycode"/>
  </p>

  <p>
  <label for="bloodgroup">Your Bloodgroup :</label>
  <select name="bloodgroup">
    <option value="A+">A+</option>
    <option value="A-">A-</option>
    <option value="B+">B+</option>
    <option value="B-">B-</option>
    <option value="O+">O+</option>
    <option value="O-">O-</option>
    <option value="AB+">AB+</option>
    <option value="AB-">AB-</option>
  </select>
  </p>

  <p>
  <label for="contactnumber">Your Contact Number :</label>
  <input type="number" id="contactnumber" name="contactnumber"/>
  </p>

  <p>
  <label for="status" ng-hide="true">Active</label>
  <input type="text" id="status" name="status" hide="true"/>
  </p>
 
  <p>
  <input type="submit" value="Submit" />
  </p>
   <?php echo form_close(); ?>

</body>
</html>