drop database if exists Drivex;

create database Drivex;
use Drivex;

create table Clientes (
    id_cliente int auto_increment primary key,
    nome varchar(100),
    cpf varchar(14),
    telefone varchar(20),
    email varchar(100),
    modelo_interesse varchar(100),
    status_atend varchar(50),
    observacao varchar(1000)
);

create table Carros (
    id_carro int auto_increment primary key,
    marca varchar(50),
    modelo varchar(100),
    placa varchar(10),
    ano int,
    categoria varchar(50),
    cor varchar(50),
    quilometragem int,
    preco_vista decimal(10,2),
    entrada decimal(10,2),
    parcelas varchar(50),
    status varchar(30)
);

create table Precos (
    id_preco int auto_increment primary key,
    id_carro_fk int,
    data_preco date,
    entrada decimal(10,2),
    parcelas varchar(50),
    preco_vista decimal(10,2),
    ipva_estimado decimal(10,2),
    status varchar(30),
    foreign key (id_carro_fk) references Carros(id_carro)
);

create table Documento_Car (
    id_documento int auto_increment primary key,
    nome_documento varchar(100)
);

create table Documentacao_Cli (
    id_documentacao int auto_increment primary key,
    id_cliente_fk int,
    id_documento_fk int,
    conferido varchar(200),
    data_conferencia datetime,
    foreign key (id_cliente_fk) references Clientes(id_cliente),
    foreign key (id_documento_fk) references Documento_Car(id_documento)
);

create table Chamados_Suporte (
    id_chamado int auto_increment primary key,
    id_cliente_fk int,
    tipo_suporte varchar(50),
    mensagem varchar(200),
    data_chamado datetime,
    status varchar(30),
    foreign key (id_cliente_fk) references Clientes(id_cliente)
);

create table Vendas (
    id_venda int auto_increment primary key,
    id_cliente_fk int,
    id_carro_fk int,
    data_venda date,
    valor_venda decimal(10,2),
    forma_pagamento varchar(50),
    status_venda varchar(30),
    foreign key (id_cliente_fk) references Clientes(id_cliente),
    foreign key (id_carro_fk) references Carros(id_carro)
);

create table Manutencoes (
    id_manutencao int auto_increment primary key,
    id_carro_fk int,
    tipo_servico varchar(100),
    descricao varchar(500),
    data_agendada date,
    valor_estimado decimal(10,2),
    status varchar(30),
    foreign key (id_carro_fk) references Carros(id_carro)
);

insert into Clientes
values (default, "Jão do Parangolé", "05404343254", "69 994324212", "joaopereira@gmail.com", "Fusca", "finalizado", "Preferência pela cor azul");

insert into Clientes
values (default, "Maria Rosilda", "12345678901", "69 992345678", "mariarosilda@gmail.com", "Civic", "em andamento", "Quer ver opções de financiamento");

insert into Clientes
values (default, "Carlos Roberto", "98765432100", "69 998765432", "carlosroberto@gmail.com", "Corolla", "em andamento", "Já fez a análise do veículo");

insert into Clientes
values (default, "Ana Banana", "45678912300", "69 991234567", "anabanana@gmail.com", "Onix", "finalizado", "Procura carro econômico");

insert into Clientes
values (default, "Pedro Pedra", "78912345600", "69 995678123", "pedropedra@gmail.com", "Hilux", "finalizado", "Tem uma caminhonete para dar na troca");

insert into Clientes
values (default, "Lucas Ferreira", "32165498700", "69 999111222", "lucas.ferreira@email.com", "Compass", "novo", "Quer agendar um test drive");

insert into Clientes
values (default, "Juliana Alves", "65498732100", "69 999222333", "juliana.alves@email.com", "HB20", "em andamento", "Analisando financiamento");

insert into Clientes
values (default, "Bruno Souza", "14725836900", "69 999333444", "bruno.souza@email.com", "Toro", "novo", "Possui carro para troca");

insert into Clientes
values (default, "Fernanda Lima", "25836914700", "69 999444555", "fernanda.lima@email.com", "Kwid", "em andamento", "Aguardando retorno do banco");

