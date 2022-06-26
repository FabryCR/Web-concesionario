const form = document.getElementById("form");
const UserMsg = document.getElementById("userError");
const PassMsg = document.getElementById("passError");
var user = "";
var pass = "";


$(document).ready(function () {
    $('#user').val('');
    $('#pass').val('');
});


function isNullOrWhitespace(input) {
    return !input || !input.trim()
}

form.addEventListener('submit', (e) => {

    user = document.getElementById("user").value.trim();
    pass = document.getElementById("pass").value;
    UserMsg.innerText = "";
    PassMsg.innerText = "";

    let error = 0;

    if (isNullOrWhitespace(user)) {
        UserMsg.innerText = "El usuario no puede estar vacío";
        error += 1;
    }

    if ((isNullOrWhitespace(pass))) {
        PassMsg.innerText = "La contraseña no puede estar vacía";
        error += 1;
    }

    if (error > 0) {
        e.preventDefault()
    }
})