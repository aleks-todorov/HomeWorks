var controls = (function () {

    function hidePrev(item) {
        var prev = item.previousElementSibling;
        while (prev) {
            var sublist = prev.querySelector("p");
            if (sublist) {
                sublist.style.display = "none";
            }
            prev = prev.previousElementSibling;
        }
    }

    function hideNext(item) {
        var next = item.nextElementSibling;
        while (next) {
            var sublist = next.querySelector("p");
            if (sublist) {
                sublist.style.display = "none";
            }
            next = next.nextElementSibling;
        }
    }

    function Gallery(selector) {
        var items = [];
        var accItem = document.querySelector(selector);
        accItem.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            var clickedItem = ev.target;
            if (clickedItem instanceof HTMLAnchorElement) {

                var liItem = clickedItem.parentNode;

                hidePrev(liItem);
                hideNext(liItem);
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
            }
            else {
                return;
            }

        }, false);

        var itemList = document.createElement("p");

        this.addImage = function (title, source) {
            var newItem = new Item(title, source);
            items.push(newItem);
            return newItem;
        };

        this.addAlbum = function (title) {
            var newItem = new Album(title);
            items.push(newItem);
            return newItem;
        };

        this.render = function (title) {

            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            }
            while (itemList.firstChild) {
                itemList.removeChild(itemList.firstChild);
            }

            for (var i = 0, len = items.length; i < len; i += 1) {
                var domItem = items[i].render();
                itemList.appendChild(domItem);
            }
            accItem.appendChild(itemList);
            return this;
        };

        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < items.length; i += 1) {
                serializedItems.push(items[i].serialize());
            }
            return serializedItems;
        }

    }

    function Item(title, source) {
        var items = [];

        this.addImage = function (title, source) {
            var newItem = new Item(title, source);
            items.push(newItem);
            return newItem;
        }

        this.render = function () {

            var itemNode = document.createElement("img");
            itemNode.src = source;
            return itemNode;
        }

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
        }
    }

    function Album(title) {
        var items = [];

        this.addImage = function (title, source) {
            var newItem = new Item(title, source);
            items.push(newItem);
            return newItem;
        };

        this.addAlbum = function (title) {
            var newItem = new Album(title);
            items.push(newItem);
            return newItem;
        }

        this.render = function () {

            var itemNode = document.createElement("p");
            itemNode.innerHTML = "<a href='#'>" + title + "</a>";
            itemNode.className = "albums";
            if (items.length > 0) {
                var sublist = document.createElement("img");
                for (var i = 0, len = items.length; i < len; i += 1) {
                    var subitem = items[i].render();
                    sublist.appendChild(subitem);
                }
                itemNode.appendChild(sublist);
            }
            return itemNode;
        }

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

        }
    }

    return {
        getImageGallery: function (selector) {
            return new Gallery(selector);
        }
    }
}());