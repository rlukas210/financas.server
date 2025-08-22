-- Active: 1749644233717@@127.0.0.1@3306@financasdev
CREATE TABLE usuarios (
    idUsuario INT PRIMARY KEY NOT NULL,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    cargo VARCHAR(50) NOT NULL,
    status ENUM('ativo', 'inativo') DEFAULT 'ativo'
);

CREATE TABLE cartao (
    idCartao INT AUTO_INCREMENT PRIMARY KEY,
    nomeCartao VARCHAR(100) NOT NULL,
    bandeira VARCHAR(50) NOT NULL,
    idUsuario INT NOT NULL,
    numero VARCHAR(4) NOT NULL,
    validade DATE NOT NULL,
    limite DECIMAL(10, 2) NOT NULL,
    status ENUM('ativo','bloqueado','cancelado','perdido') DEFAULT 'ativo',
    descricaoStatus VARCHAR(255),
    FOREIGN KEY (idUsuario) REFERENCES usuarios(idUsuario)
);

CREATE TABLE categorias (
    idCategoria INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descricao VARCHAR(255)
);

CREATE TABLE transacaoCartao (
    idTransacao INT AUTO_INCREMENT PRIMARY KEY,
    idCartao INT NOT NULL,
    descricao VARCHAR(255) NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    data DATE NOT NULL,
    parcelaAtual INT NOT NULL DEFAULT 1,
    parcelaTotal INT NOT NULL DEFAULT 1,
    categoria INT NOT NULL,
    status ENUM('pendente', 'paga', 'cancelada') DEFAULT 'pendente',
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observacao VARCHAR(255),
    usuarioInclusao INT NOT NULL,
    FOREIGN KEY (usuarioInclusao) REFERENCES usuarios(idUsuario),
    FOREIGN KEY (idCartao) REFERENCES cartao(idCartao),
    FOREIGN KEY (categoria) REFERENCES categorias(idCategoria)
);

CREATE TABLE transacaoBoleto (
    idTransacao INT AUTO_INCREMENT PRIMARY KEY,
    descricao VARCHAR(255) NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    data DATE NOT NULL,
    categoria INT NOT NULL,
    status ENUM('pendente', 'paga', 'cancelada') DEFAULT 'pendente',
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observacao VARCHAR(255),
    usuarioInclusao INT NOT NULL,
    FOREIGN KEY (usuarioInclusao) REFERENCES usuarios(idUsuario),
    FOREIGN KEY (categoria) REFERENCES categorias(idCategoria)
);

CREATE TABLE faturas(
    idFatura INT AUTO_INCREMENT PRIMARY KEY,
    idUsuario INT NOT NULL,
    idCartao INT NOT NULL,
    mes INT NOT NULL,
    ano INT NOT NULL,
    valorTotal DECIMAL(10, 2) NOT NULL,
    status ENUM('pendente', 'paga', 'cancelada') DEFAULT 'pendente',
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observacao VARCHAR(255),
    usuarioInclusao INT NOT NULL,
    FOREIGN KEY (usuarioInclusao) REFERENCES usuarios(idUsuario),
    FOREIGN KEY (idCartao) REFERENCES cartao(idCartao),
    FOREIGN KEY (idUsuario) REFERENCES usuarios(idUsuario)
);

CREATE TABLE pagamentos(
    idPagamento INT AUTO_INCREMENT PRIMARY KEY,
    idFatura INT NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    dataPagamento DATE NOT NULL,
   # metodoPagamento ENUM('cartao', 'boleto', 'dinheiro') NOT NULL,
    status ENUM('pendente', 'pago', 'pago parcialmennte', 'cancelado') DEFAULT 'pendente',
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idFatura) REFERENCES faturas(idFatura)
);

CREATE TABLE transacaoDinheiro(
    idTransacao INT AUTO_INCREMENT PRIMARY KEY,
    descricao VARCHAR(255) NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    data DATE NOT NULL,
    categoria INT NOT NULL,
    status ENUM('pendente', 'paga', 'cancelada') DEFAULT 'pendente',
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observacao VARCHAR(255),
    usuarioInclusao INT NOT NULL,
    FOREIGN KEY (usuarioInclusao) REFERENCES usuarios(idUsuario),
    FOREIGN KEY (categoria) REFERENCES categorias(idCategoria)
    );

CREATE TABLE transacaoPessoas(
    idTransacao INT AUTO_INCREMENT PRIMARY KEY,
    idUsuario INT NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    natureza ENUM('credito', 'debito', 'boleto', 'dinheiro') NOT NULL,
    status ENUM('pendente', 'paga', 'cancelada') DEFAULT 'pendente',
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observacao VARCHAR(255),
    usuarioInclusao INT NOT NULL,
    FOREIGN KEY (usuarioInclusao) REFERENCES usuarios(idUsuario),
    FOREIGN KEY (idUsuario) REFERENCES usuarios(idUsuario)
);
