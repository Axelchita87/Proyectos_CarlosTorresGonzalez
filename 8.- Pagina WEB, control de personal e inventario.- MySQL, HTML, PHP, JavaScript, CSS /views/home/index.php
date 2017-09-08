<!-- 

  Mie, 26 de junio, 2016
  ♥ DOBLEU ♥ <salvadoratz@gmail.com>
  Actualización de front end  

-->

<?php
require_once 'class/class.login.php';
?>
 <style type="text/css">
html,body{
 height: 100%;


}



 body{

  background-color: #d2d6de;
 }
 .wraper{

  min-height: 100%;
  height: 100%;
  margin:0 auto -50px;
 }

 .foother{

  height:  50px;
  text-align: center;
  background-color: #dfdfdf;
 }

  .foother img{

  width: 150px;
  color: #848484;
 }


 #div_1{
  width: 70%; 
  margin: 0 auto; 
  padding-top: 200px;
 }

 #div_2{
  width: 30%;
  float: left;
 }
 #div_3{
  float: right;

 }
#image3 {
  width: 200px;
   border-radius:100%; 
   float: right;

}
#div_4{
  width: 50%; 
  float: left;
}
#div_5{
  width: 90%; 
  margin: 0 auto; 
  padding-top: 35px;
}
#div_6{
  width: 20%; 
  float: right;
   padding-top: 35px;

}
#boton{
  height: 115px;
   width: 100px;
}

 @media(max-width: 719px) {
  #div_2{
    float: initial;
    width: 70%;
    text-align: center;
  }

   #div_1{
  width: 70%; 
  margin: 0 auto; 
  padding-top: 80px;
 }

 #div_4{
  width: 78%; 
  float: left;
}

 }

 @media(max-width: 549px) {
  #div_2{
    float: initial;
    width: 80%;
    text-align: center;
  }
#boton{
  height: 115px;
   width: 100%;
   margin: 0 auto;
}
 #div_4{
  width: 100%; 
  float: left;
}
#div_6{
  width: 98%; 
  float: right;
  

}


}

 @media(max-width: 379px) {
  
#div_2{
    float: initial;
    width: 90%;
    text-align: center;
  }

  .foother{

  height:  50px;
  text-align: center;
  background-color: #dfdfdf;
  font-size: 10px;
 }
}




 </style>
<body>

<div class="wraper">

<div id="div_1">

    <div id="div_2">

        <div  id="div_3 "><img id="image3" src="imagina/s1.jpg" ></div>
      
    </div>

    <form action="index.php?command=home" method="POST">

          <div  id="div_4">

                <div id="div_5" >

                      <div class="form-group has-feedback">
                        <input type="text" class="form-control" name="usuario" id="usuario" placeholder="Correo o usuario" style="height: 50px;" />
                        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                      </div>
                      <div class="form-group has-feedback">
                        <input type="password" class="form-control" name="contrasena" id="contrasena" placeholder="Password" style="height: 50px;"/>
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                      </div>

                      <div class="checkbox icheck">
                            <label>
                              <input type="checkbox"> Recordarme
                            </label>
                          </div>
                </div>
            
          </div>
          <div id="div_6" >

          <button  id="boton" type="submit" name="entrar" id="entrar" class="btn btn-primary btn-block btn-flat" > <img src="imagina/arrow.png" ></button>

            
          </div>
          <div style="clear: both;">&nbsp;</div>
    </form>


</div>

            
          
   <!-- <div class="login-box">
      <div class="login-logo">
        <a href="../../index2.html"><b>S</b>igma</a>
      </div><!- /.login-logo ->
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
            </div><!- /.col ->
            <div class="col-xs-4">
              <button type="submit" name="entrar" id="entrar" class="btn btn-primary btn-block btn-flat">Iniciar sesión</button>
            </div><!- /.col ->
          </div>
        </form>

      </div><!- /.login-box-body -->
    <!-- /.login-box ->
</div>-->


</div>

          <div style="clear: both;">&nbsp;</div>

<div class="foother">

<div style="width: 50%; float: left;"><img src="imagina/L2.png"> </div>
<div style="width: 50%; float: left;">Todos lo derechos Reservados. Creado por International Services S.A de C.V </div>


</div>
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
