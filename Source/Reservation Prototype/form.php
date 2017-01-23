<?php
/**
 * Created by PhpStorm.
 * User: sarsenault112452
 * Date: 1/23/2017
 * Time: 1:11 PM
 * Purpose: Prototype for Reservation System, Web Side
 */
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>
<form action="submit.php" method="post">
    <label for="tableNum">Table Number:</label>
    <select name="tableNum" id="tableNum" required>
        <option value="1">1</option>
    </select><br/>

    <label for="date">Date:</label>
    <input type="date" id="date" name="date" required/><br/>

    <label for="time">Time:</label>
    <input type="time" id="time" name="time" required/><br/>

    <label for="name">Name:</label>
    <input type="text" id="name" name="name" required/><br/>

    <label for="contactNumber">Contact Number:</label>
    <input type="tel" id="contactNumber" name="contactNumber" required/><br/>

    <input type="submit"/>
</form>
</body>
</html>
