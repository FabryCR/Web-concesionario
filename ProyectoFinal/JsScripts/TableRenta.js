(function () {

    //Columna actual
    let currentTR;

    //Seleccionar todos los botones con la clase "rent"
    document.querySelectorAll("a.rent").forEach(a => {

        //Añadir un evento a todos los botones "delete"
        a.addEventListener("click", function () {

            //Encontrar el padre de la columna
            currentTR = a.closest("tr");

            //Eliminar la entrada
            Rent();
        });
    });

    //Función alquilar
    function Rent() {

        var user = {};
        user.IdUsuario = currentTR.cells[7].innerText;

        user.NombUsuario = $("#usuario").val();
        user.Identificacion = $("#ide").val();
        user.Nombre = $("#nam").val();
        user.Apellido = $("#ape").val();
        user.Correo = $("#mail").val();
        user.Telefono = $("#tel").val();

        $.ajax({
            type: 'POST',
            url: '/Empleado/EditEmpleado',
            data: JSON.stringify(user),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //Setear los valores de la columna
                currentTR.cells[1].innerText = usuario.value;
                currentTR.cells[2].innerText = ide.value;
                currentTR.cells[3].innerText = nam.value;
                currentTR.cells[4].innerText = ape.value;
                currentTR.cells[5].innerText = mail.value;
                currentTR.cells[6].innerText = tel.value
            },
            error: function (data) {
                alert(data);
            }
        });
    }
})();