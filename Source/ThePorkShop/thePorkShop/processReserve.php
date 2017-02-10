<?php
/**
 * Created by PhpStorm.
 * User: sarsenault112452
 * Date: 1/23/2017
 * Time: 1:12 PM
 * Purpose: Submit Page for form, prototype reservation
 */

@$tableNum = $_POST['tableNum'];
@$date = $_POST['date'];
@$time = $_POST['time'];
@$name = $_POST['name'];
@$contactNumber = $_POST['contactNumber'];

//opens up database
@ $db = new mysqli('sarsenau.hccis.info', 'sarsenau_admin', '5tr&ng3rTh!ng$', 'sarsenau_pork_shop');

//adds security to fields
$name = mysqli_real_escape_string($db, $name);

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
    <link rel="stylesheet" href="style.css">
</head>
<body>
<?php include("header.php") ?>

<?php

if (empty($tableNum) || empty($date) || empty($time) || empty($name) || empty($contactNumber)) {
    echo "<h1>You forgot some required parts of your submission. Reservation was not added.</h1>
    <br/><button onclick=\"history.go(-1);\">Go Back to Form </button></body></html>";
    die();
} else {

    echo "<div><h1>Your submission is as follows:</h1><br/>
    Name: $name <br/>
    Table Number: $tableNum<br/>
    Date/Time: $date @ $time<br/>
    Contact Number: $contactNumber<br/>
</div>";

//query derived from form that gets search results
    $query = "SELECT * FROM reservation WHERE tableNum = '$tableNum' AND reservationDate = '$date' AND reservationTime = '$time'";

//result of query
    $result = $db->query($query);

//printing out results, along to check whether a row exists from the query
    if (@$result->num_rows > 0) {
        echo "Reservation is already set for this table at the specified date and time. Reservation was not added.
    <br/><button onclick=\"history.go(-1);\">Go Back to Form </button></body></html>";
        die();
    } else {

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
}
?>


<a href="reserve.php">Go Back to Form</a>
<?php include("footer.php") ?>

</body>
</html>