var DocCoreServicesBaseAddress = "http://localhost:2085/Service.svc";
var DocCoreAppBaseAddress = "http://localhost:8520";

//GET
function DocCoreGETService(Url) {
    var result;
    $.ajax({
        type: "GET",
        url: Url,
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            result = data;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            result = -1;
        }
    });
    return result;
}

//POST
function DocCorePOSTService(Url, data) {
    var result;
    $.ajax({
        type: "POST",
        url: Url,
        contentType: "application/json; charset=utf-8",
        async: false,
        data: JSON.stringify(data),
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            result = data;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            result = -1;
        }
    });
    return result;
}

//Update
function DocCorePUTService(Url, data) {
    var result;
    $.ajax({
        type: "PUT",
        url: Url,
        contentType: "application/json; charset=utf-8",
        async: false,
        data: JSON.stringify(data),
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            result = data;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            result = -1;
        }
    });
    return result;
}

//Delete
function DocCoreDeleteService(Url, data) {
    var result;
    $.ajax({
        type: "DELETE",
        url: Url,
        contentType: "application/json; charset=utf-8",
        async: false,
        data: JSON.stringify(data),
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            result = data;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            result = -1;
        }
    });
    return result;
}

function CallDocRestService(EmailId) {
    var url = DocCoreServicesBaseAddress + "/DocRest/GetPhotosByEmailID?EmailId=" + EmailId;
    var people = DocCoreGETService(url)
    return people;
}

//function CallGetMyLikesService(id) {
//    var url = DocCoreServicesBaseAddress + "/likesRest/GetLikesByDocID?DocID=" + id;
//    var likes = DocCoreGETService(url)
//    return likes;
//}

function CallCommentRestService(DocID) {
    var url = DocCoreServicesBaseAddress + "/DocRest/GetCommentsByID?DocID=" + DocID;
    var comment = DocCoreGETService(url)
    return comment;
}

//function CallAddMyLikesService(likeData) {
//    var url = DocCoreServicesBaseAddress + "/likesRest/AddLikesByDocID";
//    DocCorePOSTService(url, likeData);
//    //return addLikes;
//}

function CallRestService() {
    var userData = {
        DateOfBirth: "/Date(753636849000-0500)/",
        EmailAddress: "surenkajan456@gmail.com",
        FirstName: "Kajaruban456",
        FullName: "Kajaruban456 Surendran456",
        LastName: "Surendran456",
        ProfilePhoto: null,
        Sex: "Male",
        UserName: "surenkajan456"
    }
    var result = DocCorePOSTService(DocCoreServicesBaseAddress + "/userRest/AddUserByEmailID", userData);

    alert("Result of the Service is" + resuldeleteDocumentServicet);

}

//function PostLikesService(likedata) {
//    DocCorePOSTService(DocCoreServicesBaseAddress + "/likesRest/AddLikesByDocID", likedata);
//}

//function GetLikesService(DocID) {
//    return (DocCoreGETService(DocCoreServicesBaseAddress + "/likesRest/GetLikesByDocID?DocID=" + DocID))
//}

function GetAllUsersByProjectID(Pid) {
    //TODO : Have not Implemented yet
    return (DocCoreGETService(DocCoreServicesBaseAddress + "/userrest/GetAllUsersByProjectID?PID=" + Pid))
}

function GetAllUsers() {
    //TODO : Have not Implemented yet
    return (DocCoreGETService(DocCoreServicesBaseAddress + "/userRest/GetAllUsers"))
}

function GetAllUserDetails() {
    //TODO : Have not Implemented yet
    return (DocCoreGETService(DocCoreServicesBaseAddress + "/userRest/GetAllUserDetails"))
}
function GetsharedDocumentsService(emailID) {
    return (DocCoreGETService(DocCoreServicesBaseAddress + "/DocRest/GetAllSharedDocumentsForEmailID?Email=" + emailID))
}

function GetMyUploadedDocumentsService(emailID) {
    return (DocCoreGETService(DocCoreServicesBaseAddress + "/DocRest/GetAllDocumentsUploadedByEmailID?Email=" + emailID))
}

function GetUploadedAndSharedDocumentsWithMeService(U_User, L_User) {
    return (DocCoreGETService(DocCoreServicesBaseAddress + "/DocRest/GetUploadedAndSharedWithMeByEmailID?Up_User=" + U_User + "&Lo_User=" + L_User))
}

function GetUserDetailsService(emailID) {
    return (DocCoreGETService(DocCoreServicesBaseAddress + "/userrest/GetUserByEmailID?Email=" + emailID))
}

//function GetUserDetailsbyFullName(fullName) {
//    return (DocCoreGETService(DocCoreServicesBaseAddress + "/userrest/GetUserByFullName?FullName=" + fullName));
//}

//function UploadPhotoService(photodetails) {
//    var url = DocCoreServicesBaseAddress + "/DocRest/AddPhotoByEmailID";
//    var result = DocCorePOSTService(url, photodetails);
//    return result;

//}

function DeleteDocumentService(DocID) {
    var url = DocCoreServicesBaseAddress + "/DocRest/DeleteDocuments?DocID=" + DocID;
    var result = DocCoreDeleteService(url, DocID);
}

function PostCommentRestService(commentobj) {
    var result = DocCorePOSTService(DocCoreServicesBaseAddress + "/DocRest/AddCommentsByEmailID", commentobj);
}

function DownloadFileViaASHX(DocID) {
    //return (DocCorePOSTService("/DownloadFile.ashx?Docid=" + DocID));
    window.open("/DownloadFile.ashx?Docid=" + DocID, '_blank');
}