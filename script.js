const API = "https://localhost:7229/api/pelicula";

const form = document.getElementById('movieForm');
const container = document.getElementById('moviesContainer');
const toggleFormBtn = document.getElementById('toggleFormBtn');

let isEditing = false;

toggleFormBtn.addEventListener('click', () => {
    form.classList.toggle('hidden');
    form.reset();
    isEditing = false;
    document.getElementById('idMovie').value = '';
});

form.addEventListener('submit', async (e) => {
    e.preventDefault();

    const pelicula = {
        id: parseInt(document.getElementById('idMovie').value) || 0,
        titulo: document.getElementById('title').value,
        genero: document.getElementById('genero').value,
        director: document.getElementById('director').value,
        estreno: parseInt(document.getElementById('estreno').value),
        calificacion: parseInt(document.getElementById('calificacion').value),
        cartelUrl: document.getElementById('cartelUrl').value,
        trailerUrl: document.getElementById('trailerUrl').value
    };

    if (isEditing) {
        await fetch(API, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(pelicula)
        });
        isEditing = false;
    } else {
        await fetch(API, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(pelicula)
        });
    }

    form.reset();
    form.classList.add('hidden');
    cargarPeliculas();
});

async function cargarPeliculas() {
    const res = await fetch(API);
    const peliculas = await res.json();

    container.innerHTML = '';
    peliculas.forEach(pelicula => {
        const card = document.createElement('div');
        card.className = 'card';

        card.innerHTML = `
      <img src="${pelicula.cartelUrl || 'https://via.placeholder.com/250x300?text=Sin+Cartel'}" alt="Cartel">
      <h3>${pelicula.titulo}</h3>
      <p><strong>Género:</strong> ${pelicula.genero}</p>
      <p><strong>Director:</strong> ${pelicula.director}</p>
      <p><strong>Estreno:</strong> ${pelicula.estreno}</p>
      <p><strong>Calificación:</strong> ${'⭐'.repeat(pelicula.calificacion || 0)}</p>
     ${pelicula.trailerUrl ? mostrarEnlaceTrailer(pelicula.trailerUrl) : ''}
      <div class="actions">
        <button class="edit" onclick='editar(${JSON.stringify(pelicula)})'>Editar</button>
        <button class="delete" onclick="eliminar(${pelicula.id})">Eliminar</button>
      </div>
    `;

        container.appendChild(card);
    });
}

function editar(pelicula) {
    document.getElementById('idMovie').value = pelicula.id;
    document.getElementById('title').value = pelicula.titulo;
    document.getElementById('genero').value = pelicula.genero;
    document.getElementById('director').value = pelicula.director;
    document.getElementById('estreno').value = pelicula.estreno;
    document.getElementById('calificacion').value = pelicula.calificacion;
    document.getElementById('cartelUrl').value = pelicula.cartelUrl;
    document.getElementById('trailerUrl').value = pelicula.trailerUrl;

    form.classList.remove('hidden');
    isEditing = true;
    window.scrollTo(0, 0);
}

async function eliminar(id) {
    if (confirm('¿Estás seguro de eliminar esta película?')) {
        await fetch(`${API}/${id}`, { method: 'DELETE' });
        cargarPeliculas();


    }
}

function mostrarEnlaceTrailer(url) {
    if (url.includes('youtube.com/watch')) {
        const videoId = new URL(url).searchParams.get('v');
        const embedUrl = `https://www.youtube.com/watch?v=${videoId}`;
        return `<a href="${embedUrl}" target="_blank" class="trailer-link">Haz clic aquí para el tráiler</a>`;
    }
    return `<a href="${url}" target="_blank" class="trailer-link">Haz clic aquí para ver el tráiler</a>`;
}

cargarPeliculas();
