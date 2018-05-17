$(document).ready(function () {
    $(".slide_panel_wrap p").click(function () {
        $(".slide_panel").slideToggle('fast');
        $(this).toggleClass("active");
    });
    return false;
});