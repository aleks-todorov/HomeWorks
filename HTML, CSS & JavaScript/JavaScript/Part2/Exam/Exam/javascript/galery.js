var controls = (function () {

    function Gallery(selector) {
        var items = [];
        var galleryItem = document.querySelector(selector);
        var imageFrame = document.querySelector("#image-frame > img");

        function sortJsonArrayByProperty(objArray, prop, direction) {
            if (arguments.length < 2) throw new Error("sortJsonArrayByProp requires 2 arguments");
            var direct = arguments.length > 2 ? arguments[2] : 1; //Default to ascending

            if (objArray && objArray.constructor === Array) {
                var propPath = (prop.constructor === Array) ? prop : prop.split(".");
                objArray.sort(function (a, b) {
                    for (var p in propPath) {
                        if (a[propPath[p]] && b[propPath[p]]) {
                            a = a[propPath[p]];
                            b = b[propPath[p]];
                        }
                    }
                    // convert numeric strings to integers
                    a = a.match(/^\d+$/) ? +a : a;
                    b = b.match(/^\d+$/) ? +b : b;
                    return ((a < b) ? -1 * direct : ((a > b) ? 1 * direct : 0));
                });
            }
        }

        galleryItem.addEventListener("click", function (ev) {

            if (!ev) {
                ev = windows.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            //getting the clicked item
            var clickedItem = ev.target;

            //Task 8: 

            //Could not make the sorting :S 
            if (clickedItem instanceof HTMLInputElement) {
                var parrent = clickedItem.parentNode;
                var albums = parrent.getElementsByClassName("albums");
                var albumsAsJASON = [];
                for (var i = 0; i < albums.length; i++) {
                    albumsAsJASON.push({ title: albums[i].name });
                }
                console.log(albumsAsJASON);
                var sortedAlbums = albumsAsJASON.sort(sortJsonArrayByProperty(albumsAsJASON, "title", +1));
                console.log(sortedAlbums);
            }

            //Task 7: 
            if (clickedItem instanceof HTMLImageElement) {
                imageFrame.src = clickedItem.src;
                console.log(clickedItem.style.width + clickedItem.style.height);
                imageFrame.style.width = 2 * clickedItem.offsetWidth + "px";
                imageFrame.style.height = 2 * clickedItem.offsetHeight + "px";
            }

            //Task 3: 
            if ((clickedItem instanceof HTMLDivElement) && (clickedItem instanceof HTMLAnchorElement)) {
                return;
            }

            var listOfElements = clickedItem.getElementsByTagName("img");
            for (var i = 0; i < listOfElements.length; i += 1) {
                if (listOfElements[i].style.display === "none") {
                    listOfElements[i].style.display = "";
                }
                else {
                    listOfElements[i].style.display = "none"
                }
            }

        }, false)

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            items.push(newAlbum);
            this.render();
            return newAlbum;
        };

        this.addImage = function (title, path) {
            var newImage = new Image(title, path);
            items.push(newImage);
            this.render();
            return newImage;
        }

        this.render = function () {

            while (galleryItem.firstChild) {
                galleryItem.removeChild(galleryItem.firstChild);
            }

            for (var i = 0; i < items.length; i += 1) {
                var domItem = items[i].render();
                galleryItem.appendChild(domItem);
            }

            return this;
        };

        //Task 4
        this.getGalleryData = function () {
            var serializedItems = [];
            for (var i = 0; i < items.length; i += 1) {
                serializedItems.push(items[i].serialize());
            }
            return serializedItems;
        };

        //Task 5: 
        this.saveGalleryDataToLocalStorage = function (name, galleryData) {
            localStorage.setObject(name, galleryData);
        }

        //Functionality needed for task 6: 
        this.loadGalleryDataFromLocalStorage = function (name) {
            var localStorageData = localStorage.getObject(name);
            return localStorageData;
        }
    };

    function Album(title) {
        var items = [];

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            items.push(newAlbum);
            this.render();
            return newAlbum;
        }

        this.addImage = function (title, path) {
            var newImage = new Image(title, path);
            items.push(newImage);
            this.render();
            return newImage;
        }

        this.render = function () {
            var itemNode = document.createElement("div");

            //Adding buttons as requested in Task 8:
            itemNode.innerHTML = "<a href='#'>" + title + "</a>";
            var sortButton = document.createElement("input");
            sortButton.type = "button";
            sortButton.value = "Sort";
            itemNode.appendChild(sortButton);
            itemNode.classList.add("albums");
            itemNode.name = title;

            if (items.length > 0) {
                for (var i = 0; i < items.length; i += 1) {
                    if (items[i] instanceof Image) {
                        var subItem = items[i].render();
                        subItem.style.display = "none";
                        itemNode.appendChild(subItem);
                    }
                }

                for (var i = 0; i < items.length; i += 1) {

                    if (items[i] instanceof Album) {
                        var subItem = items[i].render();
                        itemNode.appendChild(subItem);
                    }
                }
            }

            return itemNode;
        };

        //Functionality needed for task 4: 
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

    };

    function Image(title, path) {

        this.render = function () {
            var itemNode = document.createElement("img");
            itemNode.name = title;
            itemNode.classList.add("images");
            itemNode.name = title;
            itemNode.src = path;
            return itemNode;
        };

        this.serialize = function () {
            var thisItem = {
                title: title,
                path: path
            };

            return thisItem;
        };

    };

    function addItem(item, dataItem) {
        if (dataItem.path) {
            var galleryItem = item.addImage(dataItem.name, dataItem.path);
            return;
        }
        else {
            var galleryItem = item.addAlbum(dataItem.title);
            if (dataItem.items) {
                for (var i = 0; i < dataItem.items.length; i++) {
                    addItem(galleryItem, dataItem.items[i]);
                }
            }
        }
    }

    return {
        getImageGallery: function (selector) {
            return new Gallery(selector);
        },

        //Task 6: 
        buildImageGallery: function (selector, data) {
            var gallery = this.getImageGallery(selector);

            if (data) {
                for (var i = 0; i < data.length ; i++) {
                    addItem(gallery, data[i]);
                }
            }
            return gallery;
        }
    }
})();