
document.addEventListener("DOMContentLoaded", function () {
    const formEliminar = document.getElementById("EliminarMembresiaForm");

    if (!formEliminar) return;

    formEliminar.addEventListener("submit", function (e) {
        e.preventDefault();

        Swal.fire({
            title: "¿Está seguro?",
            text: "El membresia será eliminado permanentemente.",
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
    const formGuardar = document.getElementById("GuardarMembresiaForm");

    if (formGuardar) {
        formGuardar.addEventListener("submit", function (e) {
            e.preventDefault();

            const nombre = document.getElementById("Nombre").value.trim();
            const idServicio = document.getElementById("IdServicio").value.trim();
            const precio = document.getElementById("Precio").value.trim();
            const duracion = document.getElementById("Duracion").value.trim();
            const descripcion = document.getElementById("Descripcion").value.trim();
            
   


            if (!nombre||!idServicio||!precio||!duracion||!descripcion) {
                Swal.fire({
                    icon: "warning",
                    title: "Campos incompletos",
                    text: "Por favor, complete todos los campos antes de guardar."
                });
                return;
            }

            Swal.fire({
                title: "¿Está seguro?",
                text: "Se guardará el membresia digitado.",
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
    const formModificar = document.getElementById("ModificarMembresiaForm");

    if (!formModificar) return;

    formModificar.addEventListener("submit", function (e) {
        e.preventDefault();

        const nombre = document.getElementById("Nombre").value.trim();
        const idServicio = document.getElementById("IdServicio").value.trim();
        const precio = document.getElementById("Precio").value.trim();
        const duracion = document.getElementById("Duracion").value.trim();
        const descripcion = document.getElementById("Descripcion").value.trim();


        if (!nombre || !idServicio || !precio || !duracion || !descripcion) {
            Swal.fire({
                icon: "warning",
                title: "Campos incompletos",
                text: "Complete todos los campos antes de modificar."
            });
            return;
        }

        Swal.fire({
            title: "¿Desea modificar este membresia?",
            text: "Se Modificara el membresia seleccionado.",
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
//mumero
document.addEventListener("DOMContentLoaded", function () {
    const nombreInput = document.getElementById('NombreMembresia');

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
//Letra
document.addEventListener("DOMContentLoaded", function () {
    const edadInput = document.getElementById('PrecioMembresia');

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