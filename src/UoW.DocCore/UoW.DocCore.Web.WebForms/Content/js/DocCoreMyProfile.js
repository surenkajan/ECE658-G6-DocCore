function initialize(person) {
    //console.log($('#FriendContainer'));
    var comments = CallCommentRestService(person.PhotoID);
    var commentString = "";

    var likes = Object.keys(GetLikesService(person.PhotoID)).length;
    for (index in comments) {
        var date = new Date(parseInt(comments[index].UploadTimeStamp.substr(6)));
        //commentString += "<li><div class='commenterImage'><img src= " + comments[index].ProfilePhoto + " /></div><div class='commentText'><p class=''><strong>" + comments[index].FullName + " </strong>" + comments[index].Comments + "</p><span class='date sub-text'>on " + date.toDateString("dd-mm-yyy") + "</span></div></li>"
        commentString += "<li><a href='" + PictureAppBaseAddress + "/myprofile/myprofile?uid=" + comments[index].UserID + "'><div class='commenterImage'><img src= " + comments[index].ProfilePhoto + " /></div><div class='commentText'><p class=''><strong>" + comments[index].FullName + " </strong></a>" + comments[index].Comments + "</p><span class='date sub-text'>on " + date.toDateString("dd-mm-yyy") + "</span></div></li>"
    }


    var tagString = "";
    if (person.Tags) {
        var tags = person.Tags.split(',');
        var personString = ""
        for (index in tags) {
            tags[index] = tags[index].trim();
            var editor = {
                setSource: function () {
                    return GetUserDetailsbyFullName(tags[index]);
                }
            }

            $.when(editor.setSource()).then(function (user) {
                if (user.length != 0) {
                    personString += '<a href=' + PictureAppBaseAddress + '/myprofile/myprofile?uid=' + user[0].UserID + '>' + user[0].FullName + '</a>, '
                }

            });
        }

        if (personString != "") {
            personString = personString.slice(0, -2);
        }

        tagString = '<span id="tags" style="margin-left:15px;color:#365899;"> <span class="checkinclass" style="color:#999999">with</span> ' + personString + '</span>'
    }

    var checkinString = "";
    if (person.Location) {
        checkinString += '<p style="display:inline" class="checkinclass small" style="color:black"> - ' + person.Location + '</p>';
    }

    var descriptionString = "";
    if (person.PhotoDescription) {
        descriptionString = person.PhotoDescription;
    }

    var currentLoggedInUser = document.getElementById('pictre_hdnf_LoggedInUserEmailID').value;
    var currentProfileUser = document.getElementById('pictre_hdnf_CurrentUserEmailID').value;
    var deleteString = "";

    var id = person.PhotoID;

    if (currentLoggedInUser != currentProfileUser) {
        deleteString = "";
    } else {
        deleteString = '<span title="Delete Photo" class="close glyphicon glyphicon-remove-sign glyphicon-white" style="position: relative;top:2px;right: 2px;z-index: 100; cursor: pointer;opacity: .2;text-align: center;padding: 5px 2px 2px;border-radius: 50%; font-size: 22px;" onclick ="deletePhoto(' + id + ')" ></span>';

    }

    $('#FriendContainer').append('<div id="rect' + id + '" class="rect" style="height:650px;border-radius:8px;">' +
        '<div style="height:50px;display:block;border-bottom-style:inset;">' + deleteString +
        '<h4 class="username1Div' + id + '" style="color:grey">' +
        '<img class ="img-circle" src="' + person.ProfilePhoto + '" /> ' +
        '<p style="display:inline;color:#365899;">' + person.FirstName + " " + person.LastName + '</p>' + checkinString + '</h4> </div > ' +
        '<div id="userpicDiv' + id + '" style="height:300px;display:block;border-bottom-style:inset;text-align:center;background-color: #f3f0f0">' +
        '<span class="helper"></span><img src="' + person.ActualPhoto + '" style="max-width:100%;max-height:100%;object-fit: contain;" />' +
        '</div >' +
        '<span id="' + id + '"class="glyphicon glyphicon-heart-empty" style="margin-left: 12px; font-size:20px; cursor: pointer;color:#365899;" onclick="likecounter(this.id)"></span>' +
        '<span style="position: relative; font-size: 20px; margin-left: 15px;color:#365899;cursor: pointer;" class="glyphicon glyphicon-comment" onclick="showcommentDiv(' + id + ')"></span> ' +
        '<div id="likeres' + person.PhotoID + '" style="height: 20px;margin-left:15px;font-weight:700;cursor:pointer;" data-toggle="modal" data-target="#LikesModal" onclick="populateLikes(' + id + ')">' + likes + ' Likes</div>' +
        '<div id="description' + id + '" style="margin-top:5px;margin-bottom:5px;margin-left:15px;height:50px;">' + descriptionString + tagString + '</div>' +
        '<div class="detailBox"><div class="titleBox"><label>Comments</label></div ><div class="actionBox"> <ul id="commentList' + id + '" class="commentList">' + commentString + '</ul></div>' +
        '<div class="input-group" style="z-index:0.5;"><input id="AddCommentDiv' + id + '" class="form-control inputcomment" type="text" placeholder="Your comments" onkeyup="handleAddButtonCss(' + id + ')" />' +
        '<span class="input-group-btn"><button id="AddCommentBtn' + id + '" class="btn btn-default btncomment" type="button" disabled onclick="addcommentToDiv(' + id + ')">Add</button></span>' +
        '</div></div>'
    );
}

