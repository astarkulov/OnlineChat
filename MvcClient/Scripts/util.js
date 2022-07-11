$(function () {
    // Ссылка на автоматически-сгенерированный прокси хаба
    var chat = $.connection.chatHub;
    $(document).ready(function () {
        $.connection.hub.start().done(function () {
            var name = $("#Username").data("value");
            chat.server.connect(name);
        });
    });
    // Объявление функции, которая хаб вызывает при получении сообщений
    chat.client.addMessage = function (name , sendTime, message, color) {
        // Добавление сообщений на веб-страницу 
        if ($("#Username").data("value") === name) {
            $('#chatContent').append(
                '<li class="clearfix"><div class="message other-message float-right">' + message + '<div style="color: rgb(167, 167, 167); font-size: 9pt; text-align: right;">' + sendTime + '</div>' + '</div></li>');
        }
        else
            $('#chatContent').append(
                '<li class="clearfix"><div class="message-data"><span class="message-data-time" style="color:' + color + '">' + name + '</span></div><div class="message my-message">' + message + '<div style="color: rgb(167, 167, 167); font-size: 9pt; text-align: right;">' + sendTime + '</div>' +  '</div></li>');
        lastMessageScroll('smooth');
    };

    // Функция, вызываемая при подключении нового пользователя
    chat.client.onConnected = function (id, allUsers, color) {

        // установка в скрытых поле id текущего пользователя
        $('#hdId').val(id);
        $('#ColorOfName').val(color);
        // Добавление всех пользователей
        for (i = 0; i < allUsers.length; i++) {

            AddUser(allUsers[i].ConnectionId, allUsers[i].Name);
        }
        lastMessageScroll();
    }

    // Добавляем нового пользователя
    chat.client.onNewUserConnected = function (id, name) {

        AddUser(id, name);
    }

    // Удаляем пользователя
    chat.client.onUserDisconnected = function (id) {

        $('#' + id).remove();
    }

    // Открываем соединение
    $.connection.hub.start().done(function () {

        $('#sendmessage').click(function () {
            // Вызываем у хаба метод Send
            chat.server.send($('#Username').data("value"), $('#message').val(), $('#ColorOfName').val());
            $('#message').val('');
        });
        $('#message').keydown(function (e) {
            if (e.keyCode === 13) {
                chat.server.send($('#Username').data("value"), $('#message').val(), $('#ColorOfName').val());
                $('#message').val('');
            }
        });
    });

    
});
// Кодирование тегов
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
//Добавление нового пользователя
function AddUser(id, name) {
    var username = $("#Username").data("value");
    if (name !== username) {
         $("#chatusers").append('<div class="input-group" id="' + id + '">' + name + '</div>');
    }
}
function lastMessageScroll(b) {
    var e = document.querySelector('.wrapper_Scrollbottom');
    if (!e) return;

    e.scrollIntoView({
        behavior: b || 'auto',
        block: 'end',
    });
}