
document.addEventListener("DOMContentLoaded", function () {
    const formEliminar = document.getElementById("EliminarInscripcionForm");

    if (!formEliminar) return;

    formEliminar.addEventListener("submit", function (e) {
        e.preventDefault();

        Swal.fire({
            title: "¿Está seguro?",
            text: "La inscripcion será eliminada permanentemente.",
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
    const formModificar = document.getElementById("ModificarInscripcionForm");

    if (!formModificar) return;

    formModificar.addEventListener("submit", function (e) {
        e.preventDefault();

        const idusuario = document.getElementById("IdUsuario").value.trim();
        const idmembresia = document.getElementById("IdMembresia").value.trim();
        const idestado = document.getElementById("IdEstado").value.trim();
        const fechainscripcion = document.getElementById("FechaInscripcion").value.trim();
        const fechavencimiento = document.getElementById("FechaVencimiento").value.trim();


        if (!idusuario || !idmembresia || !idestado || !fechainscripcion || !fechavencimiento) {
            Swal.fire({
                icon: "warning",
                title: "Campos incompletos",
                text: "Complete todos los campos antes de modificar."
            });
            return;
        }

        Swal.fire({
            title: "¿Desea modificar esta inscripcion?",
            text: "Se Modificara la inscripcion seleccionada.",
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
