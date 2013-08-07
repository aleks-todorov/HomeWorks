var controls = (function () {

    function ImageGallery(selector) {
        var images = [];
        var albums = [];
        var galleryItem = document.querySelector(selector);

        var galleryWrapper = document.createElement("div");
        galleryWrapper.style.textAlign = "center";

        this.getImageGalleryData = function() {
            var galleryImages = [];
            for (var i = 0; i < images.length; i += 1) {
                galleryImages.push(images[i].serialize());
            }

            var galleryAlbums = [];
            for (var i = 0; i < albums.length; i += 1) {
                galleryAlbums.push(albums[i].serialize());
            }

            return {
                galleryImages: galleryImages,
                galleryAlbums: galleryAlbums
            };
        }

        this.addImage = function (title, source) {
            var newImage = new GalleryImage(title, source);
            images.push(newImage);
            return newImage;
        };

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        this.render = function () {
            while (galleryItem.firstChild) {
                galleryItem.removeChild(galleryItem.firstChild);
            }

            while (images.firstChild) {
                images.removeChild(images.firstChild);
            }

            while (albums.firstChild) {
                albums.removeChild(albums.firstChild);
            }

            var imagesDiv = document.createElement("div");
            imagesDiv.style.display = "inline-block";


            for (var i = 0, len = images.length; i < len; i += 1) {
                var imageItem = images[i].render();
                imagesDiv.appendChild(imageItem);
            }
            galleryWrapper.appendChild(imagesDiv);

            for (var i = 0, len = albums.length; i < len; i += 1) {
                var albumItem = albums[i].render();
                galleryWrapper.appendChild(albumItem);
            }
            galleryItem.appendChild(galleryWrapper);
            return this;
        };
    }

   
         function GalleryImage(title, source) {

            this.render = function() {
                var imageWrapper = document.createElement("div");
                imageWrapper.style.border = "1px solid black"
                imageWrapper.style.width = "204px";
                imageWrapper.style.height = "250px";
                imageWrapper.style.display = "inline-block";
                var name = document.createElement("div");
                name.style.display = "inline-block";
                name.style.textAlign = "center";
                name.innerHTML = title;
                imageWrapper.appendChild(name);
                var image = document.createElement("img");
                image.src = source;
                image.alt = title;
                imageWrapper.appendChild(image);
               
                return imageWrapper;
            };

            this.serialize = function () {
                var thisImage = {
                    title: title,
                    source: source
                };
                return thisImage;
            }
        }

        function Album(title) {
            var imagesArray = [];
            var albumsArray = [];

            this.addImage = function(title, source) {
                var newImage = new GalleryImage(title, source);
                imagesArray.push(newImage);
                return newImage;
            };

            this.addAlbum = function(title) {
                var newAlbum = new Album(title);
                albumsArray.push(newAlbum);
                return newAlbum;
            };

            this.serialize = function() {
                var thisAlbum = {
                    title: title,
                };

                if (imagesArray.length > 0) {
                var serializedImages = [];
                for (var i = 0; i < imagesArray.length; i += 1) {
                    var serImage = imagesArray[i].serialize();
                    serializedImages.push(serImage);
                }
                thisAlbum.images = serializedImages;
                }

                if (albumsArray.length > 0) {
                    var serializedAlbums = [];
                    for (var i = 0; i < albumsArray.length; i += 1) {
                        var serAlbum = albumsArray[i].serialize();
                        serializedAlbums.push(serAlbum);
                    }
                    thisAlbum.albums = serializedAlbums;
                }
                return thisAlbum;
            }

            this.render = function() {
                var albumWraper = document.createElement("div");
                albumWraper.style.border = "1px solid black";

                var name = document.createElement("span");
                name.style.cursor = "pointer";
                name.addEventListener("click",
                    function(ev) {
                      if (!ev) {
                        ev = window.event;
                      }
                      ev.stopPropagation();
                      ev.preventDefault();

                      var clickedItem = ev.target;
                      if (!(clickedItem instanceof HTMLSpanElement)) {
                        return;
                      }

                      var imagesDiv = clickedItem.nextElementSibling;
                      var sublistDisplay = "";
                      if (imagesDiv.style.display === "none") {
                          imagesDiv.style.display = "";
                      } else {
                          imagesDiv.style.display = "none";
                      }
                    }, false);

                name.innerHTML = title;
                name.style.fontSize = "30px";
                name.style.textAlign = "center";
                albumWraper.appendChild(name);

                if (imagesArray.length > 0) {
                    var imageList = document.createElement("div");

                    for (var i = 0, len = imagesArray.length; i < len; i += 1) {
                        var subitem = imagesArray[i].render();
                        imageList.appendChild(subitem);
                    }
                    albumWraper.appendChild(imageList);
                };

                if (albumsArray.length > 0) {
                    var albumsList = document.createElement("div");
                    albumsList.style.clear = "both";
                    for (var i = 0, len = albumsArray.length; i < len; i += 1) {
                        var subitem = albumsArray[i].render();
                        albumsList.appendChild(subitem);
                    }
                    albumWraper.appendChild(albumsList);
                };

                return albumWraper;
            };
        }

  return {
    getImageGallery: function(selector) {
        return new ImageGallery(selector);
    }
  }

}());


var imageGalleryRepository = (function() {

    this.save = function (galleryName, galleryData) {
        localStorage.setObject(galleryName, galleryData);
    };

    this.load = function (galleryName) {
        var deserializedData = localStorage.getObject(galleryName);
        return deserializedData;
    };

    return {
        save: save,
        load: load
    };
}());