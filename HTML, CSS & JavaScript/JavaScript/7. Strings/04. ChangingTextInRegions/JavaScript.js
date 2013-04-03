//Task 4: 
//You are given a text. Write a function that changes the text in all regions:
//<upcase>text</upcase> to uppercase.
//<lowcase>text</lowcase> to lowercase
//<mixcase>text</mixcase> to mix casing(random)
//We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.
//The expected result:
//We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.
//Regions can be nested

var text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";
var pattern = new RegExp("(<upcase>[^<>]*?</upcase>)", "ig");
text = text.replace(/<upcase>[^<>]*?<\/upcase>/gi, function (out) { return out.toUpperCase() });
text = text.replace(/<lowcase>[^<>]*?<\/lowcase>/gi, function (out) { return out.toLowerCase() });
text = text.replace(/<mixcase>[^<>]*?<\/mixcase>/gi, function (out) { return SetMixCase(out) });
text = text.replace(/<(.*?)>/g, "");
console.log(text);

function SetMixCase(out) {
    var mixedValue = new String();
    for (var i = 0; i < out.length; i++) {
        if (i % 2 == 0) {
            mixedValue += out[i].toUpperCase();
        }
        else {
            mixedValue += out[i];
        }
    }
    return mixedValue;
}

