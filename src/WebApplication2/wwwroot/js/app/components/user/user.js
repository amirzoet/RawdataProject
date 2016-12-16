define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, ds, postman, config) {
        return function (params) {
            var user = ko.observable();

            var getUser = function (url) {
                ds.getUrl(url, function (data) {
                    user(data);
                });
            }
            getUser(params.url);


            return {
                user: user,
            };
        }
    });