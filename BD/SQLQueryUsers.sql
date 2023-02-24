

-- Script para criação do BD para os usuários no login

CREATE TABLE Users
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50),
    _password VARCHAR(50),
);

INSERT INTO Users VALUES
('magalu','m@galu123')