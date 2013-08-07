(function () {
    function ImageGalleryRepository() {
        this.save = function () {

            Storage.prototype.setObject = function (key, obj) {
                this.setItem(key, JSON.stringify(obj));
            }            
        }

        this.load = function () {

            Storage.prototype.getObject = function (key) {
                return JSON.parse(this.getItem(key));
            }            
        }
    }
}());