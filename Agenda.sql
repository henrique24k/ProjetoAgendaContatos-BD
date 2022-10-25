create database agenda;
use agenda;

create table tbcontato(
codcontato int not null primary	key auto_increment
, nome varchar(100)
, telefone char(14)
, celular char(15)
, email varchar(100)
);

insert into tbcontato(nome, telefone, celular, email)
values('Henrique', '(11) 2499-2072', '(11) 98528-9052', 'henriquevieira431@@gmail.com');

select * from tbcontato;

create table tblogin( 
login varchar(30) not null primary key,
senha varchar(30) not null
);

insert into tblogin(login,senha)values('adm', '123');
insert into tblogin(login,senha)values('root', 'root');

select * from tblogin;


