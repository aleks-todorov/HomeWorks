﻿var controls = (function () {

    function hidePrev(item) {
        var prev = item.previousElementSibling;
        while (prev) {

            var sublist = prev.querySelector("ul");
            if (sublist) {
                sublist.style.display = "none";
            }

            prev = prev.previousElementSibling;
        }
    }

    function hideNext(item) {
        var next = item.nextElementSibling;
        while (next) {
            var sublist = next.querySelector("ul");
            if (sublist) {
                sublist.style.display = "none";
            }

            next = next.previousElementSibling;
        }
    }

    function Accordion(selector) {
        var items = [];
        var accItem = document.querySelector(selector);

        accItem.addEventListener("click", function (ev) {
            if (!ev) {
                ev = windows.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            //anchor element
            var clickedItem = ev.target;

            if (!(clickedItem instanceof HTMLAnchorElement)) {
                return;
            }

            hidePrev(clickedItem.parentNode);
            hideNext(clickedItem.parentNode);

            var sublist = clickedItem.nextElementSibling;

            if (!sublist) {
                return;
            }

            if (sublist.style.display === "none") {
                sublist.style.display = "";
            }
            else {
                sublist.style.display = "none";
            }

        }, false);


        var itemsList = document.createElement("ul");

        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
            return newItem;
        };

        this.render = function () {

            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            }

            var thisList = itemsList.cloneNode(true);

            for (var i = 0; i < items.length; i += 1) {
                var domItem = items[i].render();
                thisList.appendChild(domItem);
            }

            accItem.appendChild(thisList);
            return this;
        };

        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < items.length; i += 1) {
                serializedItems.push(items[i].serialize());
            }
            return serializedItems;
        };
    }

    function Item(title) {
        var items = [];

        this.add = function (title) {
            var newItem = new Item(title);
            items.push(newItem);
            return newItem
        }

        this.render = function () {
            var itemNode = document.createElement("li");

            itemNode.innerHTML = "<a href='#'>" + title + "</a>";
            if (items.length > 0) {
                var sublist = document.createElement("ul");
                sublist.style.display = "none";
                for (var i = 0; i < items.length; i += 1) {
                    var subItem = items[i].render();
                    sublist.appendChild(subItem);
                }

                itemNode.appendChild(sublist);
            }

            return itemNode;
        };

        this.serialize = function () {
            var thisItem = {
                title: title
            };

            if (items.length > 0) {
                var serializedItems = [];
                for (var i = 0; i < items.length; i += 1) {
                    var serItem = items[i].serialize();
                    serializedItems.push(serItem);
                }
                thisItem.items = serializedItems;
            }
            return thisItem;
        };
    }

    function addItem(item, dataItem) {
        var accItem = item.add(dataItem.title);
        if (dataItem.items) {
            for (var i = 0; i < dataItem.items.length; i++) {
                addItem(accItem, dataItem.items[i]);
            }
        }
    }

    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        },
        buildAccordion: function (selector, data) {
            var accordion = this.getAccordion(selector);

            if (data) {
                for (var i = 0; i < data.length ; i++) {
                    addItem(accordion, data[i]);
                }
            }
            return accordion;
        }
    }
})();