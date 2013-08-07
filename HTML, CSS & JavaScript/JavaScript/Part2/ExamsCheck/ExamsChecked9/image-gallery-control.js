'use strict';

this.controls = this.controls || {}

controls.getImageGallery = (function () {
    function Gallery(element) {
        this.holder = element
    }    
    
    Gallery.prototype.addImage = function (imageTitle, source) {
        var figure = document.createElement("figure");
        var figcaption = document.createElement("figcaption");
        var image = document.createElement("img");
        figcaption.textContent = imageTitle;
        image.src = source;

        figure.appendChild(figcaption);
        figure.appendChild(image);
        this.holder.appendChild(figure);
    }

    Gallery.prototype.addAlbum = function (albumTitle) {
        var album = document.createElement("div");
        album.className = "album";
        album.textContent = albumTitle;
        this.holder.appendChild(album);        
    }     

    return function (selector) {
        var element = document.querySelector(selector);
        var gallery = new Gallery(element);

        return gallery;
    }
}())