-- create database lab_mundo charset utf8mb4;

use lab_mundo;

create table visitante (
codigo int primary key,
nombre varchar(45),
correo varchar(30),
rol varchar(30)
);

insert into visitante(codigo, nombre ,correo, rol) values 
(1010, 'Roger Penrose', 'rogerpe@misena.edu.co', 'nacional'),
(1011, 'Andrea Ghez', 'andreagh@misena.edu.co', 'extranjero'),
(1012, 'Jennifer Doudna', 'jenniferdo@misena.edu.co', 'extranjero'),
(1013, 'Robert Wilson', 'robertwil@misena.edu.co', 'nacional'),
(1014, 'Kip Thorne', 'kiptho@misena.edu.co', 'nacional'),
(1015, 'Bob Dylan', 'bobdy@misena.edu.co', 'nacional'),
(1016, 'Aziz Sancar', 'azizsan@misena.edu.co', 'extranjero'),
(1017, 'Svetlana Alexievich', 'svetlanaal@misena.edu.co', 'extranjero'),
(1018, 'Angus Deaton', 'angusde@misena.edu.co', 'nacional'),
(1019, 'Eric Betzig', 'ericbet@misena.edu.co', 'nacional'),
(1020, 'Malala Yousafzai', 'malalayou@misena.edu.co', 'extranjero');


create table empleado (
id int primary key,
nombre varchar(50),
usuario varchar(25),
contraseña varchar(20),
rol varchar(20)
);


insert into empleado(id, nombre, usuario, contraseña, rol) values
(1001, 'Santiago Ramón y Cajal', 'santi', 'cajal', 'cientifico'),
(1002, 'Camillo Golgi', 'cami', 'golgii', 'cientifico'),
(1003, 'Marie Curie', 'marie', 'cuurie', 'administrador'),
(1004, 'Alfred Werner', 'alfred', 'wwwner', 'asistente'),
(1005, 'William Bragg', 'bragg', 'william', 'asistente');


create table roles (
id int auto_increment primary key,
rol varchar(20),
descripcion varchar(100)
);


insert into roles(rol, descripcion) values
('cientifico', 'Encargado de experimentos'),
('administrador', 'Supervisor del laboratorio'),
('asistente', 'Encargado de la ayuda en el laboratorio');








