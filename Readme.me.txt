#Bases de datos del sistema 

BD usuariosjjagro

-- Table: public.usuariosjjagro

-- DROP TABLE public.usuariosjjagro;

CREATE TABLE public.usuariosjjagro
(
  id character(50),
  fechaalta timestamp without time zone NOT NULL DEFAULT now(),
  paterno character(40) DEFAULT ''::bpchar,
  materno character(40) DEFAULT ''::bpchar,
  nombres character(40) DEFAULT ''::bpchar,
  correoelectronico character(40) NOT NULL,
  "contraseña" character(50),
  administrador integer NOT NULL DEFAULT 0,
  CONSTRAINT recserviciosafore_pkey PRIMARY KEY (correoelectronico)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.usuariosjjagro
  OWNER TO postgres;

--------------------------------------------------------------------------------------------------------
# BD cientes
-- Table: public.clientesjjagro

-- DROP TABLE public.clientesjjagro;

CREATE TABLE public.clientesjjagro
(
  id integer NOT NULL DEFAULT nextval('clientesjjagro_id_seq'::regclass),
  fechaalta timestamp without time zone NOT NULL DEFAULT now(),
  maternocli character(40) DEFAULT ''::bpchar,
  paternocli character(40) DEFAULT ''::bpchar,
  nombrescli character(40) DEFAULT ''::bpchar,
  empresacli character(40) DEFAULT ''::bpchar,
  razoncli character(40) NOT NULL DEFAULT ''::bpchar,
  cultivocli character(40) DEFAULT ''::bpchar,
  hascli character(40) DEFAULT ''::bpchar,
  CONSTRAINT clientesjjagro_pkey PRIMARY KEY (razoncli)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE public.clientesjjagro
  OWNER TO postgres;


-- Sequence: public.clientesjjagro_id_seq

-- DROP SEQUENCE public.clientesjjagro_id_seq;

CREATE SEQUENCE public.clientesjjagro_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 19
  CACHE 1;
ALTER TABLE public.clientesjjagro_id_seq
  OWNER TO postgres;