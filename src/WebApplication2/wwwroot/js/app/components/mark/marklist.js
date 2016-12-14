﻿define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, ds, postman, config) {
        return function () {
            var marks = ko.observableArray([]);

            var getMarks = function (url) {
                ds.getMarks(url, function (data) {
                    marks(data);
                });
            }
            getMarks("api/myusers/1/marks/1");

            var selectMark = function () {

            }

            var selectPost = function (mark) {
                postman.publish(config.events.showPost, mark.url);
            }

            return {
                marks: marks,
                selectMark: selectMark,
                selectPost: selectPost
            };
        }
    });