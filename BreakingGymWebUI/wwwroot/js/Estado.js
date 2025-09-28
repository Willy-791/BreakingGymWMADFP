
document.addEventListener("DOMContentLoaded", function () {
    const formEliminar = document.getElementById("EliminarEstadoForm");

    if (!formEliminar) return;

    formEliminar.addEventListener("submit", function (e) {
        e.preventDefault();

        Swal.fire({
            title: "¿Está seguro?",
            text: "El Estado será eliminado permanentemente.",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Sí, eliminar",
            cancelButtonText: "Cancelar",
            reverseButtons: true
        }).then(result => {
            if (result.isConfirmed) formEliminar.submit();
        });
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const formGuardar = document.getElementById("GuardarEstadoForm");

    if (formGuardar) {
        formGuardar.addEventListener("submit", function (e) {
            e.preventDefault();

            const nombre = document.getElementById("NombreEstado").value.trim();
     
            if (!nombre ) {
                Swal.fire({
                    icon: "warning",
                    title: "Campos incompletos",
                    text: "Por favor, complete todos los campos antes de guardar."
                });
                return;
            }

            Swal.fire({
                title: "¿Está seguro?",
                text: "Se guardará el Estado digitado.",
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
});
document.addEventListener("DOMContentLoaded", function () {
    const formModificar = document.getElementById("ModificarEstadoForm");

    if (!formModificar) return;

    formModificar.addEventListener("submit", function (e) {
        e.preventDefault();

        const nombre = document.getElementById("NombreEstado").value.trim();


        if (!nombre) {
            Swal.fire({
                icon: "warning",
                title: "Campos incompletos",
                text: "Complete todos los campos antes de modificar."
            });
            return;
        }

        Swal.fire({
            title: "¿Desea modificar este estado?",
            text: "Se Modificara el estado seleccionado.",
            icon: "question",
            showCancelButton: true,
            confirmButtonText: "Sí, modificar",
            cancelButtonText: "Cancelar",
            reverseButtons: true
        }).then(result => {
            if (result.isConfirmed) formModificar.submit();
        });
    });
});
document.addEventListener("DOMContentLoaded", function () {
    const nombreInput = document.getElementById('NombreEstado');

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