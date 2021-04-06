create database Taller_estudiantes charset utf8mb4;

use Taller_estudiantes;

create table Estudiantes (
codigo int unsigned primary key,
nombre varchar(45),
correo varchar(30),
nota1 double,
nota2 double,
nota3 double
);

insert into estudiantes (codigo, nombre ,correo , nota1, nota2, nota3) values 
(1010, 'julian pedroza', 'jpedroza@misena.edu.co', 3.4 , 4.5, 2.2 ),
(1011, 'nairoby rojas', 'nrojas@misena.edu.co', 4.4 , 4.6, 1.2 ),
(1012, 'carkis roddriguez', 'crodriguez@misena.edu.co', 4.4 , 3.2, 3.6 ),
(1013, 'erika tobon', 'etobon@misena.edu.co', 4.4 , 4.7, 4.2 )

