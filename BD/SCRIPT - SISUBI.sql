/****** Object:  StoredProcedure [dbo].[rptMaterias]    Script Date: 09/05/2017 19:42:51 ******/
DROP PROCEDURE [dbo].[rptMaterias]
GO
/****** Object:  StoredProcedure [dbo].[rptCursos]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[rptCursos]
GO
/****** Object:  StoredProcedure [dbo].[rptComisiones]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[rptComisiones]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarUsuarioLoginsActivos]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarUsuarioLoginsActivos]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarUltimoID]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarUltimoID]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarTipoPersona]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarTipoPersona]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonasPorTipoActivos]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarPersonasPorTipoActivos]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonasPorTipo]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarPersonasPorTipo]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonasActivo]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarPersonasActivo]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonas]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarPersonas]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonaPorNombreDeUsuario]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarPersonaPorNombreDeUsuario]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonaPorLegajo]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarPersonaPorLegajo]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersona]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarPersona]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarNotasPorID]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarNotasPorID]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarMaterias]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarMaterias]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarMateriaPorDescripcion]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarMateriaPorDescripcion]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarMateria]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarMateria]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisionPorIdMateria]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarComisionPorIdMateria]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisionPorIdArchivo]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarComisionPorIdArchivo]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisionPorDescripcion]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarComisionPorDescripcion]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisionesPersonas]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarComisionesPersonas]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisiones]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarComisiones]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarComision]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarArchivosPorAlumnoPorTipo]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarArchivosPorAlumnoPorTipo]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarArchivosPorAlumno]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarArchivosPorAlumno]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarArchivos]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarArchivos]
GO
/****** Object:  StoredProcedure [dbo].[RecuperarAlumnosXComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[RecuperarAlumnosXComision]
GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuarioLogin]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[ModificarUsuarioLogin]
GO
/****** Object:  StoredProcedure [dbo].[ModificarPersona]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[ModificarPersona]
GO
/****** Object:  StoredProcedure [dbo].[ModificarNotas]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[ModificarNotas]
GO
/****** Object:  StoredProcedure [dbo].[ModificarMateria]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[ModificarMateria]
GO
/****** Object:  StoredProcedure [dbo].[ModificarComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[ModificarComision]
GO
/****** Object:  StoredProcedure [dbo].[ModificarArchivoComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[ModificarArchivoComision]
GO
/****** Object:  StoredProcedure [dbo].[ModificarArchivo]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[ModificarArchivo]
GO
/****** Object:  StoredProcedure [dbo].[BorrarPersona]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[BorrarPersona]
GO
/****** Object:  StoredProcedure [dbo].[BorrarMateria]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[BorrarMateria]
GO
/****** Object:  StoredProcedure [dbo].[BorrarComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[BorrarComision]
GO
/****** Object:  StoredProcedure [dbo].[BorrarArchivoComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[BorrarArchivoComision]
GO
/****** Object:  StoredProcedure [dbo].[BorrarArchivo]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[BorrarArchivo]
GO
/****** Object:  StoredProcedure [dbo].[BorrarAlumnoDeComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[BorrarAlumnoDeComision]
GO
/****** Object:  StoredProcedure [dbo].[AgregarUsuarioLogin]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[AgregarUsuarioLogin]
GO
/****** Object:  StoredProcedure [dbo].[AgregarPersona]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[AgregarPersona]
GO
/****** Object:  StoredProcedure [dbo].[AgregarNuevoAlumnoAComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[AgregarNuevoAlumnoAComision]
GO
/****** Object:  StoredProcedure [dbo].[AgregarMateria]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[AgregarMateria]
GO
/****** Object:  StoredProcedure [dbo].[AgregarComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[AgregarComision]
GO
/****** Object:  StoredProcedure [dbo].[AgregarArchivoComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[AgregarArchivoComision]
GO
/****** Object:  StoredProcedure [dbo].[AgregarArchivo]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[AgregarArchivo]
GO
/****** Object:  StoredProcedure [dbo].[AgregarAlumnoAComision]    Script Date: 09/05/2017 19:42:52 ******/
DROP PROCEDURE [dbo].[AgregarAlumnoAComision]
GO
/****** Object:  Table [dbo].[usrLogins]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[usrLogins]
GO
/****** Object:  Table [dbo].[tipos_persona]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[tipos_persona]
GO
/****** Object:  Table [dbo].[tipos_archivos]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[tipos_archivos]
GO
/****** Object:  Table [dbo].[personas_comisiones]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[personas_comisiones]
GO
/****** Object:  Table [dbo].[personas]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[personas]
GO
/****** Object:  Table [dbo].[materias]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[materias]
GO
/****** Object:  Table [dbo].[comisiones]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[comisiones]
GO
/****** Object:  Table [dbo].[archivos_personas]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[archivos_personas]
GO
/****** Object:  Table [dbo].[archivos_comisiones]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[archivos_comisiones]
GO
/****** Object:  Table [dbo].[archivos]    Script Date: 09/05/2017 19:42:52 ******/
DROP TABLE [dbo].[archivos]
GO
/****** Object:  Table [dbo].[archivos]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[archivos](
	[IDArchivo] [int] IDENTITY(1,1) NOT NULL,
	[NombreArchivo] [varchar](100) NOT NULL,
	[UbicacionArchivo] [varchar](250) NOT NULL,
	[FechaArchivo] [smalldatetime] NOT NULL,
	[FechaHoraInicio] [smalldatetime] NOT NULL,
	[FechaHoraFin] [smalldatetime] NOT NULL,
	[IP] [varchar](150) NULL,
	[CoordenadaLatitud] [float] NULL,
	[CoordenadaLongitud] [float] NULL,
	[Radio] [float] NULL,
	[Descripcion] [varchar](50) NULL,
	[IDTipo] [int] NULL,
 CONSTRAINT [PK_archivos] PRIMARY KEY CLUSTERED 
(
	[IDArchivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[archivos_comisiones]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[archivos_comisiones](
	[IdArchivo] [int] NOT NULL,
	[IdComision] [int] NOT NULL,
 CONSTRAINT [PK_dbo.archivos_comisiones] PRIMARY KEY CLUSTERED 
(
	[IdArchivo] ASC,
	[IdComision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[archivos_personas]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[archivos_personas](
	[IDArchivoPersona] [int] IDENTITY(1,1) NOT NULL,
	[IDArchivo] [int] NOT NULL,
	[IDPersona] [int] NOT NULL,
 CONSTRAINT [PK_archivos_personas] PRIMARY KEY CLUSTERED 
(
	[IDArchivoPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[comisiones]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[comisiones](
	[id_comision] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_comision] [varchar](50) NOT NULL,
	[id_materia] [int] NULL,
	[anio] [int] NULL,
 CONSTRAINT [PK_comisiones] PRIMARY KEY CLUSTERED 
(
	[id_comision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[comisiones] SET (LOCK_ESCALATION = DISABLE)
GO
/****** Object:  Table [dbo].[materias]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[materias](
	[id_materia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_materia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_materias] PRIMARY KEY CLUSTERED 
(
	[id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[personas]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[personas](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[legajo] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[id_tipo_persona] [int] NOT NULL,
	[usuario] [varchar](50) NULL,
	[contrasenia] [varchar](50) NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_personas] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[personas_comisiones]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[personas_comisiones](
	[idpersona_idcomision] [int] IDENTITY(1,1) NOT NULL,
	[id_persona] [int] NOT NULL,
	[id_comision] [int] NOT NULL,
	[notaP1] [float] NULL,
	[notaP2] [float] NULL,
	[notaR1] [float] NULL,
	[notaR2] [float] NULL,
	[estado] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipos_archivos]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipos_archivos](
	[id_tipo] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipos_persona]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipos_persona](
	[id_tipo_persona] [int] NOT NULL,
	[descripcion_persona] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tipos_persona] PRIMARY KEY CLUSTERED 
(
	[id_tipo_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[usrLogins]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usrLogins](
	[IDUsuarioLogin] [int] IDENTITY(1,1) NOT NULL,
	[ID_Persona] [int] NOT NULL,
	[Fecha_Login] [smalldatetime] NULL,
	[Fecha_Logout] [smalldatetime] NULL,
	[IP] [varchar](150) NULL,
 CONSTRAINT [PK_usrLogins] PRIMARY KEY CLUSTERED 
(
	[IDUsuarioLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AgregarAlumnoAComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarAlumnoAComision]
	-- Add the parameters for the stored procedure here
	@idcomision as int,
	@idpersona as int,
	@notap1 as float,
	@notap2 as float,
	@notar1 as float, 
	@notar2 as float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.personas_comisiones(id_persona,id_comision,notaP1,notaP2,notaR1,notaR2) VALUES(@idpersona,@idcomision,@notap1,@notap2,@notar1,@notar2); 
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarArchivo]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarArchivo]
	@nom_archivo as VARCHAR(100),
	@ubicacion_archivo as VARCHAR(250),
	@fec_archivo as smalldatetime,
	@fechora_ini as smalldatetime,
	@fechora_fin as smalldatetime,
	@ip as VARCHAR(150),
	@latitud_archivo as float,
	@longitud_archivo as float,
	@radio as float,
	@descripcion as VARCHAR(50),
	@tipo as int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.archivos (NombreArchivo,UbicacionArchivo,FechaArchivo,FechaHoraInicio,FechaHoraFin, IP, CoordenadaLatitud, CoordenadaLongitud, Radio, Descripcion, IDTipo)
	VALUES(@nom_archivo, @ubicacion_archivo, @fec_archivo, @fechora_ini, @fechora_fin, @ip, @latitud_archivo, @longitud_archivo, @radio, @descripcion,@tipo)
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarArchivoComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarArchivoComision]
	-- Add the parameters for the stored procedure here
	@IdArchivo as int,
	@IdComision as int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.archivos_comisiones (IdArchivo,IdComision)
	VALUES(@IdArchivo,@IdComision)
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarComision]
	@desc_comision as VARCHAR(50),
	@idMateria int,
	@anio int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.comisiones (descripcion_comision,id_materia,anio)
	VALUES(@desc_comision, @idMateria,@anio)
END


GO
/****** Object:  StoredProcedure [dbo].[AgregarMateria]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarMateria]
  @desc_materia varchar(50)
  AS
  BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.materias(descripcion_materia)
	VALUES(@desc_materia)
END


GO
/****** Object:  StoredProcedure [dbo].[AgregarNuevoAlumnoAComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AgregarNuevoAlumnoAComision] 
	-- Add the parameters for the stored procedure here
	@idcomision as int,
	@legajo as varchar(50),
	@nombre as varchar(50),
	@apellido as varchar(50),
	@usr as varchar(50),
	@pass as varchar(50),
	@notap1 as float,
	@notap2 as float,
	@notar1 as float, 
	@notar2 as float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO dbo.personas(nombre,apellido,legajo,id_tipo_persona,usuario,contrasenia,activo)
	VALUES (@nombre,@apellido,@legajo,3,@usr,@pass,1);

	DECLARE @idpersona int;
	SELECT @idpersona = id_persona
	FROM dbo.personas
	WHERE nombre = @nombre AND apellido = @apellido AND legajo = @legajo;

	INSERT INTO dbo.personas_comisiones(id_persona,id_comision,notaP1,notaP2,notaR1,notaR2) VALUES(@idpersona,@idcomision,@notap1,@notap2,@notar1,@notar2);

END

GO
/****** Object:  StoredProcedure [dbo].[AgregarPersona]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarPersona]
  @apellido varchar(50),
  @nombre varchar(50),
  @legajo varchar(50),
  @usuario varchar(50),
  @contrasenia varchar(50),
  @email varchar(50),
  @id_tipo_persona int,
  @activo bit
  AS
  BEGIN

	SET NOCOUNT ON;
	INSERT INTO dbo.personas (apellido, nombre, legajo, usuario, contrasenia, email, id_tipo_persona, activo)
	VALUES(@apellido, @nombre, @legajo, @usuario, @contrasenia, @email, @id_tipo_persona, @activo)
END



GO
/****** Object:  StoredProcedure [dbo].[AgregarUsuarioLogin]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarUsuarioLogin]
        @ID_Persona int,
        @Fecha_Login smalldatetime,
        @Fecha_Logout smalldatetime = null,
        @IP varchar(150)
  AS
  BEGIN
	SET NOCOUNT ON;
	IF @Fecha_Logout < GETDATE()
		BEGIN
		SET @Fecha_Logout = NULL
		END
	INSERT INTO dbo.usrLogins(ID_Persona, Fecha_Login, Fecha_Logout, IP)
	VALUES(@ID_Persona, @Fecha_Login, @Fecha_Logout, @IP)
END

GO
/****** Object:  StoredProcedure [dbo].[BorrarAlumnoDeComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BorrarAlumnoDeComision]
	@idpersona as int,
	@idcomision as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.personas_comisiones WHERE id_comision=@idcomision AND id_persona=@idpersona;
END

GO
/****** Object:  StoredProcedure [dbo].[BorrarArchivo]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BorrarArchivo] 
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM dbo.archivos WHERE IDArchivo = @id;
	DELETE FROM dbo.archivos_comisiones WHERE IdArchivo = @id;
	DELETE FROM dbo.archivos_personas WHERE IDArchivo = @id
END

GO
/****** Object:  StoredProcedure [dbo].[BorrarArchivoComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BorrarArchivoComision]
	-- Add the parameters for the stored procedure here
	@idComision as int,
	@idArchivo as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DELETE archivos_comisiones WHERE archivos_comisiones.IdComision=@idComision AND archivos_comisiones.IdArchivo=@idArchivo
END

GO
/****** Object:  StoredProcedure [dbo].[BorrarComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarComision]
	@id as int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE comisiones WHERE id_comision=@id;
	DELETE archivos_comisiones WHERE IdComision=@id;
END


GO
/****** Object:  StoredProcedure [dbo].[BorrarMateria]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarMateria]
	@id_materia int  
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.materias
	WHERE id_materia=@id_materia;
	DELETE FROM dbo.comisiones
	WHERE id_materia=@id_materia
END


GO
/****** Object:  StoredProcedure [dbo].[BorrarPersona]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarPersona]
  @id_persona int
  
  AS
  BEGIN

	SET NOCOUNT ON;
	DELETE FROM dbo.personas
	WHERE id_persona=@id_persona
END


GO
/****** Object:  StoredProcedure [dbo].[ModificarArchivo]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarArchivo]
	-- Add the parameters for the stored procedure here
	@idarchivo as int,
	@fec_archivo as smalldatetime,
	@fechora_ini as smalldatetime,
	@fechora_fin as smalldatetime,
	@ip as VARCHAR(150),
	@latitud_archivo as float,
	@longitud_archivo as float,
	@radio as float,
	@descripcion as VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.archivos 
		SET FechaArchivo = @fec_archivo, 
			FechaHoraInicio = @fechora_ini,
			FechaHoraFin = @fechora_fin,
			IP = @ip,
			CoordenadaLatitud = @latitud_archivo,
			CoordenadaLongitud = @longitud_archivo,
			Radio = @radio,
			Descripcion = @descripcion
		WHERE IDArchivo = @idarchivo
END

GO
/****** Object:  StoredProcedure [dbo].[ModificarArchivoComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarArchivoComision]
	-- Add the parameters for the stored procedure here
	@idComViejo int,
	@idArchivo int,
	@idComNuevo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.archivos_comisiones
      SET 
             dbo.archivos_comisiones.IdComision = @idComNuevo
      FROM   dbo.archivos_comisiones
      WHERE  
      dbo.archivos_comisiones.IdComision = @idComViejo AND
	  dbo.archivos_comisiones.IdArchivo = @idArchivo 
END

GO
/****** Object:  StoredProcedure [dbo].[ModificarComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarComision]
 @id_comision int,
 @desc_comision varchar(50),
 @id_materia int,
 @anio int
AS
BEGIN 
      SET NOCOUNT ON 

      UPDATE dbo.comisiones
      SET 
             descripcion_comision = @desc_comision,
			 id_materia = @id_materia,
			 anio = @anio
      FROM   dbo.comisiones
      WHERE  
      id_comision = @id_comision
END


GO
/****** Object:  StoredProcedure [dbo].[ModificarMateria]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarMateria]
	 @id_materia int,
	 @desc_materia varchar(50)
AS
BEGIN 
      SET NOCOUNT ON 

      UPDATE dbo.materias
      SET 
		descripcion_materia = @desc_materia
      WHERE  
      id_materia = @id_materia
END


GO
/****** Object:  StoredProcedure [dbo].[ModificarNotas]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarNotas] 
	-- Add the parameters for the stored procedure here
	@idcomision as int,
	@idpersona as int,
	@notap1 as float,
	@notap2 as float,
	@notar1 as float,
	@notar2 as float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.personas_comisiones 
	SET notaP1=@notap1,notaP2=@notap2,notaR1=@notar1,notaR2=@notar2
	WHERE id_comision=@idcomision AND id_persona=@idpersona;
END

GO
/****** Object:  StoredProcedure [dbo].[ModificarPersona]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarPersona]
 @id int,
 @apellido varchar(50),
 @nombre varchar(50),
 @legajo varchar(50),
 @usuario varchar(50),
 @contrasenia varchar(50),
 @email varchar(50),
 @tipo_persona int,
 @activo bit
AS
BEGIN 
      SET NOCOUNT ON 

      UPDATE dbo.personas
      SET 
             apellido = @apellido,
			 nombre = @nombre,
			 legajo = @legajo,
			 usuario = @usuario ,
			 contrasenia = @contrasenia ,
			 email =  @email ,
			 id_tipo_persona = @tipo_persona,
			 activo = @activo 
      FROM   dbo.personas
      WHERE  
      id_persona = @id
END



GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuarioLogin]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarUsuarioLogin]
 @IDUsuarioLogin int,
 @Fecha_Logout datetime

AS
BEGIN 
      SET NOCOUNT ON 

      UPDATE dbo.usrLogins
      SET Fecha_Logout = @Fecha_Logout
      FROM   dbo.usrLogins
      WHERE  
      IDUsuarioLogin = @IDUsuarioLogin
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarAlumnosXComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarAlumnosXComision]
	@idcom int	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT per.id_persona, per.apellido, per.nombre, per.legajo, percom.notaP1, percom.notaP2, percom.notaR1, percom.notaR2
	FROM dbo.personas_comisiones percom
	INNER JOIN dbo.personas per
	ON percom.id_persona = per.id_persona
	WHERE percom.id_comision = @idcom;
END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarArchivos]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RecuperarArchivos] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT arch.*, tip.descripcion
	FROM dbo.archivos arch
	INNER JOIN dbo.tipos_archivos tip
	ON arch.IDTipo = tip.id_tipo
	ORDER BY arch.IDTipo
END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarArchivosPorAlumno]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarArchivosPorAlumno]
	@id int
AS
BEGIN
	SET NOCOUNT ON;
    SELECT arch.*, tip.descripcion
	FROM [dbo].[personas] per
	INNER JOIN [dbo].[personas_comisiones] percom
	ON per.id_persona = percom.id_persona
	INNER JOIN [dbo].[archivos_comisiones] archcom
	ON percom.id_comision = archcom.IdComision
	INNER JOIN [dbo].[archivos] arch
	ON arch.IDArchivo = archcom.IdArchivo
	INNER JOIN dbo.tipos_archivos tip
	ON arch.IDTipo = tip.id_tipo
	WHERE per.id_persona = @id
END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarArchivosPorAlumnoPorTipo]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarArchivosPorAlumnoPorTipo] 
	@id int,
	@idtipo int
AS
BEGIN
	SET NOCOUNT ON;
    SELECT arch.*, tip.descripcion
	FROM [dbo].[personas] per
	INNER JOIN [dbo].[personas_comisiones] percom
	ON per.id_persona = percom.id_persona
	INNER JOIN [dbo].[archivos_comisiones] archcom
	ON percom.id_comision = archcom.IdComision
	INNER JOIN [dbo].[archivos] arch
	ON arch.IDArchivo = archcom.IdArchivo
	INNER JOIN dbo.tipos_archivos tip
	ON arch.IDTipo = tip.id_tipo
	WHERE per.id_persona = @id AND arch.IDTipo = @idtipo
END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarComision]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarComision]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.comisiones
	WHERE id_comision = @id
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisiones]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarComisiones]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT com.id_comision, (LTRIM(STR(com.anio))+' - '+mat.descripcion_materia+' '+com.descripcion_comision) as descripcion
	FROM dbo.comisiones com
	INNER JOIN dbo.materias mat
	ON com.id_materia = mat.id_materia
	ORDER BY descripcion
END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisionesPersonas]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RecuperarComisionesPersonas]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT percom.idpersona_idcomision, percom.id_comision, percom.id_persona, com.anio
	FROM dbo.personas_comisiones percom
	INNER JOIN dbo.comisiones com
	ON com.id_comision = percom.id_comision
END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisionPorDescripcion]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarComisionPorDescripcion]
	@descripcion_comision varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.comisiones
	WHERE descripcion_comision = @descripcion_comision
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisionPorIdArchivo]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RecuperarComisionPorIdArchivo] 
	-- Add the parameters for the stored procedure here
	@id_archivo int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT dbo.comisiones.id_comision, dbo.comisiones.id_materia
	FROM dbo.comisiones
	INNER JOIN dbo.archivos_comisiones
	ON dbo.comisiones.id_comision = dbo.archivos_comisiones.IdComision
	WHERE dbo.archivos_comisiones.IdArchivo = @id_archivo
END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarComisionPorIdMateria]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE[dbo].[RecuperarComisionPorIdMateria]
	@id_materia int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.comisiones
	WHERE id_materia = @id_materia
END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarMateria]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarMateria]
	@id_materia int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.materias
	WHERE id_materia = @id_materia
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarMateriaPorDescripcion]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarMateriaPorDescripcion]
	@descripcion_materia varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.materias
	WHERE descripcion_materia = @descripcion_materia
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarMaterias]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarMaterias]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.materias
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarNotasPorID]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RecuperarNotasPorID]
	@idpersona as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT (LTRIM(STR(com.anio))+' - '+mat.descripcion_materia+' '+com.descripcion_comision) as Descripcion, percom.notaP1 as NotaP1, percom.notaP2 as NotaP2, percom.notaR1 as NotaR1, percom.notaR2 as NotaR2 
	FROM dbo.comisiones com
	INNER JOIN dbo.materias mat
	ON com.id_materia = mat.id_materia
	INNER JOIN dbo.personas_comisiones percom
	ON percom.id_comision = com.id_comision
	WHERE percom.id_persona = @idpersona
	ORDER BY descripcion

END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersona]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarPersona]
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.personas
	WHERE id_persona = @id
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonaPorLegajo]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarPersonaPorLegajo]
	@legajo varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.personas
	WHERE legajo = @legajo
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonaPorNombreDeUsuario]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarPersonaPorNombreDeUsuario]
	@usuario varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.personas
	WHERE usuario = @usuario
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonas]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarPersonas]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.personas
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonasActivo]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarPersonasActivo]
	@activo bit
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.personas
	WHERE activo = @activo
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonasPorTipo]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarPersonasPorTipo]
	@id_tipo int,
	@activo bit
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.personas
	WHERE id_tipo_persona = @id_tipo AND activo = @activo
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarPersonasPorTipoActivos]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarPersonasPorTipoActivos]
	@id_tipo int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.personas
	WHERE id_tipo_persona = @id_tipo AND activo = 1;
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarTipoPersona]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarTipoPersona]
	@id_tipo int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.tipos_persona
	WHERE id_tipo_persona = @id_tipo
END


GO
/****** Object:  StoredProcedure [dbo].[RecuperarUltimoID]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarUltimoID]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT ISNULL(MAX(IDArchivo),0) as id
	FROM [dbo].[archivos]
END

GO
/****** Object:  StoredProcedure [dbo].[RecuperarUsuarioLoginsActivos]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarUsuarioLoginsActivos]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.usrLogins
	WHERE Fecha_Logout IS NULL
END


GO
/****** Object:  StoredProcedure [dbo].[rptComisiones]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rptComisiones]
AS
BEGIN
	SET NOCOUNT ON;

SELECT comisiones.descripcion_comision, turnos.desc_turno, planes.descripcion_plan
FROM   comisiones INNER JOIN
             turnos ON comisiones.id_turno = turnos.id_turno INNER JOIN
             planes ON comisiones.id_plan = planes.id_plan
END


GO
/****** Object:  StoredProcedure [dbo].[rptCursos]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rptCursos]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT cursado.anio_calendario, cursado.cupo, estados_cursos.descripcion_estado, comisiones.descripcion_comision, turnos.desc_turno, materias.descripcion_materia, materias.electiva, planes.descripcion_plan, 
             especialidades.descripcion_especialidad
FROM   cursado INNER JOIN
             comisiones ON cursado.id_comision = comisiones.id_comision INNER JOIN
             materias ON cursado.id_materia = materias.id_materia INNER JOIN
             estados_cursos ON cursado.id_estado = estados_cursos.id_estado INNER JOIN
             turnos ON comisiones.id_turno = turnos.id_turno INNER JOIN
             planes ON comisiones.id_plan = planes.id_plan AND materias.id_plan = planes.id_plan INNER JOIN
             especialidades ON planes.id_especialidad = especialidades.id_especialidad
END


GO
/****** Object:  StoredProcedure [dbo].[rptMaterias]    Script Date: 09/05/2017 19:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rptMaterias]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT        materias.descripcion_materia, materias.electiva, planes.descripcion_plan, especialidades.descripcion_especialidad, materias.horas_semanales, 
                         materias.horas_totales, materias.nivel
FROM            materias INNER JOIN
                         planes ON materias.id_plan = planes.id_plan INNER JOIN
                         especialidades ON planes.id_especialidad = especialidades.id_especialidad
END


GO
