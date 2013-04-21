<!DOCTYPE HTML>
<html>
<head>
<title>shadowplay_2</title>
<meta name="description" content="website description" />
<meta name="keywords" content="website keywords, website keywords" />
<meta http-equiv="content-type"
	content="text/html; charset=windows-1252" />
<link rel="stylesheet" type="text/css"
	href="<?php bloginfo ('stylesheet_url'); ?>" />
<?php wp_head(); ?>
</head>

<body>
	<div id="main">
		<div id="header">
			<div id="logo">
				<div id="logo_text">
					<!-- class="logo_colour", allows you to change the colour of the text -->
					<h1>
						<a href="index.html">shadow<span class="logo_colour">play_2</span></a>
					</h1>
					<h2>Simple. Contemporary. Website Template.</h2>
				</div>
			</div>
			<?php wp_nav_menu(array(
					'theme_location' => 'top-site-menu',
					'container_class' => 'menu',
				))?> 
		</div>
		<div id="content_header"></div>
		<div id="site_content">
			<?php get_sidebar('right-sidebar')?>
			<div id="content">