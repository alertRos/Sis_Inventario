const inputs = [ 'password', 'email'];
import { validarInput } from "./index.js";
document.addEventListener('DOMContentLoaded', function () {
    inputs.forEach(item => {
        var inputElement = document.getElementById(item);
        inputElement.addEventListener('input', function (inputEvent) {
            validarInput(inputElement, item);
        });
        inputElement.addEventListener('blur', function (inputEvent) {
            validarInput(inputElement, item);
        });
    });
    var submitButton = document.getElementById('submitButton');
    submitButton.addEventListener('click', function (event) {
        // Validar todos los campos
        inputs.forEach(item => {
            var inputElement = document.getElementById(item);
            validarInput(inputElement, item);
        });

        // Verificar si todos los campos son válidos
        var isFormValid = Array.from(document.querySelectorAll('.validationServer')).every(input => input.classList.contains('is-valid'));

        if (!isFormValid) {
            // Evitar que el formulario se envíe si no es válido
            event.preventDefault();
        }
        // No es necesario un else aquí; el formulario se enviará solo si es válido
    });


});