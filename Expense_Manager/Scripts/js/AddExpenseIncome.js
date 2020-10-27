
$("#submit").click(function () {
        var userid = $("#useridHidden").val();
        var ExpenseIncome = $("#addrecordform").serialize() +'&userid='+userid+'';  //appending user id

        $.ajax({
            data: ExpenseIncome,
            method: "POST",
            async: false,
            url: "/AddExpenseOrIncome/Add_record",
            success: function (response) {
                if (response.success) {
                    location.reload(true);  //Refreshing the page to load lists
                    $("#categoryID").val("");
                } else if (response.success==false) {
                    alert(response.responseText);
                }
            }
            ,
            error: function (response) {
                alert("error!");  //
            }
        });
    return false;
    });


