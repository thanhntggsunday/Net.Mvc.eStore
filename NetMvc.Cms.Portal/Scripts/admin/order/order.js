;
var dataTable = {};
var strAction = "@Resources.CmsResource.AdminFunctionActionColumnHeaderText";

$(document).ready(function () {
    var urlGetPaging = '/Admin/Order/GetAllPaging';

    dataTable = $('#tbl_Orders').DataTable({
        "processing": true,
        "serverSide": true,
        "paging": true,
        "pageLength": 5,
        "lengthMenu": [[5, 10, 20, 50, 500], [5, 10, 20, 50, 500]],
        'searching': true,
        "ordering": false,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        "ajax": {
            "url": urlGetPaging,
            "type": "GET",
            'data': function (data) {

            },
            "dataSrc": function (json) {

                json.draw = json.draw;
                json.recordsTotal = json.recordsTotal;
                json.recordsFiltered = json.recordsFiltered;

                if (json.data != null && json.data != undefined) {
                    for (var i = 0, ien = json.data.length; i < ien; i++) {
                        //let edit = " ";
                        //json.data[i].edit = "Edit";

                        let details = "<button class='btn btn-primary' onclick=\"showDetails('" + json.data[i].ID + "')\">" + "Chi tiết" + "</button>";
                        let edit = "<button class='btn btn-primary' onclick=\"showEditForm('" + json.data[i].ID + "')\">" + "Edit" + "</button>";
                        json.data[i].edit = details + " " + edit;

                        let cssIcon = "";
                    }
                }

                return json.data;
            }
        },
        "columns":
            [
                {

                    "title": "Mã đơn hàng", "data": "ID", "orderable": false
                },
                {

                    "title": "Email", "data": "CustomerEmail", "orderable": false
                },

                {

                    "title": "Số ĐT", "data": "CustomerMobile", "orderable": false
                },
                {

                    "title": "Ngày đặt", "data": "StrCreatedDate", "orderable": false
                },

                {

                    "title": "Status", "data": "StrStatus", "orderable": false
                },
                {

                    "title": "Trạng thái thanh toán", "data": "PaymentStatus", "orderable": false
                },
                {

                    "title": "Tổng giá", "data": "Total", "orderable": false
                },

                {

                    "title": "Thao tác", "data": "edit", "orderable": false
                }

            ]

    });


});


function showDetails(id) {
    console.log(id);

    window.location.href = "/Admin/Order/Details/" + id;
}

function showEditForm(id) {
    console.log(id);

    window.location.href = "/Admin/Order/Edit/" + id;
}

