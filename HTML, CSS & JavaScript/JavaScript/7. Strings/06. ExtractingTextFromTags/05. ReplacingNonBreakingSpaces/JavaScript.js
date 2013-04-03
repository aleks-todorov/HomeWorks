//Task 5: 
//Write a function that replaces non breaking white-spaces in a text with &nbsp;

var text = "Write a function that replaces non breaking white-spaces in a text with &nbsp";
//Not sure if this is the desired output :? 
text = text.replace(/\s/g, "&nbsp");
console.log(text);