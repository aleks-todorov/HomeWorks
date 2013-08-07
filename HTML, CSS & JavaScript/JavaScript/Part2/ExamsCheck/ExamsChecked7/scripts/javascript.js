(function () {

    controls = function (param) {
        this.imageName = document.getElementById(param.imageName);
        this.imageSource = document.getElementById(param.imageSource);
        this.imageAlbum = document.getElementById(param.imageAlbum);
        this.emptyAlbumName = document.getElementById(param.emptyAlbumName);
        this.addAlbum = document.getElementById(param.addAlbum);
        this.addImageAlbum = document.getElementById(param.addImageAlbum);
        this.addImageGallery = document.getElementById(param.addImageGallery);
        this.gallery = document.getElementById(param.gallery);
        this.addAlbumTitle = document.getElementById(param.addAlbumTitle);
        this.toAlbumTitle = document.getElementById(param.toAlbumTitle);
        this.addToAlbum = document.getElementById(param.addToAlbum);
        this.addAlbumToRepositoryTitle = document.getElementById(param.addAlbumToRepositoryTitle);
        this.addToRepository = document.getElementById(param.addToRepository);
        this.enlarged = document.getElementById(param.enlarged);
        this.sortAlbums = document.getElementById(param.sortAlbums);
        this.addGalleryToRepository = document.getElementById(param.addGalleryToRepository);
        this.buildGalleryFromRepository = document.getElementById(param.buildGalleryFromRepository);
    }

    controls.prototype = {
        init: function () {
            this.initImageGallery();
        },
        initImageGallery: function () {
            this.imageGallery = new ImageGallery({
                imageName: this.imageName,
                imageSource: this.imageSource,
                imageAlbum: this.imageAlbum,
                emptyAlbumName: this.emptyAlbumName,
                addAlbum: this.addAlbum,
                addImageAlbum: this.addImageAlbum,
                addImageGallery: this.addImageGallery,
                gallery: this.gallery,
                addAlbumTitle: this.addAlbumTitle,
                toAlbumTitle: this.toAlbumTitle,
                addToAlbum: this.addToAlbum,
                addAlbumToRepositoryTitle: this.addAlbumToRepositoryTitle,
                addToRepository: this.addToRepository,
                enlarged: this.enlarged,
                sortAlbums: this.sortAlbums,
                addGalleryToRepository: this.addGalleryToRepository,
                buildGalleryFromRepository: this.buildGalleryFromRepository
            });
            this.imageGallery.init();
        }
    }

    window.addEventListener('load', function () {
        var controlList = new controls({
            imageName: "image-title",
            imageSource: "image-source",
            imageAlbum: "image-album",
            emptyAlbumName: "album-title",
            addAlbum: "AddAlbum",
            addImageAlbum: "AddImageAlbum",
            addImageGallery: "AddImageGallery",
            gallery: "gallery",
            addAlbumTitle: "add-album-title",
            toAlbumTitle: "to-album-title",
            addToAlbum: "AddToAlbum",
            addAlbumToRepositoryTitle: "add-album-to-repository-title",
            addToRepository: "AddToRepository",
            enlarged: "enlarged",
            sortAlbums: "sortAlbums",
            addGalleryToRepository: "addGalleryToRepository",
            buildGalleryFromRepository: "buildGalleryFromRepository"
        });

        controlList.init();
    }, false);
})();

