//Si el input es de clase numeric, no permitir otros dígitos que no sean números
$(document).on("input", ".numeric", function () {
    this.value = this.value.replace(/\D/g, '');
});

//Función para Insertar Vehículos
//Si se selecciona el tipo "Venta", el field de Placa se desactiva.
$('#tipo').change(function () {

    if ($('#tipo').val() === 'Venta') {
        $('#placa').val('');
        $('#placa').prop('disabled', true);
    } else {
        $('#placa').prop('disabled', false);
    }
});