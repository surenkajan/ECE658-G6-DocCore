function initialize(document) {
    var comments = CallCommentRestService(document.DocID);
    var commentString = "";

    //var likes = Object.keys(GetLikesService(document.DocID)).length;
    if (comments != -1) {
        for (index in comments) {
            var date = new Date(parseInt(comments[index].UploadTimeStamp.substr(6)));
            commentString += "<li><a href='" + DocCoreAppBaseAddress + "/myprofile?uid=" + comments[index].UserID + "'><div class='commenterImage'><img src= " + comments[index].ProfilePhoto + " /></div><div class='commentText'><p class=''><strong>" + comments[index].FullName + " </strong></a>" + comments[index].Comments + "</p><span class='date sub-text'>on " + date.toDateString("dd-mm-yyy") + "</span></div></li>"
        }
    }


    var tagString = "";
    if (document.SharedWith) {
        //var tags = document.Tags.split(',');
        var documentString = ""
        //for (index in tags) {
        //    tags[index] = tags[index].trim();
        //    var editor = {
        //        setSource: function () {
        //            return GetUserDetailsbyFullName(tags[index]);
        //        }
        //    }

        //    $.when(editor.setSource()).then(function (user) {
        //        if (user.length != 0) {
        //            documentString += '<a href=' + PictureAppBaseAddress + '/myprofile?uid=' + user[0].UserID + '>' + user[0].FullName + '</a>, '
        //        }

        //    });
        //}
        for (i = 0; i < document.SharedWith.length; i++) {
            documentString += '<a href=' + DocCoreAppBaseAddress + '/myprofile?uid=' + document.SharedWith[i].UserID + '>' + document.SharedWith[i].FullName + '</a>, '
        }

        if (documentString != "") {
            documentString = documentString.slice(0, -2);
        }

        tagString = '<span id="tags" style="margin-left:15px;color:#365899;"> <span class="checkinclass" style="color:#999999">with</span> ' + documentString + '</span>'
    }

    //var checkinString = "";
    //if (document.Location) {
    //    checkinString += '<p style="display:inline" class="checkinclass small" style="color:black"> - ' + document.Location + '</p>';
    //}

    var descriptionString = "";
    if (document.FileSummary) {
        descriptionString = document.FileSummary;
    }

    var currentLoggedInUser = $('#DocCore_hdnf_LoggedInUserEmailID').val();
    var currentProfileUser = $('#DocCore_hdnf_CurrentUserEmailID').val()
    //currentLoggedInUser = document.getElementById('DocCore_hdnf_LoggedInUserEmailID').value;
    //var currentProfileUser =  document.getElementById('DocCore_hdnf_CurrentUserEmailID').value;
    var deleteString = "";
    var id = document.DocID;

    if (currentLoggedInUser != currentProfileUser) {
        deleteString = "";
    } else {
        deleteString = '<span title="Delete Photo" class="close glyphicon glyphicon-remove-sign glyphicon-white" style="position: relative;top:2px;right: 2px;z-index: 100; cursor: pointer;opacity: .2;text-align: center;padding: 5px 2px 2px;border-radius: 50%; font-size: 22px;" onclick ="deleteDocument(' + id + ')" ></span>';

    }

    $('#UploadedDocumentsContainer').append('<div id="rect' + id + '" class="rect" style="height:650px;border-radius:8px;">' +
        '<div style="height:50px;display:block;border-bottom-style:inset;">' + deleteString +
        '<h4 class="username1Div' + id + '" style="color:grey">' +
        '<img class ="img-circle" src="' + document.CreatedUser.ProfilePhoto + '" /> ' +
        '<p style="display:inline;color:#365899;">' + document.CreatedUser.FirstName + " " + document.CreatedUser.LastName + '</p></h4> </div > ' +
        '<div id="userpicDiv' + id + '" style="height:200px;display:block;border-bottom-style:inset;background-color: #f3f0f0">' +
        '<span class="helper"></span>' +
        '<img src= "Content\\Images\\extNew\\' + document.FileType.toLowerCase() + '-icon-128x128.png" style= "min-width:200px;max-width:100%;max-height:100%;object-fit: contain;" />' +
        '<div class="helper dochelper">' +
        '<div><span class="docMetaData-title">Project Name:</span><span class="docMetaData-value">' + document.FileName + '</span></div>' +
        '<div><span class="docMetaData-title">Created Time:</span><span class="docMetaData-value">' + document.UploadedTime + '</span></div>' +
        '<div><span class="docMetaData-title">Modified By:</span><span class="docMetaData-value">' + document.ModifiedBy + '</span></div>' +
        '<div><span class="docMetaData-title">Modified Time:</span><span class="docMetaData-value">' + document.Modified + '</span></div>' +
        '</div>' +
        '</div >' +
        '<span style="position: relative; font-size: 20px; margin-left: 15px;color:#365899;cursor: pointer;" class="glyphicon glyphicon-comment" onclick="showcommentDiv(' + id + ')"></span> ' +
        '<div><img src= "Content\\Images\\download.png" onclick= "DownloadFileViaASHX(' + id + ')" id= "doc' + id + '" style= "float:right;height:30px;" /></div>' +
        '<div id="description' + id + '" style="margin-top:5px;margin-bottom:5px;margin-left:15px;height:50px;">' + descriptionString + tagString + '</div>' +
        '<div class="detailBox"><div class="titleBox"><label>Comments</label></div ><div class="actionBox"> <ul id="commentList' + id + '" class="commentList">' + commentString + '</ul></div>' +
        '<div class="input-group" style="z-index:0.5;"><input id="AddCommentDiv' + id + '" class="form-control inputcomment" type="text" placeholder="Your comments" onkeyup="handleAddButtonCss(' + id + ')" />' +
        '<span class="input-group-btn"><button id="AddCommentBtn' + id + '" class="btn btn-default btncomment" type="button" disabled onclick="addcommentToDiv(' + id + ')">Add</button></span>' +
        '</div></div>'
    );
}

