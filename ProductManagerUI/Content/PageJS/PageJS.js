
function PostData(url, obj) {

    var model = obj;
    $.post(url, model)
    .done(function (data) {
        toastr.success('Success', response.Message);
    }, "json")
.fail(function () {
    toastr.error(response.Message, 'Error!');
}, "json")
.always(function () {

}, "json");
}

function PostAPIData(url, obj) {

    var model = obj;
    $.post(url, model)
    .done(function (data) {
        toastr.success('Success', response.Message);
    }, "json")
.fail(function () {
    toastr.error(response.Message, 'Error!');
}, "json")
.always(function () {

}, "json");
}
