var FavouriteBarNS = (function () {

    var URL = Class.create({
        init: function (title, url) {
            this.title = title;
            this.url = url;
        },

        render: function () {
            var address = document.createElement("li");
            address.innerHTML = "<a href=" + this.url + " target = \"_blank\">" + this.title + "</a>";
            return address;
        }
    });

    var Folder = Class.create({
        init: function (title) {
            this.title = title;
            this.setOfUrls = [];
        },

        addURL: function (URL) {
            this.setOfUrls.push(URL);
        },

        render: function () {
            var folder = document.createElement("ul");
            folder.innerHTML = "<p>" + this.title + "</p>";
            var i = 0;

            for (i = 0; i < this.setOfUrls.length; i += 1) {
                var child = this.setOfUrls[i].render();
                folder.appendChild(child);
            }

            return folder;
        }
    });

    var FavouriteBar = Class.create({
        init: function () {
            this.content = [];
        },

        addFolder: function (folder) {
            this.content.push(folder);
        },

        addURL: function (URL) {
            this.content.push(URL);
        },

        render: function () {
            var favouriteBar = document.createElement("ul");
            favouriteBar.id = "favouriteBar";
            favouriteBar.style.display = "block";
            favouriteBar.innerHTML = "<p>Favourite Bar:</p>";
            var i = 0;
            for (i = 0; i < this.content.length; i += 1) {
                var child = this.content[i].render();
                favouriteBar.appendChild(child);
            }
            document.body.appendChild(favouriteBar);
        }
    });

    return {
        FavouriteBar: FavouriteBar,
        Folder: Folder,
        URL: URL
    }
})();