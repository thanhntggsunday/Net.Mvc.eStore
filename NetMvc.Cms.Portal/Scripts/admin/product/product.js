;
var dataTable = {};
var strAction = "@Resources.CmsResource.AdminFunctionActionColumnHeaderText";

$(document).ready(function () {
    var urlGetPaging = '/Admin/Product/GetAllPaging';

    dataTable = $('#tbl_Products').DataTable({
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

                        let edit = "<button class='btn btn-primary' onclick=\"showEditForm('" + json.data[i].ID + "')\">" + "Edit" + "</button>";
                        let deleteContent = "<button class='btn btn-danger' id = 'btn-" + json.data[i].ID + "' onclick=\"deleteContent('" + json.data[i].ID + "')\">" + "Delete" + "</button>";
                        json.data[i].edit = edit + " " + deleteContent;

                        let cssIcon = "";
                    }
                }

                return json.data;
            }
        },
        "columns":
            [
                {
                    "title": "ID", "data": "ID", "orderable": false, 'visible': false
                },
                {
                    "title": "Mã sản phẩm", "data": "Code", "orderable": false
                },
                {

                    "title": "Tiêu đề", "data": "Title", "orderable": false
                },
                {

                    "title": "Số lượt xem", "data": "ViewCount", "orderable": false
                },

                {

                    "title": "Người tạo", "data": "CreatedBy", "orderable": false
                },
                {

                    "title": "Ngày tạo", "data": "StrCreatedDate", "orderable": false
                },

                {

                    "title": "Thao tác", "data": "edit", "orderable": false
                }

            ]

    });
    
   
});


function showEditForm (id) {
    console.log(id);
   
    window.location.href = "/Admin/Product/Edit/" + id;
}


function deleteContent(id) {
    console.log(id);
    var r = confirm("Your are delete item selected ?");
    if (r == true) {
        var url = "/Admin/Product/Delete/" + id;

        jQuery.ajax({
            url: url,
            type: "DELETE",
            dataType: "json",
            //data: { id: id },
            contentType: "application/json",
            success: function (data) {
                console.log(data);
                // swindow.location.reload();

                let btn = jQuery('#btn-' + id);

                let row = $(btn).closest("tr");

                if (row != undefined && row.length > 0) {
                    row[0].remove();
                }
            },
            error: function (data) {
                console.log(data);
            }
        });
    } 
}