var peopleData = [{
    'username': "Jaspreet",
    'fullname': "Jaspreet Singh Sambee",
    'place': "Delhi",
    'imgsrc': "../Home/Images/Eiffel.jpg"
},
{
    'username': "Shitij",
    'fullname': "Shitij Vashisht",
    'place': "Dehradun",
    'imgsrc': "../Content/Images/dog.jpg"
}

];

$("span.close").css("display", "none");
$('#close').on('mouseover mouseout', function () {
    $(this).find('.close').toggle();
    //find its children with class .editInLine and 
    //toggle its display using 'toggle()'
});

//initialize();
$(document).ready(function () {
    var LoggeedInUser = document.getElementById("pictre_hdnf_CurrentUserEmailID").value;
    //console.log(peopleData);
    //$.ajax({
    //    type: "GET",
    //    dataType: "jsonp",
    //    url: "http://localhost:32785/Service.svc/PhotoRest/GetPhotosByEmailID?EmailId=enlil@gmail.com",
    //    success: function (data) {
    //        for (var i = 0; i < Object.keys(data).length; i++) {
    //            console.log(data[i]);
    //            initialize(data[i]);

    //        }



    //    }
    //});
    var data = CallPhotoRestService(LoggeedInUser);
    for (var i = 0; i < Object.keys(data).length; i++) {
        //console.log(data[i]);
        initialize(data[i]);

    }
    //initialize(data);

});

/*   $('#thirdlvl').click(function () {
});
    $('#TagFriend').click(function () {
    $('#thirdlvl').hide();
}); */

function showthirdDiv() {
    //console.log("Yayy");
    document.getElementById("tagDiv").focus();
    //document.getElementsByClassName("tagorCheckin")[0].fo
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
    //document.getElementsByClassName("tagorCheckin")[0].fo
    return false;
}
function EnterEvent(e, photoID) {
    if (e.keyCode == 13) {
        addcomment(photoID);
    }
}
/*function showthirdDiv() {
    console.log("Yayy");
    div = document.getElementById('thirdlvl');
    div.style.display = "block";
    return false;
}*/

