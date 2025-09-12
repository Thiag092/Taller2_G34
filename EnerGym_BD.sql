-- Crear base de datos
CREATE DATABASE EnerGym;
GO

-- Usar la base de datos recién creada
USE EnerGym;
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
    id_rol INT NOT NULL,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL UNIQUE,
    telefono NVARCHAR(50),
    dni NVARCHAR(20) UNIQUE,
    fecha_nacimiento DATE,
    estado BIT NOT NULL,
    contrasena NVARCHAR(255),

    CONSTRAINT FK_Usuario_Rol FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
);
GO

/* ============================================
   TABLA: Membresia
   ============================================ */
CREATE TABLE Membresia (
    id_membresia INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    duracion INT, -- en días o meses, depende de tu lógica
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
    descripcion NVARCHAR(MAX),
    fecha_creacion DATE DEFAULT GETDATE(),
    estado BIT NOT NULL
);
GO

/* ============================================
   TABLA: Ejercicio
   ============================================ */
CREATE TABLE Ejercicio (
    id_ejercicio INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(MAX),
    musculo_objetivo NVARCHAR(100)
);
GO

/* ============================================
   TABLA: Plan_Ejercicio (relación N:M)
   ============================================ */
CREATE TABLE Plan_Ejercicio (
    id_plan INT NOT NULL,
    id_ejercicio INT NOT NULL,
    PRIMARY KEY (id_plan, id_ejercicio),

    CONSTRAINT FK_PlanEjercicio_Plan FOREIGN KEY (id_plan) REFERENCES PlanEntrenamiento(id_plan),
    CONSTRAINT FK_PlanEjercicio_Ejercicio FOREIGN KEY (id_ejercicio) REFERENCES Ejercicio(id_ejercicio)
);
GO

/* ============================================
   TABLA: Alumno
   ============================================ */
CREATE TABLE Alumno (
    id_alumno INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NOT NULL,
    id_membresia INT,
    id_plan INT,
    foto NVARCHAR(MAX),
    contacto_emergencia NVARCHAR(100),
    sexo NVARCHAR(10) CHECK (sexo IN ('Masculino','Femenino','Otro')),
    observaciones NVARCHAR(MAX),
    estado BIT NOT NULL,

    CONSTRAINT FK_Alumno_Usuario FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_Alumno_Membresia FOREIGN KEY (id_membresia) REFERENCES Membresia(id_membresia),
    CONSTRAINT FK_Alumno_Plan FOREIGN KEY (id_plan) REFERENCES PlanEntrenamiento(id_plan)
);
GO

/* ============================================
   TABLA: Usuario_Plan (relación N:M)
   ============================================ */
CREATE TABLE Usuario_Plan (
    id_usuario INT NOT NULL,
    id_plan INT NOT NULL,
    PRIMARY KEY (id_usuario, id_plan),

    CONSTRAINT FK_UsuarioPlan_Usuario FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    CONSTRAINT FK_UsuarioPlan_Plan FOREIGN KEY (id_plan) REFERENCES PlanEntrenamiento(id_plan)
);
GO


/*Insetamos los roles*/
INSERT INTO Rol (descripcion)
VALUES ('Propietario'), ('Administrador'), ('Coach');

/*Controlamos que se agregaron*/
SELECT * FROM rol

/*Ahora insertamos un usuario de cada tipo*/

INSERT INTO Usuario (id_rol, nombre, apellido, email, telefono, dni, fecha_nacimiento, estado, contrasena)
VALUES
  (3,'Martin', 'Lopez', 'coach1@gmail.com', '341-555-0101', '33333333', '1990-05-12', 1, 'coach');
  GO
  INSERT INTO Usuario (id_rol, nombre, apellido, email, telefono, dni, fecha_nacimiento, estado, contrasena)
VALUES
  (1,'Ana', 'Gomez', 'propietario@gmail.com', '341-555-0202', '11111111', '1985-11-20', 1, 'propietario');
  GO
  INSERT INTO Usuario (id_rol, nombre, apellido, email, telefono, dni, fecha_nacimiento, estado, contrasena)
VALUES
  (2,'Sofia', 'Perez', 'admin@gmail.com', '341-555-0303', '22222222', '1992-02-02', 1, 'admin');
GO

/*Controlamos que se hayan insertado los nuevos usuarios*/
select*from Usuario;