insert into Clientes
values (default, "Ricardo Silva", "36914725800", "69 999555666", "ricardo.silva@email.com", "Ranger", "finalizado", "Compra concluída");

insert into Carros
values (default, "Volkswagen", "Fusca", "ABC-1A01", 1999, "Clássico", "Azul", 85000, 28000.00, 8000.00, "48x R$ 625,00", "vendido");

insert into Carros
values (default, "Honda", "Civic", "DEF-2B02", 2020, "Sedan", "Preto", 54000, 108000.00, 28000.00, "60x R$ 1.333,33", "vendido");

insert into Carros
values (default, "Toyota", "Corolla", "GHI-3C03", 2022, "Sedan", "Branco", 41000, 132000.00, 32000.00, "60x R$ 1.666,67", "manutencao");

insert into Carros
values (default, "Chevrolet", "Onix", "JKL-4D04", 2023, "Hatch", "Prata", 27000, 82000.00, 22000.00, "48x R$ 1.250,00", "vendido");

insert into Carros
values (default, "Toyota", "Hilux", "MNO-5E05", 2021, "Picape", "Cinza", 68000, 218000.00, 58000.00, "60x R$ 2.666,67", "vendido");

insert into Carros
values (default, "Renault", "Kwid", "PQR-6F06", 2023, "Hatch", "Branco", 32000, 61000.00, 15000.00, "48x R$ 958,33", "manutencao");

insert into Carros
values (default, "Jeep", "Compass", "STU-7G07", 2022, "SUV", "Cinza", 46000, 138000.00, 38000.00, "60x R$ 1.666,67", "disponivel");

insert into Carros
values (default, "Hyundai", "HB20", "VWX-8H08", 2024, "Hatch", "Vermelho", 18000, 79000.00, 20000.00, "48x R$ 1.229,17", "disponivel");

insert into Carros
values (default, "Fiat", "Toro", "YZA-9I09", 2021, "Picape", "Preto", 71000, 116000.00, 32000.00, "60x R$ 1.400,00", "manutencao");

insert into Carros
values (default, "Ford", "Ranger", "BCD-0J10", 2020, "Picape", "Prata", 88000, 175000.00, 50000.00, "60x R$ 2.083,33", "vendido");

insert into Precos
values (default, 1, "2026-08-01", 8000.00, "48x R$ 625,00", 28000.00, 900.00, "vendido");

insert into Precos
values (default, 2, "2026-08-02", 28000.00, "60x R$ 1.333,33", 108000.00, 3200.00, "vendido");

insert into Precos
values (default, 3, "2026-08-03", 32000.00, "60x R$ 1.666,67", 132000.00, 3800.00, "manutencao");

insert into Precos
values (default, 4, "2026-08-04", 22000.00, "48x R$ 1.250,00", 82000.00, 2500.00, "vendido");

insert into Precos
values (default, 5, "2026-08-05", 58000.00, "60x R$ 2.666,67", 218000.00, 6200.00, "vendido");

insert into Precos
values (default, 6, "2026-08-06", 15000.00, "48x R$ 958,33", 61000.00, 1800.00, "manutencao");

insert into Precos
values (default, 7, "2026-08-07", 38000.00, "60x R$ 1.666,67", 138000.00, 4100.00, "disponivel");

insert into Precos
values (default, 8, "2026-08-08", 20000.00, "48x R$ 1.229,17", 79000.00, 2300.00, "disponivel");

insert into Precos
values (default, 9, "2026-08-09", 32000.00, "60x R$ 1.400,00", 116000.00, 3500.00, "manutencao");

insert into Precos
values (default, 10, "2026-08-10", 50000.00, "60x R$ 2.083,33", 175000.00, 5300.00, "vendido");

insert into Documento_Car
values (default, "CNH ou RG do comprador");

insert into Documento_Car
values (default, "CPF regularizado");

insert into Documento_Car
values (default, "Comprovante de residência");

insert into Documento_Car
values (default, "Comprovante de renda");

insert into Documento_Car
values (default, "Contrato assinado");

insert into Documento_Car
values (default, "Laudo de vistoria");

