
#bd mecanica 8.0
create database bd_mecanica_8;
use bd_mecanica_8;

create table estado (
id_est int not null primary key auto_increment,
nome_est varchar (200) not null,
sigla_est varchar (2)
);

insert into estado values (null, 'acre', 'ac');
insert into estado values (null, 'alagoas', 'al');
insert into estado values (null, 'amapá','ap');
insert into estado values (null, 'amazonas','am');
insert into estado values (null, 'bahia','ba');
insert into estado values (null, 'ceara','ce');
insert into estado values (null, 'distrito federal','df');
insert into estado values (null, 'espírito santo','es');
insert into estado values (null, 'goiás','go');
insert into estado values (null, 'maranhão','ma');
insert into estado values (null, 'mato grosso','mt');
insert into estado values (null, 'mato grosso do sul','ms');
insert into estado values (null, 'minas gerais','mg');
insert into estado values (null, 'pará','pa');
insert into estado values (null, 'paraíba','pb');
insert into estado values (null, 'paraná','pr');
insert into estado values (null, 'pernambuco','pe');
insert into estado values (null, 'piauí','pi');
insert into estado values (null, 'rio de janeiro','rj');
insert into estado values (null, 'rio grande do norte','rn');
insert into estado values (null, 'rio grande do sul','rs');
insert into estado values (null, 'rondônia','ro');
insert into estado values (null, 'roraima','rr');
insert into estado values (null, 'santa catarina','sc');
insert into estado values (null, 'são paulo','sp');
insert into estado values (null, 'sergipe','se');
insert into estado values (null, 'tocantins','to');

create table cidade (
id_cid int not null primary key auto_increment,
nome_cid varchar (200) not null,
id_est_fk int,
foreign key (id_est_fk) references estado (id_est)
);

insert into cidade values (null, 'ji-paraná', 22);
insert into cidade values (null, 'porto velho', 22);
insert into cidade values (null, 'vilhena', 22);
insert into cidade values (null, 'ariquemes', 22);
insert into cidade values (null, 'jaru', 22);
insert into cidade values (null, 'guajará-mirim ', 22);
insert into cidade values (null, 'colorado do oeste', 22);
insert into cidade values (null, 'ouro preto do oeste', 22);
insert into cidade values (null, 'pimenta bueno', 22);
insert into cidade values (null, 'rio branco', 1);
insert into cidade values (null, 'são paulo', 25);
insert into cidade values (null, 'manaus', 4);

create table endereco (
id_end integer not null primary key auto_increment,
rua_end varchar (300),
numero_end integer,
bairro_end varchar (100),
id_cid_fk int not null,
foreign key (id_cid_fk) references cidade (id_cid)
); 

insert into endereco values (null, 'av. brasil', 111, 'nova brasília', 1);
insert into endereco values (null, 'av. marechal rondon', 1245, 'centro', 1);
insert into endereco values (null, 'rua dr. telma rios', 1174, 'colina park i', 1);
insert into endereco values (null, 'av. aracaju', 911, 'bnh', 1);
insert into endereco values (null, 'rua 07 de setembro', 121,'centro',  1);
insert into endereco values (null, 'rua mato grosso', 887, 'dom bosco', 1);
insert into endereco values (null, 'av. jorge teixeira', 1589, 'centro', 2);
insert into endereco values (null, 'av. paulista', 989, 'centro', 11);
insert into endereco values (null, 'travessa dos mineiros', 456, 'centro', 4);
insert into endereco values (null, 'av. monte castelo', 555, 'jardim dos migrantes', 1);
insert into endereco values (null, 'av. aracaju', 5111, 'nova brasilia', 1);
insert into endereco values (null, 'av. monte castelo', 9999, 'jardim dos migrantes', 1);
insert into endereco values (null, 'rua x', 12, 'jardim dos migrantes', 1);
insert into endereco values (null, 'k-0', 522, 'são francisco', 1);
insert into endereco values (null, 'av. monte castelo', 11229, 'jardim dos migrantes', 1);

