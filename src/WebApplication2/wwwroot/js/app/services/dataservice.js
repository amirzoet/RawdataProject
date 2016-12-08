define(['jquery'], function ($) {
    var getUser = function (id,callback) {
        $.getJSON("api/users/"+id, function (data) {
            callback(data);
        });
    }
    return {
        getUser
    };
});