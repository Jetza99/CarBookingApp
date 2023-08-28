$(function () {
    $('.deleteBtn').click(function (e) {
        swal("Are you sure you want to do this?", {
            buttons: ["No", true],
            icon: "warning",
            dangerMode: true
        }).then((confirm) => {
            if (confirm) {
                var btn = $(this);
                var id = btn.data("id");
                $('#recordid').val(id);
                $('#deleteForm').submit();
            }
        });
    });
});