create table sexo (
id_sex int not null primary key auto_increment,
nome_sex varchar (100) not null
);

insert into sexo values (null, 'masculino');
insert into sexo values (null, 'feminino');

create table cliente (
id_cli integer not null primary key auto_increment,
nome_cli varchar (200) not null,
estado_civil_cli varchar (50),
cpf_cli varchar (20) not null,
rg_cli varchar (30),
data_nascimento_cli date,
renda_familiar_cli float,
telefone_cli varchar (50),
celular_cli varchar (50) not null,
id_sex_fk integer not null,
id_end_fk integer not null,
foreign key (id_sex_fk) references sexo (id_sex),
foreign key (id_end_fk) references endereco (id_end)
);

insert into cliente values (null, 'rodrigo hilbert', 'casado', '111.111.111-11', '54654 sesdec', '1987-06-30', 10000.00, '69 84085712', '69 84111111', 1, 3);
insert into cliente values (null, 'tiago lacerda', 'casado', '111.111.111-22', '54654 sesdec',  '1965-1-1', 456454.45, '', '', 1, 8);
insert into cliente values (null, 'tom cruise', 'solteiro', '111.111.111-33', '48877 sesdec',  '1950-05-30', 0.00, '11 454546511', '', 1, 1);
insert into cliente values (null, 'josé pereiro da silva', 'casado', '222.222.222-88', '8888888 spp',  '1990-11-12', 900.00, '69 88998899', '69 4444 4444', 1, 4);
insert into cliente values (null, 'maria de jesus dos santos', 'solteira', '554.454.444-99', '99999 sesdec',  '1993-06-21', 3000.00, '69 3421 5511', '69 99111111', 2, 3);
insert into cliente values (null, 'camila de oliveira', 'casada', '987.123.654-55', '8889999 sesdec',  '2000-12-12', 5450.00, '69 3421 1122', '69 9999 7788', 2, 10);
insert into cliente values (null, 'marcos araujo de souza', 'casado', '654.789.123-88', '998877 sesdec',  '1970-01-01', 6845.00, '69 84085712', '69 84111111', 1, 9);
insert into cliente values (null, 'cleiton batista ferraz', 'solteiro', '321.111.222-44', '1234312 sesdec',  '1982-07-30', 4199.00, '69 3421 2211', '69 84118811', 1, 2);
insert into cliente values (null, 'eliana da cruz', 'solteira', '988.235.654-54', '12345 sesdec',  '1978-11-11', 3250.00, '69 3421 9999', '69 84118811', 2, 5);
insert into cliente values (null, 'igor garcia da silva', 'solteiro', '123.445.888-99', '999992 sesdec',  '1989-12-30', 9600.00, '69 3421 1123', '69 84118811', 1, 11);
insert into cliente values (null, 'jackson henrique da silva bezerra', 'casado', '529.562.612-15', '880075 sesdec',  '1987-06-30', 11000.00, '', '69 84085712', 1, 3);
insert into cliente values (null, 'jaqueline leão pereira', 'casada', '522.222.153-15', '12315 sesdec', '1993-06-21', 11000.00, null, '69 984210921', 2, 3);
insert into cliente values (null, 'gleicy borgio', 'casada', '126.777.888-99', null, null, 5000.00, null, '69 84888899', 2, 11);
insert into cliente values (null, 'diego da silva bezerra', 'solteiro', '111.987.123-55', null, null, 3999.99, null, '69 88997722', 1, 15);
insert into cliente values (null, 'murilo benicio', 'casado', '321.123.321-55', null, null, 2450.80, null, '11 2121 1111', 1, 8);

create table carro (
id_car int primary key not null auto_increment,
modelo_car varchar (100) not null,
cor_car varchar (50) not null,
portas_car varchar (50),
placa_car varchar (50) not null,
marca_car varchar (50) not null,
id_cli_fk int not null,
foreign key (id_cli_fk) references cliente (id_cli)
);

