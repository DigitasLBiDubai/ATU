var app = {

    // ##################
    // #### Defaults ####
    username: "otavio",
    password: "aaa",

    // ###################
    // #### Variables ####
    myQuestions: null,
    currentQuestionId: null,
    currentQuestionTitle: null,
    currentQuestion: null,
    appHistory: [],
    previousHash: "",

	updateView: function(page){
		document.getElementById("container").innerHTML = page;
	},

    route: function (event) {

        var page,
            hash = window.location.hash;

        console.log("hash:" + hash);
        app.appHistory.push(hash);

        if (app.isAuthenticated()) {
            if (hash === core.newQuestionPageHash) {
                page = app.merge(questionPage.template, { name: "Ask The Unicorn!", description: "" });
                app.updateView(page);
                app.bindQuestionPageEvents();
                return;
            }
            else if (hash === core.questionPageHash) {
                page = app.merge(questionDetailPage.template, { name: app.currentQuestionTitle, description: "" });
                app.updateView(page);
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
            else if (hash === core.registerPageHash) {
                page = app.merge(registerPage.template, { name: "Registration Page", description: "" });
                app.updateView(page);
                app.bindRegisterPageEvents();
                return;
            }            
            else if (hash === app.loginPageHash || hash === null || hash === '') {
                page = app.merge(questionPage.template, { name: "Ask The Unicorn!", description: "" });
                app.updateView(page);
                app.bindQuestionPageEvents();
                return;
            }
        }

        page = app.merge(registerPage.template, { name: "Sign up for Unicorn wisdom", description: "" });
		app.updateView(page);
        app.bindRegisterPageEvents();
    },

    isAuthenticated: function () {
        //console.log("isAuthenticated");
        if (ls.get(core.usernameLocalStorageKey) !== null &&
            ls.get(core.usernameLocalStorageKey) !== "" &&
            ls.get(core.usernameLocalStorageKey) !== "null" &&
            ls.get(core.authTokenLocalStorageKey) !== null &&
            ls.get(core.authTokenLocalStorageKey) !== "" &&
            ls.get(core.authTokenLocalStorageKey) !== "null") {
            return true;
        }
        else {
            return false;
        }
    },

    getAuthThoken:function () {
        return ls.get(core.authTokenLocalStorageKey);
    },

    merge: function (tpl, data) {
        return tpl.replace("{{name}}", data.name)
                  .replace("{{description}}", data.description)
    },

    questionListItemMarkup: function (data, cat) {
        var html = '';
        if (cat != ''){
            html = html + '<li class="category"><strong>' + cat + '</strong></li>';
        }
        html = html + '<li>';
        html = html + '<a id="question-' + data.Id  + '" data-question-id="' + data.Id + '" class="question-link">' + data.Text + '</a>';
        return html + '</li>'
    },

    templateQuestions: function (data) {
        var html = '<ul class="list">';
        var prev_Cat = '';

        
        for (var i = 0; i < data.length; i++) { 
            var item = data[i];
            var cat = '';
            if (item.Category != null && item.Category.Id != prev_Cat){
                cat = item.Category.Text;
            }
            html = html + app.questionListItemMarkup(item, cat); 

            if(item.Category != null){
                prev_Cat = item.Category.Id;
            }
        }
        return html + '</ul>';
    },

    templateQuestion: function (data) {
        var html = '<p class="question">';   

        if(data.Answers.length > 0){    
            html = html + "<ul>"
            for(var i = 0; i < data.Answers.length; i++){
                html = html + "<li>" + data.Answers[i].Text + "</li>"; 
            }        
        }else{
            html = "<p>The Unicorn is currently answering your question, this should be done within 24 hours.</p>"
        }
        return html + '</p>';
    },

    loadMyQuestions: function (data) {
        var req = null;
        req = new XMLHttpRequest();
        req.open("POST", core.APIUrl + "MyQuestion/");
        req.setRequestHeader("Content-Type", "application/json");

        req.onreadystatechange = function () {
            if (req.readyState == 4 && req.status == 200) {
                app.myQuestions = JSON.parse(req.responseText);
                var questionsHtml = app.templateQuestions(app.myQuestions);
                document.getElementById(core.questionListDivId).innerHTML = questionsHtml;
                app.bindQuestionListLinks();                
            }
        }        
        var r =  '{"AuthToken":"' + app.getAuthThoken() + '"}';
        console.log(r); 
        req.send(r);
    },

    loadFaqs: function (data) {
        var req = null;
        req = new XMLHttpRequest();
        req.open("GET", core.APIUrl + "Faq");
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
            app.bindHeaderEvents();
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

        req.send('{ "Text":"' + text + '", "AuthToken":"'+ app.getAuthThoken() + '"}');
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
        ls.set(core.authTokenLocalStorageKey, null)
    },
    goBack: function(){

        var previous = "";
        if(app.appHistory.length > 0){
            app.appHistory.pop();            
            
            if (app.appHistory.length > 0){
                previous = app.appHistory[app.appHistory.length - 1];
            }
        }               
        window.location.hash = previous;        
    },

    bindRegisterPageEvents: function () {
        document.getElementById(core.registerSubmitButtonId).addEventListener("click", function (e) {
            var displayName = document.getElementById(core.registerDisplayNameTextBoxId).value;           
            //email is username
            if (displayName !== null && displayName !== "") {
                //var req = null;
                var req = new XMLHttpRequest();
                req.open("POST", core.APIUrl + "registration", false);
                req.setRequestHeader("Content-Type", "application/json");

                req.onreadystatechange = function () {
                    if (req.readyState == 4 && req.status == 201) {
                        var h = req.responseText.replace(/"/g, '');

                        ls.set(core.authTokenLocalStorageKey, h);
                        console.log("authentication hash: " + h);
                        window.location.hash = core.faqPageHash;
                    }
                }

                ls.set(core.usernameLocalStorageKey, displayName);
                req.send('{ "DisplayName":"' + displayName + '"}');                                                
            }
        }, false);
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
            console.log("binding question click event, question id: " + questionLinks[i].id);
            document.getElementById(questionLinks[i].id).addEventListener("click", function (e) {
                console.log("question clicked: " + e.target.getAttribute("data-question-id"))
                app.currentQuestionId = e.target.getAttribute("data-question-id");
                app.currentQuestionTitle = e.target.innerHTML;
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