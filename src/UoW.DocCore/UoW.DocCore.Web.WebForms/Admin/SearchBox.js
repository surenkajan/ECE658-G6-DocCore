$(document).ready(function () {

    $("#MainContent_txtSearch").autocomplete({

        source: function (request, response) {

            $.ajax({

                type: "POST",

                contentType: "application/json; charset=utf-8",

                url: "ViewAllUsers.aspx/GetFirstNames",

                data: "{'namePrefix':'" + $("#MainContent_txtSearch").val() + "'}",

                dataType: "json",

                delay: 1000,

                minLength: 3,

                success: function (data) {

                    response(data.d)

                },

                error: function (response) {

                    alert("Error" + res.responseText);

                }

            });

        }

    });

});