function likecounter(photoID) {
    //document.getElementById("usernameDiv").innerHTML = "Jaspreet";
    //console.log("heyHi");
    //var LoggedInUser = document.getElementById('pictre_hdnf_CurrentUserEmailID').value;
    var LoggedInUser = document.getElementById('pictre_hdnf_LoggedInUserEmailID').value;
    //console.log(serverName);
    var likeData = {
        "PhotoID": parseInt(photoID),
        "EmailAddress": LoggedInUser

    };
    //if (typeof (Storage) !== "undefined") {
    //    if (sessionStorage.clickcount) {
    //        sessionStorage.clickcount = Number(sessionStorage.clickcount) + 1;
    //    } else {
    //        sessionStorage.clickcount = 1;
    //    }
    //    var count = 0;
    //    count++;
    //    var count1 = Object.keys(getlikes).length;
    //    document.getElementById("likeres").innerHTML = getlikes + " Likes";
    //    document.getElementById("likeres").style.marginLeft = "15px";
    //    document.getElementById("likeres").style.fontWeight = "700";
    //}
    //var url = "http://localhost:32785/Service.svc/likesRest/AddLikesByPhotoID";

    //PictrePOSTService(url, likeData);
    CallAddMyLikesService(likeData)
    //var likeurl = "http://localhost:32785/Service.svc/likesRest/GetLikesByPhotoID?PhotoID=" + id;
    //var  likes = PictreGETService(url)
    var getlikes = CallGetMyLikesService(photoID);
    //document.getElementById("likeres").innerHTML = Object.keys(getlikes).length + " Likes";
    document.getElementById("likeres" + photoID).innerHTML = Object.keys(getlikes).length + " Likes";
    //document.getElementById("likeres").style.marginLeft = "15px";
    //document.getElementById("likeres").style.fontWeight = "700";
    //console.log("LikeDataNow");
    //console.log(getlikes);
}

/*  function addcomment()
  {
      console.log("addedcomment");
      document.getElementById("commenttext").innerHTML = "Haha"
  }
*/

function addcommentToDiv(id) {
    if ($('#AddCommentDiv' + id).val()) {
        //var useremail = $('#pictre_hdnf_CurrentUserEmailID').val();
        var useremail = $('#pictre_hdnf_LoggedInUserEmailID').val();
        var newComment = $('#AddCommentDiv' + id).val();
        commentobject = {
            PhotoID: id,
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
function deletePhoto(PhotoID) {
    Photo = {
        "PhotoID": PhotoID
    };

    $("#myModal1").modal("show");

    $('#ModalDeleteButton').click(function () {
        var result = DeletePhotoService(Photo);
        if (result != 0) {
            $('#rect' + PhotoID).remove();
        }
    });

}




/*  function ShowImagePreview(input) {
   console.log(input);
console.log(input.files.length);
       if (input.files && input.files.length > 0) {
           for (var i = 0; i < input.files.length; i++) {
               var reader = new FileReader();
               $('#ImgPrv').empty();
               reader.onload = function (e) {
   $('#ImgPrv').attr('src', e.target.result);
$('#ImgPrv').append($('<img>', {src: e.target.result, width: '200px', height: '150' }));
               }
               reader.readAsDataURL(input.files[i]);
           }
       }
   }  */

$("#FileUpload1").change(function () {
    ShowImagePreview(this);
});

function populateLikes(id) {
    var likeDetails = GetLikesService(id);

    $('#likes-modal-container').empty();

    var contentString = "";

    if (likeDetails) {
        for (index in likeDetails) {
            contentString += "<div><a href='" + PictureAppBaseAddress + "/myprofile/myprofile?uid=" + likeDetails[index].UserID + "'><img class='img- circle' width='60px' src=" + likeDetails[index].ProfilePhoto + " />&nbsp;" + likeDetails[index].FullName + "</a></div>";
        }
    }
    $('#likes-modal-container').append(contentString);
}


function Pictre_Div() {
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

function Pictre_LoadDiv(url, x) {
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
function Pictre_HideDiv() {
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