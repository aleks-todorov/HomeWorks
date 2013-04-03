//Task 7: 
//Write a script that parses an URL address given in the format:
//[protocol]://[server]/[resource]
//and extracts from it the [protocol], [server] and [resource] elements. Return the elements in a JSON object.For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//{protocol: "http",
//server: "www.devbg.org", 
//resource: "/forum/index.php"}

//As suggesed in http://stackoverflow.com/questions/6168260/how-to-parse-a-url
var link = "http://www.devbg.org/forum/index.php";

function CreateJsonFromLink(link) {
    var url = document.createElement('a');
    url.href = link;
    var jsonLink = {
        protocol: url.protocol,
        server: url.hostname,
        resource: url.pathname
    }
    return jsonLink;
}

console.log(CreateJsonFromLink(link));