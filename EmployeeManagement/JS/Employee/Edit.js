//==========Page Load==========
$(function () {
    //Edit时，需要判断新增的EducationInfo为第几个，很可能不是从0开始
    var clickCount = $("#existEducationCount").val();
    $("#deleteEducationInfo").attr("disabled", true);

    $('#createEducationInfo').click(function () {
        $.ajax({
            type: "POST",
            data: { index: clickCount },
            url: "/Employee/AddEducationInfo",
            success: function (data) {
                $("#EducationInfoShow").append(data);
                $("#deleteEducationInfo").attr("disabled", false);
                $("form").removeData("validator");
                $("form").removeData("unobtrusiveValidation");
                $.validator.unobtrusive.parse("form");
            }
        });
        clickCount++;
    });
    $("#deleteEducationInfo").click(function () {
        $("#EducationInfoShow ul:last-child").remove();
        $("form").removeData("validator");
        $("form").removeData("unobtrusiveValidation");
        $.validator.unobtrusive.parse("form");
        clickCount--;
        if ($("#EducationInfoShow").html().length < 500) {
            $("#deleteEducationInfo").attr("disabled", true);
        }
    });
});