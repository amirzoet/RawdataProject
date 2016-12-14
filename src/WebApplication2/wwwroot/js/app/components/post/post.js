define(['knockout', 'dataservice', 'postman'],
    function (ko, ds, pm) {
        return function () {
            var post = ko.observable();

            var getPost = function (url) {
                ds.getPost(url, function (data) {
                    post(data);
                });
            };
            getPost("api/posts/13");

            return {
                post: post,
            };
        }
    });