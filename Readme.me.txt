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
  
CREATE SEQUENCE public.usuariosjjagro_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 7
  CACHE 1;
ALTER TABLE public.usuariosjjagro_id_seq
  OWNER TO postgres;

--------------------------------------------------------------------------------------------------------