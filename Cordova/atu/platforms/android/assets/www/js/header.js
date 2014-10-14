
function goBack(){
    if (typeof (navigator.app) !== "undefined") {
        navigator.app.backHistory();
    } else {
        window.history.back();
    }
}
var header = {

    getHeader: function (isAuthenticated, backHash) {
        var html = '<span class="centerlogo" title="DigitasLBi"></span>';

        if (backHash !== null && backHash !== '') {
            html = html + '<a id="back-button" href="javascript:goBack()" class="btn-left" >Back</a>';
        }

        if (isAuthenticated) {
            html = html + '<a id="logout-button" href="#" class="btn-right" >Logout</a>';
        }
        else {
            html = html + '<a href="#" class="btn-right" >Login</a>';
        }

        return html;
    }
}