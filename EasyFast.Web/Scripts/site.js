$(function () {
    $("#nav li").click(function () {
        $("#nav li").removeClass("active");
        $(this).addClass("active");
    })
    /***专业领域***/
    $(".arbitration,.finance,.colligate").find("li img").mouseenter(function () {
        var src = $(this).attr("src");
        $(this).attr("src", src.split(".")[0] + "_1.png");
    })
    $(".arbitration,.finance,.colligate").find("li img").mouseleave(function () {
        var src = $(this).attr("src");
        $(this).attr("src", src.split("_")[0] + "_" + src.split("_")[1] + ".png");
    })
})
