$(document).ready(function () {
    SetDialog();

    try {
        $("#btnSelectImg").click(function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $('#txtImgUrl').val(fileUrl);
            };
            finder.popup();
        });
    } catch (e) {
        console.log(e);
    }

    try {
        var editor = CKEDITOR.replace('contenteditor', {
            customConfig: '/Scripts/Plugins/ckeditor/article.js',
        });
    } catch (e) {
        console.log(e);
    }
    

    $("#datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
});