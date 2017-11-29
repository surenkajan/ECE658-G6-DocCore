$(document).ready(function () {
    $.ajax({
        type: "GET",
        dataType: "jsonp",
        url: DocCoreServicesBaseAddress + "/userRest/GetAllUserDetails",
        success: function (friends) {

            for (index in friends) {
                friends[index].value = friends[index].FullName;
            }
            $("#MainContent_txtSearch").autocomplete({
                source: friends,
                minLength: 1,
                focus: function (event, ui) {
                    $("#MainContent_txtSearch").val(ui.item.FullName)
                    return false;
                }
                //select: function (event, ui) {
                //    location.href = DocCoreServicesBaseAddress + "/myprofile/myprofile?uid=" + ui.item.UserID;
                //    return false;
                //},
            });
        }
    });
});









   