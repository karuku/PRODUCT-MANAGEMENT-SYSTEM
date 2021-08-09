 
function PostData(url, obj) {

    var model = obj;
    var postObj = $.post(url, model)
    .done(function (response) {

        if (response.rCode == 0) {
            toastr.success(response.Message, 'Success');
        } else {
            toastr.error(response.Message, 'Error!');
        }
    }, "json")
.fail(function (e) {
    toastr.error(e, 'Error!');
}, "json")
.always(function (response) {
    //toastr.info(response.Message, 'Info');
}, "json");

    return postObj;
}

function GetData(url,obj) {
     
    var getData = $.get(url, obj)
      .done(function (response) {

          if (response.rCode == 0) {
              toastr.success(response.Message, 'Data Found');
          } else {
              toastr.error(response.Message, 'Error!');
          }
      }, "json")
.fail(function (e) {
    toastr.error(e, 'Error!');
}, "json")
.always(function (response) {
    //toastr.info(response.Message, 'Info');
}, "json");

    return getData;
}

