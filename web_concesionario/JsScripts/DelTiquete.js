(function () {

    //Columna actual
    let currentTR;

    //Seleccionar todos los botones con la clase "delete"
    document.querySelectorAll("a.delete").forEach(a => {

        //Añadir un evento a todos los botones "delete"
        a.addEventListener("click", function () {

            //Encontrar el padre de la columna
            currentTR = a.closest("tr");

            //Esconder
            currentTR.hidden = true;

            //Eliminar la entrada
            Delete();
        });
    });

    //Función eliminar
    function Delete() {

        if (confirm("¿Quieres eliminar este tíquete?")) {

            var tiq = {};
            tiq.IdTiquete = currentTR.cells[1].innerText;

            $.ajax({
                type: "POST",
                url: "/Tiquete/DeleteTiquete",
                data: JSON.stringify(tiq),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data != null) {
                        alert("Eliminado correctamente");
                    } else {
                        alert("No se puede eliminar esta entrada");
                    }
                }
            });
        }
    }

})();