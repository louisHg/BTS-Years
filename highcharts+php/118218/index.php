<!-- <?php session_start(); 

	echo $_SESSION['email'];
?> -->
<!DOCTYPE html>
<html>
<head>
	<title>Page de connexion</title>
	<meta charset="utf-8">
        <!-- importer le fichier de style -->
        <link rel="stylesheet" href="style.css" media="screen" type="text/css" />
</head>
<body>
	<!-- Login -->
	<h1>Login</h1>
	<form method="post">
		<input type="email" name="lemail" id="lemail" placeholder="Email"><br/>
		<input type="password" name="lpassword" id="lpassword" placeholder="Mot de passe"><br/>
		<input type="submit" name="formlogin" id="formlogin" value="Connexion"><br/>
	</form>

	<?php

		if(isset($_POST['formlogin']))
		{
			extract($_POST);

			if(!empty($lemail) && !empty($lpassword))
			{

				include 'database.php';
				global $db;

				$q = $db->prepare("SELECT * FROM site WHERE email = :email");
				$q->execute(['email' => $lemail]);
				$result = $q->fetch();

				if($result == true)
				{

					$secur = $result['password'];
					if(password_verify($lpassword, $secur))
					{
						echo "le mot de passe est bon";
						header('Location: http://' . $_SERVER['HTTP_HOST'] . '/temperature/index.php');
						exit;
					}
					else
					{
						echo "Mot de passe erronée";
					}
				}
				else
				{
					echo "le compte n'existe pas";
				}
			}
		}
	?>
	<!-- Inscription -->
	<h1>Incription</h1>
	<form method="post">
		<input type="email" name="email" id="email" placeholder="Email"><br/>
		<input type="password" name="password" id="password" placeholder="Mot de passe"><br/>
		<input type="password" name="cpa" id="cpa" placeholder="Confirmation Mot de passe"><br/>
		<input type="submit" name="formsend" id="formsend" value="Inscription">
	</form>

	<?php
		if(isset($_POST['formsend'])){

			extract($_POST);

			if(!empty($password) && !empty($cpa) && !empty($email)){
				

				if($password == $cpa){

					$options = [
					'cost' => 12,
					];

					$secur = password_hash($password, PASSWORD_BCRYPT, $options);

					include 'database.php';
					global $db;

					$c = $db->prepare("SELECT email FROM site WHERE email = :email");
					$c->execute(['email' => $email]);

					$resu = $c->rowCount();

					if($resu == 0){

						$q = $db->prepare("INSERT INTO site(email,password) VALUES(:email,:password)");
						$q->execute([
						'email' => $email,
						'password' => $secur
					]);
					echo "Le compte est crée";
					}else{
						echo "Email deja utilisé!";
					}
				}

				// if(password_verify($password, $secur)){
				// 	echo "Bon Mot de passe";
				// } else {
				// 	echo "Mauvais Mot de passe";
				// }
			}


		}
	?>

</body>
</html>