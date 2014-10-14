
var questionDetailPage = {

    template:
    '<div class="page center">' +
        '<header>' +
            header.getHeader(true, core.myQsPageHash) +
        '</header>' +
        '<div class="body">' +
            '<h1>{{name}}</h1>' +
            '<div id="question-detail">' +
                '<img id="loader-image" src="img/unicorn-100px.gif" alt="loading" style="padding-left: 8px;" />' +
            '</div>' +
        '</div>' +
        '<footer>' +
            footerMenu.getFooterMenu() +
        '</footer>' +
    '</div>'
}