<div class="sidebar">
<?php 
	if( !dynamic_sidebar('right-sidebar')): 
?>
				<!-- insert your sidebar items here -->
				<h3>Latest News</h3>
				<h5>January 1st, 2011</h5>
				<p>
					2011 sees the redesign of our website. Take a look around and let
					us know what you think.<br />
					<a href="#">Read more</a>
				</p>
				<h5>January 1st, 2011</h5>
				<p>
					2011 sees the redesign of our website. Take a look around and let
					us know what you think.<br />
					<a href="#">Read more</a>
				</p>
				<h3>Useful Links</h3>
				<ul>
					<li><a href="#">link 1</a></li>
					<li><a href="#">link 2</a></li>
					<li><a href="#">link 3</a></li>
					<li><a href="#">link 4</a></li>
				</ul>
				<h3>Search</h3>
				<form method="post" action="#" id="search_form">
					<p>
						<input class="search" type="text" name="search_field"
							value="Enter keywords....." /> 
						<input name="search" type="image"
							style="border: 0; margin: 0 0 -9px 5px;" src="<?php echo get_template_directory_uri();?>/images/search.png"
							alt="Search" title="Search" />
					</p>
				</form>
<?php endif; ?>
		</div>	