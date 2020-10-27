
$("#RegisterBtn").click(function () {
    if (CheckValidation()) {
        if (checkUserExist() == 0) {                 //checkUserExist() in this ajax method i m using async:off so that before
            var data = $("#FormId").serialize();     //going below it will execute that method syncrously otherwise it will behave strangelt
            $.ajax({
                data: data,
                method: "POST",
                url: "/Account/RegisterInfo",
                success: function(response) {
                    if (response.success) {
                        $("#FirstName").val("");
                        $("#LastName").val("");
                        $("#Email").val("");
                        $("#Password").val("");
                        $("#RepeatPassword").val("");
                        alert(response.responseText);
                        window.location.href = "/account/login";
                    } else {
                        alert(response.responseText);

                    }
                },
                error: function(response) {
                    alert("error!");  //
                }

            });
        }
    }
    });

function CheckValidation() {         //writing client side validation code bcoz while using ajax post the server side validation is not working
    var result = 0;
    var fname = $("#FirstName").val();
    var lname = $("#LastName").val();
    var email = $("#Email").val();
    var pass = $("#Password").val();
    var cpass = $("#RepeatPassword").val();
    if (fname.length > 0) {
        $("#vfname").html("");
    } else {
        $("#vfname").html("Enter First name");
    }
    if (lname.length > 0) {
        $("#vlname").html("");
        //result = true;
    } else {
        $("#vlname").html("Enter Last name");
    }
    if (email.length > 0) {
        if (email.includes("@")) {
            $("#vemail").html("");
        }
        else {
            $("#vemail").html("Enter Valid Email address");
        }
        //result = true;
    } else {
        $("#vemail").html("Enter email address");
    }
    if (pass.length > 0) {
        if (pass.length < 6) {
            $("#vpass").html("Enter atleast 6 char long password");
        } else {
            $("#vpass").html("");
        }

    } else {
        $("#vpass").html("Enter Password");
    }

    if (cpass.length > 0) {
        if (cpass.length < 6) {
            $("#vconfirmpass").html("Enter atleast 6 char long password");
        } else {
            if (cpass==pass) {
                $("#vconfirmpass").html("");
            } else {
                $("#vconfirmpass").html("Not matching to the previous password");
            }
        }

    } else {
        $("#vconfirmpass").html("Enter Repeat Password");
    }
    var a = $("#vfname").text();
    var b = $("#vlname").text();
    var c = $("#vemail").text();
    var d = $("#vpass").text();
    var e = $("#vconfirmpass").text();
    if ( (a=="")&&(b=="")&&(c=="")&&(d=="")&&(e==""))
    {
        result = 1;
    }
    return result;
}

function checkUserExist(){
    var username = $("#Email").val();
    var result = 0;
    $.ajax({
        data: { email: username },
        method: "POST",
        async:false,      //i make it false so that it will wait and run before it execute the next ajax method syncrously for registering user
        url: "/Account/CheckUsernameExist",
        success: function (response) {
            if (response==1) {
                $("#vemail").html("Account already existed with this email, please use different email.");
                result= 1;
            } else {
                $("#vemail").html("");
                result = 0;
            }
        },
    });
    return result;
}

//$(document).bind("viewtransfer", function () {

//    $('form').removeData('validator');

//    $('form').removeData('unobtrusiveValidation'); //Use This code to make validator work

//    $.validator.unobtrusive.parse('form');
//}

//$(function () {
//    $('form').submit(function () {
//        if ($(this).valid()) {
//            $.ajax({
//                url: "/Controller/RegisterInfo",
//                type: this.method,
//                data: $(this).serialize(),
//                success: function (response) {
//                if (response.success) {
//                    $("#FirstName").val("");
//                    $("#LastName").val("");
//                    $("#Email").val("");
//                    $("#Password").val("");
//                    $("#RepeatPassword").val("");
//                    alert(response.responseText);
//                    window.location.href ="/account/login";
//                }
//            },
//            error: function (response) {
//                alert("error!");  //
//            }
//            });
//        }
//        return false;
//    });
//});

