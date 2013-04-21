<?php

//Registering Menues
register_nav_menu('top-site-menu', "This is my top site menu");

//Registering Rigt Sidebar
$sidebar_args = array(
		'id' => 'right-sidebar',
		'name' => 'Main Sidebar',
);
register_sidebar( $sidebar_args );