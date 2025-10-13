
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
    estado BIT NOT NULL,
    id_tipoPlan INT NULL FOREIGN KEY REFERENCES TipoPlan(id_tipoPlan)
);
GO

CREATE TABLE Ejercicio (
    id_ejercicio INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
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
    id_dia INT NOT NULL FOREIGN KEY REFERENCES Plan_Dia(id_dia),
    cant_series INT NOT NULL,
    repeticiones INT NOT NULL,
    tiempo INT NOT NULL
);
GO 

-- Fijamos PK compuesta correcta
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
INSERT INTO Ejercicio (nombre) VALUES
('Sentadillas con peso corporal'),
('Plancha abdominal'),
('Press de banca'),
('Remo con mancuernas'),
('Zancadas'),
('Curl de bíceps', 12, 60),
('Extensión de tríceps', 12, 60),
('Elevaciones laterales', 15, 60),
('Peso muerto', 10, 120),
('Abdominales bicicleta', 20, 60);
GO

-------------------------------------------------------
-- 🧩 PLANES BASE (3 niveles)
-------------------------------------------------------
INSERT INTO PlanEntrenamiento (nombre, fechaInicio, fechaFin, estado, id_tipoPlan)
VALUES
('Plan Principiante Full Body', NULL, NULL, 1, 1),
('Plan Intermedio Push Pull Legs', NULL, NULL, 1, 2),
('Plan Avanzado 2x6', NULL, NULL, 1, 3);
GO

-------------------------------------------------------
-------------------------------------------------------
-- 🗓️ DÍAS POR PLAN (CORREGIDO - DÍAS SEMANALES)
-------------------------------------------------------
DELETE FROM Plan_Dia;
GO

INSERT INTO Plan_Dia (id_plan, nombreDia, descripcion) VALUES
-- Principiante (Lunes, Miércoles, Viernes)
(1, 'Lunes - Full Body A', 'Cuerpo completo con foco en técnica'),
(1, 'Miércoles - Full Body B', 'Cuerpo completo con variaciones'),
(1, 'Viernes - Full Body C', 'Cuerpo completo con foco en core'),

-- Intermedio (Lunes, Martes, Jueves, Viernes)
(2, 'Lunes - Push', 'Pecho, hombros, tríceps'),
(2, 'Martes - Pull', 'Espalda y bíceps'),
(2, 'Jueves - Legs', 'Piernas y glúteos'),
(2, 'Viernes - Core', 'Zona media y estabilidad'),

-- Avanzado (Lunes a Sábado)
(3, 'Lunes - Pecho/Tríceps', NULL),
(3, 'Martes - Espalda/Bíceps', NULL),
(3, 'Miércoles - Piernas', NULL),
(3, 'Jueves - Hombros', NULL),
(3, 'Viernes - Core', NULL),
(3, 'Sábado - Brazos', NULL);
GO

-------------------------------------------------------
-- 🔗 RELACIÓN EJERCICIOS ↔ DÍAS ↔ PLANES (CORREGIDO)
-------------------------------------------------------

DELETE FROM Plan_Ejercicio;
GO

-- Principiante (Lunes=1, Miércoles=3, Viernes=5)
INSERT INTO Plan_Ejercicio (id_plan, id_dia, id_ejercicio, cant_series, repeticiones, tiempo)
VALUES
-- Lunes (id_dia 1)
(1, 1, 1, 3, 15, NULL),    -- Sentadillas
(1, 1, 3, 4, 12, NULL),    -- Press banca
(1, 1, 2, 3, NULL, 45),    -- Plancha
-- Miércoles (id_dia 3)
(1, 3, 4, 4, 12, NULL),    -- Remo
(1, 3, 5, 4, 10, NULL),    -- Zancadas
(1, 3, 6, 3, 12, NULL),    -- Bíceps
-- Viernes (id_dia 5)
(1, 5, 9, 4, 10, NULL),    -- Peso muerto
(1, 5, 10, 4, 20, NULL),   -- Abdominales
(1, 5, 7, 3, 12, NULL);    -- Tríceps
GO

-- Intermedio (Lunes=1, Martes=2, Jueves=4, Viernes=5)
INSERT INTO Plan_Ejercicio (id_plan, id_dia, id_ejercicio, cant_series, repeticiones, tiempo)
VALUES
-- Lunes (id_dia 1 - Push)
(2, 1, 3, 4, 10, NULL),    -- Press banca
(2, 1, 8, 3, 12, NULL),    -- Elevaciones
(2, 1, 7, 3, 10, NULL),    -- Tríceps
-- Martes (id_dia 2 - Pull)
(2, 2, 4, 4, 10, NULL),    -- Remo
(2, 2, 6, 3, 12, NULL),    -- Bíceps
(2, 2, 2, 3, NULL, 60),    -- Plancha
-- Jueves (id_dia 4 - Legs)
(2, 4, 1, 4, 12, NULL),    -- Sentadillas
(2, 4, 5, 4, 10, NULL),    -- Zancadas
(2, 4, 9, 4, 8, NULL),     -- Peso muerto
-- Viernes (id_dia 5 - Core)
(2, 5, 10, 4, 15, NULL),   -- Abdominales
(2, 5, 2, 3, NULL, 90, NULL); -- Plancha avanzada
GO

-- Avanzado (Lunes=1, Martes=2, Miércoles=3, Jueves=4, Viernes=5, Sábado=6)
INSERT INTO Plan_Ejercicio (id_plan, id_dia, id_ejercicio, cant_series, repeticiones, tiempo)
VALUES
-- Lunes (id_dia 1 - Pecho/Tríceps)
(3, 1, 3, 4, 8, NULL),     -- Press banca
(3, 1, 7, 3, 10, NULL),    -- Tríceps
-- Martes (id_dia 2 - Espalda/Bíceps)
(3, 2, 4, 4, 8, NULL),     -- Remo
(3, 2, 6, 3, 10, NULL),    -- Bíceps
-- Miércoles (id_dia 3 - Piernas)
(3, 3, 1, 4, 10, NULL),    -- Sentadillas
(3, 3, 9, 4, 6, NULL),     -- Peso muerto
-- Jueves (id_dia 4 - Hombros)
(3, 4, 8, 4, 12, NULL),    -- Elevaciones
(3, 4, 2, 3, NULL, 60),    -- Plancha
-- Viernes (id_dia 5 - Core)
(3, 5, 10, 4, 20, NULL),   -- Abdominales
(3, 5, 5, 3, 15, NULL),    -- Zancadas
-- Sábado (id_dia 6 - Brazos)
(3, 6, 6, 4, 12, NULL),    -- Bíceps
(3, 6, 7, 4, 12, NULL);    -- Tríceps
GO