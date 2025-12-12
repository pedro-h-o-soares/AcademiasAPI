CREATE TABLE "academias" (
                             "id" uuid PRIMARY KEY DEFAULT GEN_RANDOM_UUID(),
                             "nome" varchar(40)
);

CREATE TABLE "usuarios" (
                            "id" uuid PRIMARY KEY DEFAULT GEN_RANDOM_UUID(),
                            "academia_id" uuid NOT NULL,
                            "nome" varchar(40) NOT NULL,
                            "email" varchar(50) NOT NULL,
                            "senha" varchar(255) NOT NULL
);

CREATE TABLE "direitos" (
                            "id" uuid PRIMARY KEY DEFAULT GEN_RANDOM_UUID(),
                            "nome" varchar(40) NOT NULL,
                            "nome_normalizado" varchar(40) UNIQUE NOT NULL
);

CREATE TABLE "direitos_usuarios" (
                                     "direito_id" uuid NOT NULL ON DELETE CASCADE,
                                     "usuario_id" uuid NOT NULL ON DELETE CASCADE,
                                     PRIMARY KEY ("direito_id", "usuario_id")
);

CREATE TABLE "maquinas" (
                            "id" uuid PRIMARY KEY DEFAULT GEN_RANDOM_UUID(),
                            "academia_id" uuid NOT NULL,
                            "nome" varchar(40) NOT NULL,
                            "foto" varchar(255)
);

CREATE TABLE "exercicios" (
                              "id" uuid PRIMARY KEY DEFAULT GEN_RANDOM_UUID(),
                              "academia_id" uuid NOT NULL,
                              "nome" varchar(40) NOT NULL,
                              "descricao" varchar(255),
                              "video" varchar(255)
);

CREATE TABLE "maquinas_exercicios" (
                                       "maquina_id" uuid NOT NULL,
                                       "exercicio_id" uuid NOT NULL,
                                       PRIMARY KEY ("exercicio_id", "maquina_id")
);

CREATE TABLE "treinos" (
                           "id" uuid PRIMARY KEY DEFAULT GEN_RANDOM_UUID(),
                           "usuario_id" uuid NOT NULL,
                           "nome" varchar(40) NOT NULL,
                           "descricao" varchar(255),
                           "ativo" boolean NOT NULL DEFAULT false
);

CREATE TABLE "series" (
                          "id" uuid PRIMARY KEY DEFAULT GEN_RANDOM_UUID(),
                          "treino_id" uuid NOT NULL,
                          "usuario_id" uuid NOT NULL,
                          "letra" varchar(1) NOT NULL,
                          "sequencia" int NOT NULL
);

CREATE TABLE "exercicios_serie" (
                                    "id" uuid PRIMARY KEY DEFAULT GEN_RANDOM_UUID(),
                                    "serie_id" uuid NOT NULL,
                                    "exercicio_id" uuid NOT NULL,
                                    "peso" int NOT NULL,
                                    "repeticoes" int NOT NULL,
                                    "sequencia" int NOT NULL
);


CREATE UNIQUE INDEX ON "usuarios" ("academia_id", "email");

CREATE INDEX ON "usuarios" ("email");

ALTER TABLE "usuarios" ADD FOREIGN KEY ("academia_id") REFERENCES "academias" ("id");

ALTER TABLE "direitos_usuarios" ADD FOREIGN KEY ("direito_id") REFERENCES "direitos" ("id") ON DELETE CASCADE;

ALTER TABLE "direitos_usuarios" ADD FOREIGN KEY ("usuario_id") REFERENCES "usuarios" ("id") ON DELETE CASCADE;

ALTER TABLE "maquinas_exercicios" ADD FOREIGN KEY ("exercicio_id") REFERENCES "exercicios" ("id") ON DELETE CASCADE;

ALTER TABLE "maquinas_exercicios" ADD FOREIGN KEY ("maquina_id") REFERENCES "maquinas" ("id") ON DELETE CASCADE;

ALTER TABLE "maquinas" ADD FOREIGN KEY ("academia_id") REFERENCES "academias" ("id");

ALTER TABLE "exercicios" ADD FOREIGN KEY ("academia_id") REFERENCES "academias" ("id");

ALTER TABLE "treinos" ADD FOREIGN KEY ("usuario_id") REFERENCES "usuarios" ("id");

ALTER TABLE "series" ADD FOREIGN KEY ("treino_id") REFERENCES "treinos" ("id");

ALTER TABLE "series" ADD FOREIGN KEY ("usuario_id") REFERENCES "usuarios" ("id");

ALTER TABLE "exercicios_serie" ADD FOREIGN KEY ("serie_id") REFERENCES "series" ("id");

ALTER TABLE "exercicios_serie" ADD FOREIGN KEY ("exercicio_id") REFERENCES "exercicios" ("id");

CREATE UNIQUE INDEX ON "series" ("treino_id", "sequencia");

CREATE UNIQUE INDEX ON "exercicios_serie" ("serie_id", "sequencia");