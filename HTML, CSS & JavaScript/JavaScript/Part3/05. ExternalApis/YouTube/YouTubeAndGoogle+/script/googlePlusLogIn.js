function signinCallback(authResult) {
    if (authResult['access_token']) {
        // Successfully authorized
        // Hide the sign-in button now that the user is authorized, for example:
        document.getElementById('signinButton').setAttribute('style', 'display: none');
        $('<div id="content"></div>').appendTo('body');
        $('#youtube-player').toggle();
        $('#content').append(
                    $('<h3>Profile photo</h3><p><img src=\"' + "https://plus.google.com/s2/photos/profile/me" + "?sz=100" + '\"></p>'));
    } else if (authResult['error']) {
        console.log('Google+ access denied!');
        // There was an error.
        // Possible error codes:
        //   "access_denied" - User denied access to your app
        //   "immediate_failed" - Could not automatically log in the user
        // console.log('There was an error: ' + authResult['error']);
    }
}