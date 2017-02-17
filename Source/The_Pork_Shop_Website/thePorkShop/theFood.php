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

<html>

<head>

    <meta charset="UTF-8">

    <title>The Pork Shop: The Food</title>

    <link rel="stylesheet" href="style.css">

</head>

<body>

<?php include("header.php") ?>

<h1> The Food</h1>

<div class="intro">
    <p>Our in-house smoker is going 24-hours a day to bring you the best eats your taste buds have ever
        tried.
        Our Pit Master lets no cut of meat leave the kitchen before its time.
    </p>
</div>

<div id="menu">

    <h2>Starters</h2>

    <span class="food">Roasted Garlic Soup - $5</span>
    <p class="info">Slow roasted garlic cloves sauteed with leeks and onions, simmered in broth and blended with heavy cream. Served
    with a crusty homemade roll.</p>

    <br>

    <span class="food">Mac n Cheese Balls - $8</span>
    <p class="info">Made with 5 types of cheese, our spicy mac n cheese is chilled, rolled into panko crusted balls and deep-fried
    for extra cheesy goodness. Served with chipotle mayo.</p>

    <br>

    <span class="food">Pulled Pork Nachos  - $12</span>
    <p class="info">Our smoky pulled pork on top of homemade nachos topped with a kicked up cheese sauce and sauteed peppers and
    onions.</p>

    <h2>Mains</h2>

    <span class="food">Porkzilla - $15</span>

    <p class="info">
        <img src="Images/porkzilla.png">
        <br><br>
        Our succulent pork shoulder, marinated in a sweet, spicy dry rub then smoked over hickory for a minimum
        12-hours. Pulled and tossed in our tangy Memphis style BBQ sauce. Served on a Chiabatta bun and topped with crispy
        bacon, deep fried banana peppers, Horseradish dill coleslaw and served with a side of Salt and Pepper Onion
        Rings.
    </p>

    <br>

    <span class="food">Bacon-Wrapped Meatloaf - $15</span>
    <p class="info"><img src="Images/baconWrappedMeatloaf.png"><br><br>Our traditional style meatloaf made of a mixture of beef and pork, onions and spices. Shaped, wrapped in a bacon
    weave and smoked with apple or hickory smoke for 3 hours.
    Served with homestyle fries or our homemade mac n cheese.</p>
    <br>
    <span class="food">Smoked Flap Steak  - $20</span>
    <p class="info"><img src="Images/smokedSteaks.png"><br><br>Succulent 6oz. Flap steak, marinated for 24-hours in our house marinade. Smoked with mesquite for an hour then
    kissed with the open flame of our grill. Served with our homestyle garlic mashed potatoes and a side of peppers and
    onions sauteed in butter.</p>

    <h2>Bar Menu</h2>

    <span class="food">Domestic Beer - $5</span>
    <p class="info"> Molson Canadian, Budweiser, Alexander Keith's Red Amber Ale, Alpine, Moosehead Light</p>
    <br>
    <span class="food">Imported Beers - $6.50</span>
    <p class="info">Guinness, Corona, Miller Genuine Draft</p>
    <br>
    <span class="food">House Liquor  - $5</span>
    <p class="info">Scotch, Rye, Vodka, Rum, Gin</p>
    <br>
    <span class="food">Cocktails - $7.50</span>
    <p class="info">Margerita, Pina Colada, Long Island Ice Tea, Alabama Slammer</p>
</div>
<!--<aside>Like the flavor?  Now you can take it home with you.  We have bottled our sauces and rubs for your convenience.  Ask you server.</aside>-->

<div id="images">
    <div id="porkzilla">

    </div>

    <div id="meatloaf">


    <div id="steak">

    </div>
</div>
<br>
<?php include("footer.php") ?>

</body>
</html>
