CREATE DATABASE BreakingGymWeb;
GO

USE BreakingGymWeb;
GO

-- TABLAS --------------------------------------------------

-- ROL
CREATE TABLE Rol (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO

-- SERVICIO
CREATE TABLE Servicio (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(MAX) NOT NULL
);
GO

-- ESTADO
CREATE TABLE Estado (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO

-- USUARIO
CREATE TABLE Usuario (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdRol INT NOT NULL FOREIGN KEY REFERENCES Rol(Id) ON DELETE CASCADE,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Celular VARCHAR(9) NOT NULL,
    Cuenta VARCHAR(50) NOT NULL,
    Contrasenia VARCHAR(20) NOT NULL
);
GO

-- MEMBRESIA
CREATE TABLE Membresia (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(30) NOT NULL,
    IdServicio INT NOT NULL FOREIGN KEY REFERENCES Servicio(Id) ON DELETE CASCADE,
    Precio INT NOT NULL,
    Duracion VARCHAR(10) NOT NULL,
    Descripcion VARCHAR(MAX) NOT NULL
);
GO

-- INSCRIPCION
CREATE TABLE Inscripcion (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuario(Id) ON DELETE CASCADE,
    IdMembresia INT NOT NULL FOREIGN KEY REFERENCES Membresia(Id) ON DELETE CASCADE,
    IdEstado INT NOT NULL FOREIGN KEY REFERENCES Estado(Id) ON DELETE CASCADE,
    FechaInscripcion DATE NOT NULL,
    FechaVencimiento DATE NOT NULL
);
GO


-- PROCEDIMIENTOS ALMACENADOS ------------------------------

-- ESTADO
CREATE PROCEDURE GuardarEstado @Nombre VARCHAR(50)
AS
BEGIN
    INSERT INTO Estado (Nombre) VALUES(@Nombre);
END;
GO

CREATE PROCEDURE EliminarEstado @Id INT
AS
BEGIN
    DELETE FROM Estado WHERE Id = @Id;
END;
GO

CREATE PROCEDURE ModificarEstado @Id INT, @Nombre VARCHAR(50)
AS
BEGIN
    UPDATE Estado SET Nombre = @Nombre WHERE Id = @Id;
END;
GO

CREATE PROCEDURE MostrarEstado @Nombre VARCHAR(50) = NULL
AS
BEGIN
    SELECT Id, Nombre
    FROM Estado
    WHERE (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%');
END;
GO

-- INSCRIPCION
CREATE PROCEDURE GuardarInscripcion 
    @IdUsuario INT,
    @IdMembresia INT,
    @IdEstado INT,
    @FechaInscripcion DATE,
    @FechaVencimiento DATE
AS
BEGIN
    INSERT INTO Inscripcion (IdUsuario,IdMembresia,IdEstado,FechaInscripcion,FechaVencimiento)
    VALUES (@IdUsuario,@IdMembresia,@IdEstado,@FechaInscripcion,@FechaVencimiento);
END;
GO

CREATE PROCEDURE EliminarInscripcion @Id INT
AS
BEGIN
    DELETE FROM Inscripcion WHERE Id = @Id;
END;
GO

CREATE PROCEDURE ModificarInscripcion
    @Id INT,
    @IdUsuario INT,
    @IdMembresia INT,
    @IdEstado INT,
    @FechaInscripcion DATE,
    @FechaVencimiento DATE
AS
BEGIN
    UPDATE Inscripcion
    SET IdUsuario = @IdUsuario,
        IdMembresia = @IdMembresia,
        IdEstado = @IdEstado,
        FechaInscripcion = @FechaInscripcion,
        FechaVencimiento = @FechaVencimiento
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE MostrarInscripcion
    @IdUsuario INT = NULL,
    @IdMembresia INT = NULL,
    @IdEstado INT = NULL,
    @FechaInscripcion DATE = NULL,
    @FechaVencimiento DATE = NULL
AS
BEGIN
    SELECT Id, IdUsuario, IdMembresia, IdEstado, FechaInscripcion, FechaVencimiento
    FROM Inscripcion
    WHERE (@IdUsuario IS NULL OR IdUsuario = @IdUsuario)
      AND (@IdMembresia IS NULL OR IdMembresia = @IdMembresia)
      AND (@IdEstado IS NULL OR IdEstado = @IdEstado)
      AND (@FechaInscripcion IS NULL OR FechaInscripcion = @FechaInscripcion)
      AND (@FechaVencimiento IS NULL OR FechaVencimiento = @FechaVencimiento);
END;
GO

-- MEMBRESIA
CREATE PROCEDURE GuardarMembresia
    @Nombre VARCHAR(30),
    @IdServicio INT,
    @Precio INT,
    @Duracion VARCHAR(10),
    @Descripcion VARCHAR(MAX)
AS
BEGIN
    INSERT INTO Membresia (Nombre, IdServicio, Precio, Duracion, Descripcion)
    VALUES(@Nombre,@IdServicio,@Precio,@Duracion,@Descripcion);
END;
GO

CREATE PROCEDURE EliminarMembresia @Id INT
AS
BEGIN
    DELETE FROM Membresia WHERE Id = @Id;
END;
GO

CREATE PROCEDURE ModificarMembresia
    @Id INT,
    @Nombre VARCHAR(30),
    @IdServicio INT,
    @Precio INT,
    @Duracion VARCHAR(10),
    @Descripcion VARCHAR(MAX)
AS
BEGIN
    UPDATE Membresia
    SET Nombre = @Nombre,
        IdServicio = @IdServicio,
        Precio = @Precio,
        Duracion = @Duracion,
        Descripcion = @Descripcion
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE MostrarMembresia
    @Nombre VARCHAR(30) = NULL,
    @IdServicio INT = NULL,
    @Precio INT = NULL,
    @Duracion VARCHAR(10) = NULL,
    @Descripcion VARCHAR(MAX) = NULL
AS
BEGIN
    SELECT Id, Nombre, IdServicio, Precio, Duracion, Descripcion
    FROM Membresia
    WHERE (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%')
      AND (@IdServicio IS NULL OR IdServicio = @IdServicio)
      AND (@Precio IS NULL OR Precio = @Precio)
      AND (@Duracion IS NULL OR Duracion LIKE '%' + @Duracion + '%')
      AND (@Descripcion IS NULL OR Descripcion LIKE '%' + @Descripcion + '%');
END;
GO

CREATE PROCEDURE ObtenerMembresiaPorId @Id INT
AS
BEGIN
    SELECT Id, IdServicio, Nombre, Duracion, Precio, Descripcion
    FROM Membresia
    WHERE Id = @Id;
END;
GO

-- ROL
CREATE PROCEDURE GuardarRol @Nombre VARCHAR(50)
AS
BEGIN
    INSERT INTO Rol (Nombre) VALUES(@Nombre);
END;
GO

CREATE PROCEDURE EliminarRol @Id INT
AS
BEGIN
    DELETE FROM Rol WHERE Id = @Id;
END;
GO

CREATE PROCEDURE ModificarRol @Id INT, @Nombre VARCHAR(50)
AS
BEGIN
    UPDATE Rol SET Nombre = @Nombre WHERE Id = @Id;
END;
GO

CREATE PROCEDURE MostrarRol @Nombre VARCHAR(50) = NULL
AS
BEGIN
    SELECT Id, Nombre
    FROM Rol
    WHERE (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%');
END;
GO

CREATE PROCEDURE ObtenerRoles
AS
BEGIN
    SELECT Id, Nombre FROM Rol;
END;
GO

-- SERVICIO
CREATE PROCEDURE GuardarServicio @Nombre VARCHAR(50), @Descripcion VARCHAR(MAX)
AS
BEGIN
    INSERT INTO Servicio (Nombre, Descripcion) VALUES(@Nombre,@Descripcion);
END;
GO

CREATE PROCEDURE EliminarServicio @Id INT
AS
BEGIN
    DELETE FROM Servicio WHERE Id = @Id;
END;
GO

CREATE PROCEDURE ModificarServicio @Id INT, @Nombre VARCHAR(50), @Descripcion VARCHAR(MAX)
AS
BEGIN
    UPDATE Servicio SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id;
END;
GO

CREATE PROCEDURE MostrarServicio @Nombre VARCHAR(50) = NULL, @Descripcion VARCHAR(MAX) = NULL
AS
BEGIN
    SELECT Id, Nombre, Descripcion
    FROM Servicio
    WHERE (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%')
      AND (@Descripcion IS NULL OR Descripcion LIKE '%' + @Descripcion + '%');
END;
GO

-- USUARIO
CREATE PROCEDURE GuardarUsuario
    @IdRol INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Celular VARCHAR(9),
    @Cuenta VARCHAR(50),
    @Contrasenia VARCHAR(20)
AS
BEGIN
    INSERT INTO Usuario (IdRol, Nombre, Apellido, Celular, Cuenta, Contrasenia)
    VALUES(@IdRol,@Nombre,@Apellido,@Celular,@Cuenta,@Contrasenia);
END;
GO

CREATE PROCEDURE EliminarUsuario @Id INT
AS
BEGIN
    DELETE FROM Usuario WHERE Id = @Id;
END;
GO

CREATE PROCEDURE ModificarUsuario
    @Id INT,
    @IdRol INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Celular VARCHAR(9),
    @Cuenta VARCHAR(50),
    @Contrasenia VARCHAR(20)
AS
BEGIN
    UPDATE Usuario
    SET IdRol = @IdRol,
        Nombre = @Nombre,
        Apellido = @Apellido,
        Celular = @Celular,
        Cuenta = @Cuenta,
        Contrasenia = @Contrasenia
    WHERE Id = @Id;
END;
GO

CREATE PROCEDURE MostrarUsuario
    @IdRol INT = NULL,
    @Nombre VARCHAR(50) = NULL,
    @Apellido VARCHAR(50) = NULL,
    @Celular VARCHAR(9) = NULL,
    @Cuenta VARCHAR(50) = NULL,
    @Contrasenia VARCHAR(20) = NULL
AS
BEGIN
    SELECT Id, IdRol, Nombre, Apellido, Celular, Cuenta, Contrasenia
    FROM Usuario
    WHERE (@IdRol IS NULL OR IdRol = @IdRol)
      AND (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%')
      AND (@Apellido IS NULL OR Apellido LIKE '%' + @Apellido + '%')
      AND (@Celular IS NULL OR Celular LIKE '%' + @Celular + '%')
      AND (@Cuenta IS NULL OR Cuenta LIKE '%' + @Cuenta + '%')
      AND (@Contrasenia IS NULL OR Contrasenia LIKE '%' + @Contrasenia + '%');
END;
GO

CREATE PROCEDURE VerificarUsuarioLogin @IdRol INT, @Cuenta VARCHAR(50), @Contrasenia VARCHAR(20)
AS
BEGIN
    SELECT ISNULL((SELECT 1 FROM Usuario WHERE IdRol=@IdRol AND Cuenta=@Cuenta AND Contrasenia=@Contrasenia), 0) AS UserExiste;
END;
GO

CREATE PROCEDURE BuscarUsuario @Nombre VARCHAR(50)
AS
BEGIN
    SELECT * FROM Usuario WHERE Nombre LIKE @Nombre + '%';
END;
GO

CREATE PROCEDURE BuscarMembresia @Nombre VARCHAR(30)
AS
BEGIN
    SELECT * FROM Membresia WHERE Nombre LIKE @Nombre + '%';
END;
GO

CREATE PROCEDURE BuscarInscripcion @IdUsuario INT
AS
BEGIN
    SELECT * FROM Inscripcion WHERE IdUsuario = @IdUsuario;
END;
GO

CREATE PROCEDURE ValidarUsuario @Cuenta VARCHAR(50), @Contrasenia VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdRol
    FROM Usuario
    WHERE Cuenta = @Cuenta AND Contrasenia = @Contrasenia;
END;
GO


-- DATOS INICIALES ----------------------------------------
EXEC GuardarRol 'Administrador';
EXEC GuardarRol 'Cliente';

EXEC GuardarUsuario 1,'William','Rosa','70294311','William791','791';
EXEC GuardarUsuario 2,'William','Rosa','70294311','William503','791';

EXEC GuardarEstado 'Activo';
EXEC GuardarEstado 'Inactivo';
GO
