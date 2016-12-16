define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, ds, postman, config) {
        return function (params) {
            var searchresults = ko.observableArray([]);
            var searchinput = ko.observable("");

            var searchurl = function (myuser, text) {
                return "api/myusers/" + myuser + "?search=" + text;
            }

            var search = function (text) {
                ds.getUrl(searchurl(1,text), function (data) {
                    searchresults(data);
                });
            }

 


            return {
                searchresults: searchresults,
                searchinput: searchinput,
                search: search,
            };
        }
    });