<?php
for ($index = 1; $index <= 1000; $index += 1) {
	if ($index % 3 === 0 || $index % 7 ===0 ) {
		echo("$index");
		echo ("<br />");
	}
}
?>