insert into carro values (null, 'gol 1.0', 'preto', '4 portas', 'ndr 2815', 'volkswagen', 1);
insert into carro values (null, 'palio 1.0', 'branco', '4 portas', 'nea 1231', 'fiat', 2);
insert into carro values (null, 'gol 1.0', 'preto', '4 portas', 'wat 1254', 'volkswagen', 3);
insert into carro values (null, 's-10', 'prata', '2 portas', 'eae 2815', 'gm', 4);
insert into carro values (null, 'celta spirit 1.0', 'branco', '4 portas', 'ndd 2815', 'gm', 5);
insert into carro values (null, 'celta life 1.0', 'vermelho', '2 portas', 'mra 1288', 'gm', 6);
insert into carro values (null, 'hilux 2.4', 'prata', '4 portas', 'rtu 3498', 'toyota', 7);
insert into carro values (null, 'prisma ltz', 'branco', '4 portas', 'oip 1231', 'gm', 8);
insert into carro values (null, 'hilux 2.4', 'branco', '4 portas', 'asd 1234', 'toyota', 9);
insert into carro values (null, 'hb-20', 'preto', '4 portas', 'ndt 1155', 'hunday', 10);
insert into carro values (null, 'hilux 2.4', 'prata', '4 portas', 'noo 2010', 'toyota', 1);
insert into carro values (null, 'gol 1.6', 'branco', '4 portas', 'nnd 2066', 'volkswagen', 7);
insert into carro values (null, 'cruze ltz 1.8', 'preto', '4 portas', 'ndm 2819', 'gm', 11);
insert into carro values (null, 'cruze ltz 1.8', 'branco', '4 portas', 'nra 2233', 'gm', 5);
insert into carro values (null, 'celta spirit 1.0', 'branco', '4 portas', 'ndr 2233', 'gm', 12);

create table departamento (
id_dep integer not null primary key auto_increment,
nome_dep varchar (100),
descricao_dep varchar (300)
);

insert into departamento values (null, 'vendas', 'venda de peças e serviços');
insert into departamento values (null, 'financeiro', 'controle financeiro e caixa');
insert into departamento values (null, 'entrega', 'entregar peças');
insert into departamento values (null, 'mecânica', 'realizar manutenção em veículos');
insert into departamento values (null, 'administração', 'gestão da empresa');

create table funcionario (
id_func integer not null primary key auto_increment,
nome_func varchar (200) not null,
cpf_func varchar (20) not null,
rg_func varchar (20),
data_nascimento_func date,
salario_func double not null,
telefone_func varchar (50),
celular_func varchar (50) not null,
funcao_func varchar (50) not null,
id_sex_fk integer not null,
id_dep_fk integer not null,
id_end_fk integer not null,
foreign key (id_sex_fk) references sexo (id_sex),
foreign key (id_dep_fk) references departamento (id_dep),
foreign key (id_end_fk) references endereco (id_end)
);

insert into funcionario values (null, 'joão batista', '123.544.311-99', '22222 sesdec', '1988-10-30', 5000.00, '', '69 84111155', 'gerente', 1, 5, 3);
insert into funcionario values (null, 'marcos garcia souza', '565.888.988-88', '64444 sesdec', '1965-1-20', 45000.00, '', '', 'vendedor', 1, 1, 8);
insert into funcionario values (null, 'leticia de jesus', '998.999.789-55', '46666 sesdec', '1990-05-23', 1500.00, '11 454546511', '', 'vendedora', 2, 1, 10);
insert into funcionario values (null, 'mateus solano ', '522.222.232-08', '65655 spp', '1990-11-30', 900.00, '69 8855 5544', '69 5555 4444', 'mecanico', 1, 4, 4);
insert into funcionario values (null, 'roger da silva', '123.589.978-77', null, '1987-11-11', 1100.00, null, '69 9988 7788', 'mecanico', 1, 4, 11);
insert into funcionario values (null, 'karina quadros', '987.987.788-88', null, '1985-11-22', 1000.50, null, '69 8888 7777', 'caixa', 2, 2, 1);
insert into funcionario values (null, 'isaias queiroz', '123.121.321-88', '87788 sesdec', '1980-11-30', 2000.00, null, '69 8877 88881', 'entregador', 1, 3, 7);

