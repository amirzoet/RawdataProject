define(['knockout', 'dataservice'],
    function (ko, ds) {
        return function () {
            var user = ko.observable();

            ds.getUser(1, function (data) {
                user(data);
            });

            return {
                user: user,
            };
        }
    });