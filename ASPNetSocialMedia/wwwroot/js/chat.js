"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

var today = new Date();
var date = today.getDate()  + '-' + (today.getMonth() + 1) + '-' + today.getFullYear();
var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
var dateTime = date + ' ' + time;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    var li2 = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    document.getElementById("messagesList").appendChild(li2);

    //li.textContent = `${user} says ${message} @ ${dateTime}`;
    li.textContent = `${user} @ ${dateTime}`;
    li2.textContent = `${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});