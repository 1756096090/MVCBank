// Obtiene referencias a los botones y las secciones
const btnMostrarUsuarios = document.getElementById('btnMostrarUsuarios');
const btnMostrarTransferencias = document.getElementById('btnMostrarTransferencias');
const tablaUsuarios = document.getElementById('tablaUsuarios');
const tablaTransferencias = document.getElementById('tablaTransferencias');

// Agrega eventos de clic a los botones
btnMostrarUsuarios.addEventListener('click', function () {
    // Oculta la tabla de transferencias
    tablaTransferencias.style.display = 'none';
    // Muestra la tabla de usuarios
    tablaUsuarios.style.display = 'table';
});

btnMostrarTransferencias.addEventListener('click', function () {
    // Oculta la tabla de usuarios
    tablaUsuarios.style.display = 'none';
    // Muestra la tabla de transferencias
    tablaTransferencias.style.display = 'table';
});
