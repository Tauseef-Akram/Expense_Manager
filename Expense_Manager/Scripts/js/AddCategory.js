
function SaveCategory() {
    var cat = $("#categoryID").val();
    var id = $("#useridHidden").val();
    var data = { category_name: cat, user_id: id }     //here i am converting value to the object, remember that the object name
    if (CategoryValidation()== 1) {                    //must be same as model name u r passing to
        $("#CategoryFieldValidation").html("");
        $.ajax({
            data: data,
            method: "POST",
            async: false,
            url: "/AddCategory/SaveCategory",
            success: function (response) {
                if (response.success) {
                    location.reload(true);  //Refreshing the page to load lists
                    $("#categoryID").val("");
                } else {
                    alert(response.responseText);
                }
            },
            error: function (response) {
                alert("error!");  //
            }
        });
    }

}


//$(document).ready(function () {
//    $("#DeleteBtn").click(function () {
//        id = $(this).attr("name")
//        var data = { id: id }     //here i am converting value to the object, remember that the object name
//        $.ajax({                                           //must be same as model name u r passing to
//            data: data,
//            method: "POST",
//            async: false,
//            url: "/AddCategory/DeleteCategory",
//            success: function (response) {
//                if (response.success) {

//                } else {
//                    alert(response.responseText);
//                }
//                $("#categoryID").val("");
//            },
//            error: function (response) {
//                alert("error!");  //
//            }

//        });

//        location.reload(true);   //Refreshing the page to load lists
//    });

function CategoryValidation() {
    var result = 0;
    var name = $("#categoryID").val();
    if (name == "" || name == null) {
        $("#CategoryFieldValidation").html("Please give category name");
        return result;
    } else {
        $("#CategoryFieldValidation").html("");
        result = 1;
    }
    return result;
}

    $("#myTable").on('click', '#DeleteBtn', function () {      //for delete btn event
        id = $(this).attr("name")
        var data = { id: id }
        $.ajax({
            data: data,
            method: "POST",
            async: false,
            url: "/AddCategory/DeleteCategory",
            success: function (response) {
                if (response.success) {

                } else {
                    alert(response.responseText);
                }
                $("#categoryID").val("");
            },
            error: function (response) {
                alert("error!");  //
            }

        });

        location.reload(true);
    });

$("#cancelBtn").on('click', function () {                //Cancel button validation
    $("#saveBtn").attr("onclick", "SaveCategory()");
    $("#CategoryFieldValidation").html("");
    $("#cancelBtn").removeAttr("hidden");
    $("#cancelBtn").attr("hidden", "hidden");
    $("#saveBtn").html("Save Changes");
    $("#categoryID").val("");
});

$("#myTable").on('click', '#EditBtn', function () {        //for Edit button Event
    // get the current row
    var currentRow = $(this).closest("tr");

    var id = $(this).attr("name");
    var col1 = currentRow.find("td:eq(0)").html(); // get current row 1st table cell TD value
    var col2 = currentRow.find("td:eq(1)").html(); // get current row 2nd table cell TD value
    $("#gotoTopWidget").click();
    $("#categoryID").val(col2);
    $("#saveBtn").html("Save Changes");
    $("#cancelBtn").removeAttr("hidden");
    $("#saveBtn").attr("name", id);
    $("#CategoryFieldValidation").html("");
    $("#saveBtn").attr("onclick","SaveEditChanges()");     // this line for changing onclick attr value of button

        //if ($("#saveBtn").html() == "Save Changes") {
        //    SaveEditChanges(id, col2);
        //    $("#saveBtn").html("Add Category");
        //}
        //location.reload(true);

});

function SaveEditChanges() {
    var id = $("#saveBtn").attr("name");
    var val = $("#categoryID").val();
    var data = { id: id, name: val };     //must be same as model name u r passing to
    if (CategoryValidation() == 1) {
        $.ajax({
            method: "POST",
            data: data,
            async: false,
            url: "/AddCategory/EditCategory",
            success: function (response) {
                if (response.success) {
                    $("#categoryID").val("");
                    $("#saveBtn").html("Add Category");
                    location.reload(true);
                } else {
                    alert(response.responseText);
                }
            },
            error: function (response) {
                alert("error!");  //
            }
        });
    }

}