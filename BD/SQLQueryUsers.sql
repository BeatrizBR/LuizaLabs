

-- Script para cria��o do BD para os usu�rios no login

CREATE TABLE Users
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50),
    _password VARCHAR(50),
);

INSERT INTO Users VALUES
('magalu','m@galu123')