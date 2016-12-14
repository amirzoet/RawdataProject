define(['jquery'], function ($) {
    var getUser = function (url,callback) {
        $.getJSON(url, function (data) {
            callback(data);
        });
    }

    var getMarks = function (url, callback) {
        $.getJSON(url, function (data) {
            callback(data);
        })
    }

    var getPost = function (url, callback) {
        $.getJSON(url, function (data) {
            callback(data)
        })
    }
    return {
        getUser,
        getMarks,
        getPost
    };
});