function downloadDoc(id) {
    alert('Clicked...');
}

$("span.close").css("display", "none");
$('#close').on('mouseover mouseout', function () {
    $(this).find('.close').toggle();
    //find its children with class .editInLine and 
    //toggle its display using 'toggle()'
});

//initialize();
$(document).ready(function () {
    //var LoggeedInUser = document.getElementById("DocCore_hdnf_CurrentUserEmailID").value;
    var T_currentLoggedInUser = document.getElementById('DocCore_hdnf_LoggedInUserEmailID').value;
    var currentProfileUser = document.getElementById('DocCore_hdnf_CurrentUserEmailID').value;
    var data = null;
    if (T_currentLoggedInUser.localeCompare(currentProfileUser) == 0) {
        //Current user see his profile
        data = GetMyUploadedDocumentsService(T_currentLoggedInUser);
    }
    else {
        //Current user(currentLoggedInUser) see other's profile(currentProfileUser)
        data = GetUploadedAndSharedDocumentsWithMeService(currentProfileUser, T_currentLoggedInUser);
    }

    if (data != -1) {
        for (var i = 0; i < Object.keys(data).length; i++) {
            initialize(data[i]);
        }
    }
});


function showthirdDiv() {
    document.getElementById("tagDiv").focus();
    return false;
}

function handleAddButtonCss(id) {
    if ($('#AddCommentDiv' + id).val() == "") {
        $('#AddCommentBtn' + id).prop('disabled', true);
    } else {
        $('#AddCommentBtn' + id).prop('disabled', false);
    }
}


function showcommentDiv(id) {
    document.getElementById("AddCommentDiv" + id).focus();
    return false;
}
function EnterEvent(e, DocID) {
    if (e.keyCode == 13) {
        addcomment(DocID);
    }
}

