define(['knockout', 'dataservice', 'postman'],
    function (ko, ds, pm) {
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

            return {
                post: post,
            };
        }
    });