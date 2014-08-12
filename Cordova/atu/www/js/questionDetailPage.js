
var questionDetailPage = {

    template:
    '<div class="pagewrapper">' +
        '<header>' +
            header.getHeader(true, core.myQsPageHash) +
        '</header>' +
        '<div class="body">' +
            '<div id="question-detail">' +
                '<img id="loader-image" src="img/loadinfo-gray-red.gif" alt="loading" />' +
            '</div>' +
        '</div>' +
        '<footer>' +
            footerMenu.getFooterMenu(core.myQsPageHash) +
        '</footer>' +
    '</div>'
}