<?php
require_once 'class/class.login.php';
?>

<body class="login-page">
    <div class="login-box">
      <div class="login-logo">
        <a href="../../index2.html"><b>S</b>igma</a>
      </div><!-- /.login-logo -->
      <div class="login-box-body">
        <p class="login-box-msg">Llena el formulario para iniciar sesión</p>
        <form action="index.php?command=home" method="POST">
          <div class="form-group has-feedback">
            <input type="text" class="form-control" name="usuario" id="usuario" placeholder="Correo o usuario"/>
            <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
          </div>
          <div class="form-group has-feedback">
            <input type="password" class="form-control" name="contrasena" id="contrasena" placeholder="Password"/>
            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
          </div>
          <div class="row">
            <div class="col-xs-8">    
              <div class="checkbox icheck">
                <label>
                  <input type="checkbox"> Recordarme
                </label>
              </div>                        
            </div><!-- /.col -->
            <div class="col-xs-4">
              <button type="submit" name="entrar" id="entrar" class="btn btn-primary btn-block btn-flat">Iniciar sesión</button>
            </div><!-- /.col -->
          </div>
        </form>

      </div><!-- /.login-box-body -->
    </div><!-- /.login-box -->

    <script>
      $(function () {
        $('input').iCheck({
          checkboxClass: 'icheckbox_square-blue',
          radioClass: 'iradio_square-blue',
          increaseArea: '20%' // optional
        });
      });
    </script>
  </body>
