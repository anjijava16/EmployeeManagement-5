//==========Page Load==========
$(function () {
    var clickCount = -1;
    $("#deleteEducationInfo").attr("disabled", true);  
    $('#createEducationInfo').click(function () {
        clickCount++;
        $.ajax({
            type: "POST",
            data: { index: clickCount },
            //dataType: "json",
            url: "/Employee/AddEducationInfo",
            success: function (data) {
                $("#EducationInfoShow").append(data);
                $("#deleteEducationInfo").attr("disabled", false);
            }
        });
    });
    $("#deleteEducationInfo").click(function () {
        $("#EducationInfoShow ul:last-child").remove();
        clickCount--;
        if ($("#EducationInfoShow").html().length <500) {
            $("#deleteEducationInfo").attr("disabled", true);
        }
    });
});