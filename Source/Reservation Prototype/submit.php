<?php
/**
 * Created by PhpStorm.
 * User: sarsenault112452
 * Date: 1/23/2017
 * Time: 1:12 PM
 * Purpose: Submit Page for form, prototype reservation
 */

$tableNum = $_GET['tableNum'];
$date = $_GET['date'];
$time = $_GET['time'];
$name = $_GET['name'];
$contactNumber = $_GET['contactNumber'];



echo "<div>Your submission is as follows:<br/>
    Name: $name <br/>
    Table Number: $tableNum<br/>
    Date/Time: $date @ $time<br/>
    Contact Number: $contactNumber<br/>
</div>";

//opens up database
@ $db = new mysqli('localhost', 'root', '', 'pork_shop');

//if the database does not connect, display custom-made error for security
if (mysqli_connect_errno()) {
    echo 'Error: Could not connect to database.  Please try again later.</body></html>';
    exit;
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Process</title>
</head>
<body>
<?php
//query derived from form that gets search results
$query = "SELECT * FROM reservation WHERE tableNum = '$tableNum' AND reservationDate = '$date' AND reservationTime = '$time'";

//result of query
$result = $db->query($query);

//printing out results, along to check whether a row exists from the query
if (@$result->num_rows > 0) {
    echo "Reservation is already set for this table at the specified date and time.</body></html>";
    die();
}else {

//free up space in memory for the next query
    @$result->free();

//query derived from form that gets search results
    $query = "INSERT INTO reservation (tableNum, reservationDate, reservationTime, reservationName, reservationContact)
VALUES ('$tableNum', '$date', '$time', '$name', '$contactNumber')";


//result of query
    $result = $db->query($query);

//free up space in memory for the next query
    @$result->free();

//closes the database for security
    $db->close();


}
?>


<a href="form.php">Go Back to Form</a>
</body>
</html>