<?php get_header(); ?>
				 <h1> </h1>
				 <div>
	<?php 
		if( have_posts() ):
			while( have_posts() ):
				the_post(); 
	?> 
		<h2><?php the_title() ?> </h2>
		<div>
			<?php the_content();?>
		</div>
	<?php 
			endwhile;
		endif;
	?>
				 </div>
<?php get_footer();?>