//Task 12 
//Write a function that creates a HTML UL using a template for every HTML LI. The source of the list should an array of elements. Replace all placeholders marked with –{…}–   with the value of the corresponding property of the object. Example: 
//<div data-type="template" id="list-item">
//<strong>-{name}-</strong> <span>-{age}-</span>
//div>
//var people = [{name: "Peter", age: 14},…];
//var tmpl = document.getElementById("list-item").innerHtml;
//var peopleList = generateList(people, template);
//peopleList = "<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>"

var people = [{ name: "Peter", age: 14 }, { name: "John", age: 23 }, { name: "Tom", age: 4 }, { name: "Mike", age: 18 }];
var temp = document.getElementById("list-item").innerHTML;
var finalArr = generateList(temp, people);

	for (var i = 0; i < finalArr.length; i+=2) {
	console.log("<ul><li><strong>" + finalArr[i] + "</strong><span>" + finalArr[i + 1] + "</span></li><li>…</li>…</ul>")
	}
function generateList(temp,people)
{
var holder = temp;
var liArr = [];
for (var person in people) {
var index = temp.indexOf("{name}");
var index2 = temp.indexOf("{age}");
temp = temp.replace("{name}", people[person].name);
liArr.push(temp.substr(index, people[person].name.length));
temp = holder;
temp = temp.replace("{age}", people[person].age);
liArr.push(temp.substr(index2, people[person].age.toString().length));
temp = holder;
}
return liArr;
}
}