var ImageSliderNS = (function () {
    var counter = 1;
    var Image = {
        init: function (title, thumbnailURL, enlargedURL) {
            this.title = title;
            this.thumbnainURL = thumbnailURL;
            this.enlargedURL = enlargedURL;
            this.url = thumbnailURL;
        },
    };

    var Album = {
        init: function () {
            this.album = [];
        },

        addImage: function (title, thumbnailURL, enlargedURL) {
            var image = Object.create(Image);
            image.init(title, thumbnailURL, enlargedURL);
            this.album.push(image);
        },

        //Not the best looking function(with these 3 eventhandler in one, 
        //but for the moment this will have to stay.
        render: function () {
            var i = 0;
            var fragment = document.createDocumentFragment();

            for (i = 0; i < this.album.length; i++) {
                var title = document.createElement("p");
                title.innerHTML = this.album[i].title;
                var img = document.createElement("img");
                img.src = this.album[i].url;
                img.alt = this.album[i].enlargedURL;
                var holder = document.createElement("div");
                holder.classList.add("holder");
                holder.appendChild(title);
                holder.appendChild(img);
                img.addEventListener("click", function (ev) {
                    if (!ev) {
                        ev = window.event;
                    }
                    if (ev.stopPropagation) {
                        ev.stopPropagation();
                    }
                    if (ev.preventDefault) {
                        ev.preventDefault();
                    }
                    var container = document.getElementById("container");

                    if (container) {
                        document.body.removeChild(container);
                    }

                    container = document.createElement("div");
                    container.id = "container";
                    var picture = document.createElement("img");
                    picture.id = "profile";
                    picture.src = ev.target.alt;
                    container.appendChild(picture);
                    var buttonPrev = document.createElement("button");
                    buttonPrev.innerHTML = "Previous";
                    buttonPrev.addEventListener("click", function () {
                        if (counter < 1) {
                            counter = 4;
                        }
                        var picture = document.getElementById("profile");
                        picture.src = "images/big-" + counter + ".jpg";
                        counter--;
                    }, false);
                    container.appendChild(buttonPrev);
                    var buttonNext = document.createElement("button");
                    buttonNext.addEventListener("click", function () {
                        if (counter > 4) {
                            counter = 1;
                        }
                        var picture = document.getElementById("profile");
                        picture.src = "images/big-" + counter + ".jpg";
                        counter++;
                    }, false);
                    buttonNext.innerHTML = "Next";
                    container.appendChild(buttonNext);
                    document.body.appendChild(container);
                }, false);
                fragment.appendChild(holder);
            }

            document.body.appendChild(fragment);
        },
    };

    return {
        Album: Album
    }
})();