document.addEventListener("DOMContentLoaded", function () {
    // Guardar Usuario
    const formGuardar = document.getElementById("GuardarUsuarioForm");
    if (formGuardar) {
        formGuardar.addEventListener("submit", function (e) {
            e.preventDefault();

            const nombre = document.getElementById("NombreUsuario").value.trim();
            const apellido = document.getElementById("ApellidoUsuario").value.trim();
            const celular = document.getElementById("Cel").value.trim();
            const cuenta = document.getElementById("Cuenta").value.trim();
            const contraseña = document.getElementById("Contrasenia").value.trim();

            if (!nombre || !apellido || !celular || !cuenta || !contraseña) {
                Swal.fire({
                    icon: "warning",
                    title: "Campos incompletos",
                    text: "Por favor, complete todos los campos antes de guardar."
                });
                return;
            }

            Swal.fire({
                title: "¿Está seguro?",
                text: "Se guardará el usuario ingresado.",
                icon: "question",
                showCancelButton: true,
                confirmButtonText: "Sí, guardar",
                cancelButtonText: "Cancelar",
                reverseButtons: true
            }).then(result => {
                if (result.isConfirmed) formGuardar.submit();
               
            });
        });
    }

    // Modificar Usuario
    const formModificar = document.getElementById("ModificarUsuarioForm");
    if (formModificar) {
        formModificar.addEventListener("submit", function (e) {
            e.preventDefault();

            const nombre = document.getElementById("NombreUsuario").value.trim();
            const apellido = document.getElementById("ApellidoUsuario").value.trim();
            const celular = document.getElementById("Cel").value.trim();
            const cuenta = document.getElementById("Cuenta").value.trim();
            const contraseña = document.getElementById("Contrasenia").value.trim();

            if (!nombre || !apellido || !celular || !cuenta || !contraseña) {
                Swal.fire({
                    icon: "warning",
                    title: "Campos incompletos",
                    text: "Complete todos los campos antes de modificar."
                });
                return;
            }

            Swal.fire({
                title: "¿Desea modificar este usuario?",
                text: "Se modificará el usuario seleccionado.",
                icon: "question",
                showCancelButton: true,
                confirmButtonText: "Sí, modificar",
                cancelButtonText: "Cancelar",
                reverseButtons: true
            }).then(result => {
                if (result.isConfirmed) formModificar.submit();
            });
        });
    }

    // Eliminar Usuario
    const formEliminar = document.getElementById("EliminarUsuarioForm");
    if (formEliminar) {
        formEliminar.addEventListener("submit", function (e) {
            e.preventDefault();

            Swal.fire({
                title: "¿Está seguro?",
                text: "El usuario será eliminado permanentemente.",
                icon: "warning",
                showCancelButton: true,
                confirmButtonText: "Sí, eliminar",
                cancelButtonText: "Cancelar",
                reverseButtons: true
            }).then(result => {
                if (result.isConfirmed) formEliminar.submit();
            });
        });
    }
});
// Numero
document.addEventListener("DOMContentLoaded", function () {
    const nombreInput = document.getElementById('NombreUsuario');

    nombreInput.addEventListener('input', function () {

        const original = this.value;

        const nuevo = this.value.replace(/\d/g, '');

        if (nuevo !== original) {
            this.value = nuevo;

            Swal.fire({
                icon: 'warning',
                title: '¡Atención!',
                text: 'No se permiten números en este campo.',
                timer: 2000,
                showConfirmButton: false
            });
        }
    });
});
// Letra
document.addEventListener("DOMContentLoaded", function () {
    const edadInput = document.getElementById('Cel'); 

    edadInput.addEventListener('input', function () {
       
        const original = this.value;
       
        const nuevo = this.value.replace(/\D/g, ''); 

        if (nuevo !== original) {
            this.value = nuevo;

            Swal.fire({
                icon: 'warning',
                title: '¡Atención!',
                text: 'Sólo se permiten números en este campo.',
                timer: 2000,
                showConfirmButton: false
            });
        }
    });
});
// Numero
document.addEventListener("DOMContentLoaded", function () {
    const nombreInput = document.getElementById('ApellidoUsuario');

    nombreInput.addEventListener('input', function () {

        const original = this.value;

        const nuevo = this.value.replace(/\d/g, '');

        if (nuevo !== original) {
            this.value = nuevo;

            Swal.fire({
                icon: 'warning',
                title: '¡Atención!',
                text: 'No se permiten números en este campo.',
                timer: 2000,
                showConfirmButton: false
            });
        }
    });
});
