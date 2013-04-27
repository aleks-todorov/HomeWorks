var wrapper = document.createElement("div");
wrapper.classList.add("wrapper");
document.body.appendChild(wrapper);
var currentAngle = 90;
var radius = 100;
createDivs(wrapper);

function createDivs(wrapper) {
   
    var top = 200 + Math.cos(currentAngle) * radius;
    var left = 200 + Math.sin(currentAngle) * radius;
    var generatedDiv = document.createElement("div");
    generatedDiv.classList.add("rotatingDiv");
    wrapper.appendChild(generatedDiv);
    generatedDiv.style.width = "50px";
    generatedDiv.style.height = "50px";
    generatedDiv.style.borderRadius = "25px"
    generatedDiv.style.backgroundColor = randomColorGenerator();
    generatedDiv.style.position = "absolute";
    generatedDiv.style.top = top + "px";
    generatedDiv.style.left = left + "px";
     
    rotateDiv(generatedDiv);
}


function rotateDiv(generatedDiv) {
    top = 200 * Math.cos(angle) + screen.width / 2;
    left = 200 * Math.sin(angle) + screen.height / 2;

}


function randomColorGenerator() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.round(Math.random() * 15)];
    }
    return color;
}