create table "Intern".images (
	id SERIAL primary key,
	name VARCHAR(100) not null,
	url VARCHAR(200) not null,
	created DATE default current_timestamp
);