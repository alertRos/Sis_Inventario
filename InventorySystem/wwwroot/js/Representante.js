import { validarInput } from "./index.js";

const inputs = ['nombre', 'cedula', 'apellido', 'usuario'];
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
});

var submitButton = document.getElementById('submitButton');
submitButton.addEventListener('click', function (event) {
    inputs.forEach(item => {
        var inputElement = document.getElementById(item);
        validarInput(inputElement, item);
    });
    var isFormValid = Array.from(document.querySelectorAll('.validationServer')).every(input => input.classList.contains('is-invalid'));

    if (isFormValid) {
        event.preventDefault();
    }
});