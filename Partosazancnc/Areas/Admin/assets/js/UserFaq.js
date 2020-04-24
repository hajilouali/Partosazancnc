﻿$(function () {
    $.get("/Admin/Faqs/UserFaqResult",
        function (result) {
            $("#Comment_content").html(result);
        });
});
function pageid(id) {
    
    $.get("/Admin/Faqs/UserFaqResult?pageId="  + id,
        function (result) {
            $("#Comment_content").html(result);
        });

};
function Edit(id) {
    $.get("/Admin/Faqs/CommentEdite/" + id,
        function (result) {
            $("#modalbody").html(result);
            $("#item_" + id).removeClass();
            $("#itemdraf_" + id).remove();
            $("#itempub_" + id).remove();
            $("#btnitem_" + id).append('<a id="itemdraf_' +
                id +
                '" onclick="DraftComment(' +
                id +
                ')" class="btn btn-info btn-xs ">خوانده نشده</a>');
        });
}
function PublishComment(id) {
    $.get('/Admin/Faqs/PublishComment/' + id,
        function () {
            $("#item_" + id).removeClass();
            $("#itempub_" + id).remove();
            $("#btnitem_" + id).append('<a id="itemdraf_' +
                id +
                '" onclick="DraftComment(' +
                id +
                ')" class="btn btn-info btn-xs ">خوانده نشده</a>');
            swal("نظر انتخاب شده منتشر گردید .",
                {
                    icon: "success",
                    button: "تایید"
                });
        });
}
function DraftComment(id) {
    $.get('/Admin/Faqs/DraftComment/' + id,
        function () {
            $("#item_" + id).addClass('info');
            $("#itemdraf_" + id).remove();
            $("#btnitem_" + id).append('<a id="itempub_' +
                id +
                '" onclick="PublishComment(' +
                id +
                ')" class="btn btn-success btn-xs ">خوانده شده</a>');
            swal("نظر انتخاب شده پیش گردید .",
                {
                    icon: "success",
                    button: "تایید"
                });
        });
}
function DeleteComment(id) {
    swal({
        title: "آیا از پاک کردن این پیغام اطمینان دارید ؟",

        icon: "warning",

        buttons: ["خیر", "بله پاک کن"],
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.get('/Admin/Faqs/DeleteComment/' + id,
                    function () {
                        $("#item_" + id).hide('slow');
                        swal("پیغام انتخاب شده با موفقیت حذف گردید .",
                            {
                                icon: "success",
                                button: "تایید"
                            });
                    });

            } else {
                swal("دستور حذف متوقف گردید", { button: "تایید" });
            }
        });
}
function cksAll() {
    if ($("#cksAll").is(':checked')) {
        $(".chk").prop("checked", true);
    } else {
        $(".chk").prop("checked", false);
    }
}
function getValuePublish() {
    /* declare an checkbox array */
    var chkArray = [];

    /* look for all checkboes that have a class 'chk' attached to it and check if it was checked */
    $(".chk:checked").each(function () {
        chkArray.push($(this).val());
    });

    /* check if there is selected checkboxes, by default the length is 1 as it contains one single comma */
    if (chkArray.length > 0) {
        swal({
            title: "آیا از خوانده شدن نظرات انتخاب شده اطمینان دارید ؟",

            icon: "info",

            buttons: ["خیر", "بله "],
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $(chkArray).each(function () {
                        $.get('/Admin/Faqs/PublishComment/' + this,
                            function () {

                            });
                        $("#item_" + this).removeClass();
                        $("#btnitem_" + this).empty();
                        $("#btnitem_" + this).append('<a id="itemdraf_' +
                            this +
                            '" onclick="DraftComment(' +
                            this +
                            ')" class="btn btn-info btn-xs ">خوانده نشدن</a>');
                    });
                    swal("نظرات  انتخاب شده منتشر گردید .",
                        {
                            icon: "success",
                            button: "تایید"
                        });
                    $(".chk:checked").each(function () {
                        $(this).prop("checked", false);
                    });

                    $("#cksAll").prop("checked", false);

                } else {
                    swal("دستور متوقف گردید", { button: "تایید" });
                }
            });

    } else {
        swal("ردیفی برای انتشار انتخاب نشده است",
            {
                icon: "warning",
                button: "تایید"
            });
    }
}
function getValueDraft() {
    /* declare an checkbox array */
    var chkArray = [];

    /* look for all checkboes that have a class 'chk' attached to it and check if it was checked */
    $(".chk:checked").each(function () {
        chkArray.push($(this).val());
    });

    /* check if there is selected checkboxes, by default the length is 1 as it contains one single comma */
    if (chkArray.length > 0) {
        swal({
            title: "آیا از خوانده شدن نظرات انتخاب شده اطمینان دارید ؟",

            icon: "info",

            buttons: ["خیر", "بله "],
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $(chkArray).each(function () {
                        $.get('/Admin/Faqs/DraftComment/' + this,
                            function () {

                            });
                        $("#item_" + this).addClass('info');
                        $("#btnitem_" + this).empty();
                        $("#btnitem_" + this).append('<a id="itempub_' +
                            this +
                            '" onclick="PublishComment(' +
                            this +
                            ')" class="btn btn-success btn-xs ">خوانده شدن</a>');
                    });
                    swal("نظرات  انتخاب شده پیش نویس گردید .",
                        {
                            icon: "success",
                            button: "تایید"
                        });
                    $(".chk:checked").each(function () {
                        $(this).prop("checked", false);

                    });
                    $("#cksAll").prop("checked", false);
                } else {
                    swal("دستور متوقف گردید", { button: "تایید" });
                }
            });

    } else {
        swal("ردیفی برای انتشار انتخاب نشده است",
            {
                icon: "warning",
                button: "تایید"
            });
    }
}
function getValueDelete() {
    /* declare an checkbox array */
    var chkArray = [];

    /* look for all checkboes that have a class 'chk' attached to it and check if it was checked */
    $(".chk:checked").each(function () {
        chkArray.push($(this).val());
    });

    /* check if there is selected checkboxes, by default the length is 1 as it contains one single comma */
    if (chkArray.length > 0) {
        swal({
            title: "آیا از حذف نظرات انتخاب شده اطمینان دارید ؟",

            icon: "warning",

            buttons: ["خیر", "بله "],
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $(chkArray).each(function () {
                        $.get('/Admin/Faqs/DeleteComment/' + this,
                            function () {

                            });
                        $("#item_" + this).hide();
                    });
                    swal("نظرات  انتخاب شده حذف گردید .",
                        {
                            icon: "success",
                            button: "تایید"
                        });
                    $(".chk:checked").each(function () {
                        $(this).prop("checked", false);

                    });
                    $("#cksAll").prop("checked", false);
                } else {
                    swal("دستور متوقف گردید", { button: "تایید" });
                }
            });

    } else {
        swal("ردیفی برای انتشار انتخاب نشده است",
            {
                icon: "warning",
                button: "تایید"
            });
    }
}