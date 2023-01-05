"use strict";

$(document).ready(function () {

    window.scrollTo(0, document.body.scrollHeight);


    if (localStorage.getItem("username")) {
        $(".blocker").addClass("d-none");
    }
    else {
        let username;
        var userColor;

        while (!username || !userColor) {
            username = prompt("enter username");
            localStorage.setItem("username", username)
            userColor = Math.floor(Math.random() * 16777215).toString(16);
            localStorage.setItem("userColor", userColor)
            $(".blocker").addClass("d-none");

        }

    }

    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    document.getElementById("sendButton").disabled = true;


    connection.on("ReceiveMessage", function (user, userColor, message) {


        var messageElem = ' <div class="message"> <div class="message-wrapper"> <p class="username" style="color:#' + userColor + '">' + user + '</p><p class="message-text"> ' + message + ' </p></div></div>'

        $("#messages-container").append(messageElem);

        window.scrollTo(0, document.body.scrollHeight);
    });

    connection.start().then(function () {

        document.getElementById("sendButton").disabled = false;
        connection.invoke("JoinGroup", $("#groupName").val());

    }).catch(function (err) {
        return console.error(err.toString());
    });

    function sendMessage() {
        var user = localStorage.getItem("username");
        var userColor = localStorage.getItem("userColor");
        var message = document.getElementById("newMessage").value;

        if (message.trim() == "") {
            window.location.href = "https://www.youtube.com/watch?v=pf2uSH5IqMw";
            return;
        }

        document.getElementById("newMessage").value = "";

        connection.invoke("SendMessage", user, userColor, message, $("#groupName").val()).catch(function (err) {
            return console.error(err.toString());
        });
    }

    document.getElementById("sendButton").addEventListener("click", function (event) {
        sendMessage();
        event.preventDefault();
    });

    $(document).on("keyup", "#newMessage", function (e) {
        if (e.keyCode==13) {
            sendMessage();
        }
    })
});

