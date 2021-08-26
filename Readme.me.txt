#Bases de datos del sistema 

BD usuariosjjagro

-- Table: public.usuariosjjagro

-- DROP TABLE public.usuariosjjagro;

CREATE TABLE public.usuariosjjagro
(
  id integer NOT NULL DEFAULT nextval('usuariosjjagro_id_seq'::regclass),
  fechaalta timestamp without time zone NOT NULL DEFAULT now(),
  paterno character(40) DEFAULT ''::bpchar,
  materno character(40) DEFAULT ''::bpchar,
  nombres character(40) DEFAULT ''::bpchar,
  correoelectronico character(40) NOT NULL,
  "contraseña" character(100),
  administrador integer NOT NULL DEFAULT 0,
  CONSTRAINT recserviciosafore_pkey PRIMARY KEY (correoelectronico)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.usuariosjjagro
  OWNER TO postgres;

--------------------------------------------------------------------------------------------------------