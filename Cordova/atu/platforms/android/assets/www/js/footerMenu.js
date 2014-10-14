
var footerMenu = {

    getFooterMenu: function (selectedItemName) {
        var menu = '';

        if (selectedItemName === core.questionPageHash) {
            menu = menu + '<a href="#question"><div class="footer-options-div selected">New Q</div></a>';
        }
        else {
            menu = menu + '<a href="#question"><div class="footer-options-div">New Q</div></a>';
        }

        if (selectedItemName === core.faqPageHash) {
            menu = menu + '<a href="#faq"><div class="footer-options-div selected">FAQ</div></a>';
        }
        else {
            menu = menu + '<a href="#faq"><div class="footer-options-div">FAQ</div></a>';
        }

        if (selectedItemName === core.myQsPageHash) {
            menu = menu + '<a href="#myqs"><div class="footer-options-div selected">My Qs</div></a>';
        }
        else {
            menu = menu + '<a href="#myqs"><div class="footer-options-div">My Qs</div></a>';
        }
        /*
        if (selectedItemName === core.usernameHash) {
            menu = menu + '<a href="#username"><div class="footer-options-div selected">Username</div></a>';
        }
        else {
            menu = menu + '<a href="#username"><div class="footer-options-div">Username</div></a>';
        }

        if (selectedItemName === core.infoPageHash) {
            menu = menu + '<a href="#info"><div class="footer-options-div selected">Info</div></a>';
        }
        else {
            menu = menu + '<a href="#info"><div class="footer-options-div">Info</div></a>';
        }
        */
        return menu;
    }
}