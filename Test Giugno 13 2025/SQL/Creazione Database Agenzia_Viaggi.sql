create database agenzia_viaggi;

create table paese
(
	paese_id int auto_increment primary key,
    nome_paese varchar(100) unique not null
);

create table citta
(
	citta_id int auto_increment primary key,
    nome_citta varchar(100) unique not null,
    paese_id int,
    foreign key (paese_id) references paese (paese_id)
);

create table volo
(
	volo_id int auto_increment primary key,
    partenza_id int,
    foreign key (partenza_id) references citta (citta_id),
    destinazione_id int,
    foreign key (destinazione_id) references citta (citta_id),
    numero_posti int,
    costo decimal(6,2) not null
);

create table utente
(
	utente_id int auto_increment primary key,
    ruolo char not null default 'u',
    username varchar(255) unique not null,
    email varchar(255) unique not null,
    password varchar(255) not null,
    telefono varchar(15) unique not null
);

create table prenotazione
(
	prenotazione_id int auto_increment primary key,
    data_prenotazione datetime default current_timestamp,
    utente_id int,
    foreign key (utente_id) references utente (utente_id),
    volo_id int,
    foreign key (volo_id) references volo (volo_id)
);

create table pagamento
(
	pagamento_id int auto_increment primary key,
    foreign key (pagamento_id) references prenotazione (prenotazione_id),
    utente_id int,
    foreign key (utente_id) references utente (utente_id),
    importo decimal(6,2) not null,
    data_pagamento datetime default current_timestamp
);