(function () {

    TreeView = function (param) {
        this.treeView = param.treeView;
        this.btnAddChild = param.btnAddChild;
        this.parentName = param.parentName;
        this.childName = param.childName;
        this.treeLevel = param.treeLevel;
    }

    TreeView.prototype = {
        init: function () {
            this.initEvents();
        },
        initEvents: function () {
            var that = this;
            that.btnAddChild.addEventListener("click", function (evt) {
                evt.preventDefault();

                var rootLevel = parseInt(that.treeLevel.value);
                var rootChildren = that.treeView.childNodes;

                if (rootLevel == 0) {
                    that.treeView.innerHTML += '<li><div class="text">' + that.childName.value + '</div><ul id="' + that.childName.value + '"></ul></li>';
                    var listBtns = that.treeView.getElementsByClassName("text");
                    for (j = 0; j < listBtns.length; j++) {
                        listBtns[j].addEventListener("click", function (ev) {
                            ev.preventDefault();
                            var next = this.nextSibling;
                            if (next.style.display == 'none') {
                                next.style.display = 'block';
                            } else {
                                next.style.display = 'none';
                            }
                        }, false);
                    }
                }
                else {
                    walkTree({
                        children: rootChildren,
                        level: 1
                    });
                }

            }, false);

            function walkTree(param) {
                var children = param.children;
                var level = param.level;
                for (i = 1; i < children.length; i++) {
                    if (level == 1) {
                        if (level == parseInt(that.treeLevel.value) && children[i].childNodes[1].id == that.parentName.value) {
                            children[i].childNodes[1].innerHTML += '<li><div class="text">' + that.childName.value + '</div><ul id="' + that.childName.value + '"></ul></li>';

                            var listBtns = children[i].childNodes[1].getElementsByClassName("text");
                            for (j = 0; j < listBtns.length; j++) {
                                listBtns[j].addEventListener("click", function (ev) {
                                    ev.preventDefault();
                                    var next = this.nextSibling;
                                    if (next.style.display == 'none') {
                                        next.style.display = 'block';
                                    } else {
                                        next.style.display = 'none';
                                    }
                                }, false);
                            }
                            return;
                        }
                        else {
                            level = walkTree({
                                children: children[i].childNodes,
                                level: level + 1
                            });

                            if (i == children.length - 1) {
                                return level - 1;
                            }
                        }
                    }
                    else {
                        if (level == parseInt(that.treeLevel.value) && children[i].childNodes[0].childNodes[1].id == that.parentName.value) {
                            children[i].childNodes[0].childNodes[1].innerHTML += '<li><div class="text">' + that.childName.value + '</div><ul id="' + that.childName.value + '"></ul></li>';

                            var listBtns = children[i].childNodes[0].childNodes[1].getElementsByClassName("text");
                            for (j = 0; j < listBtns.length; j++) {
                                listBtns[j].addEventListener("click", function (ev) {
                                    ev.preventDefault();
                                    var next = this.nextSibling;
                                    if (next.style.display == 'none') {
                                        next.style.display = 'block';
                                    } else {
                                        next.style.display = 'none';
                                    }
                                }, false);
                            }
                            return;
                        }
                        else {
                            level = walkTree({
                                children: children[i].childNodes,
                                level: level + 1
                            });

                            if (i == children.length - 1) {
                                return level - 1;
                            }
                        }
                    }
                }
            }
        }
    }
})();

(function () {

    Accordion = function (param) {
        this.accordion = param.accordion;
        this.addAccordionChild = param.addAccordionChild;
        this.headerText = param.headerText;
        this.contentText = param.contentText;
    }

    var height = 0;
    var minimal = 90;
    var id = 0;

    Accordion.prototype = {
        init: function () {
            this.initEvents();
        },
        initEvents: function () {

            var that = this;
            that.addAccordionChild.addEventListener("click", function (ev) {
                ev.preventDefault();

                var header = that.headerText.value;
                var content = that.contentText.value;

                var accordion = that.accordion;

                accordion.innerHTML += '<li class="slider"><div class="header" id="' + id + '">' + header + '</div><div class="content">' + content + '</div></li>';
                id++;
                var headers = accordion.getElementsByClassName("header");
                for (i = 0; i < headers.length; i++) {
                    headers[i].addEventListener("click", function () {
                        var that = this;
                        var content = that.nextSibling;

                        if (content.style.display == 'none') {
                            content.style.height = 0 + 'px';
                            content = that.nextSibling;
                            rise = setInterval(function () { RiseUp(content); }, 50);

                            var elements = accordion.getElementsByClassName("slider");
                            for (j = 0; j < elements.length; j++) {
                                if (elements[j].childNodes[0].id != that.id) {
                                    elements[j].childNodes[1].style.display = 'none';
                                }
                            }
                        } else {
                            content.style.height = 90 + 'px';
                            fall = setInterval(function () { FallDown(content); }, 50);

                        }
                    }, false);
                }

            }, false);



            function RiseUp(element) {
                if (height == 95) {
                    clearInterval(rise);
                    minimal = 90;
                }
                height += 5;
                element.style.height = height + 'px';
                element.style.display = "block";
            }

            function FallDown(element) {

                minimal -= 5;
                element.style.height = minimal + 'px';
                if (minimal == 0) {
                    clearInterval(fall);
                    element.style.display = 'none';
                    height = 0;
                }
            }

        }
    }
})();

