$(function () {
    $(".CancelLink").click(function () {
        var id = $(this).attr("data-id");

        $.post("/TicketsOrdered/CancelOrder", { "id": id }, function (data) {
            $("#item-status-" + data.DeleteId).text(data.Status);
            //$("#update-message").text(data.Status);
            //document.getElementById("link").innerHTML = "";
            //$("#cart-total").text(data.CartTotal);
            //$("#item-count-" + data.DeleteId).text(data.ItemCount);

            //if (data.ItemCount < 1) {
            //    $("#record-" + data.DeleteId).fadeOut();
            //}
        });
    });
});