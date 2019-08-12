$(document).ready(function () {


    $("#obtener").click(function () {

        $.ajax({
            type: "post",
            url: "/api/Cliente/Consultar",
            contentType: "application/json",
            dataType: "json",
            success: function (response) {
                alert(response);
            }



        });

    });


})