create table fornecedor (
id_forn integer not null primary key auto_increment,
razao_social_forn varchar (200),
nome_fantasia_forn varchar (100),
representante_forn varchar (100),
contato_forn varchar (300),
id_end_fk integer not null,
foreign key (id_end_fk) references endereco (id_end)
);

insert into fornecedor values (null, 'gm motors ltda', 'chevrolet gm', 'tony', null, 5);
insert into fornecedor values (null, 'fiat ltda', 'fiat', 'fabio', '3421 5588', 1);
insert into fornecedor values (null, 'toyota ltda', 'toyota', 'marcos', '3422 7246', 2);
insert into fornecedor values (null, 'volkswagen ltda', 'volkswagem', 'nilson', null, 3);
insert into fornecedor values (null, 'hunday ltda', 'hynday', 'marcos', '3421 7897', 3);
insert into fornecedor values (null, 'eletrobrás brasil', 'ceron', 'governo', '3423 1234', 10);
insert into fornecedor values (null, 'companhia de agua e esgoto de rondonia', 'caerd', 'maria', null, 11);

create table produto (
id_prod int primary key not null auto_increment,
descricao_prod varchar (50) not null,
marca_prod varchar (50),
quant_prod int,
valor_prod double,
tamanho_prod varchar (50),
tipo_prod varchar (50)
);

insert into produto values (null, 'farol civic 2020 ld', 'honda', 5, 3500.00, 'médio', 'led');
insert into produto values (null, 'pneu aro 17 225/45', 'pirelli', 20, 999.00, 'médio', 'borracha');
insert into produto values (null, 'farol gol g7 2020 le', 'volkswagen', 10, 1500.99, 'médio', 'vidro');
insert into produto values (null, 'farol gol g7 2020 ld', 'ford', 10, 1500.99, 'médio', 'vidro');
insert into produto values (null, 'capô uno 2018', 'fiat', 5, 900.00, 'grande', 'metal');
insert into produto values (null, 'volante sportivo cruze 2021', 'chevrolet', 3, 4000.00, 'médio', 'borracha');
insert into produto values (null, 'difusor ar condicionado celta 2011 le', 'chevrolet', 10, 50.00, 'médio', 'plastico');
insert into produto values (null, 'parachoque s10 2020', 'chevrolet', 10, 2500.00, 'médio', 'fibra');
insert into produto values (null, 'parachoque celta 2020', 'chevrolet', 10, 1000.00, 'médio', 'fibra');
insert into produto values (null, 'roda aro 15', 'fiat', 4, 1000.00, 'médio', 'metal');
insert into produto values (null, 'porta hillux 2021 ld', 'toyota', 4, 5000.00, 'médio', 'metal');
insert into produto values (null, 'escape gol 2021', 'volkswagen', 10, 500.00, 'médio', 'metal');
insert into produto values (null, 'bico injetor motor 1.6 uno 2020', 'fiat', 5, 500.00, 'médio', 'metal');
insert into produto values (null, 'lanterna s10 2020 ld', 'chevrolet', 10, 1800.00, 'médio', 'plastico');
insert into produto values (null, 'lanterna s10 2020 le', 'chevrolet', 10, 1800.00, 'médio', 'plastico');
insert into produto values (null, 'escape cela 2008', 'chevrolet', 10, 500.00, 'médio', 'metal');
insert into produto values (null, 'difusor ar condicionado celta 2011 ld', 'chevrolet', 10, 50.00, 'médio', 'plastico');
insert into produto values (null, 'farol civic 2020 le', 'honda', 5, 3500.00, 'médio', 'led');
insert into produto values (null, 'grade difusora civic 2021', 'honda', 3, 3200.00, 'médio', 'metal');
insert into produto values (null, 'motor 1.8 cruze 2021', 'chevrolet', 1, 18500.00, 'grande', 'metal');

