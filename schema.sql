    CREATE TABLE usuario (
        idUsuario INT PRIMARY KEY NOT NULL,
        nomeUsuario VARCHAR(100) NOT NULL,
        emailUsuario VARCHAR(100) NOT NULL UNIQUE,
        senhaUsuario VARCHAR(255) NOT NULL,
        cargoUsuario VARCHAR(50) NOT NULL,
        statusUsuario ENUM('ativo', 'inativo') DEFAULT 'ativo'
    );

    CREATE TABLE cartoes (
        idCartao INT PRIMARY KEY NOT NULL,
        nomeCartao VARCHAR(100) NOT NULL,
        bandeiraCartao VARCHAR(50) NOT NULL,
        tipoCartao ENUM('credito', 'debito', 'ambos') NOT NULL,
        numeroCartao VARCHAR(4) NOT NULL DEFAULT 0000,
        validadeCartao DATE NOT NULL,
        limiteCartao DECIMAL(10, 2) NOT NULL,
        statusCartao ENUM('ativo','bloqueado','cancelado','perdido') DEFAULT 'ativo',
        observacaoCartao VARCHAR(255),
        idUsuario INT NOT NULL,
        FOREIGN KEY (idUsuario) REFERENCES usuario(idUsuario)
    );

    CREATE TABLE categorias (
        idCategoria INT PRIMARY KEY NOT NULL,
        nomeCategoria VARCHAR(100) NOT NULL,
        descricaoCategoria VARCHAR(255)
    );

    CREATE TABLE  faturas(
        idFatura INT PRIMARY KEY NOT NULL,
        idUsuario INT NOT NULL,
        idCartao INT NOT NULL,
        dataReferencia DATE NOT NULL,
        valorTotal DECIMAL(10, 2) NOT NULL,
        statusFatura ENUM('pendente', 'paga', 'atraso') DEFAULT 'pendente',
        dataCriacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
        FOREIGN KEY (idUsuario) REFERENCES usuario(idUsuario),
        FOREIGN KEY (idCartao) REFERENCES cartoes(idCartao)
    );
    CREATE TABLE boletos (
    idBoleto INT PRIMARY KEY NOT NULL,
    nomeBoleto VARCHAR(255) NOT NULL,
    donoBoleto INT NOT NULL,
    cedenteBoleto VARCHAR(128),
    sacadoBoleto VARCHAR(128),
    codigoBoleto VARCHAR(48),
    valorNominal DECIMAL(10, 2) NOT NULL,
    jurosBoleto DECIMAL(10, 2),
    multaBoleto DECIMAL(10, 2),
    descontoBoleto DECIMAL(10, 2),
    qrCodePix LONGTEXT,
    dataVencimento DATE NOT NULL,
    statusBoleto ENUM('pendente', 'pago','atraso', 'cancelado') DEFAULT 'pendente',
    dataCriacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observacaoBoleto VARCHAR(255),
    usuarioInclusao INT NOT NULL,
    FOREIGN KEY (donoBoleto) REFERENCES usuario(idUsuario),
    FOREIGN KEY (usuarioInclusao) REFERENCES usuario(idUsuario)
    );

CREATE TABLE despesaCartao (
    idDespesa INT PRIMARY KEY NOT NULL,
    idFatura INT NOT NULL,
    natureza ENUM('credito', 'debito') NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    data DATE NOT NULL,
    parcelaAtual INT NOT NULL DEFAULT 1,
    parcelaTotal INT NOT NULL DEFAULT 1,
    categoria INT NOT NULL,
    status ENUM('pendente', 'parcial', 'total', 'cancelada') DEFAULT 'pendente',
    dataCriacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observacao VARCHAR(255),
    usuarioInclusao INT NOT NULL,
    FOREIGN KEY (usuarioInclusao) REFERENCES usuario(idUsuario),
    FOREIGN KEY (idFatura) REFERENCES faturas(idFatura),
    FOREIGN KEY (categoria) REFERENCES categorias(idCategoria)
);

CREATE TABLE divisaoTransacao(
    idDivisao INT PRIMARY KEY NOT NULL,
    idDespesa INT NOT NULL,
    donoDespesa INT NOT NULL,
    valor DECIMAL(10, 2) NOT NULL,
    status ENUM('pendente', 'pago', 'cancelado') DEFAULT 'pendente',
    dataCriacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idDespesa) REFERENCES despesaCartao(idDespesa),
    FOREIGN KEY (donoDespesa) REFERENCES usuario(idUsuario)
);

CREATE TABLE transacoes(
    idTransacao INT PRIMARY KEY NOT NULL,
    naturezaTransacao ENUM('credito', 'debito', 'boleto', 'dinheiro') NOT NULL,
    dataTransacao DATE NOT NULL,
    idCartao INT NOT NULL,
    idCategoria INT NOT NULL,
    statusTransacao ENUM('pendente', 'parcial', 'total', 'cancelada') DEFAULT 'pendente',
    observacaoTransacao VARCHAR(255),
    dataLancamento TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    donoId INT NOT NULL,
    FOREIGN KEY (donoId) REFERENCES usuario(idUsuario)
)