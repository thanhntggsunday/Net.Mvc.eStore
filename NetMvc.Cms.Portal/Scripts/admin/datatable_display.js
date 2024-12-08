$(document).ready(function () {
    $('#dataTables').dataTable({
        "iDisplayLength": 50,
        "oSearch": {
            "sZeroRecords": "@Resources.CmsResource.AdminNoRecordMessage"
        }
    });
    $("#NotificationBox").fadeIn(1000);

    if ($("#NotificationAutoHide").val() == "true") {
        $("#NotificationBox").delay(1000).slideUp(500);
    }

});