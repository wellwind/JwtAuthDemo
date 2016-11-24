$(document).ready(function () {
    var apiServer = 'http://localhost:40939/api/';

    $('#getToken').click(function () {
        $.post(apiServer + 'Token', {
                Username: $('#username').val(),
                Password: $('#password').val()
            })
            .done(function (data) {
                if (data.Result !== undefined && data.Result) {
                    $('#token').val(data.token);
                } else {
                    $('#token').val('error');
                }
            })
            .fail(function (err) {
                $('#token').val('error');
            });
    });

    $('#getData').click(function(){
        $.ajax({
            url: apiServer + 'Values',
            type: 'GET',
            headers: {
                Authorization: 'Bearer ' + $('#token').val()
            },
            dataType: 'json',
            success: function(data){
                $('#result').val(JSON.stringify(data));
            },
            error: function(data){
                $('#result').val('error');
            }
        })
    })
});