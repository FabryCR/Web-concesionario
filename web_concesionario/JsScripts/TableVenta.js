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
            marca.value = currentTR.cells[1].innerText.trim();
            modelo.value = currentTR.cells[2].innerText.trim();
            color.value = currentTR.cells[3].innerText.trim();
            anio.value = currentTR.cells[4].innerText.trim();

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

        var car = {};
        car.IdVehiculo = currentTR.cells[5].innerText;
        car.Marca = $("#marca").val();
        car.Modelo = $("#modelo").val();
        car.Color = $("#color").val();
        car.Anio = $("#anio").val();

        $.ajax({
            type: 'POST',
            url: '/Vehiculo/EditVehiculo',
            data: JSON.stringify(car),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                //Setear los valores de la columna
                currentTR.cells[1].innerText = marca.value;
                currentTR.cells[2].innerText = modelo.value;
                currentTR.cells[3].innerText = color.value;
                currentTR.cells[4].innerText = anio.value;
            },
            error: function (data) {
                alert(data);
            }
        });
    }

     //Función eliminar
    function Delete() {

        if (confirm("¿Quieres eliminar este vehículo?")) {
            var car = {};
            car.IdVehiculo = currentTR.cells[5].innerText;
            $.ajax({
                type: "POST",
                url: "/Vehiculo/DeleteVehiculo",
                data: JSON.stringify(car),
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