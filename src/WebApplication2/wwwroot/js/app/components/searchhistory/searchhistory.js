define(['knockout', 'dataservice', 'postman'],
    function (ko, ds, postman) {
        return function (params) {
            var searchhistory = ko.observableArray([]);


            var getSearchHistory = function (url) {
                ds.getUrl(url, function (data) {
                    searchhistory(data);
                });
            }
            getSearchHistory("api/myusers/1/searchhistory");

            return {
                searchhistory: searchhistory
            };
        }
    });