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
    <title>Form</title>
    <script src="jquery-3.1.1.min.js"></script>
    <script src="jQuery-Mask-Plugin-master/dist/jquery.mask.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function(){
            $('.phone_us').mask('(000)000-0000');

        });

        function test(){
            var regex = "/[a-zA-Z]+$/";
            var val = document.getElementById("name").value;
            if(/[a-zA-Z]+$/.test(val)==false){
                alert("Name must have only alphabetical characters.");
            }

        }
    </script>
</head>
<body>
<form action="submit.php" method="post">
    <label for="tableNum">Table Number:</label>
    <select name="tableNum" id="tableNum" required>
        <?php
        //opens up database
        @ $db = new mysqli('localhost', 'root', '', 'pork_shop');

        //if the database does not connect, display custom-made error for security
        if (mysqli_connect_errno()) {
            echo 'Error: Could not connect to database.  Please try again later.</body></html>';
            exit;
        }


        //query derived from form that gets search results
        $query = "SELECT *
                            FROM tables
                            WHERE tableNum LIKE 'B%'
                            OR tableNum LIKE  'T%'
                            ";


        //result of query
        $result = $db->query($query);

        //printing out results, along to check whether a row exists from the query
        if (@$result->num_rows > 0) {


            $boothCount = 1;
            $tableCount = 1;

            while ($row = $result->fetch_assoc()) {
                var_dump($row['tableNum']);
                $tableName = $row['tableNum'];

                echo "<option value=$tableName>";
                if (strpos($row['tableNum'], 'BTH') !== false) {
                    echo "Booth " . $boothCount;
                    $boothCount++;
                } elseif (strpos($row['tableNum'], 'TBL') !== false) {
                    echo "Table " . $tableCount;
                    $tableCount++;
                } else {
                    echo "If this happened call the store to reserve your table.";
                }

                echo "</option>";
            }

        } else {

            echo "<option value='placeholder'>Placeholder</option>";

        }

        //free up space in memory for the next query
        @$result->free();

        //closes the database for security
        $db->close();
        ?>
    </select><br/>

    <label for="date">Date:</label>
    <input type="date" id="date" name="date" required/><br/>

    <label for="time">Time:</label>
    <input type="time" id="time" name="time" required/><br/>

    <label for="name">Name:</label>
    <input type="text" id="name" name="name"  pattern="[a-zA-Z]+$" required title="Name can only be alphabetical characters."/><br/>

    <label for="contactNumber">Contact Number:</label>
    <input type="tel" id="contactNumber" name="contactNumber" class="phone_us" maxlength="13" pattern=".{13,}" required title="13 characters minimum"/><br/>

    <input type="submit"/>
</form>
</body>
</html>
