
var myQsPage = {

    template:
    '<div class="page center">' +
        '<header>' +
            header.getHeader(true) +
        '</header>' +
        '<div class="body">' +
            '<h1>{{name}}</h1>' +
            '<div id="questions" style="padding-bottom: 44px;">' +
                '<img id="loader-image" src="img/unicorn-100px.gif" style="padding-left: 8px;" alt="loading" />' +
            '</div>' +
        '</div>' +
        '<footer>' +
            footerMenu.getFooterMenu(core.myQsPageHash) +
        '</footer>' +
    '</div>',
}