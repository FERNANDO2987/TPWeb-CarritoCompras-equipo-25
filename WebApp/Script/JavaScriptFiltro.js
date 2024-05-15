﻿document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('searchButton').addEventListener('click', function () {
        applyFilters();
    });

    document.getElementById('searchInput').addEventListener('input', function () {
        applyFilters();
    });

    document.getElementById('entradaBusquedaDescripcion').addEventListener('input', function () {
        aplicarFiltros();
    });

    document.getElementById('priceFilter').addEventListener('change', function () {
        applyFilters();
    });

    function applyFilters() {
        var input = document.getElementById('searchInput').value.toLowerCase();
        var entradaDescripcion = document.getElementById('searchDescripcion').value.toLowerCase();
        var priceFilter = document.getElementById('priceFilter').value;
        var cards = document.getElementsByClassName('image-card');
        var cardsArray = Array.prototype.slice.call(cards);

        // Filtrado por nombre
        for (var i = 0; i < cards.length; i++) {
            var cardTitle = cards[i].getAttribute('data-nombre');
            var descripcionTarjeta = tarjetas[i].getAttribute('data-descripcion');
            if (tituloTarjeta.toLowerCase().includes(entradaNombre) && descripcionTarjeta.toLowerCase().includes(entradaDescripcion)) {
                cards[i].style.display = "";
            } else {
                cards[i].style.display = "none";
            }
        }

        // Ordenar por precio
        if (priceFilter) {
            cardsArray.sort(function (a, b) {
                var priceA = parseFloat(a.getAttribute('data-precio'));
                var priceB = parseFloat(b.getAttribute('data-precio'));

                if (priceFilter === 'low') {
                    return priceA - priceB;
                } else if (priceFilter === 'high') {
                    return priceB - priceA;
                }
                return 0;
            });

            var container = document.getElementById('imageContainer');
            container.innerHTML = '';
            cardsArray.forEach(function (card) {
                container.appendChild(card);
            });
        }
    }
});
