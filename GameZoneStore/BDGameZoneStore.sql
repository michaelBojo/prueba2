CREATE DATABASE GameZoneStoreBD;

USE GameZoneStoreBD;

CREATE TABLE Usuarios (
ID INT PRIMARY KEY IDENTITY,
Usuario NVARCHAR(150),
Contraseña NVARCHAR(150)
)

CREATE TABLE Productos(
ID INT PRIMARY KEY IDENTITY,
Nombre NVARCHAR (150),
Precio DECIMAL (10,2),
Categoria NVARCHAR (100),
Imagen NVARCHAR (100)
)

INSERT INTO Usuarios (Usuario, Contraseña) VALUES ('admin', '1234');

INSERT INTO Productos (Nombre, Precio, Categoria, Imagen) VALUES
('GTA Vl', 79.99, 'PS5 y XBOX', '20266181662926_1.jpg'),
('ELDEN RING', 49.99, 'Todos', '562e311c3db929a33e6919832120b6c7.jpg' ),
('MARIO KART', 79.99, 'SWITCH', 'images.jpg'),
('WUKONG', 69.99, 'Todos', 'images (1).jpg'),
('HALO', 39.99, 'XBOX y PC', 'images (3).jpg'),
('FC 27', 69.99, 'Todos', 'images (2).jpg');

SELECT * FROM Usuarios;
SELECT * FROM Productos;


