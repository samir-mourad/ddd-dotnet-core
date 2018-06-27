
$(document).ready(function () {
    $("#bootbox-confirm").on(ace.click_event, function () {
        bootbox.dialog({
            title: 'A custom dialog with buttons and callbacks',
            message: "<p>This dialog has buttons. Each button has it's own callback function.</p>",
            buttons: {
              
                ok: {
                    label: "Ok, entendi!",
                    className: 'btn-info',
                    callback: function () {
                       
                    }
                }
            }
        });
    });
});