<?php
/**
 * Created by PhpStorm.
 * User: sarsenault112452
 * Date: 1/23/2017
 * Time: 1:12 PM
 * Purpose: Submit Page for form, prototype reservation
 */

$tableNum = $_POST['tableNum'];
$date = $_POST['date'];
$time = $_POST['time'];
$name = $_POST['name'];
$contactNumber = $_POST['contactNumber'];
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>
<div>Your reservation is as follows:<br/>
    Name: <?php echo $name ?><br/>
    Table Number: <?php echo $tableNum ?><br/>
    Date/Time: <?php echo $date . " @ " . $time ?><br/>
    Contact Number: <?php echo $contactNumber ?><br/>
</div>
<a href="form.php">Go Back to Form</a>
</body>
</html>