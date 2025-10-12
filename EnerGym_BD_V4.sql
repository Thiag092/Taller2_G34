
CREATE DATABASE EnerGym_BD_V4;
GO
USE EnerGym_BD_V4;
GO

-------------------------------------------------------
-- 🧱 TABLAS BASE
-------------------------------------------------------

CREATE TABLE Rol (
    id_rol INT PRIMARY KEY IDENTITY(1,1),
    descripcion NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    id_rol INT FOREIGN KEY REFERENCES Rol(id_rol),
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,  
    email NVARCHAR(100) NOT NULL UNIQUE,
    telefono NVARCHAR(50),
    dni NVARCHAR(20) UNIQUE,
    fecha_nacimiento DATE,
    estado BIT NOT NULL,
    contrasena NVARCHAR(255)
);
GO

CREATE TABLE Membresia (
    id_membresia INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    duracion INT, 
    fecha_creacion DATE DEFAULT GETDATE(),
    costo DECIMAL(10, 2),
    estado BIT NOT NULL
);
GO

CREATE TABLE TipoPlan (
    id_tipoPlan INT PRIMARY KEY IDENTITY(1,1),
    descripcion NVARCHAR(50) NOT NULL -- Principiante / Intermedio / Avanzado
);
GO

CREATE TABLE PlanEntrenamiento (
    id_plan INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    fechaInicio DATE,
    fechaFin DATE,
    cantSeries INT,
    estado BIT NOT NULL,
    id_tipoPlan INT NULL FOREIGN KEY REFERENCES TipoPlan(id_tipoPlan)
);
GO

CREATE TABLE Ejercicio (
    id_ejercicio INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    repeticiones INT,
    tiempo INT
);
GO

CREATE TABLE Plan_Dia (
    id_dia INT PRIMARY KEY IDENTITY(1,1),
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    nombreDia NVARCHAR(50) NOT NULL,
    descripcion NVARCHAR(MAX)
);
GO

CREATE TABLE Plan_Ejercicio (
    id_plan INT NOT NULL FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    id_ejercicio INT NOT NULL FOREIGN KEY REFERENCES Ejercicio(id_ejercicio),
    id_dia INT NOT NULL FOREIGN KEY REFERENCES Plan_Dia(id_dia)
);
GO

-- ✅ Fijamos PK compuesta correcta
ALTER TABLE Plan_Ejercicio
ADD CONSTRAINT PK_Plan_Ejercicio PRIMARY KEY (id_plan, id_dia, id_ejercicio);
GO

CREATE TABLE Usuario_Plan (
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    PRIMARY KEY (id_usuario, id_plan)
);
GO

CREATE TABLE Alumno (
    id_alumno INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario), 
    id_membresia INT FOREIGN KEY REFERENCES Membresia(id_membresia),
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    id_coach INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    foto NVARCHAR(MAX),
    contacto_emergencia NVARCHAR(100),
    sexo NVARCHAR(10) CHECK (sexo IN ('Masculino','Femenino','Otro')),
    observaciones NVARCHAR(MAX),
    estado BIT NOT NULL
);
GO

CREATE TABLE MedioDePago (
    id_medioPago INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    comision DECIMAL(5, 2),
    fechaCreacion DATE DEFAULT GETDATE(),
    estado BIT NOT NULL
);
GO

CREATE TABLE Pago (
    id_pago INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    id_alumno INT FOREIGN KEY REFERENCES Alumno(id_alumno),
    id_medioPago INT FOREIGN KEY REFERENCES MedioDePago(id_medioPago),
    fecha DATE,
    cantidad DECIMAL(10, 2),
    total DECIMAL(10, 2),
    recargo DECIMAL(10, 2)
);
GO

CREATE TABLE PagoDetalle (
    id_pagoDetalle INT PRIMARY KEY IDENTITY(1,1),
    id_pago INT FOREIGN KEY REFERENCES Pago(id_pago),
    id_membresia INT FOREIGN KEY REFERENCES Membresia(id_membresia),
    periodo INT,
    monto DECIMAL(10, 2)
);
GO

CREATE TABLE Horario (
    id_horario INT PRIMARY KEY IDENTITY(1,1),
    id_coach INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    diaSemana NVARCHAR(10),
    horaInicio TIME,
    horaFin TIME,
    estado BIT
);
GO

CREATE TABLE Permiso(
    id_permiso INT PRIMARY KEY IDENTITY(1,1),
    id_rol INT REFERENCES ROL(id_rol),
    nombreMenu NVARCHAR(100) NOT NULL
);
GO

-------------------------------------------------------
-- 🔹 DATOS INICIALES
-------------------------------------------------------

