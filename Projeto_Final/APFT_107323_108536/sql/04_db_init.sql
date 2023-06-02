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