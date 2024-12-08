$(function () {
    // Document.ready -> link up remove event handler
    $(".RemoveLink").click(function () {
        debugger;
        // Get the id from the link
        var recordToDelete = $(this).attr("data-id");
        if (recordToDelete != '') {
            // Perform the ajax post
            $.post("/ShoppingCart/RemoveFromCart", { "id": recordToDelete },
            function (data) {
                // Successful requests get here
                // Update the page elements
                if (data.ItemCount == 0) {
                    $('#row-' + data.DeleteId).fadeOut('slow');
                } else {
                    $('#item-count-' + data.DeleteId).text(data.ItemCount);
                }
                $('#cart-total').text(data.CartTotal);
                $('#update-message').text(data.Message);
                $('#cart-status').text('Cart (' + data.CartCount + ')');

                // Reload page:
                window.location.reload();
            });
        }
    });

    $(".UpdateLink").click(function () {
        debugger;
        // Get the id from the link
        var recordToDelete = $(this).attr("data-id");
        var tempcount = $('#item-count-' + recordToDelete).val();
        var count = parseInt(tempcount);

        if (recordToDelete != '') {
            // Perform the ajax post
            $.post("/ShoppingCart/SaveUpdateCart", { "id": recordToDelete, "count": count },
            function (data) {
                alert("Save update cart " + data);
                if (count == 0) {
                    $('#row-' + recordToDelete).fadeOut('slow');
                }

                // Reload page:
                window.location.reload();
            });
        }
    });
});