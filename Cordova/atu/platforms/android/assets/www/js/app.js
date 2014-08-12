var app = {

    // ##################
    // #### Defaults ####
    username: "otavio",
    password: "aaa",

    // ###################
    // #### Variables ####
    myQuestions: null,

	updateView: function(page){
		document.getElementById("container").innerHTML = page;
	},

    route: function (event) {
        var page,
            hash = window.location.hash;

        if (app.isAuthenticated()) {
            if (hash === core.questionPageHash) {
                page = app.merge(questionPage.template, { img: "buildbot.jpg", name: "Ask The Unicorn!", description: "" });
                app.updateView(page);
                app.bindQuestionPageEvents();
                return;
            }
            else if (hash === core.infoPageHash) {
                page = app.merge(infoPage.template, { img: "buildbot.jpg", name: "Info", description: "" });
                app.updateView(page);
                app.bindInfoPageEvents();
                return;
            }
            else if (hash === core.faqPageHash) {
                page = app.merge(faqPage.template, { img: "buildbot.jpg", name: "FAQs", description: "" });
                app.updateView(page);
                app.bindFaqPageEvents();
                window.setTimeout(app.loadFaqs(), core.requestDelayMiliseconds);
                return;
            }
            else if (hash === core.myQsPageHash) {
                page = app.merge(myQsPage.template, { img: "buildbot.jpg", name: "My Questions", description: "" });
                app.updateView(page);
                app.bindMyQsPageEvents();
                window.setTimeout(app.loadMyQuestions(), core.requestDelayMiliseconds);
                return;
            }
            else if (hash === core.usernameHash) {
                page = app.merge(usernamePage.template, { img: "buildbot.jpg", name: "Username Page", description: "" });
                app.updateView(page);
                app.bindUsernamePageEvents();
                return;
            }
            else if (hash === app.loginPageHash || hash === null || hash === '') {
                page = app.merge(questionPage.template, { img: "buildbot.jpg", name: "Ask The Unicorn!", description: "" });
                app.updateView(page);
                app.bindQuestionPageEvents();
                return;
            }
        }

        page = app.merge(loginPage.template, { img: "buildbot.jpg", name: "Login", description: "" });
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
        html = html + '<a href="#"><strong>' + data.Text + '</strong></a>';
        return html + '</li>'
    },

    templateQuestions: function (data) {
        var html = '<ul class="list">';
        for (var i = 0; i < data.length; i++) { html = html + app.questionListItemMarkup(data[i]); }
        return html + '</ul>';
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
            window.location.hash = core.faqPageHash;
        }, false);
    },

    bindLoginPageEvents: function () {
        document.getElementById(core.loginButtonId).addEventListener("click", function (e) {
            if (app.login()) {
                e.target.href = core.questionPageHash;
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

    bindUsernamePageEvents: function () {
        app.bindHeaderEvents();
    },

    initialize: function () {
        window.addEventListener("hashchange", app.route);
        app.route();
    }
}