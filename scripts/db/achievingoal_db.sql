/*
use master;
go

drop database achievingoal_db;
go
*/

create database achievingoal_db collate Latin1_General_CI_AI;
go

use achievingoal_db;
go

-- ############################
-- ###   common             ###
-- ############################

create schema common;
go

-- groups

create table common.groups (
	id int identity(1, 1) not null,
	uuid uniqueidentifier not null default newid(),
	created_at datetimeoffset not null default sysdatetimeoffset(),
    deleted int not null default 0,

	name varchar(200) not null,
	alias varchar(32) not null,
	
	constraint PK_common_groups_1 primary key (id),
	constraint UQ_common_groups_1 unique (uuid),
	constraint UQ_common_groups_2 unique (deleted, alias)
);
go

create index IX_common_groups_1 on common.groups (uuid) include (id, name, alias);
create index IX_common_groups_2 on common.groups (alias, deleted) include (id, uuid, name);
--create index IX_common_groups_3 on common.groups (deleted) include (id, uuid);
go

-- users

create table common.users (
	id int identity(1, 1) not null,
	uuid uniqueidentifier not null default newid(),
	created_at datetimeoffset not null default sysdatetimeoffset(),
    deleted int not null default 0,
	
	id_group int not null,
	is_admin bit not null default 0,
	name varchar(200) not null,
    email varchar(200) not null,
    password varchar(100),
	phone_number varchar(50),
	birthday date,
	
	constraint PK_common_users_1 primary key (id),
	constraint FK_common_users_1 foreign key (id_group) references common.groups(id),
	constraint UQ_common_users_1 unique (uuid),
	constraint UQ_common_users_2 unique (deleted, email)
);
go

create index IX_common_users_1 on common.users (uuid) include (id, name, email);
create index IX_common_users_2 on common.users (id_group, deleted) include (id, uuid, name, email);
create index IX_common_users_3 on common.users (email, deleted) include (id, uuid, name);
--create index IX_common_users_4 on common.users (deleted) include (id, id_group, uuid);
go

-- users_passwords_histories

create table common.users_passwords_histories (
	id int identity(1, 1) not null,
	created_at datetimeoffset not null default sysdatetimeoffset(),

	id_user int not null,
    password varchar(100) not null,

	constraint PK_common_users_passwords_histories_1 primary key (id),
	constraint FK_common_users_passwords_histories_1 foreign key (id_user) references common.users(id),
	constraint UQ_common_users_passwords_histories_2 unique (id_user, password)
);
go

create index IX_common_users_passwords_histories_1 on common.users_passwords_histories (id_user, password) include (id);
go

-- seeds

declare @group table (id int);

insert into common.groups (name, alias) output inserted.id into @group values ('Main Group', 'main-group');
insert into common.groups (name, alias) values ('Second Group', 'second-group');
insert into common.groups (name, alias) values ('Third Group', 'third-group');

insert into common.users (id_group, is_admin, name, email, password) 
	select g.id as id_group, 1 as is_admin, 'Fake Name' as name, 'fake-email@main-group.ca' as email, 'a123' as password from @group g;
go

-- ############################
-- ###   gtd                ###
-- ############################

create schema gtd;
go

-- ############################
-- ###   kanban             ###
-- ############################

create schema kanban;
go

-- ############################
-- ###   okr                ###
-- ############################

create schema okr;
go