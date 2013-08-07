(function () {
    if (!Storage.prototype.setObject) {
        Storage.prototype.setObject = function setObject(key, obj) {
            var jsonObj = JSON.stringify(obj);
            this.setItem(key, jsonObj);
        };

    }

    if (!Storage.prototype.getObject) {
        Storage.prototype.getObject = function getObject(key) {
            var jsonObj = this.getItem(key);
            var obj = JSON.parse(jsonObj);
            return obj;
        };
    }
})();

Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
};

Function.prototype.extend = function (parent) {
    for (var i = 1; i < arguments.length; i += 1) {
        var name = arguments[i];
        this.prototype[name] = parent.prototype[name];
    }
    return this;
};

function attachEventHandler(element, eventType, eventHandler) {
    if (!element) {
        return;
    }

    if (document.addEventListener) {
        element.addEventListener(eventType, eventHandler, false);
    }
    else if (document.attachEvent) {
        element.attachEvent("on" + eventType, eventHandler);
    }
    else {
        element['on' + eventType] = eventHandler;
    }
}

var controls = (function () {

    function getImageGallery(id) {
        return new Gallery(id);
    }

    function onClickExpandOrCollapse(ev) {
        if (!ev) {
            ev = window.event;
        }

        if (ev.stopPropagation) {
            ev.stopPropagation();
        }

        if (ev.preventDefault) {
            ev.preventDefault();
        }

        var clickedItem = ev.target;
        var previousItem = clickedItem.parentNode;
        var imageContainer = previousItem.nextElementSibling;

        if (imageContainer) {
            if (imageContainer.style.display == "none") {
                imageContainer.style.display = "";
            }
            else if (imageContainer.style.display == "") {
                imageContainer.style.display = "none";
            }
        }
    }

    function onClickGetImage(ev) {
        if (!ev) {
            ev = window.event;
        }

        if (ev.stopPropagation) {
            ev.stopPropagation();
        }

        if (ev.preventDefault) {
            ev.preventDefault();
        }

        var clickedItem = ev.target;
        var container = document.getElementById("containerExpandedImage");
        if (!container) {
            container = document.createElement("img");
            container.id = "containerExpandedImage";
            document.body.appendChild(container);
            container.style.width = parseInt(clickedItem.offsetHeight) * 2 + "px";
            container.style.height = parseInt(clickedItem.offsetWidth) * 2 + "px";
        }

        container.src = clickedItem.src;
    }

    function Gallery(id) {
        var holder = document.createElement("div");
        holder.style.width = "600px";

        // We have two pairs of arrays - one containing the elements (images or albums) and another containing
        // the data about them. This is necessary because: "Only primitive values (strings, dates, booleans, numbers) 
        // and objects and array structures are possible to serialize into JSON." Thus, it will not work on DOM elements saved
        // in variables or arrays.
        var images = [];
        var albums = [];

        var imagesData = [];
        var albumsData = [];

        var galleryId = getId(id);

        holder.id = galleryId;
        document.body.appendChild(holder);

        this.addImage = function (title, source) {
            var image = document.createElement("img");
            image.src = source;
            image.title = title;
            attachEventHandler(image, "click", onClickGetImage);
            images.push(image);
            var imageData = {};
            imageData.title = image.title;
            imageData.source = image.src;
            imagesData.push(imageData);
            renderMain();
            return image;
        }

        function renderMain() {
            holder.innerHTML = "";
            for (var i = 0, len = images.length; i < len; i++) {
                holder.appendChild(images[i]);
            }

            var currentAlbum;
            for (var j = 0, len = albums.length; j < len; j++) {
                currentAlbum = albums[j];
                holder.appendChild(currentAlbum.render());
            }
        }

        this.addAlbum = function (title) {
            var album = new Album(title);
            albums.push(album);
            return album;
        }

        this.getImageGalleryData = function () {
            var galleryData = [];
            for (var i = 0, len = imagesData.length; i < len; i++) {
                galleryData.push(imagesData[i]);
            }

            for (var i = 0, len = albums.length; i < len; i++) {
                galleryData.push(albums[i].getAlbumData());
            }

            return galleryData;
        }

        function getId(id) {
            var index = id.indexOf("#");
            var stringToSearch = id.substr(index + 1);
            while (stringToSearch.indexOf("#") != -1) {
                index = stringToSearch.indexOf("#");
                stringToSearch = stringToSearch.substr(index + 1);
            }

            return stringToSearch;
        }

        function Album(title) {
            var albumTitle = title;

            var albumHolder = document.createElement("div");
            albumHolder.className = "albumHolder";

            var titleHolder = document.createElement("div");
            titleHolder.className = "albumTitle";

            var titleLink = document.createElement("a");
            titleLink.innerHTML = albumTitle;
            attachEventHandler(titleLink, "click", onClickExpandOrCollapse);

            var picHolder = document.createElement("div");
            picHolder.className = "holder";
            picHolder.style.display = "none";

            var images = [];
            var albums = [];

            var imagesData = [];
            var albumsData = [];

            this.addImage = function (title, source) {
                var image = document.createElement("img");
                image.title = title;
                image.src = source;
                attachEventHandler(image, "click", onClickGetImage);
                images.push(image);
                var imageData = {};
                imageData.title = image.title;
                imageData.source = image.src;
                imagesData.push(imageData);
                renderMain();
            }

            this.addAlbum = function (title) {
                var album = new Album(title);
                albums.push(album);
                renderMain();
                return album;
            }

            this.render = function () {
                albumHolder.innerHTML = "";
                titleHolder.innerHTML = "";

                // I have to do this because IE for some reason does not "remember" the content (innerHTML) of the titleLink.
                titleLink.innerHTML = albumTitle;

                titleHolder.appendChild(titleLink);
                albumHolder.appendChild(titleHolder);
                picHolder.innerHTML = "";
                for (var i = 0, len = images.length; i < len; i++) {
                    picHolder.appendChild(images[i]);
                }

                for (var j = 0, len = albums.length; j < len; j++) {
                    picHolder.appendChild(albums[j].render());
                }

                albumHolder.appendChild(picHolder);
                return albumHolder;
            }

            this.getAlbumData = function () {
                var albumData = [];
                albumData.push({ "title": albumTitle });

                for (var i = 0, len = imagesData.length; i < len; i++) {
                    albumData.push(imagesData[i]);
                }

                for (var i = 0, len = albums.length; i < len; i++) {
                    albumData.push(albums[i].getAlbumData());
                }

                return albumData;
            }
        }
    }

    function buildImageGallery(id, data) {
        var newGallery = new Gallery(id);
        for (var i = 0, len = data.length; i < len; i++) {
            if (data[i].source) {
                newGallery.addImage(data[i].title, data[i].source);
            }
            else {
                var appendedAlbum = newGallery.addAlbum(data[i][0].title);
                processAlbum(appendedAlbum, data[i]);
            }
        }
    }

    function processAlbum(album, data) {
        for (var i = 1, len = data.length; i < len; i++) {
            if (data[i].source) {
                album.addImage(data[i].title, data[i].source);
            }
            else {
                var appendedAlbum = album.addAlbum(data[i][0].title);
                processAlbum(appendedAlbum, data[i]);
            }
        }
    }

    return {
        getImageGallery: getImageGallery,
        buildImageGallery: buildImageGallery
    }
}());

var imageGalleryRepository = (function () {
    function save(key, data) {
        localStorage.setObject(key, data);
    }

    function load(key) {
        var objectToReturn;
        objectToReturn = localStorage.getObject(key);
        return objectToReturn;
    }

    return {
        save: save,
        load: load
    }
}());