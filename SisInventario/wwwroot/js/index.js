const caracteresNoPermitidos = /[^a-zA-Z\s]/;
const caracteresPermitidosEmail = /^[a-zA-Z0-9_%+-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,}$/;
export function validarInput(input, item) {
        var inputValue = input.value.trim();
        var feedbackElement = document.getElementById(item + 'Feedback');

        if (item === 'email' && !caracteresPermitidosEmail.test(inputValue)) {
            input.classList.add('is-invalid');
            input.classList.remove('is-valid');
            feedbackElement.textContent = 'El campo de correo electrónico no es válido.';
        } else if (item === 'email' && inputValue.indexOf('@') === -1) {
            // Añadir validación adicional para asegurarse de que hay al menos una arroba
            input.classList.add('is-invalid');
            input.classList.remove('is-valid');
            feedbackElement.textContent = 'El campo de correo electrónico debe contener una arroba (@).';
        } else if (inputValue === '') {
            input.classList.add('is-invalid');
            input.classList.remove('is-valid');
            feedbackElement.textContent = 'Este campo es obligatorio.';
        } else if (caracteresNoPermitidos.test(inputValue) && item !== 'email' && item !== 'password' && item !== 'confirm') {
            input.classList.add('is-invalid');
            input.classList.remove('is-valid');
            feedbackElement.textContent = 'Mensaje para caracteres no permitidos en ' + item + '.';
        } else {
            input.classList.add('is-valid');
            input.classList.remove('is-invalid');
            feedbackElement.textContent = '';
        }
    }


