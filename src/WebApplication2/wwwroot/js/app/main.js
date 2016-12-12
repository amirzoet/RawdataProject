/// <reference path="components/searchhistory/searchhistory.js" />

(function () {
    require.config({
        baseUrl: "js",
        paths: {
            "jquery": "lib/jquery/dist/jquery",
            "knockout": "lib/knockout/dist/knockout",
            "dataservice": "app/services/dataservice",
            "text": "lib/requirejs-text/text",
            "postman": "app/services/postman",
            "config": "app/config",
            "bootstrap": "lib/bootstrap/dist/css/bootstrap"
        }
    });

    require(['knockout', 'config'], function (ko, config) {
        ko.components.register(config.components.app,
            {
                viewModel: { require: 'app/components/app/app' },
                template: {require: 'text!app/components/app/appview.html'}
            });

        ko.components.register(config.components.search,
            {
                viewModel: { require: 'app/components/search/search' },
                template: { require: 'text!app/components/search/searchview.html' }
            });

        ko.components.register(config.components.searchHistory,
            {
                viewModel: { require: 'app/components/searchhistory/searchhistory' },
                template: { require: 'text!app/components/searchhistory/searchhistoryview.html' }
            });

        ko.components.register(config.components.mark,
            {
                viewModel: { require: 'app/components/mark/mark' },
                template: { require: 'text!app/components/mark/markview.html' }
            });

        ko.components.register(config.components.user,
            {
                viewModel: { require: 'app/components/user/user' },
                template: { require: 'text!app/components/user/userview.html' }
            });
    })


    require(['knockout'], function (ko) {
        ko.applyBindings();
    })
})();


