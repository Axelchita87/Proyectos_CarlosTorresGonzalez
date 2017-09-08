<!-- Left side column. contains the logo and sidebar -->
      <aside class="main-sidebar">
        <!-- sidebar: style can be found in sidebar.less -->
        <section class="sidebar">
          <!-- Sidebar user panel -->
          <div class="user-panel">
            <div class="pull-left image">
              <img src="dist/img/user2-160x160.jpg" class="img-circle" alt="User Image" />
            </div>
            <div class="pull-left info">
              <p><?php echo $_SESSION['user']; ?></p>

              <a href="#"><i class="fa fa-circle text-success"></i> Online</a>
            </div>
          </div>
          <!-- search form -->
          <form action="#" method="get" class="sidebar-form">
            <div class="input-group">
              <input type="text" name="q" class="form-control" placeholder="Search..."/>
              <span class="input-group-btn">
                <button type='submit' name='search' id='search-btn' class="btn btn-flat"><i class="fa fa-search"></i></button>
              </span>
            </div>
          </form>
          <!-- /.search form -->
          <!-- sidebar menu: : style can be found in sidebar.less -->
          <ul class="sidebar-menu">
            <li class="header">NAVEGACIÓN</li>
            <li class="treeview">
              <a href="index.php?command=directivo">
                <i class="fa fa-dashboard"></i> <span>Dashboard</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li>
            <!-- <li class="treeview">
              <a href="index.php?command=ventas">
                <i class="fa fa-shopping-cart"></i> <span>Ventas</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li> -->
            <li class="treeview">
              <a href="#">
                <i class="fa fa-upload"></i> <span>Altas</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                <li><a href="index.php?command=alta_directivo"><i class="fa fa-circle-o"></i> Usuarios</a></li>
                <li><a href="index.php?command=alta_cac"><i class="fa fa-circle-o"></i> Tiendas</a></li>
                <!-- <li><a href="index.php?command=alta_producto"><i class="fa fa-circle-o"></i> Productos</a></li> -->
              </ul>
            </li>
            <li class="treeview">
              <a href="index.php?command=fotos">
                <i class="fa fa-picture-o"></i> <span>Fotos</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li>
            <!-- <li class="treeview">
              <a href="index.php?command=inventario">
                <i class="fa fa-barcode"></i> <span>Inventario</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li> -->
            <li class="treeview">
              <a href="#">
                <i class="fa fa-group"></i> <span>Perfiles</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                <li><a href="index.php?command=perfil_directivo"><i class="fa fa-circle-o"></i> Usuarios</a></li>
                <li><a href="index.php?command=perfil_cac"><i class="fa fa-circle-o"></i> Tiendas</a></li>
                <!-- <li><a href="index.php?command=perfil_producto"><i class="fa fa-circle-o"></i> Productos</a></li> -->
              </ul>
            </li>
            <li class="treeview">
              <a href="#">
                <i class="fa fa-folder"></i> <span>Extras</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
              <ul class="treeview-menu">
                <li><a href="index.php?command=form_extras"><i class="fa fa-circle-o"></i> Campos personalizados</a></li>
                <!-- <li><a href="index.php?command=agregar_formulario"><i class="fa fa-circle-o"></i> Formularios personalizados</a></li> -->
                <!-- <li><a href="index.php?command=respuestas_cuestionario1_directivo"><i class="fa fa-circle-o"></i> Cuestionario Sigma</a></li> -->
                <li><a href="index.php?command=campanas_sigma"><i class="fa fa-circle-o"></i> Campañas Sigma</a></li>
                <li><a href="index.php?command=evaluacion_de_usuarios"><i class="fa fa-circle-o"></i> Evaluación de promotores</a></li>
              </ul>
            </li>
            
            <li class="header">&nbsp;</li>
            <li><a href="#"><i class="fa fa-circle-o text-red"></i> <span>Política de privacidad</span></a></li>
            <li><a href="#"><i class="fa fa-circle-o text-aqua"></i> <span>Información</span></a></li>
          </ul>
        </section>
        <!-- /.sidebar -->
      </aside>