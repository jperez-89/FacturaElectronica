$(document).ready(function () {
    // Funcion para mostrar y ocultar los submenu aplicando una clase css
    $('.wrapper .left-side .sidebar .sidebar-menu li:has(ul)').click(function (e) { //accede a los elementos li que tiene ul del menu
        e.preventDefault(); // para que no redireccione al #

        if ($(this).hasClass('activado')) { // this se refiere al elemento que fue clickeado
            $(this).removeClass('activado');
            $(this).children('ul').slideUp();
        } else {
            $('.wrapper .left-side .sidebar .sidebar-menu li ul').slideUp(); // contraiga los submenu
            $('.wrapper .left-side .sidebar .sidebar-menu li').removeClass('activado');
            $(this).addClass('activado');
            $(this).children('ul').slideDown();
        }
    });

    // Funcion para extraer el link de la pagina a redireccionar
    $('.sidebar-menu li ul li a').click(function () { // accedes hasta el elemento a
        window.location.href = $(this).attr("href"); // extrae el link del href del elemento a
    });
    
});




