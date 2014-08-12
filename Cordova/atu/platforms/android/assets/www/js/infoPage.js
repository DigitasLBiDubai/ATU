
var infoPage = {

    template:
    '<div class="page center">' +
        '<header>' +
            header.getHeader(true) +
        '</header>' +
        '<div class="body">' +
            '<div class="centered">' +
                '<h1>{{name}}</h1>' +
                '<p>Here you can get directly in touch with the DigitasLBi specialists of all disciplines.</p>' +
            '</div>' +
        '</div>' +
        '<footer>' +
            footerMenu.getFooterMenu(core.infoPageHash) +
        '</footer>' +
    '</div>',
}