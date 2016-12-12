define(['knockout', 'dataservice', 'postman'],
    function (ko, ds, postman) {
        return function (url) {
            var marks = ko.observableArray([]);

            var getMarks = function (url) {
                
            }
            getMarks();

            return {
                marks:marks
            };
        }
    });