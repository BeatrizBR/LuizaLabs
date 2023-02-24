
-- Criar um banco de dados chamado db_magalu
CREATE DATABASE db_magalu

-- Neste banco de dados devem ser criadas três tabelas: tb_product, tb_category, tb_product_category
-- tb_product: id (int, PK), name(texto), price(decimal)
-- tb_category: id (int, PK),name (texto)
-- tb_product_category: id (int, PK), productId (int, FK de id em tb_product) e um campo categoryId (int, FK de id em tb_category)
CREATE TABLE tb_product
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    _name VARCHAR(200),
    price DECIMAL
);

CREATE TABLE tb_category
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    _name VARCHAR(200)
);

CREATE TABLE tb_product_category
(
    id INT IDENTITY(1,1) PRIMARY KEY,
	productid INT,
	categoryid INT,
    CONSTRAINT FK_productid FOREIGN KEY (productid) REFERENCES tb_product (id),
    CONSTRAINT FK_categoryid FOREIGN KEY (categoryid) REFERENCES tb_category (id)
);

-- Três comandos INSERT para a category
INSERT INTO tb_category VALUES
('Eletrodomésticos'),
('Periféricos'),
('Móveis para cozinha')

-- Três comandos INSERT para a product
INSERT INTO tb_product VALUES
('Televisão 50 polegadas',1250),
('Headphone Gamer',50),
('Mouse Logitech',120)

INSERT INTO tb_product_category VALUES
(1,1),
(2,2),
(3,2)

-- Um comando SELECT na product com o objetivo de carregar produtos com preços superiores a R$ 100,00.
SELECT * FROM tb_product 
WHERE price > 100.0

-- Um comando UPDATE com o objetivo de atualizar o nome de um dos dois produtos, realizando a busca pelo id.
UPDATE tb_product
SET _name = 'Headphone Logitech'
where id = 2

--Um comando DELETE com o objetivo de apagar um dos dois produtos,
--realizando a busca pelo id.
ALTER TABLE tb_product_category
DROP CONSTRAINT FK_productid
DELETE FROM tb_product 
WHERE id = 2