create table servico (
id_serv int not null primary key auto_increment,
descricao_serv varchar(300),
tipo_serv varchar (100),
valor_serv float not null,
tempo_serv time
);

insert into servico values (null, 'funilaria de parachoque traseiro', 'conserto', 350.00, '04:00:00');
insert into servico values (null, 'rebaixar suspensao dianteira carro', 'estética', 400.50, '01:10:00');
insert into servico values (null, 'envelopar veiculo com pelicula preto fosco', 'pintura', 1900.00, '08:00:00');
insert into servico values (null, 'trocar volante', 'conserto', 49.99, '00:50:00');
insert into servico values (null, 'instalacao de acessório interno', 'estética', 49.99, '00:50:00');
insert into servico values (null, 'trocar pneu traseiro', 'conserto', 30.80, '00:30:00');
insert into servico values (null, 'instalar jogo de rodas', 'conserto', 100.00, '00:30:00');
insert into servico values (null, 'pintar veículo sedan', 'pintura', 5000.00, '12:00:00');
insert into servico values (null, 'substituição de suspensão dianteira', 'conserto', 299.90, '03:00:00');
insert into servico values (null, 'funilaria de parachoque dianteiro', 'conserto', 350.00, '04:00:00'); 

create table compra (
id_comp integer not null primary key auto_increment,
data_comp date,
valor_total_comp double,
forma_pagamento_comp varchar (100),
id_func_fk integer not null,
id_forn_fk integer not null,
foreign key (id_func_fk) references funcionario (id_func),
foreign key (id_forn_fk) references fornecedor (id_forn)
);

insert into compra values (null, '2018-01-23', 4654.50, '30 dias', 1, 1);
insert into compra values (null, '2019-02-10', 45464.00, '30 dias', 1, 2);
insert into compra values (null, '2019-06-30', 5045.90, 'vista', 1, 3);
insert into compra values (null, '2020-09-23', 2154.79, '60 dias', 1, 4);

create table itens_compra (
id_itc integer not null primary key auto_increment,
quant_itc integer not null,
valor_itc float not null,
id_prod_fk integer not null,
id_comp_fk integer not null,
foreign key (id_prod_fk) references produto (id_prod),
foreign key (id_comp_fk) references compra (id_comp)
);


insert into itens_compra values (null, 5, 5.55, 1, 1);
insert into itens_compra values (null, 12, 10.80, 2, 1);
insert into itens_compra values (null, 9, 19.99, 3, 1);
insert into itens_compra values (null, 2, 6.55, 4, 1);
insert into itens_compra values (null, 10, 10.00, 5, 1);

insert into itens_compra values (null, 5, 5.00, 6, 2);
insert into itens_compra values (null, 20, 20.50, 7, 2);
insert into itens_compra values (null, 15, 18.90, 8, 2);
insert into itens_compra values (null, 5, 30.60, 9, 2);
insert into itens_compra values (null, 30, 7.99, 10, 2);

insert into itens_compra values (null, 10, 12.90, 11, 3);
insert into itens_compra values (null, 20, 18.90, 12, 3);
insert into itens_compra values (null, 5, 120.00, 13, 3);
insert into itens_compra values (null, 2, 220.80, 14, 3);
insert into itens_compra values (null, 8, 127.70, 15, 3);

