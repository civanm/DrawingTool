(function () {
    $('#submit-command').on('click', function () {
        var input = $.trim($("#text-input").val());
        $.post('/api/draw', { '': input }, function (resp) {
            //resp = resp.replace(/ /g, '<span>&nbsp;</span>');

            resp = resp.split('<br/>').map(function (item) {
                return item.split('').map(function (item) {
                    return '<span>' + item + '</span>';
                }).join('');
            }).join('<br/>')
            $('#results').html(resp);
        }, "json");
    });

})();