$(document).ready(function () {
    $.ajax({
        type: "GET",
        dataType: "jsonp",
        url: DocCoreServicesBaseAddress + "/adminRest/GetAllProject",
        success: function (friends) {

            for (index in friends) {
                friends[index].value = friends[index].ProjectName;
            }
            $("#MainContent_txtSearch").autocomplete({
                source: friends,
                minLength: 1,
                focus: function (event, ui) {
                    $("#MainContent_txtSearch").val(ui.item.FullName)
                    return false;
                }
                //select: function (event, ui) {
                //    location.href = DocCoreServicesBaseAddress + "/Admin/ViewAllUsers";
                //    return false;
                //}
            });
        }
    });
});









   