insert into Documentacao_Cli
values (default, 1, 1, "sim", "2026-08-01 10:30:00");

insert into Documentacao_Cli
values (default, 2, 2, "sim", "2026-08-02 11:15:00");

insert into Documentacao_Cli
values (default, 3, 3, "pendente", null);

insert into Documentacao_Cli
values (default, 4, 4, "sim", "2026-08-04 14:20:00");

insert into Documentacao_Cli
values (default, 5, 5, "sim", "2026-08-05 16:00:00");

insert into Documentacao_Cli
values (default, 6, 1, "sim", "2026-08-06 10:30:00");

insert into Documentacao_Cli
values (default, 7, 2, "sim", "2026-08-07 11:15:00");

insert into Documentacao_Cli
values (default, 8, 3, "pendente", null);

insert into Documentacao_Cli
values (default, 9, 4, "sim", "2026-08-09 14:20:00");

insert into Documentacao_Cli
values (default, 10, 5, "sim", "2026-08-10 15:00:00");

insert into Chamados_Suporte
values (default, 1, "duvida", "Queria saber como funciona o financiamento", "2026-08-01 09:30:00", "aberto");

insert into Chamados_Suporte
values (default, 2, "documentacao", "Faltou enviar um documento", "2026-08-02 10:45:00", "em andamento");

insert into Chamados_Suporte
values (default, 3, "pagamento", "Quero mudar a forma de pagamento", "2026-08-03 13:20:00", "aberto");

insert into Chamados_Suporte
values (default, 4, "veiculo", "Quero marcar uma avaliacao", "2026-08-04 15:10:00", "resolvido");

insert into Chamados_Suporte
values (default, 5, "duvida", "Quando o carro fica disponivel", "2026-08-05 16:40:00", "aberto");

insert into Chamados_Suporte
values (default, 6, "visita", "Gostaria de agendar uma visita para conhecer o Compass", "2026-08-06 09:00:00", "aberto");

insert into Chamados_Suporte
values (default, 7, "financiamento", "Quais documentos preciso para financiar o HB20?", "2026-08-07 11:30:00", "em andamento");

insert into Chamados_Suporte
values (default, 8, "veiculo", "A Toro passou por revisão recentemente?", "2026-08-08 14:10:00", "resolvido");

insert into Chamados_Suporte
values (default, 9, "manutencao", "Quando o Kwid estará disponível novamente?", "2026-08-09 16:00:00", "aberto");

insert into Chamados_Suporte
values (default, 10, "documentacao", "Quero receber a documentação da Ranger", "2026-08-10 10:45:00", "resolvido");

insert into Manutencoes
values (default, 3, "Revisão preventiva", "Troca de óleo, filtros e inspeção geral", "2026-09-22", 850.00, "agendada");

insert into Manutencoes
values (default, 6, "Sistema de freios", "Troca das pastilhas e revisão dos discos", "2026-09-24", 1200.00, "em andamento");

insert into Manutencoes
values (default, 9, "Alinhamento e suspensão", "Revisão da suspensão e alinhamento completo", "2026-09-27", 950.00, "agendada");

insert into Vendas
values (default, 1, 1, "2026-08-01", 28000.00, "a vista", "concluida");

insert into Vendas
values (default, 2, 2, "2026-08-02", 108000.00, "financiamento", "concluida");

insert into Vendas
values (default, 3, 3, "2026-08-03", 132000.00, "financiamento", "em andamento");

insert into Vendas
values (default, 4, 4, "2026-08-04", 82000.00, "a vista", "concluida");

insert into Vendas
values (default, 5, 5, "2026-08-05", 218000.00, "financiamento", "concluida");

insert into Vendas
values (default, 6, 7, "2026-08-11", 138000.00, "financiamento", "em andamento");

insert into Vendas
values (default, 7, 8, "2026-08-12", 79000.00, "a vista", "em andamento");

insert into Vendas
values (default, 10, 10, "2026-08-13", 175000.00, "financiamento", "concluida");

select * from Clientes;
select * from Carros;
select * from Precos;
select * from Manutencoes;
select * from Vendas;