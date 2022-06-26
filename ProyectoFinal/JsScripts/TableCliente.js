(function () {

    //Columna actual
    let currentTR;

    //Seleccionar todos los botones con la clase "edit"
    document.querySelectorAll("a.edit").forEach(a => {

        //Añadir un evento a todos los botones "edit"
        a.addEventListener("click", function () {

            //Cancelar cualquier edición pendiente
            if (currentTR) {
                aCancel.click();
            }

            //Encontrar el padre de la columna
            currentTR = a.closest("tr");

            //Insertar la columna de edición "boxes" en la posición de la columna actual
            currentTR.insertAdjacentElement('beforebegin', boxes);

            //Esconder la columna actual
            currentTR.hidden = true;

            //Llenar los text-box con la información de la columna

            usuario.value = currentTR.cells[1].innerText.trim();
            ide.value = currentTR.cells[2].innerText.trim();
            nam.value = currentTR.cells[3].innerText.trim();
            ape.value = currentTR.cells[4].innerText.trim();
            mail.value = currentTR.cells[5].innerText.trim();
            tel.value = currentTR.cells[6].innerText.trim();

            //Mostrar la columna de edición "boxes"
            boxes.hidden = false;

        });

    });

    //Seleccionar todos los botones con la clase "delete"
    document.querySelectorAll("a.delete").forEach(a => {

        //Añadir un evento a todos los botones "delete"
        a.addEventListener("click", function () {

            //Cancelar cualquier edición pendiente
            if (currentTR) {
                aCancel.click();
            }

            //Encontrar el padre de la columna
            currentTR = a.closest("tr");

            //Esconder la columna actual
            currentTR.hidden = true;

            //Eliminar la entrada
            Delete();
        });
    });

    //Botón de cancelar del modo edición
    aCancel.addEventListener("click", function () {

        //Esconder la columna de edición
        boxes.hidden = true;

        //Mostrar la columna fuera del modo edición
        currentTR.hidden = false;

    });

    //Botón de actualizar del modo edición
    aUpdate.addEventListener("click", function () {

        //Esconder la columna de edición
        boxes.hidden = true;

        //Mostrar la columna fuera del modo edición
        currentTR.hidden = false;

        //Actualizar los datos en la BD
        Update();
    });


    //Función actualizar
    function Update() {

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
            url: '/Cliente/EditCliente',
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

    //Función eliminar
    function Delete() {

        if (confirm("¿Quieres eliminar este cliente?")) {
            var user = {};
            user.IdUsuario = currentTR.cells[7].innerText;
            $.ajax({
                type: "POST",
                url: "/Cliente/DeleteCliente",
                data: JSON.stringify(user),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data != null) {
                        alert("Eliminado correctamente");
                    } else {
                        alert("Ocurrió un error al eliminar la entrada");
                    }
                }
            });
        }
    }

})();