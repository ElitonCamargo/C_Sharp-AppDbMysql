CREATE TABLE categoria
(
    id int unsigned PRIMARY KEY AUTO_INCREMENT,
    nome varchar(50) UNIQUE    
);
CREATE TABLE produto
(
    id int unsigned PRIMARY KEY AUTO_INCREMENT,
    nome varchar(50),
    quantidade int unsigned,
    valor double,
   	categoria int unsigned,
    FOREIGN KEY (categoria) REFERENCES categoria(id)
);