function addcommentToDiv(id) {
    if ($('#AddCommentDiv' + id).val()) {
        var useremail = $('#DocCore_hdnf_LoggedInUserEmailID').val();
        var newComment = $('#AddCommentDiv' + id).val();
        commentobject = {
            DocID: id,
            EmailAddress: useremail,
            Comments: newComment
        }

        PostCommentRestService(commentobject);

        var userDetails = GetUserDetailsService(useremail);
        var date = new Date();

        $('#commentList' + id).prepend(
            "<li><a href='" + PictureAppBaseAddress + "/myprofile/myprofile?uid=" + userDetails.UserID + "'><div class='commenterImage'><img src= " + userDetails.ProfilePhoto + " /></div><div class='commentText'><p class=''><strong>" + userDetails.FullName + " </strong></a>" + newComment + "</p><span class='date sub-text'>on " + date.toDateString("dd-mm-yyy") + "</span></div></li>"
        );

        $('#AddCommentDiv' + id).val("");
        $('#AddCommentBtn' + id).prop('disabled', true);
    }
}
function deleteDocument(DocID) {
    Doc = {
        "DocID": DocID
    };

    $("#myModal1").modal("show");

    $('#ModalDeleteButton').click(function () {
        var result = DeleteDocumentService(DocID);
        if (result != 0) {
            $('#rect' + DocID).remove();
        }
    });

}


function DocCore_Div() {
    var bckgrnd = document.getElementById("divBackground");
    var imgDiv1 = document.getElementById("uploadwin1");
    var width = document.body.clientWidth;
    if (document.body.clientHeight > document.body.scrollHeight) {
        bckgrnd.style.height = document.body.clientHeight + "px";
    }
    else {
        bckgrnd.style.height = document.body.scrollHeight + "px";
    }
    console.log(imgDiv1);
    imgDiv1.style.left = (width - 650) / 2 + "px";
    imgDiv1.style.top = "20px";
    bckgrnd.style.width = "100%";

    bckgrnd.style.display = "block";
    imgDiv1.style.display = "block";
    return false;
}

function DocCore_LoadDiv(url, x) {
    var img = new Image();
    //document.getElementById("divImage1").style.top = "60px";
    var bcgDiv = document.getElementById("divBackground");
    var imgDiv = document.getElementById("divImage1");
    var imgFull = document.getElementById("imgFull");
    //var imgLoader = document.getElementById("imgLoader");
    var captionText = document.getElementById("pcaption")

    //imgLoader.style.display = "block";
    img.onload = function () {
        imgFull.src = img.src;
        imgFull.style.display = "block";
        //imgLoader.style.display = "none";
        captionText.innerHTML = x;
        //console.log(url);
        //console.log(x);
    };
    img.src = url;
    var width = document.body.clientWidth;
    if (document.body.clientHeight > document.body.scrollHeight) {
        bcgDiv.style.height = document.body.clientHeight + "px";
    }
    else {
        bcgDiv.style.height = document.body.scrollHeight + "px";
    }

    imgDiv.style.left = (width - 650) / 2 + "px";
    imgDiv.style.top = "20px";
    bcgDiv.style.width = "100%";

    bcgDiv.style.display = "block";
    imgDiv.style.display = "block";
    return false;
}
function DocCore_HideDiv() {
    console.log("EnteredHide");
    var bcgDiv = document.getElementById("divBackground");
    var imgDiv = document.getElementById("divImage1");
    var imgFull = document.getElementById("imgFull");
    if (bcgDiv != null) {
        bcgDiv.style.display = "none";
        imgDiv.style.display = "none";
        imgFull.style.display = "none";
    }
}

function cancel() {
    var bckgrnd = document.getElementById("divBackground");
    var imgDiv1 = document.getElementById("uploadwin1");
    if (bckgrnd != null) {
        bckgrnd.style.display = "none";
        imgDiv1.style.display = "none";

    }

}

jQuery(function ($) {
    $(".tagorCheckin").focusout(function () {
        console.log(this);
        var element = $(this);
        if (!element.text().replace(" ", "").length) {
            element.empty();
        }
    });
});