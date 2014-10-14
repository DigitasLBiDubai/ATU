
var questionPage = {

    template:
    '<div class="page center">' +
        '<header>' +
            header.getHeader(true) +
        '</header>' +
        '<div class="body">' +
            '<div class="login-form">' +
                '<h1>{{name}}</h1>' +
                '<form>' +
                    '<div class="form-input">' +
                        '<textarea id="question-input" name="question" cols="40" rows="7" placeholder="This is what I always wanted to know ..."></textarea>' +
                    '</div>' +
                    '<div class="form-input">' +
                        '<a id="submit-question-button" href="#" class="btn">Submit Question</a>' +
                    '</div>' +
                '</form>' +
            '</div>' +
        '</div>' +
        '<footer>' +
            footerMenu.getFooterMenu(core.questionPageHash) +
        '</footer>' +
    '</div>',
}