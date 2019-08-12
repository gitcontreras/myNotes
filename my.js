$(document).ready(function () {


    consultar_clientes();

    $("#btn_insertar").click(function (e) {
        e.preventDefault();

        insertar_cliente();
    });

});


function insertar_cliente() {

    var obj = new Object();

    obj.nombre = $("#txt_nombre").val();
    obj.clave = $("#txt_clave").val();
    obj.numero = $("#txt_numero").val();
    obj.cliente_id = $("#txt_cliente_id").val();

    var $datos = JSON.stringify(obj);

    var myurl = "/api/Cliente/Insertar_Cliente";
    if (obj.cliente_id != null && obj.cliente_id != undefined && obj.cliente_id!="")
        myurl = "/api/Cliente/Actualizar_Cliente";

    $.ajax({
        type: "post",
        url: myurl,
        data: $datos,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (resultado) {

            if (resultado != null) {

               $("#txt_nombre").val('');
                $("#txt_clave").val('');
                $("#txt_numero").val('');

                consultar_clientes();
            }

        }

    });


}

function editar(valor) {

    $("#txt_nombre").val(valor.nombre);
    $("#txt_clave").val(valor.clave);
    $("#txt_numero").val(valor.numero);
    $("#txt_cliente_id").val(valor.cliente_id);

}

function consultar_clientes() {


    $.ajax({
        type: "post",
        url: "/api/Cliente/Consultar_Clientes",
        DataType: "json",
        success: function (resultado) {

            if (resultado != null) {

                $("#tbl_cliente").empty();
                $("#tbl_cliente").append("<tr>");
                $("#tbl_cliente").append("<th>nombre</th>");
                $("#tbl_cliente").append("<th>clave</th>");
                $("#tbl_cliente").append("<th>numero</th>");
                $("#tbl_cliente").append("<th>accion</th>");
                $("#tbl_cliente").append("</tr>");

                var datos = $.parseJSON(resultado);

                for (var i = 0; i < datos.length; i++) {

                    $("#tbl_cliente").append("<tr>");
                    $("#tbl_cliente").append("<td>"+datos[i].nombre+"</td>");
                    $("#tbl_cliente").append("<td>"+datos[i].clave+"</td>");
                    $("#tbl_cliente").append("<td>" + datos[i].numero + "</td>");
                    $("#tbl_cliente").append("<td><button type='button' onclick='editar(" + JSON.stringify(datos[i]) + ")'>editar</button></td>");
                    $("#tbl_cliente").append("</tr>");

                }

            }

        }

    });


}
