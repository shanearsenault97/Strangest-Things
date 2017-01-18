<?php
/**
 * Created by PhpStorm.
 * User: Shane Arsenault
 * Date: 1/16/2017
 * Time: 1:28 PM
 * Originally created by Heather Watterson on 10/7/2015, adapted for CIS2261 Final Project
 * Purpose: Front page of website.
 */
?>

<!DOCTYPE html>

<html lang="en">

    <head>

        <meta charset="UTF-8">

        <title>The Pork Shop: Blues and BBQ Restaurant in Summerside, PEI</title>

        <link rel="stylesheet" href="style.css">

    </head>

    <body>

        <!-- Main content -->

        <?php include("header.php") ?>

        <div id="secondary">

            <header><h1>The Home of Summerside's best Blues and BBQ</h1></header>

        </div>


        <h3>Welcome to The Pork Shop!</h3>


        <img src="Images\bluesPig.jpg" style="width:400px;">


        <div class="intro">

            <p>We are Summerside's One and Only home for Sweet, Smoky Blues and even Smokier BBQ.
                Once you have been in we guarantee you WILL be back.</p>

            <p>We feature
                <span>LIVE Local Blues 3 nights a week, GUARANTEED!</span>
                and local artists stopping in to jam any time at all.</p>

        </div>

        <?php include("footer.php") ?>

    </body>

</html>
