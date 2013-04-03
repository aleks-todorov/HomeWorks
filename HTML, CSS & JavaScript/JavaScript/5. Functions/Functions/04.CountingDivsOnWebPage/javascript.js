//Task 4: 
//Write a function to count the number of divs on the web page

function CountDivs() {
    var numberOfDivs = document.getElementsByTagName('div');
    alert(numberOfDivs.length);
}