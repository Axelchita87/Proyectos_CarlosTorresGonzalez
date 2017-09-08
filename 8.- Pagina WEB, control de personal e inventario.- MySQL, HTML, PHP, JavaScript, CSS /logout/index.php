<?php
if(session_id() == '') {
    session_start();
}
session_destroy();
session_unset();
$_SESSION['user_id'];
$_SESSION['user'];
$_SESSION['permiso'];
?>
<script>
document.location.href="index.php?command=home";
</script>
