$(function () {

    var myClientName = $('#Placeholder').val();

    var connection = $.connection('/echo');

    connection.received(function (data) {
        var msg = new String(data);
        var index = msg.indexOf("#");
        var clientName = msg.substring(0, index);
        var content = msg.substring(index + 1);

        if (clientName == null || clientName == "") {
            writeEvent('<b>' + "系统消息" + '</b>: ' + content, 'event-message');
        }
        else {
            writeEvent('<b>' + clientName + '</b> 对大家说: ' + content, 'event-message');
        }
    });

    connection.start();

    $("#broadcast").click(function () {
        var msg = myClientName + "#" + $('#msg').val();
        connection.send(msg);
    });

    //A function to write events to the page
    function writeEvent(eventLog, logClass) {
        var now = new Date();
        var nowStr = now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
        $('#messages').prepend('<li class="' + logClass + '"><b>' + nowStr + '</b> ' + eventLog + '.</li>');
    }
});