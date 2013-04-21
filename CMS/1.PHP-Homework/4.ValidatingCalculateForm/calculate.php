<?php
	$numberOne = $_GET["numberOne"];
	$sign = $_GET["sign"];
	$numberTwo = $_GET["numberTwo"];
	$signIsCorrect = FALSE;
	
	//Data validation was not made with JS, but it was more interesting for me to try it with PHP. 
	if ($sign == '+' || $sign == '-' || $sign  == '*' || $sign == '/'){
		$signIsCorrect = TRUE;
	}
	
	if (is_numeric($numberOne) && is_numeric($numberTwo) && $signIsCorrect=== TRUE) {
		echo $numberOne . " " . $sign . " " . $numberTwo . "= ";
		switch ($sign){
			case '+': echo ($numberOne + $numberTwo); break;
			case '-': echo ($numberOne - $numberTwo); break;
			case '*': echo ($numberOne * $numberTwo); break;
			case '/': echo ($numberOne / $numberTwo); break;
		}
	}
	else {
		echo ("The input data was not correct. Please provided valid data!");
		echo ("<a href=\"index.html\"> Go Back!</a>");
	}
?>