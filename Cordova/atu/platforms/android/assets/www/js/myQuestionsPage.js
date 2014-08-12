
var myQsPage = {

    template:
    '<div class="page center">' +
        '<header>' +
            header.getHeader(true) +
        '</header>' +
        '<div class="body">' +
            '<h1>{{name}}</h1>' +
            '<div id="questions">' +
                '<img id="loader-image" src="img/loadinfo-gray-red.gif" alt="loading" />' +
            '</div>' +
        '</div>' +
        '<footer>' +
            footerMenu.getFooterMenu(core.myQsPageHash) +
        '</footer>' +
    '</div>',
}