<!-- SlidePanel -->
    <div id="slidein-panel" style="z-index:100;height:100%">
        <!-- SlidePanel Button Container -->
        <div id="slidein-panel-container">
            <a id="slidein-panel-btn" href="#"><i class="icon-list"></i></a>
        </div>
        <!-- /SlidePanel Button Container -->

        <!-- SlidePanel Content -->
        <!--
        <ul>
            <li><a href="#"><i class="icon-gear"></i>&nbsp; Settings</a></li>
            <li><a href="#"><i class="icon-music"></i>&nbsp; Music</a></li>
            <li><a href="#"><i class="icon-facetime-video"></i>&nbsp; Video</a></li>
            <li><a href="#"><i class="icon-cloud-upload"></i>&nbsp; Cloud</a></li>
            <li><a href="#"><i class="icon-bell-alt"></i>&nbsp; Alarm</a></li>
            <li><a href="#"><i class="icon-comment"></i>&nbsp; Comment</a></li>
            <li><a href="#"><i class="icon-envelope"></i>&nbsp; Inbox</a></li>
            <li><a href="#"><i class="icon-bookmark"></i>&nbsp; Bookmarks</a></li>  
            <li><a href="#"><i class="icon-off"></i>&nbsp; Logout</a></li>
        </ul>
        -->

        <!--  Inicio Menú Vertical   -->

        <div class="col-lg-12 text-success" id="label_user" style="font-size:17px;">
          <?php echo "Hola! ".$_SESSION['user']; ?> | <a href="index.php?command=salir">Salir</a>
        </div>
        <br />
        <br />
        <div class="btn btn-sm btn-block btn-success" onclick="document.getElementById('ventas').style.display='none',document.getElementById('fotos').style.display='none',document.getElementById('altas').style.display='block',document.getElementById('perfiles').style.display='none',document.getElementById('configuracion').style.display='none'">Altas</div>
                                                            

        <div id="altas" class="text-danger sub-menu" style="display:none;">
           <div class="text-danger text-center"><a href="index.php?command=alta_directivo">Usuarios</a></div>
           <div class="text-danger text-center"><a href="index.php?command=alta_cac">Tiendas</a></div>
           <div class="text-danger text-center"><a href="index.php?command=alta_producto">Productos</a></div>
        </div> 

        <br/>

        <div class="btn btn-sm btn-block btn-success" <?php if($command!='ventas'&&$command!='ventas2'){
                                                              echo "onclick=\"document.location.href='index.php?command=ventas'\"";
                                                            }else{
                                                              echo "onclick=\"document.getElementById('altas').style.display='none',document.getElementById('fotos').style.display='none',document.getElementById('ventas').style.display='block',document.getElementById('perfiles').style.display='none',document.getElementById('configuracion').style.display='none'\"";
                                                            }
                                                      ?> >Ventas</div>
        <div id="ventas" class="text-danger" style="<?php if($command!='ventas'){echo "display:none";} ?>">
          <div class="text-danger text-center">Promotor


                  <select class="text-danger text-center" name="promotor" id="promotor" style="width:95%">
                    <option value="0">Todos</option>
                      <?php
                        global $obj_db;
                        $consulta = "SELECT id_usuario, user_name, id_right FROM usuario WHERE id_right=3 ORDER BY user_name ASC";
                        $result = $obj_db->consulta($consulta);
                        if($result!=false){
                          foreach($result as $fila){
                          echo "<option class='text-danger text-center' value ='".$fila['id_usuario']."'>".$fila['user_name']."</option>";
                          }
                        }
                      ?>
                  </select> 

          </div>

          <div class="text-danger text-center">Region

                  <select class="text-danger text-center" name="estados" id="estados" style="width:95%">
                    <option value="0">Todos</option>
                      <?php
                        global $obj_db;
                        $consulta = "SELECT id_estado, nombre FROM estados ORDER BY nombre ASC";
                        $result = $obj_db->consulta($consulta);
                        if($result!=false){
                          foreach($result as $fila){
                          echo "<option class='text-danger text-center' value ='".$fila['id_estado']."'>".utf8_encode($fila['nombre'])."</option>";
                          }
                        }
                      ?>
                  </select> 

          </div>

          <div class="text-danger text-center">Tiendas

                  <select class="text-danger text-center" name="cac_menu" id="cac_menu" style="width:95%">
                    <option value="0">Todas</option>
                      <?php
                        global $obj_db;
                        $consulta = "SELECT id_cac, cac_name FROM cac ORDER BY cac_name ASC";
                        $result = $obj_db->consulta($consulta);
                        if($result!=false){
                          foreach($result as $fila){
                          echo "<option class='text-danger text-center' value ='".$fila['id_cac']."'>".utf8_encode($fila['cac_name'])."</option>";
                          }
                        }
                      ?>
                  </select> 

          </div>
          <div class="text-danger text-center">Fecha
            <input type="text" value='' id="fecha_i" style="width:95%" placeholder="Fecha Inicial">
            <input type="text" value='' id="fecha_f" style="width:95%" placeholder="Fecha Final">
          </div>

          <br>

          <div class="text-danger" style="text-align:right;">
            <div id="btn_buscar_filtrar" style="width:40%;margin-left:55%" class="btn btn-sm btn-block btn-success">Buscar</div>
          </div>

        </div> 

        <br />
        <div class="btn btn-sm btn-block btn-success" <?php if($command!='fotos'){
                                                              echo "onclick=\"document.location.href='index.php?command=fotos'\"";
                                                            }else{
                                                              echo "onclick=\"document.getElementById('altas').style.display='none',document.getElementById('ventas').style.display='none',document.getElementById('fotos').style.display='block',document.getElementById('perfiles').style.display='none',document.getElementById('configuracion').style.display='none'\"";
                                                            }
                                                      ?> >Fotos</div>
        <div id="fotos" class="text-danger" style="<?php if($command!='fotos'){echo "display:none";} ?>">
          <div class="text-danger text-center">Promotor


                  <select class="text-danger text-center" name="promotor_fotos" id="promotor_fotos" style="width:95%">
                    <option value="0">Todos</option>
                      <?php
                        global $obj_db;
                        $consulta = "SELECT id_usuario, user_name, id_right FROM usuario WHERE id_right=3 ORDER BY user_name ASC";
                        $result = $obj_db->consulta($consulta);
                        if($result!=false){
                          foreach($result as $fila){
                          echo "<option class='text-danger text-center' value ='".$fila['id_usuario']."'>".$fila['user_name']."</option>";
                          }
                        }
                      ?>
                  </select> 

          </div>

          <div class="text-danger text-center">Tiendas

                  <select class="text-danger text-center" name="cac_fotos" id="cac_fotos" style="width:95%">
                    <option value="0">Todos</option>
                      <?php
                        global $obj_db;
                        $consulta = "SELECT id_cac, cac_name FROM cac ORDER BY cac_name ASC";
                        $result = $obj_db->consulta($consulta);
                        if($result!=false){
                          foreach($result as $fila){
                          echo "<option class='text-danger text-center' value ='".$fila['id_cac']."'>".$fila['cac_name']."</option>";
                          }
                        }
                      ?>
                  </select> 

          </div>
          
          <div class="text-danger text-center">Clasificación

                  <select class="text-danger text-center" name="fotos_clasificacion" id="fotos_clasificacion" style="width:95%">
                    <option value="0">Todos</option>
                      <?php
                        global $obj_db;
                        $consulta = "SELECT id_fotos_clasificacion, fotos_clasificacion_name FROM fotos_clasificacion ORDER BY fotos_clasificacion_name ASC";
                        $result = $obj_db->consulta($consulta);
                        if($result!=false){
                          foreach($result as $fila){
                          echo "<option class='text-danger text-center' value ='".$fila['id_fotos_clasificacion']."'>".$fila['fotos_clasificacion_name']."</option>";
                          }
                        }
                      ?>
                  </select> 

          </div>
        </div> 
        <br />
        <div class="btn btn-sm btn-block btn-success" onclick="document.getElementById('ventas').style.display='none',document.getElementById('fotos').style.display='none',document.getElementById('altas').style.display='none',document.getElementById('perfiles').style.display='block',document.getElementById('configuracion').style.display='none'">Perfiles</div>
        <div id="perfiles" class="text-danger sub-menu" style="display:none;">
           <div class="text-danger text-center"><a href="index.php?command=perfil_directivo">Usuarios</a></div>
           <div class="text-danger text-center"><a href="index.php?command=perfil_cac">Tiendas</a></div>
           <div class="text-danger text-center"><a href="index.php?command=perfil_producto">Productos</a></div>
        </div> 
        <br />
        <div class="btn btn-sm btn-block btn-success" onclick="document.getElementById('ventas').style.display='none',document.getElementById('fotos').style.display='none',document.getElementById('altas').style.display='none',document.getElementById('perfiles').style.display='none',document.getElementById('configuracion').style.display='block'">Configuración</div>
        <div id="configuracion" class="text-danger sub-menu" style="display:none;">
           <div class="text-danger text-center"><a href="index.php?command=form_extras">Campos Personalizados</a></div> 
           <div class="text-danger text-center"><a href="index.php?command=agregar_formulario">Formularios Personalizados</a></div>          
        </div>
        <br />
        
        <!--  Fin Menú Vertical  -->

        <!-- /SlidePanel Content -->
    </div>
    <!-- /SlidePanel -->

   

      