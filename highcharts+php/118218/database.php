<?php

	$dbhost= 'localhost';
	$dbname= 'siteweb';
	$dbuser= 'root';
	$dbpass= '';

	try {
		$db = new PDO("mysql:host={$dbhost};dbname={$dbname}", $dbuser, $dbpass);
		$db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
		//echo "Connecté > OK !";
		
	} catch (PDOException $e){
		echo $e;
	}
?>