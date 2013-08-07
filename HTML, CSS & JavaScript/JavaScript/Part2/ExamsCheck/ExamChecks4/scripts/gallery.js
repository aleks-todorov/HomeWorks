var controls = (function () {
     
    function Gallery(name) {
        var accItem = document.querySelector(name);
        var itemList = document.createElement("ul");

        this.addImage = function (title, path) {
            var newItem = new Item(title, path);
            var domItem = newItem.addImage(title, path);       
            accItem.appendChild(domItem);

            return newItem;
        };

        this.addAlbum = function (title) {
            var newItem = new Item(title);
            newItem = newItem.addAlbum(title);
            accItem.appendChild(newItem);

            return this;
        };
    }

    function Item(title, path) {

        var itemNode = document.createElement("li");

        this.addImage = function (title, path) {
            itemNode.innerHTML = '<img src="' + path + '" />' + title;
            itemNode.style.border = "1px solid black";
            return itemNode;

        };

        this.addAlbum = function (title) {

            var itemNode = document.createElement("ul");
            //itemNode.style.border = "1px solid black";
            itemNode.innerHTML = '<li>' + title;

            return itemNode;
        };
    }

    return {
        getImageGallery: function (selector) {
            return new Gallery(selector);
        }
    }
}());
