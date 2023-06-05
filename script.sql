-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Usuarios (
  IdUsuario BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Usuario varchar(200) NOT NULL,
  Clave TEXT NOT NULL
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Roles (
  IdRol BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  IdUsuario BIGINT NOT NULL,
  Tabla TEXT NOT NULL,
  TipoDePrivilegio TEXT NOT NULL,
  FOREIGN KEY (IdUsuario) REFERENCES Usuarios (IdUsuario)
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Clientes (
  IdCliente BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  NIT BIGINT NOT NULL,
  Nombre TEXT NOT NULL,
  Telefono BIGINT NOT NULL,
  Direccion TEXT NOT NULL
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Productos (
  CodigoProducto BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Nombre TEXT NOT NULL,
  Descripcion TEXT NOT NULL,
  Precio DECIMAL(10,2) NOT NULL,
  Cantidad BIGINT NOT NULL
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE Facturas (
  CodigoFactura BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  IdCliente BIGINT NOT NULL,
  FOREIGN KEY (IdCliente) REFERENCES Clientes (IdCliente)
);

-- SQLINES LICENSE FOR EVALUATION USE ONLY
CREATE TABLE DetalleDeFactura (
  CodigoFactura BIGINT NOT NULL,
  CodigoProducto BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FOREIGN KEY (CodigoFactura) REFERENCES Facturas (CodigoFactura),
  FOREIGN KEY (CodigoProducto) REFERENCES Productos (CodigoProducto)
);

insert into Usuarios values('admin','admin');

/*Creamos el cliente consumidor final*/
insert into Clientes values(0,'CF',0,'CF');

/*CONFIGURACION INICIAR DE PRIVILEGIOS PARA EL USUARIO SUPER ADMINISTRADOR*/
/*--------------------------------------------------------------------------*/
/*--------------------------------------------------------------------------*/

/*Privilegios del usuario super administrador*/
/*Privilegios de insercion*/
insert into Roles values(1,'Usuarios','Insertar');
insert into Roles values(1,'Roles','Insertar');
insert into Roles values(1,'Clientes','Insertar');
insert into Roles values(1,'Productos','Insertar');
insert into Roles values(1,'Facturas','Insertar');
insert into Roles values(1,'DetalleDeFactura','Insertar');

/*Privilegios de modificacion*/
insert into Roles values(1,'Usuarios','Modificar');
insert into Roles values(1,'Roles','Modificar');
insert into Roles values(1,'Clientes','Modificar');
insert into Roles values(1,'Productos','Modificar');
insert into Roles values(1,'Facturas','Modificar');
insert into Roles values(1,'DetalleDeFactura','Modificar');

/*Privilegios de eliminacion*/
insert into Roles values(1,'Usuarios','Eliminar');
insert into Roles values(1,'Roles','Eliminar');
insert into Roles values(1,'Clientes','Eliminar');
insert into Roles values(1,'Productos','Eliminar');
insert into Roles values(1,'Facturas','Eliminar');
insert into Roles values(1,'DetalleDeFactura','Eliminar');

/*Privilegios de visualizacion*/
insert into Roles values(1,'Usuarios','Visualizar');
insert into Roles values(1,'Roles','Visualizar');
insert into Roles values(1,'Clientes','Visualizar');
insert into Roles values(1,'Productos','Visualizar');
insert into Roles values(1,'Facturas','Visualizar');
insert into Roles values(1,'DetalleDeFactura','Visualizar');
/*Fin privilegios del usuario super administrador*/

/*--------------------------------------------------------------------------*/