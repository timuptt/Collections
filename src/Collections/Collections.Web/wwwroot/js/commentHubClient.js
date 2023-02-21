"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/commentsHub").build();

connection.on("ReceiveMessage", function (userProfileId, userName, body) {
    console.log(
        userProfileId + ' ' + userName + ' ' + body
    );
    var commentDiv = document.getElementById("comments");
    
    var commentBlock =
        "<div class='bg-light p-1 rounded-1 mb-2'>" +
        "            <div class='d-flex justify-content-between p-2'>" +
        "                <h5 class=''>"+ userName +"</h5>" +
        "                <p class='text-muted micro'>just now</p>" +
        "            </div>" +
        "            <div class='bg-white p-2'>" +
        "                <p>"+ body +"</p>" +
        "            </div>" +
        "        </div>"
        
    commentDiv.insertAdjacentHTML("afterbegin" ,commentBlock);
});

connection.start().then(function () {
    var groupId = document.getElementById("groupId").value;
    connection.invoke("JoinGroup", groupId);
    console.log("Join to group " + groupId)
}).catch(function (err) {
    return console.error(err.toString());
});
