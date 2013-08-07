var controls = (function () {

    function gallery(selector) {
        var albums = [];
        var images = [];

        var accItem = document.querySelector(selector);
        var itemsList = document.createElement("ul");

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        this.addImage = function (title, source) {
            var newImage = new Image(title, source);
            images.push(newImage);
            return newImage;
        }

        this.render = function () {
            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            }

            while (itemsList.firstChild) {
                itemsList.removeChild(itemsList.firstChild);
            }

            for (var i = 0, len = albums.length; i < len; i += 1) {
                var domItem = albums[i].render();
                itemsList.appendChild(domItem);
            }
            accItem.appendChild(itemsList);
            return this;
        };
    };

    function Album(title) {
        var albums = [];
        var images = [];

        this.addAlb = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        this.addImg = function (title, source) {
            var newImage = new Image(title, source);
            images.push(newImage);
            return newImage;
        }

        this.render = function () {
            var albumNode = document.createElement("li");
            albumNode.innerHTML = "<a href='#' >" + title + "</a>";
            if (albums.length > 0) {
                var sublist = document.createElement("ul");
                sublist.style.display = "none";
                for (var i = 0, len =albums.length; i < len; i += 1) {
                    var subitem = albums[i].render();
                    sublist.appendChild(subitem);
                }
                albumNode.appendChild(sublist);
            }
            return albumNode;
        }
    }

    function Image(title, source) {
        var images = [];

        this.add = function (title) {
            var newImage = new Image(title);
            images.push(newImage);
            return newImage;
        }
        this.render = function () {
            var imageNode = document.createElement("li");

            imageNode.innerHTML = "<a href='#' >" + title + "</a>" +
                            "<img src=" +source+ "Alt=" + title+ "/>"

            if (images.length > 0) {
                var sublist = document.createElement("ul");
                sublist.style.display = "none";
                for (var i = 0, len = images.length; i < len; i += 1) {
                    var subitem = images[i].render();
                    sublist.appendChild(subitem);
                }
                imageNode.appendChild(sublist);
            }
            return imageNode;
        };
    }
    
    return {
        getImageGallery: function (selector) {
            return new gallery(selector);
        }
    }
}());