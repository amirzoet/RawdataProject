define(['jquery'], function ($) {
    var getUser = function (url,callback) {
        $.getJSON(url, function (data) {
            callback(data);
        });
    }

    var getPost = function (callback) {

    }
    return {
        getUser,
        getPost
    };
});