insert into itens_compra values (null, 10, 11.80, 16, 4);
insert into itens_compra values (null, 5, 124.90, 17, 4);
insert into itens_compra values (null, 22, 12.90, 18, 4);
insert into itens_compra values (null, 15, 34.80, 19, 4);
insert into itens_compra values (null, 12, 48.00, 20, 4);

create table caixa (
id_cai integer not null primary key auto_increment,
data_abertura_cai date not null,
data_fechamento_cai date,
saldo_inicial_cai double not null,
troco_cai double,
valor_creditos_cai double,
valor_debitos_cai double,
saldo_final_cai double,
status_cai varchar (100) not null
);

insert into caixa values (null, '2021-08-19', '2019-08-20', 0, 100.00, 500.00, 0, 600.00, 'fechado');
insert into caixa values (null, '2021-08-20', null, 0, 0.00, 0, 0, 0, 'aberto');

create table venda (
id_vend integer not null primary key auto_increment,
data_vend date,
valor_total_vend double not null,
desconto_vend double,
forma_recebimento_vend varchar (50),
parcelas_vend int,
id_func_fk integer not null,
id_cli_fk integer not null,
foreign key (id_func_fk) references funcionario (id_func),
foreign key (id_cli_fk) references cliente (id_cli)
);

insert into venda values (null, '2019-01-30', 454.99, 0, 'vista', 1, 2, 1);
insert into venda values (null, '2019-11-30', 4564.99, 10.50, 'vista', 1,  2, 2);
insert into venda values (null, '2020-09-23', 500.80, 5.80, 'vista', 1, 3, 8);

create table itens_venda (
id_itv integer not null primary key auto_increment,
quant_itv integer not null,
valor_itv float not null,
id_prod_fk integer not null,
id_vend_fk integer not null,
foreign key (id_prod_fk) references produto (id_prod),
foreign key (id_vend_fk) references venda (id_vend)
);

insert into itens_venda values (null, 2, 12.50, 1, 1);
insert into itens_venda values (null, 1, 45.45, 3, 1);
insert into itens_venda values (null, 1, 89.77, 5, 1);
insert into itens_venda values (null, 3, 456.75, 4, 1);

insert into itens_venda values (null, 1, 45.05, 10, 2);
insert into itens_venda values (null, 4, 45.77, 4, 2);
insert into itens_venda values (null, 3, 99.87, 7, 2);
insert into itens_venda values (null, 9, 50.46, 1, 2);

insert into itens_venda values (null, 10, 78.77, 9, 3);
insert into itens_venda values (null, 2, 65.79, 2, 3);
insert into itens_venda values (null, 3, 20.57, 8, 3);
insert into itens_venda values (null, 1, 789.77, 1, 3);

create table recebimento (
id_rec integer not null primary key auto_increment,
data_vencimento_rec date,
valor_rec double,
parcela_rec varchar(100),
status_rec varchar (100),
forma_recebimento_rec varchar (100),
data_recebimento_rec date,
id_func_fk integer,
id_cai_fk integer,
id_vend_fk integer not null,
foreign key (id_func_fk) references funcionario (id_func),
foreign key (id_cai_fk) references caixa (id_cai),
foreign key (id_vend_fk) references venda (id_vend)
);

insert into recebimento values (null, '2020-01-14', 454.00, '1/1', 'Pago', 'Dinheiro', '2021-02-14', 6, 1, 1);
insert into recebimento values (null, '2020-01-20', 4546.00, '1/2', 'Pago', 'Dinheiro', '2021-02-20', 6, 1, 2);
insert into recebimento values (null, '2020-01-30', 1234.79, '2/2', 'Pago', 'Cartão de Crédito', '2021-03-30', 6, 1, 3);

create table despesa (
id_desp integer not null primary key auto_increment,
descricao_desp varchar (200),
valor_desp double,
data_desp date,
numero_documento_desp varchar (300),
id_forn_fk int,
foreign key (id_forn_fk) references fornecedor (id_forn)
);

