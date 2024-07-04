/*Creación de la base*/
CREATE DATABASE MiniCoreTasks

/*Uso de la base*/
USE MiniCoreTasks
GO

/*Creación tabla Empleados*/
CREATE TABLE Empleados(
	id_Empleado INT IDENTITY (1,1) NOT NULL, 
	Nombre_Empleado VARCHAR(50) NOT NULL, 
	Apellido_Empleado VARCHAR(50) NOT NULL, 

	CONSTRAINT PK_Empleado PRIMARY KEY(id_Empleado),
)

/*Creación tabla Proyectos*/
CREATE TABLE Proyectos(
	id_Proyecto INT IDENTITY(1,1) NOT NULL, 
	Nombre_Proyecto VARCHAR(100) NOT NULL,

	CONSTRAINT PK_Proyecto PRIMARY KEY(id_Proyecto)
)

/*Creación tabla Tareas*/
CREATE TABLE Tareas(
	id_Tarea INT IDENTITY(1,1) NOT NULL, 
	id_EmpleadoV INT NOT NULL, 
	id_ProyectoV INT NOT NULL, 
	Descripcion_Tarea VARCHAR(100) NOT NULL, 
	Fecha_Inicio_Tarea DATE NOT NULL,
	Tiempo_Estimado_Tarea INT NOT NULL, 
	Estado_Tarea VARCHAR(50) NOT NULL, 
	
	CONSTRAINT PK_Tarea PRIMARY KEY (id_Tarea),
	CONSTRAINT FK_TareaEmpleado FOREIGN KEY (id_EmpleadoV) REFERENCES Empleados (id_Empleado),
	CONSTRAINT FK_TareasProyecto FOREIGN KEY (id_ProyectoV) REFERENCES Proyectos (id_Proyecto)
)

/*Insertar valores en la tabla Empleados*/
INSERT INTO Empleados
VALUES ('Palotes', 'Perico')
INSERT INTO Empleados
VALUES ('Baca', 'Zoila Ostia')
INSERT INTO Empleados
VALUES ('Cabeza', 'De Vaca')

/*Insertar valores en la tabla Proyectos*/
INSERT INTO Proyectos
VALUES ('Udla Website')
INSERT INTO Proyectos
VALUES ('Supermaxi App')
INSERT INTO Proyectos
VALUES ('Cigarra Pedidos')
INSERT INTO Proyectos
VALUES ('Whatever')

/*Insertar valores en la tabla Tareas*/
INSERT INTO Tareas
VALUES(1, 2, 'Fun Spec App', '2024-1-10', 15, 'In progress')
INSERT INTO Tareas
VALUES(2, 1, 'Homepage', '2024-1-10', 2, 'In progress')
INSERT INTO Tareas
VALUES(2, 1, 'Homepage1', '2024-1-10', 3, 'In progress')
INSERT INTO Tareas
VALUES(3, 3, 'Cobranzas', '2023-12-27', 7, 'Done')
INSERT INTO Tareas
VALUES(2, 2, 'Diseño Splash Screen', '2024-11-13', 1, 'In progress')
INSERT INTO Tareas
VALUES(1, 1, 'Header', '2024-01-12', 1, 'In progress')
INSERT INTO Tareas
VALUES(3, 4, 'Login Pedidos', '2024-12-19', 1, 'Done')

/*Select para probar tabla Empleados*/
SELECT * FROM Empleados
/*Select para probar tabla Proyectos*/
SELECT * FROM Proyectos
/*Select para probar tabla Tareas*/
SELECT * FROM Tareas

