
(function () {
    require.config({
        baseUrl: "js",
        paths: {
            "jquery": "lib/jquery/dist/jquery",
            "knockout": "lib/knockout/dist/knockout",
            "dataservice": "app/services/dataservice",
            "text": "lib/requirejs-text/text"
        }
    });

    require(['knockout'], function (ko) {
        ko.components.register("user",
            {
                viewModel: { require: 'app/components/user/user' },
                template: { require: 'text!app/components//user/userview.html' }
            });
    })


    require(['knockout'], function (ko) {
        ko.applyBindings();
    })
})();


