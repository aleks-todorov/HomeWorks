/// <reference path="../../Scripts/jquery-2.0.2.js" />
(function () {

    var map;
    var x = 42.691394;
    var y = 23.314362;
    var z = 9;

    function initialize() {
        var mapOptions = {
            zoom: z,
            center: new google.maps.LatLng(x, y),
            mapTypeId: google.maps.MapTypeId.ROADMAP //SATELITE
        };
        map = new google.maps.Map(document.getElementById('map-container'),
            mapOptions);
    }

    google.maps.event.addDomListener(window, 'load', initialize());

    $('#capitals').on('change', function () {
        var text;
        if (this.value === "Sofia") {
            x = 42.691394;
            y = 23.314362;
            text = "Sofia (Bulgarian: София, pronounced [ˈsɔfijɐ] ( listen)) is the capital and largest city of Bulgaria. Sofia is located at the foot of Mount Vitosha in the western part of the country. It occupies a strategic position at the centre of the Balkan Peninsula.[5] Sofia's history spans 2,400 years. Its ancient name Serdica derives from the local Celtic tribe of the serdi who established the town in the 5th century BC. It remained a relatively small settlement until 1879, when it was declared the capital of Bulgaria.";
        }
        else if (this.value === "Rome") {
            x = 41.893525;
            y = 12.493515;
            text = "Rome (/ˈroʊm/; Italian: Roma pronounced [ˈroːma] ( listen); Latin: Rōma) is a city and special comune (named 'Roma Capitale') in Italy. Rome is the capital of Italy and also of the homonymous province and of the region of Lazio. With 2.8 million residents in 1,285.3 km2 (496.3 sq mi), it is also the country's largest and most populated comune and fifth-most populous city in the European Union by population within city limits. Between 3.2 and 3.8 million people live in the Rome urban and metropolitan area.[3][4][5][6][7][8] The city is located in the central-western portion of the Italian Peninsula, on the Tiber within the Lazio region of Italy. Rome is referred to as 'The Eternal City', a notion expressed by ancient Roman poets and writers.";
        }
        else if (this.value === "London") {
            x = 51.512909;
            y = -0.122223;
            text = "London i/ˈlʌndən/ is the capital of England and the United Kingdom. With an estimated 8,308,369 residents as of 2012, London is the most populous region, urban zone and metropolitan area in the United Kingdom.[note 1] Standing on the River Thames, London has been a major settlement for two millennia, its history going back to its founding by the Romans, who named it Londinium.[5] London's ancient core, the City of London, largely retains its 1.12-square-mile (2.9 km2) mediaeval boundaries. With its population of 7,375 as of 2011, it is the smallest city in England. Since at least the 19th century, the term London has also referred to the metropolis developed around this core.[6] The bulk of this conurbation forms the London region[7] and the Greater London administrative area,[8][note 2] governed by the Mayor of London and the London Assembly.[9]";
        }
        else if (this.value === "Paris") {
            x = 48.851840;
            y = 2.364807;
            text = "Paris (English /ˈpærɪs/, i/ˈpɛrɪs/; French: [paʁi] ( listen)) is the capital and most populous city of France. It is situated on the river Seine, in the northern central part of the country, at the heart of the Île-de-France region. Within its administrative limits (the 20 arrondissements), Paris has a population of about 2,230,000, and its metropolitan area is one of the largest population centres in Europe, with more than 12 million inhabitants. Inhabitants of the city are referred to as 'Parisians' (English /pəˈrɪzɪənz/ or /pəˈriʒənz/; French: Parisiens (masculine) – French pronunciation: ​[pa.ʁi.zjɛ̃] or Parisiennes (feminine) – French pronunciation: ​[pa.ʁi.zjɛn]).";
        }
        else if (this.value === "Vienna") {
            x = 48.176618;
            y = 16.408081;
            text = "Vienna (/viːˈɛnə/; German:  Wien (help·info) [viːn], Austro-Bavarian: Wean) is the capital and largest city of Austria, and one of the nine states of Austria. Vienna is Austria's primary city, with a population of about 1.757 million[5] (2.4 million within the metropolitan area,[4] more than 20% of Austria's population), and is by far the largest city in Austria, as well as its cultural, economic, and political centre. It is the 7th-largest city by population within city limits in the European Union. Until the beginning of the 20th century it was the largest German-speaking city in the world, and before the splitting of the Austro-Hungarian Empire in World War I the city had 2 million inhabitants.[6] Vienna is host to many major international organizations, including the United Nations and OPEC. The city lies in the east of Austria and is close to the borders of the Czech Republic, Slovakia, and Hungary. These regions work together in a European Centrope border region. Along with nearby Bratislava, Vienna forms a metropolitan region with 3 million inhabitants. In 2001, the city centre was designated a UNESCO World Heritage Site.[7]";
        }
        else if (this.value === "Berlin") {
            x = 52.479017;
            y = 13.452759;
            text = "Berlin (/bərˈlɪn/; German pronunciation: [bɛɐ̯ˈliːn] ( listen)) is the capital city of Germany and one of the 16 states of Germany. With a population of 3.3 million people,[1] Berlin is Germany's largest city and is the second most populous city proper and the seventh most populous urban area in the European Union.[4] Located in northeastern Germany on the River Spree, it is the center of the Berlin-Brandenburg Metropolitan Region, which has about 4½ million residents from over 180 nations.[5][6][7][8] Due to its location in the European Plain, Berlin is influenced by a temperate seasonal climate. Around one third of the city's area is composed of forests, parks, gardens, rivers and lakes.[9]";
        }
        else if (this.value === "Madrid") {
            x = 40.366951;
            y = -3.663940;
            text = "Madrid (English /məˈdrɪd/, Spanish: [maˈðɾið]) is the capital of Spain and its largest city. The population of the city is roughly 3.3 million[4] and the entire population of the Madrid metropolitan area is calculated to be around 6.5 million. It is the third-largest city in the European Union, after London and Berlin, and its metropolitan area is the third-largest in the European Union after London and Paris.[5][6][7][8] The city spans a total of 604.3 km2 (233.3 sq mi).[9]";
        }
        else if (this.value === "Budapest") {
            x = 47.351850;
            y = 19.313965;
            text = "Budapest (/ˈbuːdəpɛʃt/, /ˈbuːdəpɛst/ or /ˈbʊdəpɛst/; Hungarian pronunciation: [ˈbudɒpɛʃt] ( listen); names in other languages) is the capital and the largest city of Hungary,[1] the largest in East-Central Europe and the seventh largest in the European Union. It is the country's principal political, cultural, commercial, industrial, and transportation centre,[2] sometimes described as the primate city of Hungary.[3] In 2011, according to the census, Budapest had 1.74 million inhabitants,[4] down from its 1989 peak of 2.1 million[5] due to suburbanization.[6] The Budapest Commuter Area is home to 3.3 million people.[7][8] The city covers an area of 525 square kilometres (202.7 sq mi)[9] within the city limits. Budapest became a single city occupying both banks of the river Danube with a unification on 17 November 1873 of west-bank Buda and Óbuda with east-bank Pest.[9][10]";
        }
        else if (this.value === "Prague") {
            x = 49.999795;
            y = 14.556885;
            text = "Prague (/ˈprɑːɡ/; Czech: Praha pronounced [ˈpraɦa] ( listen)) is the capital and largest city of the Czech Republic. It is the fourteenth-largest city in the European Union.[6] It is also the historical capital of Bohemia proper. Situated in the north-west of the country on the Vltava river, the city is home to about 1.3 million people, while its larger urban zone is estimated to have a population of nearly 2 million.[4] The city has a temperate oceanic climate, with warm summers and chilly winters.";
        }
        else if (this.value === "Helsinki") {
            x = 60.132957;
            y = 24.999390;
            text = "Helsinki (Finnish pronunciation: [ˈhe̞l.siŋ.k̟i])  listen (help·info); Swedish: Helsingfors,  listen (help·info)) is the capital and largest city of Finland. It is in the region of Uusimaa, located in southern Finland, on the shore of the Gulf of Finland, an arm of the Baltic Sea. Helsinki has a population of 605,523 (28 February 2013),[3] an urban population of 1,159,211 (31 December 2011)[7] and a metropolitan population of 1,361,506, making it by far the most populous municipality and urban area in Finland. Helsinki is located some 80 kilometres (50 mi) north of Tallinn, Estonia, 400 kilometres (250 mi) east of Stockholm, Sweden, and 300 kilometres (190 mi) west of Saint Petersburg, Russia. Helsinki has close historical connections with these three cities.";
        }

        google.maps.event.addDomListener(window, 'load', initialize());

        $('#infobox').remove();
        $('<div id="infobox"></div>').appendTo('body');
        $('<h2>' + this.value + '</h2>').appendTo('#infobox');
        $('<p>' + text + '</p>').appendTo('#infobox');
    });
})();