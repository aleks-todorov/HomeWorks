var applicationName = navigator.appName;
var addScroll = false;
var possitionX = 0;
var possitionY = 0;
var theLayer;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

document.onmousemove = mouseMove;

if (applicationName === "Netscape") {
    document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(evn) {
    if (applicationName === "Netscape") {
        possitionX = evn.pageX - 5;
        possitionY = evn.pageY;
    } else {
        possitionX = event.x - 5;
        possitionY = event.y;
    }

    if (applicationName === "Netscape") {
        if (document.layers.toolTip.visibility === 'show') {
            popTip();
        }
    } else {
        if (document.all.toolTip.style.visibility === 'visible') {
            popTip();
        }
    }
}

function popTip() {

    if (applicationName === "Netscape") {
        theLayer = document.layers.toolTip;

        if ((possitionX + 120) > window.innerWidth) {
            possitionX = window.innerWidth - 150;
        }
        theLayer.left = possitionX + 10;
        theLayer.top = possitionY + 15;
        theLayer.visibility = 'show';
    } else {
        theLayer = document.all.toolTip;

        if (theLayer) {
            possitionX = event.x - 5;
            possitionY = event.y;

            if (addScroll) {
                possitionX = possitionX + document.body.scrollLeft;
                possitionY = possitionY + document.body.scrollTop;
            }

            if ((possitionX + 120) > document.body.clientWidth) {
                possitionX = possitionX - 150;
            }
            theLayer.style.pixelLeft = possitionX + 10;
            theLayer.style.pixelTop = possitionY + 15;
            theLayer.style.visibility = 'visible';
        }
    }
}

function hideTip() {
    if (applicationName === "Netscape") {
        document.layers.toolTip.visibility = 'hide';
    } else {
        document.all.toolTip.style.visibility = 'hidden';
    }
}

function hideMenu1() {
    if (applicationName === "Netscape") {
        document.layers.menu1.visibility = 'hide';
    } else {
        document.all.menu1.style.visibility = 'hidden';
    }
}

function showMenu1() {
    if (applicationName === "Netscape") {
        theLayer = document.layers.menu1;
        theLayer.visibility = 'show';
    } else {
        theLayer = document.all.menu1;
        theLayer.style.visibility = 'visible';
    }
}

function hideMenu2() {
    if (applicationName === "Netscape") {
        document.layers.menu2.visibility = 'hide';
    } else {
        document.all.menu2.style.visibility = 'hidden';
    }
}

function showMenu2() {
    if (applicationName === "Netscape") {
        theLayer = document.layers.menu2;
        theLayer.visibility = 'show';
    } else {
        theLayer = document.all.menu2;
        theLayer.style.visibility = 'visible';
    }
}