CREATE TABLE IF NOT EXISTS public."ContactManagers"
(
    id uuid NOT NULL,
    first_name text COLLATE pg_catalog."default" NOT NULL,
    last_name text COLLATE pg_catalog."default" NOT NULL,
    display_name text COLLATE pg_catalog."default",
    birth_date date,
    creation_timestamp timestamp with time zone NOT NULL,
    last_change_timestamp timestamp with time zone,
    email text COLLATE pg_catalog."default" NOT NULL,
    phone_number text COLLATE pg_catalog."default",
    salution text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "ContactManagers_pkey" PRIMARY KEY (id),
    CONSTRAINT unique_email UNIQUE (email)
)

    TABLESPACE pg_default;