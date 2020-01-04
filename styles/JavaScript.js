
$(document).ready(function () {
    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        $("#wrapper").toggleClass("active");
    });
    $("#editProfile").hover(function () {
        $("p").toggle();
        $("#profileView").hide();
    });
    $("#hide").click(function () {
        $("p").toggle();
        $("#hide").hide();
    });
});