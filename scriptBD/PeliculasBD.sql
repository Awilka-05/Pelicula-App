create database Peliculas

use Peliculas
go

create table Pelicula (
    Id int identity(1,1) primary key,
    Titulo nvarchar(200) not null,
    Estreno int not null,
    Genero nvarchar(100) not null,
    Director nvarchar(150) not null,
    Calificacion int,
    CartelUrl nvarchar(500),
    TrailerUrl nvarchar(500)
);

INSERT INTO Pelicula (Titulo, Estreno, Genero, Director, Calificacion, CartelUrl, TrailerUrl)
VALUES 
('El Castillo Ambulante', 2004, 'Animación, Fantasía', 'Hayao Miyazaki', 9, 'https://example.com/cartel_castillo_ambulante.jpg', 'https://example.com/trailer_castillo_ambulante.mp4');

select * from Pelicula
DELETE FROM Pelicula
WHERE Id IN (8, 7, 6, 5, 4, 3);

