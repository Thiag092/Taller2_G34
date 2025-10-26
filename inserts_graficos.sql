USE EnerGym_BD_V9;
GO

DECLARE @id_alumno INT, @monto DECIMAL(10,2), @cantidad INT, @total DECIMAL(10,2);

---------------------------------------------------------------
-- 🔹 ENERO
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (3, 1, 4, 'Lucia Ferreyra - 3794 555666', 'Femenino', 'Alta enero', 1, 'Juan', 'Benitez', '50111222', '+54 3794 600001', '1999-01-11', 'juan.benitez@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 3;
SET @cantidad = 1; SET @total = @monto;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 1, '2025-01-10', @cantidad, @total, 0);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 3, 1, @total);

---------------------------------------------------------------
-- 🔹 FEBRERO
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (2, 2, 5, 'Mario Diaz - 3794 777888', 'Masculino', 'Alta febrero', 1, 'Sergio', 'Acosta', '50111333', '+54 3794 600002', '1996-03-05', 'sergio.acosta@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 2;
SET @cantidad = 2; SET @total = @monto * @cantidad;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 3, '2025-02-15', @cantidad, @total, @total*0.08);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 2, 1, @total);

---------------------------------------------------------------
-- 🔹 MARZO
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (4, 3, 4, 'Carlos Ruiz - 3794 887766', 'Masculino', 'Avanzado, rutina anual', 1, 'Nicolás', 'Ruiz', '39111999', '+54 3794 345678', '1995-06-12', 'nico.ruiz@gmail.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 4;
SET @cantidad = 1; SET @total = @monto;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 2, '2025-03-20', @cantidad, @total, @total*0.05);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 4, 1, @total);

---------------------------------------------------------------
-- 🔹 ABRIL
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (3, 2, 4, 'Sabrina Soto - 3794 111222', 'Femenino', 'Alta abril', 1, 'Rocio', 'Soto', '50111666', '+54 3794 600005', '1997-02-21', 'rocio.soto@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 3;
SET @cantidad = 1; SET @total = @monto;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 1, '2025-04-10', @cantidad, @total, 0);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 3, 1, @total);

---------------------------------------------------------------
-- 🔹 MAYO
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (1, 1, 5, 'Laura Torres - 3794 667788', 'Femenino', 'Alta mayo', 1, 'Laura', 'Torres', '36123456', '+54 3794 456789', '1993-07-03', 'laura.torres@gmail.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 1;
SET @cantidad = 10; SET @total = @monto * @cantidad;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 1, '2025-05-15', @cantidad, @total, 0);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 1, 1, @total);

---------------------------------------------------------------
-- 🔹 JUNIO
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (2, 2, 5, 'Miguel Rojas - 3794 404040', 'Masculino', 'Alta junio', 1, 'Miguel', 'Rojas', '50112111', '+54 3794 600010', '1994-07-07', 'miguel.rojas@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 2;
SET @cantidad = 4; SET @total = @monto * @cantidad;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 3, '2025-06-12', @cantidad, @total, @total*0.08);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 2, 1, @total);

---------------------------------------------------------------
-- 🔹 JULIO
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (3, 3, 4, 'Graciela Alvarenga - 3794 101010', 'Femenino', 'Alta julio', 1, 'Paula', 'Maidana', '50111999', '+54 3794 600008', '1991-08-08', 'paula.maidana@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 3;
SET @cantidad = 1; SET @total = @monto;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 2, '2025-07-14', @cantidad, @total, @total*0.05);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 3, 1, @total);

---------------------------------------------------------------
-- 🔹 AGOSTO
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (3, 2, 4, 'Brenda Perez - 3794 777999', 'Femenino', 'Alta agosto', 1, 'Brenda', 'Perez', '50112444', '+54 3794 600013', '1998-02-14', 'brenda.perez@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 3;
SET @cantidad = 1; SET @total = @monto;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 1, '2025-08-09', @cantidad, @total, 0);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 3, 1, @total);

---------------------------------------------------------------
-- 🔹 SEPTIEMBRE
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (2, 1, 5, 'Luciano Duarte - 3794 555777', 'Masculino', 'Alta septiembre', 1, 'Luciano', 'Duarte', '50112555', '+54 3794 600014', '1996-11-20', 'luciano.duarte@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 2;
SET @cantidad = 3; SET @total = @monto * @cantidad;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 3, '2025-09-15', @cantidad, @total, @total*0.08);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 2, 1, @total);

---------------------------------------------------------------
-- 🔹 OCTUBRE
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (3, 3, 5, 'Sonia Ojeda - 3794 303030', 'Femenino', 'Alta octubre', 1, 'Sonia', 'Ojeda', '50112666', '+54 3794 600015', '1998-12-01', 'sonia.ojeda@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 3;
SET @cantidad = 1; SET @total = @monto;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 2, '2025-10-10', @cantidad, @total, @total*0.05);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 3, 1, @total);

---------------------------------------------------------------
-- 🔹 NOVIEMBRE
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (1, 1, 4, 'Raul Encina - 3794 606060', 'Masculino', 'Alta noviembre', 1, 'Raul', 'Encina', '50112777', '+54 3794 600016', '2000-03-03', 'raul.encina@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 1;
SET @cantidad = 5; SET @total = @monto * @cantidad;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 1, '2025-11-11', @cantidad, @total, 0);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 1, 1, @total);

---------------------------------------------------------------
-- 🔹 DICIEMBRE
---------------------------------------------------------------
INSERT INTO Alumno (id_membresia, id_plan, id_coach, contacto_emergencia, sexo, observaciones, estado, nombre, apellido, dni, telefono, fecha_nacimiento, email)
VALUES (3, 2, 5, 'Patricia Soto - 3794 505050', 'Femenino', 'Alta diciembre', 1, 'Patricia', 'Soto', '50112888', '+54 3794 600017', '1992-10-12', 'patricia.soto@email.com');
SET @id_alumno = SCOPE_IDENTITY();

SELECT @monto = costo FROM Membresia WHERE id_membresia = 3;
SET @cantidad = 1; SET @total = @monto;
INSERT INTO Pago (id_usuario, id_alumno, id_medioPago, fecha, cantidad, total, recargo)
VALUES (2, @id_alumno, 3, '2025-12-09', @cantidad, @total, @total*0.08);
INSERT INTO PagoDetalle (id_pago, id_membresia, periodo, monto)
VALUES (SCOPE_IDENTITY(), 3, 1, @total);
GO
