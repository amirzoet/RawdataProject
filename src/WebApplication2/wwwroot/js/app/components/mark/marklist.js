define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, ds, postman, config) {
        return function () {
            var marks = ko.observableArray([]);

            var getMarks = function (url) {
                ds.getUrl(url, function (data) {
                    marks(data);
                });
            }
            getMarks("api/myusers/1/marks");

            var editMark = function () {

            }

            var selectPost = function (mark) {
                postman.publish(config.events.showPost, mark.posturl);
            }

            return {
                marks: marks,
                editMark: editMark,
                selectPost: selectPost
            };
        }
    });