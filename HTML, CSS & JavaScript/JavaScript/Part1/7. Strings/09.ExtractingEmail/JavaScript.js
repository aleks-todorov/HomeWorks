//Task 9: 
//Write a function for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails. Return the emails as array of strings.

var text = "My name is John Smith and my email address is jsmith_23@something.com. Before that I was using smith_johny15@abv.bg but there was some problem with receiving emails...";
var emails = text.match(/([\w-\.]+)@((?:[\w]+\.)+)([a-zA-Z]{2,4})/g);
console.log(emails);