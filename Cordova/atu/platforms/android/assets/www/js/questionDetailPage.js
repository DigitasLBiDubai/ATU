
var questionDetailPage = {

    template:
    '<div class="page center">' +
        '<header>' +
            header.getHeader(true) +
        '</header>' +
        '<div class="body">' +
            '<h1>{{name}}</h1>' +
        '</div>' +
        '<footer>' +
            footerMenu.getFooterMenu(core.myQsPageHash) +
        '</footer>' +
    '</div>',
}