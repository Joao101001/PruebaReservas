create database pruebaReservas;

use pruebaReservas;

create table persona (ID int NOT NULL IDENTITY(1,1) , Nombre varchar(50), FechaDeNacimiento date, PRIMARY KEY (ID));



select * from persona;



insert into persona values ('Aaron Navarro', '10/10/2001');


