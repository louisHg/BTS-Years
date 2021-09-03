<?php
try // On essaie de se connecter à MySQL
{
$bdd = new PDO ("mysql:host=localhost;dbname=lecture_temperature",'root','');
}
catch(Exception $e) // En cas d'erreur, on affiche un message et on arrête tout
{
die('Erreur : '.$e->getMessage());
}
// écriture dans la table
if (isset ($_GET ['tempext'])) // test si la variable existe
{
$_GET['tempext'] = floatval($_GET['tempext']); // force le type float pour la variable
echo ('donnee ' .$_GET["tempext"]. ' en cours d\'ecriture</br>');
}
if (isset ($_GET ['tempint'])) // test si la variable existe
{
$_GET['tempint'] = floatval($_GET['tempint']); // force le type float pour la variable
echo ('donnee ' .$_GET["tempint"]. ' en cours d\'ecriture</br>');
}
$bdd->exec('INSERT INTO temperature (tempint,tempext) VALUES('.$_GET['tempext'].','.$_GET['tempint'].')');
echo ('donnee ' .$_GET['tempext'].','.$_GET['tempint']. ' ecrite!');
?>