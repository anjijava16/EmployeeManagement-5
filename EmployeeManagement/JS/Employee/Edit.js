//==========Page Load==========
$(function () {
    //Edit时，需要判断新增的EducationInfo为第几个，很可能不是从0开始
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
            }
        });
    });
});