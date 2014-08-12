var app = {

    // ##################
    // #### Defaults ####
    username: "otavio",
    password: "aaa",

    // ###################
    // #### Variables ####
    myQuestions: null,
    currentQuestionId: null,
    currentQuestion: null,

	updateView: function(page){
		document.getElementById("container").innerHTML = page;
	},

    route: function (event) {
        var page,
            hash = window.location.hash;

        console.log(hash);

        if (app.isAuthenticated()) {
            if (hash === core.newQuestionPageHash) {
                page = app.merge(questionPage.template, { name: "Ask The Unicorn!", description: "" });
                app.updateView(page);
                app.bindQuestionPageEvents();
                return;
            }
            else if (hash === core.questionPageHash) {
                page = app.merge(questionPage.template, { name: "Ask The Unicorn!", description: "" });
                app.updateView(page);
                app.bindQuestionPageEvents();
                window.setTimeout(app.loadQuestion(), core.requestDelayMiliseconds);
                return;
            }
            else if (hash === core.infoPageHash) {
                page = app.merge(infoPage.template, { name: "Info", description: "" });
                app.updateView(page);
                app.bindInfoPageEvents();
                return;
            }
            else if (hash === core.faqPageHash) {
                page = app.merge(faqPage.template, { name: "FAQs", description: "" });
                app.updateView(page);
                app.bindFaqPageEvents();
                window.setTimeout(app.loadFaqs(), core.requestDelayMiliseconds);
                return;
            }
            else if (hash === core.myQsPageHash) {
                page = app.merge(myQsPage.template, { name: "My Questions", description: "" });
                app.updateView(page);
                app.bindMyQsPageEvents();
                window.setTimeout(app.loadMyQuestions(), core.requestDelayMiliseconds);
                return;
            }
            else if (hash === core.usernameHash) {
                page = app.merge(usernamePage.template, { name: "Username Page", description: "" });
                app.updateView(page);
                app.bindUsernamePageEvents();
                return;
            }
            else if (hash === app.loginPageHash || hash === null || hash === '') {
                page = app.merge(questionPage.template, { name: "Ask The Unicorn!", description: "" });
                app.updateView(page);
                app.bindQuestionPageEvents();
                return;
            }
        }

        page = app.merge(loginPage.template, { name: "Login", description: "" });
		app.updateView(page);
        app.bindLoginPageEvents();
    },

    isAuthenticated: function () {
        //console.log("isAuthenticated");
        if (ls.get(core.usernameLocalStorageKey) !== null &&
            ls.get(core.usernameLocalStorageKey) !== "" &&
            ls.get(core.usernameLocalStorageKey) !== "null" &&
            ls.get(core.passwordLocalStorageKey) !== null &&
            ls.get(core.passwordLocalStorageKey) !== "" &&
            ls.get(core.passwordLocalStorageKey) !== "null") {
            return true;
        }
        else {
            return false;
        }
    },

    merge: function (tpl, data) {
        return tpl.replace("{{name}}", data.name)
                  .replace("{{description}}", data.description)
    },

    questionListItemMarkup: function (data) {
        var html = '<li>';
        html = html + '<a href="#" id="question-' + data.Id  + '" data-question-id="' + data.Id + '" class="question-link">' + data.Text + '</a>';
        return html + '</li>'
    },

    templateQuestions: function (data) {
        var html = '<ul class="list">';
        for (var i = 0; i < data.length; i++) { html = html + app.questionListItemMarkup(data[i]); }
        return html + '</ul>';
    },

    templateQuestion: function (data) {
        var html = '<p class="question">';
        html = html + data.Text;
        return html + '</p>';
    },

    loadMyQuestions: function (data) {
        var req = null;
        req = new XMLHttpRequest();
        req.open("GET", core.APIUrl + "question");
        req.setRequestHeader("Content-Type", "application/json");

        req.onreadystatechange = function () {
            if (req.readyState == 4 && req.status == 200) {
                app.myQuestions = JSON.parse(req.responseText);
                var questionsHtml = app.templateQuestions(app.myQuestions);
                document.getElementById(core.questionListDivId).innerHTML = questionsHtml;
                app.bindQuestionListLinks();
            }
        }

        req.send(null);
    },

    loadFaqs: function (data) {
        var req = null;
        req = new XMLHttpRequest();
        req.open("GET", core.APIUrl + "question");
        req.setRequestHeader("Content-Type", "application/json");

        req.onreadystatechange = function () {
            if (req.readyState == 4 && req.status == 200) {
                app.myQuestions = JSON.parse(req.responseText);
                var questionsHtml = app.templateQuestions(app.myQuestions);
                document.getElementById(core.questionListDivId).innerHTML = questionsHtml;
            }
        }

        req.send(null);
    },

    loadQuestion: function (data) {
        var req = null;
        req = new XMLHttpRequest();
        req.open("GET", core.APIUrl + "question/" + app.currentQuestionId);
        req.setRequestHeader("Content-Type", "application/json");

        req.onreadystatechange = function () {
            if (req.readyState == 4 && req.status == 200) {
                app.currentQuestion = JSON.parse(req.responseText);
                var questionHtml = app.templateQuestion(app.currentQuestion);
                document.getElementById(core.questionDetailDivId).innerHTML = questionHtml;
            }
        }

        req.send(null);
    },

    // #################################
    // ######## Event Handling #########
    postQuestion: function (text) {
        //console.log("postQuestion");
        var req = null;
        req = new XMLHttpRequest();
        req.open("POST", core.APIUrl + "question", false);
        req.setRequestHeader("Content-Type", "application/json");

        req.onreadystatechange = function () {
            if (req.readyState == 4 && req.status == 200) {
                window.location.hash = core.faqPageHash;
            }
        }

        req.send('{ "Text":"' + text + '"}');
    },

    getQuestions: function (text) {
        //console.log("getQuestions");
        var req = null;
        req = new XMLHttpRequest();
        req.open("GET", core.APIUrl + "question");
        req.setRequestHeader("Content-Type", "application/json");
        req.send(null);
    },

    login: function () {
        //console.log("login");
        if (document.getElementById(core.usernameTextBoxId).value == app.username && document.getElementById(core.passwordTextBoxId).value == app.password) {
            ls.set(core.usernameLocalStorageKey, document.getElementById(core.usernameTextBoxId).value);
            ls.set(core.passwordLocalStorageKey, document.getElementById(core.passwordTextBoxId).value);
            return true;
        }
        else {
            return false;
        }
    },

    logout: function () {
        //console.log("logout");
        ls.set(core.usernameLocalStorageKey, null);
        ls.set(core.passwordLocalStorageKey, null);
    },

    bindHeaderEvents: function () {
        document.getElementById(core.logoutButtonId).addEventListener("click", function (e) {
            app.logout();
        }, false);
    },

    bindLoginPageEvents: function () {
        document.getElementById(core.loginButtonId).addEventListener("click", function (e) {
            if (app.login()) {
                e.target.href = core.newQuestionPageHash;
            }
        }, false);
    },

    bindQuestionPageEvents: function () {
        document.getElementById(core.submitQuestionButtonId).addEventListener("click", function (e) {
            var text = document.getElementById(core.questionInputId).value;
            if (text !== null && text !== "") {
                app.postQuestion(text);
            }
        }, false);

        app.bindHeaderEvents();
    },

    bindInfoPageEvents: function () {
        app.bindHeaderEvents();
    },

    bindFaqPageEvents: function () {
        app.bindHeaderEvents();
    },

    bindMyQsPageEvents: function () {
        app.bindHeaderEvents();
    },

    bindQuestionListLinks: function(){
        var questionLinks = document.getElementsByClassName('question-link');
        for (var i = 0; i < questionLinks.length; i++) {
            document.getElementById(questionLinks[i].id).addEventListener("click", function (e) {
                app.currentQuestionId = e.target.getAttribute("data-question-id");
                window.location.hash = core.questionPageHash;
            }, false);
        }
    },

    bindUsernamePageEvents: function () {
        app.bindHeaderEvents();
    },

    initialize: function () {
        window.addEventListener("hashchange", app.route);
        app.route();
    }
}