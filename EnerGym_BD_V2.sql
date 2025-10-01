-- ==========================================================
-- Script modificado de EnerGym (versión mejorada)
-- Cambios aplicados: 
-- 1) La base de datos ahora se llama EnerGym_BD_V2.
-- 2) Se eliminan datos redundantes en Alumno (ya existen en Usuario).
-- 3) Se agrega relación clara entre Alumno y Coach.
-- 4) Horario apunta a Coach en lugar de Usuario genérico.
-- ==========================================================

CREATE DATABASE EnerGym_BD_V2;
GO
USE EnerGym_BD_V2;
GO

/* ============================================
   TABLA: Rol
   ============================================ */
CREATE TABLE Rol (
    id_rol INT PRIMARY KEY IDENTITY(1,1),
    descripcion NVARCHAR(100) NOT NULL
);
GO

/* ============================================
   TABLA: Usuario
   ============================================ */
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
    contraseña NVARCHAR(255)
);
GO

/* ============================================
   TABLA: Membresia
   ============================================ */
CREATE TABLE Membresia (
    id_membresia INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    duracion INT, 
    fecha_creacion DATE DEFAULT GETDATE(),
    costo DECIMAL(10, 2),
    estado BIT NOT NULL
);
GO

/* ============================================
   TABLA: PlanEntrenamiento
   ============================================ */
CREATE TABLE PlanEntrenamiento (
    id_plan INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    fechaInicio DATE,
    fechaFin DATE,
    cantSeries INT,
    estado BIT NOT NULL
);
GO

/* ============================================
   TABLA: Ejercicio
   ============================================ */
CREATE TABLE Ejercicio (
    id_ejercicio INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    repeticiones INT,
    tiempo INT
);
GO

/* ============================================
   TABLA: Plan_Ejercicio (N:M)
   ============================================ */
CREATE TABLE Plan_Ejercicio (
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    id_ejercicio INT FOREIGN KEY REFERENCES Ejercicio(id_ejercicio),
    PRIMARY KEY (id_plan, id_ejercicio)
);
GO

/* ============================================
   TABLA: Usuario_Plan (N:M - Coach ↔ Plan)
   ============================================ */
CREATE TABLE Usuario_Plan (
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario),
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),
    PRIMARY KEY (id_usuario, id_plan)
);
GO

/* ============================================
   TABLA: Alumno
   ============================================ */
CREATE TABLE Alumno (
    id_alumno INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario), 
    id_membresia INT FOREIGN KEY REFERENCES Membresia(id_membresia),
    id_plan INT FOREIGN KEY REFERENCES PlanEntrenamiento(id_plan),

    -- Relación directa Alumno ↔ Coach
    id_coach INT FOREIGN KEY REFERENCES Usuario(id_usuario), -- debe ser un rol=3 (Coach)

    foto NVARCHAR(MAX),
    contacto_emergencia NVARCHAR(100),
    sexo NVARCHAR(10) CHECK (sexo IN ('Masculino','Femenino','Otro')),
    observaciones NVARCHAR(MAX),
    estado BIT NOT NULL
);
GO

/* ============================================
   TABLA: MedioDePago
   ============================================ */
CREATE TABLE MedioDePago (
    id_medioPago INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    comision DECIMAL(5, 2),
    fechaCreacion DATE DEFAULT GETDATE(),
    estado BIT NOT NULL
);
GO

/* ============================================
   TABLA: Pago y PagoDetalle
   ============================================ */
CREATE TABLE Pago (
    id_pago INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT FOREIGN KEY REFERENCES Usuario(id_usuario), -- admin que registra pago
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

/* ============================================
   TABLA: Horario (aplicable a coaches)
   ============================================ */
CREATE TABLE Horario (
    id_horario INT PRIMARY KEY IDENTITY(1,1),
    id_coach INT FOREIGN KEY REFERENCES Usuario(id_usuario), -- coach asignado
    diaSemana NVARCHAR(10),
    horaInicio TIME,
    horaFin TIME,
    estado BIT
);
GO

/* ============================================
   TABLA: Permiso
   ============================================ */
CREATE TABLE Permiso(
    id_permiso INT PRIMARY KEY IDENTITY(1,1),
    id_rol INT REFERENCES ROL(id_rol),
    nombreMenu NVARCHAR(100) NOT NULL
);
GO

-- ==========================================================
-- NOTAS DE CAMBIO IMPORTANTES:
-- 1) Base de datos ahora se llama EnerGym_BD_V2.
-- 2) Eliminada redundancia en Alumno (datos personales solo en Usuario).
-- 3) Agregado campo id_coach en Alumno para relación clara con entrenador.
-- 4) Horario apunta directamente a coaches (id_coach).
-- ==========================================================
