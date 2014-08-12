
var header = {

    getHeader: function (isAuthenticated) {
        var html = '<span class="centerlogo" title="DigitasLBi"></span>';

        if (isAuthenticated) {
            html = html + '<a id="logout-button" href="#" class="btn-right" >Logout</a>';
        }
        else {
            html = html + '<a href="#" class="btn-right" >Login</a>';
        }

        return html;
    }
}