INSERT INTO Rol (descripcion)
VALUES ('Propietario'), ('Administrador'), ('Coach');
GO

INSERT INTO Usuario (id_rol, nombre, apellido, email, telefono, dni, fecha_nacimiento, estado, contrasena)
VALUES
(3,'Martin','Lopez','coach1@gmail.com','341-555-0101','33333333','1990-05-12',1,'coach'),
(1,'Ana','Gomez','propietario@gmail.com','341-555-0202','11111111','1985-11-20',1,'propietario'),
(2,'Sofia','Perez','admin@gmail.com','341-555-0303','22222222','1992-02-02',1,'admin');
GO

-------------------------------------------------------
-- 🏋️ TIPOS DE PLAN
-------------------------------------------------------
INSERT INTO TipoPlan (descripcion)
VALUES ('Principiante'), ('Intermedio'), ('Avanzado');
GO

-------------------------------------------------------
-- 💪 EJERCICIOS BASE
-------------------------------------------------------
INSERT INTO Ejercicio (nombre, repeticiones, tiempo) VALUES
('Sentadillas con peso corporal', 15, 60),
('Plancha abdominal', 1, 45),
('Press de banca', 12, 90),
('Remo con mancuernas', 12, 90),
('Zancadas', 10, 60),
('Curl de bíceps', 12, 60),
('Extensión de tríceps', 12, 60),
('Elevaciones laterales', 15, 60),
('Peso muerto', 10, 120),
('Abdominales bicicleta', 20, 60);
GO

-------------------------------------------------------
-- 🧩 PLANES BASE (3 niveles)
-------------------------------------------------------
INSERT INTO PlanEntrenamiento (nombre, fechaInicio, fechaFin, cantSeries, estado, id_tipoPlan)
VALUES
('Plan Principiante Full Body', NULL, NULL, 3, 1, 1),
('Plan Intermedio Push Pull Legs', NULL, NULL, 4, 1, 2),
('Plan Avanzado 2x6', NULL, NULL, 6, 1, 3);
GO

-------------------------------------------------------
-- 🗓️ DÍAS POR PLAN
-------------------------------------------------------
INSERT INTO Plan_Dia (id_plan, nombreDia, descripcion) VALUES
-- Principiante (3 días)
(1, 'Día 1 - Full Body A', 'Cuerpo completo con foco en técnica'),
(1, 'Día 2 - Full Body B', 'Cuerpo completo con variaciones'),
(1, 'Día 3 - Full Body C', 'Cuerpo completo con foco en core'),
-- Intermedio (4 días)
(2, 'Día 1 - Push', 'Pecho, hombros, tríceps'),
(2, 'Día 2 - Pull', 'Espalda y bíceps'),
(2, 'Día 3 - Legs', 'Piernas y glúteos'),
(2, 'Día 4 - Core', 'Zona media y estabilidad'),
-- Avanzado (6 días)
(3, 'Día 1 - Pecho y Tríceps', NULL),
(3, 'Día 2 - Espalda y Bíceps', NULL),
(3, 'Día 3 - Piernas', NULL),
(3, 'Día 4 - Hombros', NULL),
(3, 'Día 5 - Core', NULL),
(3, 'Día 6 - Brazos', NULL);
GO

-------------------------------------------------------
-- 🧠 AUTO-LIMPIEZA ANTES DE CARGAR EJERCICIOS
-------------------------------------------------------
DELETE FROM Plan_Ejercicio;
GO

-------------------------------------------------------
-- 🔗 RELACIÓN EJERCICIOS ↔ DÍAS ↔ PLANES
-------------------------------------------------------

-- Principiante
INSERT INTO Plan_Ejercicio (id_plan, id_dia, id_ejercicio)
VALUES
(1, 1, 1),(1, 1, 3),(1, 1, 2),
(1, 2, 4),(1, 2, 5),(1, 2, 2),
(1, 3, 1),(1, 3, 9),(1, 3, 10);

-- Intermedio
INSERT INTO Plan_Ejercicio (id_plan, id_dia, id_ejercicio)
VALUES
(2, 4, 2),(2, 4, 10),
(2, 1, 3),(2, 1, 8),(2, 1, 7),
(2, 2, 4),(2, 2, 6),
(2, 3, 5),(2, 3, 9);

-- Avanzado
INSERT INTO Plan_Ejercicio (id_plan, id_dia, id_ejercicio)
VALUES
(3, 7, 3),(3, 7, 7),
(3, 8, 4),(3, 8, 6),
(3, 9, 1),(3, 9, 9),
(3,10, 8),(3,10, 2),
(3,11, 4),(3,11, 3),
(3,12, 6),(3,12,10);
GO
