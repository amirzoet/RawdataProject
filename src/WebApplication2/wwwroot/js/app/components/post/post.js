define(['knockout', 'dataservice'],
    function (ko, ds) {
        return function () {
            var post = ko.observableArray([]);

            ds.getUser(1, function (data) {
                user(data);
            });

            return {
                user: user,
            };
        }
    });