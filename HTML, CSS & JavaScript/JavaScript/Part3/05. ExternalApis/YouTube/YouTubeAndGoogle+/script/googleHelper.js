var helper = (function () {

    return {
        disconnect: function () {
            // Revoke the access token.
            $.ajax({
                type: 'GET',
                url: 'https://accounts.google.com/o/oauth2/revoke?token=' +
                    gapi.auth.getToken().access_token,
                async: false,
                contentType: 'application/json',
                dataType: 'jsonp',
                success: function (result) {
                    $('#signinButton').toggle();
                },
                error: function (e) {
                    console.log(e);
                }
            });
        }
    };
})();