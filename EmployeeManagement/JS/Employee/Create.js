//==========Page Load==========
$(function () {
    var clickCount = -1;
    $('#createEducationInfo').click(function () {
        clickCount++;
        $.ajax({
            type: "POST",
            data: { index: clickCount },
            //dataType: "json",
            url: "/Employee/AddEducationInfo",
            success: function (data) {
                $("#EducationInfoShow").append(data);
            },
            error: function () {
                alert("ajax request error");
            }
        });
    });
});