
// Función para actualizar el reloj en la pantalla de inicio
function updateClock() {
    var now = new Date();
    var hours = now.getHours();
    var minutes = now.getMinutes().toString().padStart(2, '0');
    var seconds = now.getSeconds().toString().padStart(2, '0');
    var ampm = hours >= 12 ? 'pm' : 'am';

    // Convertir a formato de 12 horas
    hours = hours % 12;
    hours = hours ? hours : 12; // Si es 0, mostrar 12

    var timeString = hours + ':' + minutes + ':' + seconds + ' ' + ampm;

    document.getElementById('clock').innerText = timeString;
}
// Actualiza el reloj cada segundo
setInterval(updateClock, 1000);
// Inicializa el reloj
updateClock();