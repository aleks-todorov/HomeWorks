/// <reference path="jquery-1.10.1.js" />
window.fbAsyncInit = function () {
    FB.init({
        appId: '207212666093569',
        channelUrl: '//http://localhost:20511/channel.html',
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });

    FB.login(function (response) {
        if (response.authResponse) {

        } else {
            console.log('User cancelled login or did not fully authorize.');
        }
    }, { scope: 'read_friendlists,user_photos, user_birthday' });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

(function () {

    $("#show-friends").click(function () { getFriends() });
    function getFriends() {
        FB.api('/me/friends', function (response) {
            var friendsHolder = $('#friends-holder');
            for (i = 0; i < response.data.length; i++) {
                var friendPictureUrl = 'https://graph.facebook.com/' + response.data[i].id + '/picture';
                var friendName = response.data[i].name;
                friendsHolder.append("<div><img src = " + friendPictureUrl + "/>  <p> " + friendName + "</p></div>");
            }
        });
    }

    $("#remove-friends").on("click", function () {
        $('#friends-holder div').remove();
    });

    $('#friends-holder').on('click', 'img', function () {

        if ($(this).css('width') !== '150px') {
            $(this).css('width', '150px');
            $(this).css('height', '150px');
        }
        else {
            $(this).css('width', '50px');
            $(this).css('height', '50px');
        }
    });

    $('#personal-info').on('click', function () {
        FB.api('me', function (responce) {
            console.log(responce);
            $('<p>Location: ' + responce.location.name + '</p>').appendTo('body');
            $('<p> Birthday: ' + responce.birthday + '</p>').appendTo('body');
        });
    });

    $("#logout").click(function () {
        FB.logout(function (response) {
        });
    });

})();