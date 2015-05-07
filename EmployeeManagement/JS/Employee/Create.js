//==========Page Load==========
$(function () {
    var clickCount = -1;
    $("#deleteEducationInfo").attr("disabled", true);
    $('#createEducationInfo').click(function () {
        clickCount++;
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