(function () {

    ImageGallery = function (params) {
        this.imageName = params.imageName;
        this.imageSource = params.imageSource;
        this.imageAlbum = params.imageAlbum;
        this.emptyAlbumName = params.emptyAlbumName;
        this.addAlbum = params.addAlbum;
        this.addImageAlbum = params.addImageAlbum;
        this.addImageGallery = params.addImageGallery;
        this.gallery = params.gallery;
        this.addAlbumTitle = params.addAlbumTitle;
        this.toAlbumTitle = params.toAlbumTitle;
        this.addToAlbum = params.addToAlbum;
        this.addAlbumToRepositoryTitle = params.addAlbumToRepositoryTitle;
        this.addToRepository = params.addToRepository;
        this.enlarged = params.enlarged;
        this.sortAlbums = params.sortAlbums;
        this.addGalleryToRepository = params.addGalleryToRepository;
        this.buildGalleryFromRepository = params.buildGalleryFromRepository;
    }

    ImageGallery.prototype = {
        init: function () {
            this.initEvents();
        },
        initEvents: function () {
            var that = this;
            this.addImageGallery.addEventListener("click", function (ev) {
                ev.preventDefault();

                var imageTitle = that.imageName.value;
                var imageSource = that.imageSource.value;

                var gallery = that.gallery;
                gallery.innerHTML += '<section class="image"><div id="imageTitle">' + imageTitle + '</div><div class="imageSource"></div></section>';

                var images = gallery.getElementsByClassName("imageSource");

                var image = images[images.length - 1];
                image.style.background = "url(" + imageSource + ")";
                image.style.backgroundRepeat = "no-repeat";
                image.style.backgroundSize = "60px 60px";
                image.style.backgroundPostition = "0% 0%";

                image.addEventListener("click", function (e) {
                    e.preventDefault();

                    style = this.currentStyle || window.getComputedStyle(this, false),
					bi = style.backgroundImage.slice(4, -1);

                    var enlarged = that.enlarged;

                    enlarged.innerHTML += '<div id="enlargeTitle">' + imageTitle + '</div><div id="enlargeSource"></div>';
                    var enlargeSource = enlarged.childNodes[2];
                    enlargeSource.style.background = "url(" + bi + ")";
                    enlargeSource.style.backgroundRepeat = "no-repeat";
                    enlargeSource.style.backgroundSize = "150px 150px";
                    enlargeSource.style.backgroundPostition = "0% 0%";

                }, false);
            }, false);

            this.addAlbum.addEventListener("click", function (ev) {
                ev.preventDefault();

                var albumTitle = that.emptyAlbumName.value;
                var gallery = that.gallery;

                gallery.innerHTML += '<section class="album" id=' + albumTitle + '><div id="albumTitle">' + albumTitle + '</div><div id="albumContainer"></div><input type="text" class="sortInnerAlbums" value="Sort inside albums"/></section>';

                var albums = gallery.getElementsByClassName("album");
                var album = albums[albums.length - 1];
                var title = album.childNodes[0];
                var button = album.childNodes[2];

                title.addEventListener("click", function (e) {
                    e.preventDefault();
                    var parentAlbum = this.parentNode;
                    if (parentAlbum.className == 'short') {
                        parentAlbum.setAttribute("class", "album");
                    } else if (parentAlbum.className == 'album') {
                        parentAlbum.setAttribute("class", "short");
                    }
                }, false);

                button.addEventListener("click", function (e) {
                    e.preventDefault();
                    var parentAlbum = this.parentNode;
                    var children = parentAlbum.childNodes[1].childNodes;

                    for (i = 0; i < children.length; i++) {

                        for (j = 0; j < children.length; j++) {

                            if (children[i].className == 'album' && children[j].className == 'album') {

                                if (children[i].childNodes[0].innerText < children[j].childNodes[0].innerText) {

                                    var temp = children[i].innerHTML;
                                    children[i].innerHTML = children[j].innerHTML;
                                    children[j].innerHTML = temp;
                                }

                            }
                        }
                    }
                }, false);

                button.addEventListener("dblclick", function (e) {
                    e.preventDefault();
                    var parentAlbum = this.parentNode;
                    var children = parentAlbum.childNodes[1].childNodes;

                    for (i = 0; i < children.length; i++) {

                        for (j = 0; j < children.length; j++) {

                            if (children[i].className == 'album' && children[j].className == 'album') {

                                if (children[i].childNodes[0].innerText > children[j].childNodes[0].innerText) {

                                    var temp = children[i].innerHTML;
                                    children[i].innerHTML = children[j].innerHTML;
                                    children[j].innerHTML = temp;
                                }

                            }
                        }
                    }
                }, false);

            }, false);

            this.addImageAlbum.addEventListener("click", function (ev) {
                ev.preventDefault();
                var imageTitle = that.imageName.value;
                var imageSource = that.imageSource.value;
                var gallery = that.gallery;
                var albumTitle = that.imageAlbum.value;

                var album = document.getElementById(albumTitle);
                var container = album.childNodes[1];
                container.innerHTML += '<section class="image"><div id="imageTitle">' + imageTitle + '</div><div class="imageSource"></div></section>';

                var images = gallery.getElementsByClassName("imageSource");
                var image = images[images.length - 1];
                image.style.background = "url(" + imageSource + ")";
                image.style.backgroundRepeat = "no-repeat";
                image.style.backgroundSize = "60px 60px";
                image.style.backgroundPostition = "0% 0%";

                image.addEventListener("click", function (e) {
                    e.preventDefault();

                    style = this.currentStyle || window.getComputedStyle(this, false),
					bi = style.backgroundImage.slice(4, -1);

                    var enlarged = that.enlarged;

                    enlarged.innerHTML += '<div id="enlargeTitle">' + imageTitle + '</div><div id="enlargeSource"></div>';
                    var enlargeSource = enlarged.childNodes[2];
                    enlargeSource.style.background = "url(" + bi + ")";
                    enlargeSource.style.backgroundRepeat = "no-repeat";
                    enlargeSource.style.backgroundSize = "150px 150px";
                    enlargeSource.style.backgroundPostition = "0% 0%";

                }, false);
            }, false);

            this.addToAlbum.addEventListener("click", function (ev) {
                ev.preventDefault();

                var albumTitle = that.addAlbumTitle.value;
                var toAlbum = that.toAlbumTitle.value;

                var containerAlbum = document.getElementById(toAlbum);
                var container = containerAlbum.childNodes[1];
                container.innerHTML += '<section class="album" id=' + albumTitle + '><div id="albumTitle">' + albumTitle + '</div><div id="albumContainer"></div><input type="text" class="sortInnerAlbums" value="Sort inside albums" /></section>';

                var albums = gallery.getElementsByClassName("album");
                var album = albums[albums.length - 1];
                var title = album.childNodes[0];
                var button = album.childNodes[2];

                title.addEventListener("click", function (e) {
                    e.preventDefault();
                    var parentAlbum = this.parentNode;
                    if (parentAlbum.className == 'short') {
                        parentAlbum.setAttribute("class", "album");
                    } else if (parentAlbum.className == 'album') {
                        parentAlbum.setAttribute("class", "short");
                    }
                }, false);

                button.addEventListener("click", function (e) {
                    e.preventDefault();
                    var parentAlbum = this.parentNode;
                    var children = parentAlbum.childNodes[1].childNodes;

                    for (i = 0; i < children.length; i++) {

                        for (j = 0; j < children.length; j++) {

                            if (children[i].className == 'album' && children[j].className == 'album') {

                                if (children[i].childNodes[0].innerText < children[j].childNodes[0].innerText) {

                                    var temp = children[i].innerHTML;
                                    children[i].innerHTML = children[j].innerHTML;
                                    children[j].innerHTML = temp;
                                }

                            }
                        }
                    }
                }, false);

                button.addEventListener("dblclick", function (e) {
                    e.preventDefault();
                    var parentAlbum = this.parentNode;
                    var children = parentAlbum.childNodes[1].childNodes;

                    for (i = 0; i < children.length; i++) {

                        for (j = 0; j < children.length; j++) {

                            if (children[i].className == 'album' && children[j].className == 'album') {

                                if (children[i].childNodes[0].innerText > children[j].childNodes[0].innerText) {

                                    var temp = children[i].innerHTML;
                                    children[i].innerHTML = children[j].innerHTML;
                                    children[j].innerHTML = temp;
                                }

                            }
                        }
                    }
                }, false);
            }, false);

            this.addToRepository.addEventListener("click", function (ev) {
                ev.preventDefault();

                var addAlbum = that.addAlbumToRepositoryTitle.value;

                var album = document.getElementById(addAlbum);
                var children = album.childNodes;

                var albumTitle = children[0].innerText;
                var albumImages = new Array();
                var albumAlbums = new Array();
                var container = children[1];

                var containerChildren = container.childNodes;

                for (i = 0; i < containerChildren.length; i++) {
                    if (containerChildren[i].className == 'image') {
                        var imageTitle = containerChildren[i].childNodes[0].innerText;
                        var imageSource = containerChildren[i].childNodes[1];

                        style = imageSource.currentStyle || window.getComputedStyle(imageSource, false),
						bi = style.backgroundImage.slice(4, -1);

                        var newImage = new Picture({
                            imageTitle: imageTitle,
                            imageSource: bi
                        });

                        albumImages.push(newImage);
                    } else if (containerChildren[i].className == 'album') {
                        var title = containerChildren[i].childNodes[0].innerText;
                        var albumContainer = containerChildren[i].childNodes[1];
                        var albumChildren = albumContainer.childNodes;

                        var albumImageSet = new Array();
                        var albumAlbumsSet = new Array();
                        for (j = 0; j < albumChildren.length; j++) {
                            if (albumChildren[j].className == 'image') {
                                var newImageTitle = albumChildren[j].childNodes[0].innerText;
                                var newSource = albumChildren[j].childNodes[1];

                                style = newSource.currentStyle || window.getComputedStyle(newSource, false),
								bi = style.backgroundImage.slice(4, -1);

                                var nextImage = new Picture({
                                    imageTitle: newImageTitle,
                                    imageSource: bi
                                });

                                albumImageSet.push(nextImage);
                            }
                        }

                        var newAlbum = new Album({
                            albumTitle: title,
                            imageSet: albumImageSet,
                            albumSet: albumAlbumsSet
                        });

                        albumAlbums.push(newAlbum);
                    }
                }

                var newRepository = new RepositoryAlbum({
                    albumTitle: albumTitle,
                    imageSet: albumImages,
                    albumSet: albumAlbums
                });

                localStorage.setItem('galleryRepository', newRepository);

                function Album(parameters) {
                    this.albumTitle = parameters.albumTitle;
                    this.imageSet = parameters.imageSet;
                    this.albumSet = parameters.albumSet;
                }

                function Picture(parameters) {
                    this.imageTitle = parameters.imageTitle;
                    this.imageSource = parameters.imageSource;
                }

                function RepositoryAlbum(parameters) {
                    this.albumTitle = parameters.albumTitle;
                    this.setImages = parameters.setImages;
                    this.setAlbums = parameters.setAlbums;
                }


            }, false);

            this.sortAlbums.addEventListener("click", function (ev) {
                ev.preventDefault();

                var gallery = that.gallery;

                var children = gallery.childNodes;

                for (i = 0; i < children.length; i++) {

                    for (j = 0; j < children.length; j++) {

                        if (children[i].className == 'album' && children[j].className == 'album') {

                            if (children[i].childNodes[0].innerText < children[j].childNodes[0].innerText) {

                                var temp = children[i].innerHTML;
                                children[i].innerHTML = children[j].innerHTML;
                                children[j].innerHTML = temp;
                            }

                        }
                    }
                }

            }, false);

            this.sortAlbums.addEventListener("dblclick", function (ev) {
                ev.preventDefault();

                var gallery = that.gallery;

                var children = gallery.childNodes;

                for (i = 0; i < children.length; i++) {

                    for (j = 0; j < children.length; j++) {

                        if (children[i].className == 'album' && children[j].className == 'album') {

                            if (children[i].childNodes[0].innerText > children[j].childNodes[0].innerText) {

                                var temp = children[i].innerHTML;
                                children[i].innerHTML = children[j].innerHTML;
                                children[j].innerHTML = temp;
                            }

                        }
                    }
                }

            }, false);

            this.addGalleryToRepository.addEventListener("click", function (ev) {
                ev.preventDefault();

                var gallery = that.gallery;
                var galleryChilds = gallery.childNodes;

                var galleryImages = new Array();
                var galleryAlbums = new Array();

                for (k = 0; k < galleryChilds.length; k++) {

                    if (galleryChilds[k].className == 'image') {
                        var imageTitle = galleryChilds[k].childNodes[0].innerText;
                        var imageSource = galleryChilds[k].childNodes[1];

                        style = imageSource.currentStyle || window.getComputedStyle(imageSource, false),
                        bi = style.backgroundImage.slice(4, -1);

                        var newImage = new Picture({
                            imageTitle: imageTitle,
                            imageSource: bi
                        });

                        galleryImages.push(newImage);

                    }
                    else if (galleryChilds[k].className == 'album') {

                        var album = galleryChilds[k];
                        var children = album.childNodes;

                        var albumTitle = children[0].innerText;
                        var albumImages = new Array();
                        var albumAlbums = new Array();
                        var container = children[1];

                        var containerChildren = container.childNodes;

                        for (i = 0; i < containerChildren.length; i++) {
                            if (containerChildren[i].className == 'image') {
                                var imageTitle = containerChildren[i].childNodes[0].innerText;
                                var imageSource = containerChildren[i].childNodes[1];

                                style = imageSource.currentStyle || window.getComputedStyle(imageSource, false),
								bi = style.backgroundImage.slice(4, -1);

                                var newImage = new Picture({
                                    imageTitle: imageTitle,
                                    imageSource: bi
                                });

                                albumImages.push(newImage);
                            } else if (containerChildren[i].className == 'album') {
                                var title = containerChildren[i].childNodes[0].innerText;
                                var albumContainer = containerChildren[i].childNodes[1];
                                var albumChildren = albumContainer.childNodes;

                                var albumImageSet = new Array();
                                var albumAlbumsSet = new Array();
                                for (j = 0; j < albumChildren.length; j++) {
                                    if (albumChildren[j].className == 'image') {
                                        var newImageTitle = albumChildren[j].childNodes[0].innerText;
                                        var newSource = albumChildren[j].childNodes[1];

                                        style = newSource.currentStyle || window.getComputedStyle(newSource, false),
										bi = style.backgroundImage.slice(4, -1);

                                        var nextImage = new Picture({
                                            imageTitle: newImageTitle,
                                            imageSource: bi
                                        });

                                        albumImageSet.push(nextImage);
                                    }
                                }

                                var newAlbum = new Album({
                                    albumTitle: title,
                                    imageSet: albumImageSet,
                                    albumSet: albumAlbumsSet
                                });

                                albumAlbums.push(newAlbum);
                            }
                        }

                        var album = new Album({
                            albumTitle: albumTitle,
                            imageSet: albumImages,
                            albumSet: albumAlbums,
                        });
                        galleryAlbums.push(album);
                    }
                }

                var repository = new Repository({
                    galleryImageSet: galleryImages,
                    galleryAlbumSet: galleryAlbums
                });

                localStorage.setItem('galleryRepository', JSON.stringify(repository));

                function Album(parameters) {
                    this.albumTitle = parameters.albumTitle;
                    this.imageSet = parameters.imageSet;
                    this.albumSet = parameters.albumSet;
                }

                function Picture(parameters) {
                    this.imageTitle = parameters.imageTitle;
                    this.imageSource = parameters.imageSource;
                }

                function RepositoryAlbum(parameters) {
                    this.albumTitle = parameters.albumTitle;
                    this.setImages = parameters.setImages;
                    this.setAlbums = parameters.setAlbums;
                }

                function Repository(parameters) {
                    this.galleryImageSet = parameters.galleryImageSet;
                    this.galleryAlbumSet = parameters.galleryAlbumSet;
                }

            }, false);

            this.buildGalleryFromRepository.addEventListener("click", function (ev) {
                var gallery = that.gallery;

                var galleryContainer = JSON.parse(localStorage.getItem('galleryRepository'));
                var imageSet = galleryContainer.galleryImageSet;
                var albumSet = galleryContainer.galleryAlbumSet;
                addImages({
                    imagesSet: imageSet,
                    container: gallery
                });

                addAlbums({
                    albumsSet: albumSet,
                    container: gallery
                });


                function addImages(pars) {
                    this.imagesSet = pars.imagesSet;
                    this.container = pars.container;

                    for (i = 0; i < imagesSet.length; i++) {

                        var imageTitle = imagesSet[i].imageTitle;
                        var imageSource = imagesSet[i].imageSource;

                        container.innerHTML += '<section class="image"><div id="imageTitle">' + imageTitle + '</div><div class="imageSource"></div></section>';

                        var images = container.getElementsByClassName("imageSource");

                        var image = images[images.length - 1];
                        image.style.background = "url(" + imageSource + ")";
                        image.style.backgroundRepeat = "no-repeat";
                        image.style.backgroundSize = "60px 60px";
                        image.style.backgroundPostition = "0% 0%";

                        image.addEventListener("click", function (e) {
                            e.preventDefault();

                            style = this.currentStyle || window.getComputedStyle(this, false),
                            bi = style.backgroundImage.slice(4, -1);

                            var enlarged = that.enlarged;

                            enlarged.innerHTML += '<div id="enlargeTitle">' + imageTitle + '</div><div id="enlargeSource"></div>';
                            var enlargeSource = enlarged.childNodes[2];
                            enlargeSource.style.background = "url(" + bi + ")";
                            enlargeSource.style.backgroundRepeat = "no-repeat";
                            enlargeSource.style.backgroundSize = "150px 150px";
                            enlargeSource.style.backgroundPostition = "0% 0%";

                        }, false);
                    }
                }

                function addAlbums(pars) {
                    this.albumsSet = pars.albumsSet;
                    this.container = pars.container;

                    for (i = 0; i < albumsSet.length; i++) {
                        var albumTitle = albumsSet[i].albumTitle;

                        container.innerHTML += '<section class="album" id=' + albumTitle + '><div id="albumTitle">' + albumTitle + '</div><div id="albumContainer"></div><input type="text" class="sortInnerAlbums" value="Sort inside albums"/></section>';

                        var albums = container.getElementsByClassName("album");
                        var album = albums[albums.length - 1];
                        var title = album.childNodes[0];
                        var albumContainer = album.childNodes[1];
                        var button = album.childNodes[2];

                        title.addEventListener("click", function (e) {
                            e.preventDefault();
                            var parentAlbum = this.parentNode;
                            if (parentAlbum.className == 'short') {
                                parentAlbum.setAttribute("class", "album");
                            } else if (parentAlbum.className == 'album') {
                                parentAlbum.setAttribute("class", "short");
                            }
                        }, false);

                        button.addEventListener("click", function (e) {
                            e.preventDefault();
                            var parentAlbum = this.parentNode;
                            var children = parentAlbum.childNodes[1].childNodes;

                            for (i = 0; i < children.length; i++) {

                                for (j = 0; j < children.length; j++) {

                                    if (children[i].className == 'album' && children[j].className == 'album') {

                                        if (children[i].childNodes[0].innerText < children[j].childNodes[0].innerText) {

                                            var temp = children[i].innerHTML;
                                            children[i].innerHTML = children[j].innerHTML;
                                            children[j].innerHTML = temp;
                                        }

                                    }
                                }
                            }
                        }, false);

                        button.addEventListener("dblclick", function (e) {
                            e.preventDefault();
                            var parentAlbum = this.parentNode;
                            var children = parentAlbum.childNodes[1].childNodes;

                            for (i = 0; i < children.length; i++) {

                                for (j = 0; j < children.length; j++) {

                                    if (children[i].className == 'album' && children[j].className == 'album') {

                                        if (children[i].childNodes[0].innerText > children[j].childNodes[0].innerText) {

                                            var temp = children[i].innerHTML;
                                            children[i].innerHTML = children[j].innerHTML;
                                            children[j].innerHTML = temp;
                                        }
                                    }
                                }
                            }
                        }, false);

                        var albumImages = albumsSet[i].imageSet;
                        var albumAlbums = albumsSet[i].albumSet;

                        if (albumImages.length != 0) {
                            addImages({
                                imagesSet: albumImages,
                                container: album
                            });
                        }

                        if (albumAlbums.length != 0) {
                            addAlbums({
                                albumsSet: albumAlbums,
                                container: album
                            });
                        }
                    }
                }
            }, false);
        }
    }
})();

