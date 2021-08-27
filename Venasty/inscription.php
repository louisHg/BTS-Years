<?php
 if (isset($_POST["nom"],$_POST["prenom"]))
        {
            echo "age: ".$_POST["age"]."<br />";
            echo "ville: ".$_POST["ville"]."<br />";
            echo "prenom: ".$_POST["prenom"]."<br />";
            echo "profession: ".$_POST["profession"]."<br />";
            echo "passion: ".$_POST["passion"]."<br />";
            echo "qualites: ".$_POST["qualites"]."<br />";
            echo "defauts: ".$_POST["defauts"]."<br />";
            echo "jeux joues: ".$_POST["jeux joues"]."<br />";
            echo "pseudo: ".$_POST["pseudo"]."<br />";
            echo "plateforme: ".$_POST["plateforme"]."<br />";
            echo "expcompetitives: ".$_POST["expcompetitives"]."<br />";
            echo "support: ".$_POST["support"]."<br />";
            echo "point en arene: ".$_POST["point en arene"]."<br />";
            echo "duo: ".$_POST["duo"]."<br />";
            echo "motivation: ".$_POST["motivation"]."<br />";
            echo "accept condidature: ".$_POST["accept condidature"]."<br />";
        }      
?>