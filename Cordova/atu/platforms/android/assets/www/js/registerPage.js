
var registerPage = {

    template:
    '<div class="page center">' +
        '<header><span class="centerlogo" title="DigitasLBi"></span></header>' +
        '<div class="body">' +
            '<div class="login-form">' +
            '<h1>{{name}}</h1>' +
                '<form id="login-form">' +
                    '<div class="form-input">' +
                        '<label for="displayname">Pick a username</label><br/>' +
                        '<input id="displayname" type="text" name="displayname" />' +
                    '</div>' +
                    '<div class="form-input">' +
                        '<a id="register-button" href="#" class="btn">Ready to go!</a>' +
                    '</div>' +
                '</form>' +
            '</div>' +
        '</div>' +
        '<footer>' +
        '</footer>' +
    '</div>',
}