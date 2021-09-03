<?php
$dbhost = 'localhost';
$dbname = 'lecture_temperature';
$dbuser = 'root';
$dbpass = '';

try {
    $dbcon = new PDO("mysql:host={$dbhost};dbname={$dbname}",$dbuser,$dbpass);
    $dbcon->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $ex) {
    die($ex->getMessage());
}
$stmt=$dbcon->prepare("SELECT * FROM temperature");
$stmt->execute();
$json = [];
while ($row=$stmt->fetch(PDO::FETCH_ASSOC)) {
    extract($row);
    $json[]= [(int)$tempext];
	
}
echo json_encode($json);

?>