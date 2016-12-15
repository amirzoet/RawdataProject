define(['jquery'], function ($) {
    var getUrl = function (url, callback) {
        $.getJSON(url, function (data) {
            callback(data)
        })
    }

    return {
        getUrl
    };
});