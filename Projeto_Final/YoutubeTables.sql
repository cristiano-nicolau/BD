USE p5g2;
GO

/*CREATE SCHEMA Youtube;
GO

CREATE TABLE Youtube.Estados (
    state_id TINYINT PRIMARY KEY,
    state_name VARCHAR(20)
);

CREATE TABLE Youtube.Utilizador (
    Nome_Utilizador varchar(20) not null,
    Email varchar(20) not null,
    Senha varchar(15) not null,
    Nome varchar(20) not null,
    Data_de_Nascimento date not null,
    PRIMARY KEY(Nome_Utilizador)
);
GO

CREATE TABLE Youtube.Premium (
    Data_de_Encerramento date not null,
    Valor_a_pagar FLOAT,
    Nome_Utilizador varchar(20) not null,
    PRIMARY KEY(Nome_Utilizador),
    FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador)
);
GO

CREATE TABLE Youtube.Canal (
    Nome_Utilizador varchar(20) not null,
    Num_Subscritores int,
    Num_conteudo int,
    Descrição_Canal varchar(600),
    Subscreve int,
    PRIMARY KEY(Nome_Utilizador),
    FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador)
);
GO

CREATE TABLE Youtube.Conteúdo (
    Titulo varchar(40) not null,
    Codigo int,
    Autor varchar(20) not null,
    Tipo varchar(20) not null,
    Estado varchar(20) not null,
    Duração time not null,
    Num_Likes int,
    Num_Visualizações int,
    Data_Publicação date not null,
    UNIQUE(Codigo),
    PRIMARY KEY(Codigo),
    FOREIGN KEY (Autor) REFERENCES Youtube.Canal(Nome_Utilizador)
);
GO

CREATE TABLE Youtube.Descrição (
    Codigo int,
    Texto varchar(500),
    Num_Likes int,
    Num_Visualizações int,
    Data_Publicação date ,
    PRIMARY KEY (Codigo),
    FOREIGN KEY (Codigo) REFERENCES Youtube.Conteúdo(Codigo),
);
GO

CREATE TABLE Youtube.Playlist (
    Titulo varchar(30) not null,
    CodigoP int,
    Autor varchar(20) not null,
    Num_Likes int,
    Estado TINYINT,
    UNIQUE(CodigoP),
    PRIMARY KEY(CodigoP),
    FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
    FOREIGN KEY (Estado) REFERENCES Youtube.Estados(state_id)
);
GO

CREATE TABLE Youtube.Comentários (
    Autor varchar(20) not null,
    Texto varchar(300) not null,
    Data_Comentário date not null,
    PRIMARY KEY(Autor),
    FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador)
);
GO

CREATE TABLE Youtube.Histórico (
    Titulo varchar(30) not null,
    Codigo int,
    Data_de_Visualização date not null,
    Nome_Utilizador varchar(20) not null,
    PRIMARY KEY (Codigo),
    FOREIGN KEY (Codigo) REFERENCES Youtube.Conteúdo(Codigo),
    FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador)
);

INSERT INTO Youtube.Estados (state_id, state_name) VALUES (0,'Private'), (1,'Public');





INSERT INTO Youtube.Utilizador (Nome_Utilizador, Email, Senha, Nome, Data_de_Nascimento)
VALUES
  ('Colins', 'blandit@icloud.edu', 'Xi9fp4hx', 'Marsden Guthrie', '1992-06-11'),
  ('Unitys', 'non.justo@google.org', 'Wf6nh0ih', 'Barclay Faulkner', '1961-08-17'),
  ('Martinas', 'quis.diam@google.net', 'Tm9su1fh', 'Harlan Leon', '1952-09-23'),
  ('Kylies', 'egestas.nunc.sed@hotmail.couk', 'Cu0wb2ik', 'Martin Guzman', '1964-08-10'),
  ('Iriss', 'eget.massa.suspendisse@yahoo.couk', 'Ir8cr2mc', 'Lionel Carpenter', '1955-11-28'),
  ('Whitneys', 'neque.tellus.imperdiet@protonmail.edu', 'Re2kq1kd', 'August Compton', '1964-03-13'),
  ('Ulyssess', 'eu@hotmail.net', 'Eo7gj0yv', 'Neville Hart', '1953-06-06'),
  ('Bretts', 'amet@icloud.com', 'Mf3ak2ly', 'Gray Berg', '1985-11-06');
	

INSERT INTO Youtube.Canal (Nome_Utilizador, Num_Subscritores, Num_conteudo, Descrição_Canal, Subscreve)
SELECT Nome_Utilizador, 100, 5, 'Sample description', 10
FROM Youtube.Utilizador;

ALTER TABLE Youtube.Comentários ADD CONSTRAINT CódigoV FOREIGN KEY (CódigoV) REFERENCES Youtube.Conteúdo(Codigo);



 ALTER TABLE Youtube.Descrição
ADD CONSTRAINT FK_Descrição_Conteúdo FOREIGN KEY (Codigo) REFERENCES Youtube.Conteúdo(Codigo);
GO

-- Add foreign key constraints to the 'Playlist' table
ALTER TABLE Youtube.Playlist
ADD CONSTRAINT FK_Playlist_Utilizador FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
    CONSTRAINT FK_Playlist_Estados FOREIGN KEY (Estado) REFERENCES Youtube.Estados(state_id);
GO

-- Add foreign key constraints to the 'Comentários' table
ALTER TABLE Youtube.Comentários
ADD CONSTRAINT FK_Comentários_Utilizador FOREIGN KEY (Autor) REFERENCES Youtube.Utilizador(Nome_Utilizador),
    CONSTRAINT FK_Comentários_Conteúdo FOREIGN KEY (CódigoV) REFERENCES Youtube.Conteúdo(Codigo);
GO

-- Add foreign key constraints to the 'Histórico' table
ALTER TABLE Youtube.Histórico
ADD CONSTRAINT FK_Histórico_Conteúdo FOREIGN KEY (Codigo) REFERENCES Youtube.Conteúdo(Codigo),
    CONSTRAINT FK_Histórico_Utilizador FOREIGN KEY (Nome_Utilizador) REFERENCES Youtube.Utilizador(Nome_Utilizador);
GO




-- Insert data into the 'Conteúdo' table
INSERT INTO Youtube.Conteúdo (Titulo, Codigo, Autor, Tipo, Estado, Duração, Num_Likes, Num_Visualizações, Data_Publicação)
VALUES
  ('Video 1', 1, 'Colins', 'Type 1', 1, '00:05:00', 5, 50, '2023-05-01'),
  ('Video 2', 2, 'Unitys', 'Type 2', 0, '00:10:00', 8, 80, '2023-05-02');

-- Insert data into the 'Descrição' table
INSERT INTO Youtube.Descrição (Codigo, Texto, Num_Likes, Num_Visualizações, Data_Publicação)
VALUES
  (1, 'Description 1', 5, 50, '2023-05-01'),
  (2, 'Description 2', 8, 80, '2023-05-02');

-- Insert data into the 'Playlist' table
INSERT INTO Youtube.Playlist (Titulo, CodigoP, Autor, Num_Likes, Estado)
VALUES
  ('Playlist 1', 1, 'Colins', 20, 1),
  ('Playlist 2', 2, 'Unitys', 30, 0);

-- Insert data into the 'Comentários' table
INSERT INTO Youtube.Comentários (Autor, Texto, Data_Comentário, CódigoV)
VALUES
  ('Colins', 'Comment 1', '2023-05-01', 1),
  ('Unitys', 'Comment 2', '2023-05-02', 2);

-- Insert data into the 'Histórico' table
INSERT INTO Youtube.Histórico (Titulo, Codigo, Data_de_Visualização, Nome_Utilizador)
VALUES
  ('Video 1', 1, '2023-05-01', 'Colins'),
  ('Video 2', 2, '2023-05-02', 'Unitys');




  

  CREATE TABLE Youtube.PlaylistVideo (
    PlaylistID int,
    VideoID int,
    PRIMARY KEY (PlaylistID, VideoID),
    FOREIGN KEY (PlaylistID) REFERENCES Youtube.Playlist(CodigoP),
    FOREIGN KEY (VideoID) REFERENCES Youtube.Conteúdo(Codigo)
);


INSERT INTO Youtube.PlaylistVideo (PlaylistID, VideoID)
VALUES
	(2 ,1);



INSERT INTO Youtube.Utilizador (Nome_Utilizador, Email, Senha, Nome, Data_de_Nascimento)
VALUES
  ('JohnDoe', 'john.doe@example.com', 'Password123', 'John Doe', '1990-01-01'),
  ('JaneSmith', 'jane.smith@example.com', 'P@ssw0rd', 'Jane Smith', '1995-02-15'),
  ('MikeJohnson', 'mike.johnson@example.com', 'SecurePassword', 'Mike Johnson', '1988-06-30'),
  ('EmilyBrown', 'emily.brown@example.com', 'Secret123', 'Emily Brown', '1992-09-22'),
  ('DavidWilson', 'david.wilson@example.com', 'MyPassword', 'David Wilson', '1985-07-10'),
  ('SarahMiller', 'sarah.miller@example.com', 'Password1234', 'Sarah Miller', '1998-03-18'),
  ('MichaelTaylor', 'michael.taylor@example.com', 'SecurePass', 'Michael Taylor', '1991-11-09'),
  ('JessicaClark', 'jessica.clark@example.com', 'SecretPass', 'Jessica Clark', '1987-04-25');

-- Insert data into the 'Canal' table
INSERT INTO Youtube.Canal (Nome_Utilizador, Num_Subscritores, Num_conteudo, Descrição_Canal, Subscreve)
SELECT Nome_Utilizador, 500, 20, 'Sample description', 50
FROM Youtube.Utilizador
WHERE Nome_Utilizador != 'Colins' AND Nome_Utilizador != 'Unitys';

-- Insert data into the 'Conteúdo' table
INSERT INTO Youtube.Conteúdo (Titulo, Codigo, Autor, Tipo, Estado, Duração, Num_Likes, Num_Visualizações, Data_Publicação)
VALUES
  ('Video 3', 3, 'JohnDoe', 'Type 1', 1, '00:08:30', 10, 100, '2023-05-03'),
  ('Video 4', 4, 'JaneSmith', 'Type 2', 0, '00:12:15', 15, 120, '2023-05-04'),
  ('Video 5', 5, 'MikeJohn', 'Type 1', 1, '00:06:45', 20, 150, '2023-05-05'),
  ('Video 6', 6, 'EmilyBrown', 'Type 2', 0, '00:09:20', 12, 110, '2023-05-06'),
  ('Video 7', 7, 'DavidWilson', 'Type 1', 1, '00:07:55', 18, 170, '2023-05-07'),
  ('Video 8', 8, 'SarahMiller', 'Type 2', 0, '00:10:40', 25, 200, '2023-05-08'),
  ('Video 9', 9, 'MichaelTaylor', 'Type 1', 1, '00:05:30', 22, 180, '2023-05-09'),
  ('Video 10', 10, 'JessicaClark', 'Type 2', 0, '00:08:10', 30, 250, '2023-05-10');

-- Insert data into the 'Descrição' table
INSERT INTO Youtube.Descrição (Codigo, Texto, Num_Likes, Num_Visualizações, Data_Publicação)
VALUES
  (3, 'Description 3', 10, 100, '2023-05-03'),
  (4, 'Description 4', 15, 120, '2023-05-04'),
  (5, 'Description 5', 20, 150, '2023-05-05'),
  (6, 'Description 6', 12, 110, '2023-05-06'),
  (7, 'Description 7', 18, 170, '2023-05-07'),
  (8, 'Description 8', 25, 200, '2023-05-08'),
  (9, 'Description 9', 22, 180, '2023-05-09'),
  (10, 'Description 10', 30, 250, '2023-05-10');

-- Insert data into the 'Playlist' table
INSERT INTO Youtube.Playlist (Titulo, CodigoP, Autor, Num_Likes, Estado)
VALUES
  ('Playlist 3', 3, 'JohnDoe', 40, 1),
  ('Playlist 4', 4, 'JaneSmith', 50, 0),
  ('Playlist 5', 5, 'MikeJohnson', 60, 1),
  ('Playlist 6', 6, 'EmilyBrown', 45, 0),
  ('Playlist 7', 7, 'DavidWilson', 55, 1),
  ('Playlist 8', 8, 'SarahMiller', 70, 0),
  ('Playlist 9', 9, 'MichaelTaylor', 65, 1),
  ('Playlist 10', 10, 'JessicaClark', 80, 0);

-- Insert data into the 'Comentários' table
INSERT INTO Youtube.Comentários (Autor, Texto, Data_Comentário, CódigoV)
VALUES
  ('JohnDoe', 'Comment 3', '2023-05-03', 3),
  ('JaneSmith', 'Comment 4', '2023-05-04', 4),
  ('MikeJohnson', 'Comment 5', '2023-05-05', 5),
  ('EmilyBrown', 'Comment 6', '2023-05-06', 6),
  ('DavidWilson', 'Comment 7', '2023-05-07', 7),
  ('SarahMiller', 'Comment 8', '2023-05-08', 8),
  ('MichaelTaylor', 'Comment 9', '2023-05-09', 9),
  ('JessicaClark', 'Comment 10', '2023-05-10', 10);

-- Insert data into the 'Histórico' table
INSERT INTO Youtube.Histórico (Titulo, Codigo, Data_de_Visualização, Nome_Utilizador)
VALUES
  ('Video 3', 3, '2023-05-03', 'JohnDoe'),
  ('Video 4', 4, '2023-05-04', 'JaneSmith'),
  ('Video 5', 5, '2023-05-05', 'MikeJohnson'),
  ('Video 6', 6, '2023-05-06', 'EmilyBrown'),
  ('Video 7', 7, '2023-05-07', 'DavidWilson'),
  ('Video 8', 8, '2023-05-08', 'SarahMiller'),
  ('Video 9', 9, '2023-05-09', 'MichaelTaylor'),
  ('Video 10', 10, '2023-05-10', 'JessicaClark');

INSERT INTO Youtube.PlaylistVideo (PlaylistID, VideoID)
VALUES
	(3, 1),
	(3, 2),
	(4, 3),
	(4, 4),
	(5, 5),
	(5, 6),
	(6, 7),
	(6, 8),
	(7, 9),
	(7, 10);



	*/