insert into despesa values (null, 'conta de agua de janeiro/2017', 150.50, '2021-01-31', '212312131311', 7);
insert into despesa values (null, 'conta de luz de janeiro/2017', 550.90, '2021-02-25', '485445646777', 6);

create table pagamento (
id_pag integer not null primary key auto_increment,
data_vencimento_pag date,
valor_pag float,
parcela_pag varchar (100),
status_pag varchar (100),
forma_pagamento_pag varchar (100),
data_pagamento_pag date,
id_func_fk integer,
id_cai_fk integer,
id_desp_fk integer,
id_comp_fk integer,
foreign key (id_func_fk) references funcionario (id_func),
foreign key (id_cai_fk) references caixa (id_cai),
foreign key (id_desp_fk) references despesa (id_desp),
foreign key (id_comp_fk) references compra (id_comp)
);

insert into pagamento values (null, '2020-09-01', 4544.77, '1/1', 'Pago', 'dinheiro', '2020-10-01', 6, 1, null, 1);
insert into pagamento values (null, '2020-09-01', 787.99, '1/1', 'Pago', 'dinheiro', '2020-10-01',6, 2, null, 2);
insert into pagamento values (null, '2020-09-01', 477.99, '1/1', 'Pago', 'dinheiro', '2020-10-01', 6, 1, null, 3);
insert into pagamento values (null, '2020-09-01', 1234.99, '1/1', 'Pago', 'dinheiro', '2020-10-01', 6, 2, null, 4);
insert into pagamento values (null, '2020-09-01', 45.77, '1/1', 'Pago', 'débito conta', '2020-10-01', 6, 2, 1, null);
insert into pagamento values (null, '2020-09-01', 100.90, '1/1', 'Pago', 'débito conta', '2020-10-01', 6, 2, 2, null);

#1 selecione o nome e o cpf de cliente e o nome do estado onde ele mora
SELECT cliente.nome_cli, cliente.cpf_cli, estado.nome_est
FROM cliente
INNER JOIN endereco ON cliente.id_end_fk = endereco.id_end
INNER JOIN cidade ON endereco.id_cid_fk = cidade.id_cid
INNER JOIN estado ON cidade.id_est_fk = estado.id_est;

#2 selecione o nome do vendedor e o nome e valor dos produtos que ele ja vendeu todos os vendedores devem ser listados 
SELECT funcionario.nome_func, produto.descricao_prod, itens_venda.valor_itv
FROM funcionario
LEFT JOIN venda ON funcionario.id_func = venda.id_func_fk
LEFT JOIN itens_venda ON venda.id_vend = itens_venda.id_vend_fk
LEFT JOIN produto ON itens_venda.id_prod_fk = produto.id_prod
WHERE funcionario.funcao_func IN ('vendedor', 'vendedora');

#3 mostre o nome e valor do produto mais barato
SELECT descricao_prod, valor_prod
FROM produto
WHERE valor_prod = (SELECT MIN(valor_prod) FROM produto);

#4 crie uma visão que mostre os dads das vendas e o seus recebimentos. depois selecione a visão e mostre somente as vendas com recebimento em diateiro e registros em janeiro
CREATE VIEW vw_vendas_recebimentos AS
SELECT venda.id_vend,
       venda.data_vend,
       venda.valor_total_vend,
       venda.desconto_vend,
       venda.forma_recebimento_vend,
       recebimento.id_rec,
       recebimento.data_vencimento_rec,
       recebimento.valor_rec,
       recebimento.parcela_rec,
       recebimento.status_rec,
       recebimento.forma_recebimento_rec,
       recebimento.data_recebimento_rec
FROM venda
INNER JOIN recebimento ON venda.id_vend = recebimento.id_vend_fk;

SELECT *
FROM vw_vendas_recebimentos
WHERE forma_recebimento_rec = 'Dinheiro'
AND MONTH(data_recebimento_rec) = 1;