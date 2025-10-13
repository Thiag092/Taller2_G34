-------------------------------------------------------
-- 🧩 CREACIÓN BASE DE DATOS
-------------------------------------------------------
CREATE DATABASE EnerGym_BD_V8;
GO
USE EnerGym_BD_V8;
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
    descripcion NVARCHAR(50) NOT NULL
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
    nombre NVARCHAR(100) NOT NULL
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
    tiempo INT NOT NULL,
    CONSTRAINT PK_Plan_Ejercicio PRIMARY KEY (id_plan, id_dia, id_ejercicio)
);
GO

CREATE TABLE Usuario_Plan (
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    PRIMARY KEY (id_usuario, id_plan)
);
GO
CREATE TABLE Alumno (
    id_alumno INT PRIMARY KEY IDENTITY(1,1),
    id_membresia INT FOREIGN KEY REFERENCES Membresia(id_membresia),
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    id_coach INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    contacto_emergencia NVARCHAR(100),
    sexo NVARCHAR(10) CHECK (sexo IN ('Masculino','Femenino','Otro')),
    observaciones NVARCHAR(MAX),
    estado BIT NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    dni NVARCHAR(20),
    telefono NVARCHAR(50)
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

CREATE TABLE Permiso (
    id_permiso INT PRIMARY KEY IDENTITY(1,1),
    id_rol INT REFERENCES Rol(id_rol),
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

INSERT INTO TipoPlan (descripcion)
VALUES ('Principiante'), ('Intermedio'), ('Avanzado');
GO

INSERT INTO Ejercicio (nombre) VALUES
('Sentadillas con peso corporal'),
('Plancha abdominal'),
('Press de banca'),
('Remo con mancuernas'),
('Zancadas'),
('Curl de bíceps'),
('Extensión de tríceps'),
('Elevaciones laterales'),
('Peso muerto'),
('Abdominales bicicleta');
GO

INSERT INTO PlanEntrenamiento (nombre, fechaInicio, fechaFin, estado, id_tipoPlan)
VALUES
('Plan Principiante Full Body', NULL, NULL, 1, 1),
('Plan Intermedio Push Pull Legs', NULL, NULL, 1, 2),
('Plan Avanzado 2x6', NULL, NULL, 1, 3);
GO

-------------------------------------------------------
-- 🗓️ DÍAS POR PLAN (CON IDS COHERENTES)
-------------------------------------------------------
INSERT INTO Plan_Dia (id_plan, nombreDia, descripcion) VALUES
-- Principiante (1–3)
(1, 'Lunes - Full Body A', 'Cuerpo completo con foco en técnica'),
(1, 'Miércoles - Full Body B', 'Cuerpo completo con variaciones'),
(1, 'Viernes - Full Body C', 'Cuerpo completo con foco en core'),

-- Intermedio (4–7)
(2, 'Lunes - Push', 'Pecho, hombros, tríceps'),
(2, 'Martes - Pull', 'Espalda y bíceps'),
(2, 'Jueves - Legs', 'Piernas y glúteos'),
(2, 'Viernes - Core', 'Zona media y estabilidad'),

-- Avanzado (8–13)
(3, 'Lunes - Pecho/Tríceps', NULL),
(3, 'Martes - Espalda/Bíceps', NULL),
(3, 'Miércoles - Piernas', NULL),
(3, 'Jueves - Hombros', NULL),
(3, 'Viernes - Core', NULL),
(3, 'Sábado - Brazos', NULL);
GO

-------------------------------------------------------
-- 💪 PLAN PRINCIPIANTE
-------------------------------------------------------
INSERT INTO Plan_Ejercicio (id_plan, id_ejercicio, id_dia, cant_series, repeticiones, tiempo)
VALUES
-- Lunes (1)
(1,1,1,3,15,60),(1,3,1,3,12,60),(1,4,1,3,12,60),(1,6,1,2,15,45),(1,7,1,2,15,45),(1,10,1,3,20,60),
-- Miércoles (2)
(1,5,2,3,12,60),(1,8,2,3,15,45),(1,3,2,3,12,60),(1,4,2,3,12,60),(1,1,2,3,15,60),(1,10,2,3,20,60),
-- Viernes (3)
(1,9,3,3,10,75),(1,2,3,3,1,60),(1,6,3,3,15,45),(1,7,3,3,15,45),(1,4,3,3,12,60),(1,10,3,3,20,60);
GO

-------------------------------------------------------
-- 💪 PLAN INTERMEDIO
-------------------------------------------------------
INSERT INTO Plan_Ejercicio (id_plan, id_ejercicio, id_dia, cant_series, repeticiones, tiempo)
VALUES
-- Lunes - Push (4)
(2,3,4,4,10,90),(2,8,4,4,12,60),(2,7,4,4,12,60),(2,5,4,3,12,60),(2,1,4,3,15,60),(2,10,4,3,20,60),
-- Martes - Pull (5)
(2,4,5,4,10,90),(2,9,5,4,8,90),(2,6,5,4,12,60),(2,8,5,3,12,60),(2,1,5,3,15,60),(2,10,5,3,20,60),
-- Jueves - Legs (6)
(2,1,6,4,15,60),(2,5,6,4,12,60),(2,9,6,4,10,90),(2,3,6,3,12,60),(2,4,6,3,12,60),(2,2,6,3,1,60),
-- Viernes - Core (7)
(2,2,7,3,1,60),(2,10,7,3,20,60),(2,5,7,3,15,60),(2,1,7,3,15,60),(2,6,7,3,12,60),(2,8,7,3,12,60);
GO

-------------------------------------------------------
-- 💪 PLAN AVANZADO
-------------------------------------------------------
INSERT INTO Plan_Ejercicio (id_plan, id_ejercicio, id_dia, cant_series, repeticiones, tiempo)
VALUES
-- Lunes - Pecho/Tríceps (8)
(3,3,8,5,10,90),(3,7,8,5,12,60),(3,8,8,5,12,60),(3,4,8,4,12,60),(3,6,8,4,12,60),(3,10,8,4,20,60),
-- Martes - Espalda/Bíceps (9)
(3,4,9,5,12,90),(3,9,9,5,10,90),(3,6,9,4,12,60),(3,8,9,4,12,60),(3,1,9,4,15,60),(3,10,9,4,20,60),
-- Miércoles - Piernas (10)
(3,1,10,5,15,60),(3,5,10,5,12,60),(3,9,10,5,10,90),(3,3,10,4,10,60),(3,4,10,4,12,60),(3,10,10,4,20,60),
-- Jueves - Hombros (11)
(3,8,11,5,15,60),(3,7,11,4,12,60),(3,3,11,4,12,60),(3,6,11,4,12,60),(3,4,11,4,12,60),(3,10,11,4,20,60),
-- Viernes - Core (12)
(3,2,12,4,1,90),(3,10,12,4,25,60),(3,1,12,4,15,60),(3,5,12,4,12,60),(3,9,12,4,10,90),(3,6,12,4,12,60),
-- Sábado - Brazos (13)
(3,6,13,5,15,60),(3,7,13,5,15,60),(3,8,13,4,12,60),(3,3,13,4,10,60),(3,4,13,4,12,60),(3,10,13,4,25,60);
GO


-------------------------------------------------------
--  MEMBRESÍAS DISPONIBLES (VALORES ACTUALIZADOS)
-------------------------------------------------------

INSERT INTO Membresia (nombre, duracion, costo, estado)
VALUES
('Diaria', 1, 2000.00, 1),       -- 1 día
('Semanal', 7, 10000.00, 1),     -- 7 días
('Mensual', 30, 30000.00, 1),    -- 30 días
('Anual', 365, 300000.00, 1);    -- 365 días
GO

-------------------------------------------------------
--  2USUARIOS COACH
-------------------------------------------------------

INSERT INTO Usuario (id_rol, nombre, apellido, email, telefono, dni, fecha_nacimiento, estado, contrasena)
VALUES
(3, 'Lucas', 'Ramirez', 'lucas.ramirez@energym.com', '341-555-0404', '44444444', '1991-07-18', 1, 'coach123'),
(3, 'Camila', 'Fernandez', 'camila.fernandez@energym.com', '341-555-0505', '55555555', '1993-09-05', 1, 'coach123');
GO

--INSERT DE ALUMNO DE PRUEBA--
INSERT INTO Alumno (
    id_membresia,
    id_plan,
    id_coach,
    contacto_emergencia,
    sexo,
    observaciones,
    estado,
    nombre,
    apellido,
    dni,
    telefono
)
VALUES (
    3,  -- Membresía mensual
    1,  -- Plan Principiante Full Body
    4,  -- Coach asignado (ya existente)
    'Carlos Gómez - 3794 442210',  -- Contacto de emergencia
    'Masculino',
    'Alumno nuevo, objetivo: mejorar fuerza general. Evaluar en 1 mes.',
    1,  -- Activo
    'Juan',
    'Pérez',
    '45123888',
    '+54 3794 512300'
);
GO

INSERT INTO Alumno (
    id_membresia,
    id_plan,
    id_coach,
    contacto_emergencia,
    sexo,
    observaciones,
    estado,
    nombre,
    apellido,
    dni,
    telefono
)
VALUES (
    4,  -- Membresía anual
    2,  -- Plan Intermedio Push Pull Legs
    5,  -- Coach asignado (ya existente)
    'Laura Ramírez - 3794 440512',  -- Contacto de emergencia
    'Femenino',
    'Alumna intermedia con experiencia previa. Objetivo: tonificar y mejorar resistencia.',
    1,  -- Activa
    'María',
    'Fernández',
    '40256987',
    '+54 3794 776890'
);
GO

