define(['knockout', 'dataservice', 'postman'],
    function (ko, ds, postman) {
        return function () {
            var user = ko.observable();

            var getUser = function (url) {
                ds.getUser(url, function (data) {
                    user(data);
                });
            }
            getUser("api/users/1");

            postman.subscribe("showuser", function (url) {
                getUser(url);
            });



            return {
                user: user,
            };
        }
    });