<?php
/**
 * Template Name: Blog Template
 */ 
get_header();
?>
	<h1>My Blog:</h1>
	
<?php
		//Showing posts from author
		$counter = 0;
		$blog_query = new WP_Query('autoh = 1');
		if($blog_query->have_posts() ):
			while( $blog_query->have_posts() ):
			
				$blog_query->the_post(); 
				$counter +=1;
	?> 
		<h2><?php echo ($counter. ". ");  the_title() ?> </h2>
		<div>
			<?php the_content();?>
		</div>
		<hr/>
	<?php 
			endwhile;
		endif;
		wp_reset_query();
	?>
<?php get_footer(); ?>