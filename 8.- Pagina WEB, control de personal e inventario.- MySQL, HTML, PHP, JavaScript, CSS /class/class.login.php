<?php
require_once 'class.db.php';
	class Log{
	public $permiso;
		function login($user,$pass){
			global $obj_db;
			$qry="SELECT * FROM usuario,permiso WHERE usuario.user_name='".$user."'"
				." AND usuario.user_pass='".$pass."' AND usuario.id_right=permiso.id_right";

			$resp=$obj_db->consulta($qry);
			if($resp!=false){
				foreach($resp as $row):
					if($row['user_name']!="" && $row['right_name']=='directivo'){
						if(session_id() == '') {
    						session_start();
						}
						$_SESSION['user_id']=$row['id_usuario'];
						$_SESSION['user']=$row['user_name'];
						$_SESSION['permiso']=$row['right_name'];
	?>
						<script>
							document.location.href="index.php?command=directivo";
						</script>
	<?php
					}
					else if($row['user_name']!="" && $row['right_name']=='auditor'){
						if(session_id() == '') {
 						   session_start();
						}
						$_SESSION['user_id']=$row['id_usuario'];
						$_SESSION['user']=$row['user_name'];
						$_SESSION['permiso']=$row['right_name'];
	?>
						<script>
							document.location.href="index.php?command=auditor";
						</script>
	<?php
					}
					else if($row['user_name']!="" && $row['right_name']=='promotor'){
						if(session_id() == '') {
    						session_start();
						}
						$_SESSION['user_id']=$row['id_usuario'];
						$_SESSION['user']=$row['user_name'];
						$_SESSION['permiso']=$row['right_name'];
	?>
						<script>
							document.location.href="index.php?command=promotor";
						</script>
	<?php
					}

				endforeach;
				return $resp;
			}
			else{
				$error="Usuario y/o contrase&ntilde;a incorrecta";
				return $error;
			}

		}

	}

	if(isset($_POST['entrar'])){

		$login=new Log();
		$user=$_POST['usuario'];
		$pass=$_POST['contrasena'];
		$r=$login->login($user,$pass);
		if($r!=""){
	?>
			<div class="alert-danger container text-center" id="message">
				<button type="button" class="close" onclick="document.getElementById('message').style.display='none'">x</button>
				<h4><?php echo $r; ?></h4>
			</div>
	<?php
		}
	}
	?>