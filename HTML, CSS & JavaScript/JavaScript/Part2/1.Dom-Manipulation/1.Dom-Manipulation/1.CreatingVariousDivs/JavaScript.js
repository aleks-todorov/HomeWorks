/*Write a script that creates a number of div elements.Each div element must have the following
Random width and height between 20px and 100px
Random background color
Random font color
Random position on the screen (position:absolute)
A strong element with text "div" inside the div
Random border-radius
Random border color
Random border-width between 1px and 20px
*/

function generateDivs() {
    var numberOfDivs = parseInt(document.getElementById("numberOfDivs").value);
    for (var i = 0; i < numberOfDivs; i++) {
        createDiv();
    }
}
  
function createDiv() {
    var maxWidth = screen.width - 300;
    var maxHeight = screen.height - 300;
    var generatedDiv = document.createElement("div");
    document.body.appendChild(generatedDiv);

    //Setting Styles
    generatedDiv.style.width = randomNumberGenerator(20, 80) + "px";
    generatedDiv.style.height = randomNumberGenerator(20, 80) + "px";
    generatedDiv.style.backgroundColor = randomColorGenerator();
    generatedDiv.style.position = "absolute";
    generatedDiv.style.top = randomNumberGenerator(30, maxHeight) + "px";
    generatedDiv.style.left = randomNumberGenerator(30, maxWidth) + "px";
    generatedDiv.innerHTML = "<strong>div</strong>";
    generatedDiv.style.color = randomColorGenerator();
    generatedDiv.style.textAlign = "center";
    generatedDiv.style.borderRadius = randomNumberGenerator(0, 50) + "px";
    generatedDiv.style.borderColor = randomColorGenerator();
    generatedDiv.style.borderWidth = randomNumberGenerator(1, 20) + "px";
    generatedDiv.style.borderStyle= "solid"
}


function randomNumberGenerator(minValue, maxValue) {
    var random = Math.floor((Math.random() * maxValue) + minValue);
    return random;
}

function randomColorGenerator() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.round(Math.random() * 15)];
    }
    return color;
}