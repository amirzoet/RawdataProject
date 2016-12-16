define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, ds, postman, config) {
        return function (params) {
            var post = ko.observable();

            var getPost = function (url) {
                ds.getUrl(url, function (data) {
                    post(data);
                });
            };
            if (params && params.url) {
                getPost(params.url);
            }

            var selectUser = function (url) {
                postman.publish(config.events.showUser, url);
                console.log(url); 
            };

            return {
                post: post,
                selectUser: selectUser
            };
        }
    });