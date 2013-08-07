var controls = (function () {

    function ImageGallery(selector) {
        var galItem = document.querySelector(selector);
        var images = [];
        var albums = [];

        galItem.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            var clickedItem = ev.target;
            //console.log(clickedItem);
            var current = clickedItem;
            if (clickedItem instanceof HTMLAnchorElement) {
                while (current.nextElementSibling) {
                    var next = current.nextElementSibling;
                    var subItem = next;
                    if (!subItem) {
                        return;
                    }
                    if (subItem.style.display === "none") {
                        subItem.style.display = "";
                    } else {
                        subItem.style.display = "none";
                    }
                    current = next;
                }
            }
            else if (clickedItem instanceof HTMLImageElement) {
                var largerImg = document.createElement("img");
                largerImg.src = clickedItem.src;
                largerImg.title = clickedItem.title;
                largerImg.width = clickedItem.width * 2;
                largerImg.height = clickedItem.height * 2;
                //console.log(largerImg);
                largerImg.style.position = "absolute";
                galItem.appendChild(largerImg);
            }
            else {
                return;
            }
        }, false);


        this.addImage = function (title, src) {
            var newImage = new Image(title, src);
            images.push(newImage);
            return newImage;
        };

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        var itemsList = document.createElement("ul");

        this.render = function () {
            for (var i = 0, len = images.length; i < len; i += 1) {
                var domItem = images[i].render();
                galItem.appendChild(domItem);
            }
            for (var i = 0, len = albums.length; i < len; i += 1) {
                var domItem = albums[i].render();
                galItem.appendChild(domItem);
            }
            // the button implementation - task 8 - not finished :S
            //var button = document.createElement("button");
            //button.innerHTML = "Sort Albums";
            //button.addEventListener("click", function (ev) {
            //    var albumNames = galItem.getElementsByTagName("a");
            //    var albumNamesArray = [];
            //    for (var i = 0; i < albumNames.length; i++) {
            //        albumNamesArray[i] = albumNames[i].innerHTML;
            //    }
            //    albumNamesArray.sort();
            //}, false)
            //galItem.appendChild(button);
            return this;
        };

        // task 4 - 5
        this.save = function () {
            var thisGallery = {
            };
            if (images.length > 0) {
                var savedImgs = [];
                for (var i = 0; i < images.length; i += 1) {
                    var serImg = images[i].save();
                    savedImgs.push(serImg);
                }
                thisGallery.images = savedImgs;
            }
            if (albums.length > 0) {
                var savedAlbums = [];
                for (var i = 0; i < albums.length; i += 1) {
                    var serImg = albums[i].save();
                    savedAlbums.push(serImg);
                }
                thisGallery.images = savedAlbums;
            }
            return thisGallery;
        };
    }

    function Image(title, src) {
        this.render = function () {
            var img = document.createElement("span");
            var name = document.createElement("span");
            name.innerHTML = title;
            name.style.position = "relative";
            name.style.top = "-20px";
            var imgNode = document.createElement("img");
            imgNode.src = src;
            imgNode.title = title;

            img.appendChild(imgNode);
            img.appendChild(name);
            return img;
        };

        // task 4 - 5
        this.save = function () {
            var thisImg = {
                title: title,
                src : src
            };
            
            return thisImg;
        };

    }

    function Album(title) {
        var images = [];
        var albums = [];

        this.addImage = function (title, src) {
            var newImage = new Image(title, src);
            images.push(newImage);
            return newImage;
        };
        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        this.render = function () {
            var albumNode = document.createElement("div");
            albumNode.innerHTML = "<a href='#'>" + title + "</a> \n </br>";
            if (images.length > 0) {
                var imgList = document.createElement("div");
                imgList.style.display = "none";
                for (var i = 0; i < images.length; i += 1) {
                    var span = document.createElement("span");
                    var name = document.createElement("span");
                    name.innerHTML = images[i].render().firstChild.title;
                    var imgNode = document.createElement("img");
                    imgNode.src = images[i].render().firstChild.src;
                    imgNode.title = images[i].render().firstChild.title;

                    span.appendChild(imgNode);
                    span.appendChild(name);
                    imgList.appendChild(span);
                }
                albumNode.appendChild(imgList);
            }
            if (albums.length > 0) {
                var subAlbum = document.createElement("div");
                subAlbum.style.display = "none";
                for (var i = 0; i < albums.length; i += 1) {
                    var subAlbumNode = albums[i].render();
                    subAlbum.appendChild(subAlbumNode);
                }
                albumNode.appendChild(subAlbum);
            }
            return albumNode;
        };

        // task 4 - 5
        this.save = function () {
            var thisItem = {
                title: title
            };
            if (images.length > 0) {
                var savedImgs = [];
                for (var i = 0; i < images.length; i += 1) {
                    var serImg = images[i].save();
                    savedImgs.push(serImg);
                }
                thisItem.images = savedImgs;
            }
            if (albums.length > 0) {
                var savedAlbums = [];
                for (var i = 0; i < albums.length; i += 1) {
                    var serImg = albums[i].save();
                    savedAlbums.push(serImg);
                }
                thisItem.images = savedAlbums;
            }
            return thisItem;
        }
    }

    return {
        getImageGallery: function (selector) {
            return new ImageGallery(selector);
        }
    }
}());