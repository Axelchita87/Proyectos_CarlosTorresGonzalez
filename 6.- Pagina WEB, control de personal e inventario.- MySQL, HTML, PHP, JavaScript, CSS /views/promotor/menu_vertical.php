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
              <a href="index.php?command=promotor">
                <i class="fa fa-dashboard"></i> <span>Dashboard</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li>
            <!-- <li class="treeview">
              <a href="index.php?command=ventas_promotor">
                <i class="fa fa-shopping-cart"></i> <span>Ventas</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li> -->
            <!-- <li class="treeview">
              <a href="index.php?command=reportes_promotor">
                <i class="fa fa-plus-square-o"></i> <span>Reportes</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li> -->
            <li class="treeview">
              <a href="index.php?command=fotos_promotor">
                <i class="fa fa-picture-o"></i> <span>Fotos</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li>
            <!-- <li class="treeview">
              <a href="index.php?command=producto_promotor">
                <i class="fa fa fa-archive"></i> <span>Productos</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li> -->
            <!-- <li class="treeview">
              <a href="index.php?command=cuestionario1_promotor">
                <i class="fa fa-folder"></i> <span>Cuestionarios</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li> -->
            <!-- <li class="treeview">
              <a href="index.php?command=contestar_formulario&formulario=p_f_<?php echo isset($fila3['id_form'])?$fila3['id_form']:''; ?>">
                <i class="fa fa-book"></i> <span>Capacitación</span> <i class="fa fa-angle-left pull-right"></i>
              </a>
            </li> -->
            <li class="header">&nbsp;</li>
            <li><a href="#"><i class="fa fa-circle-o text-red"></i> <span>Política de privacidad</span></a></li>
            <li><a href="#"><i class="fa fa-circle-o text-aqua"></i> <span>Información</span></a></li>
          </ul>
        </section>
        <!-- /.sidebar -->
      </aside>
