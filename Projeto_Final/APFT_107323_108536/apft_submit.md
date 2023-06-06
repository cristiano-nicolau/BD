# BD: Trabalho Prático APF-T Youtube

**Grupo**: P5G2
- Vasco Faria, MEC: 107323
- Cristiano Nicolau, MEC: 108536
- 
## Introdução / Introduction
 
O nosso projeto final é uma modelação de uma base de dados sobre a plataforma Youtube.
Permite aos utilizadores enviar, compartilhas e visualizar conteudos, que podem ser de varios tipos.
Podem ainda subscrever outros utilizadores, dar like, comentar conteúdo, criar playlist e ainda assinar o premium. 

## ​Análise de Requisitos / Requirements

- O utilizador tem de criar uma conta, registando-se com um e-mail, uma senha de acesso, nome de utilizador, nome próprio, data de nascimento.
- O utilizador pode ainda subscrever o premium que tem uma mensalidade, um valor a pagar e uma data de encerramento.  Pode ainda dar like em cada vídeo que vê.
- O utilizador tem um histórico com a data da visualização dos vídeos que deu like e ainda o nome dos vídeos e o canal ao qual o vídeo pertence.
- O conteúdo disponível pertence a um canal e pode ser assistido por um utilizador, cada conteúdo tem uma duração, o número de likes, uma descrição, os comentários e um título. 
- A descrição tem um número de visualizações, uma data de publicação e um texto.
- O comentário pertence a um canal e tem o respetivo texto.
- O conteúdo pode ainda pertencer a uma playlist que tem um nome, número de likes, pertence a um canal e pode ser privada ou não. Alem disso o conteúdo tem anúncios que tem o número de anúncios, a duração e pertence ao canal da empresa.
- Cada canal pertence a um utilizador tem o número de seguidores, o número de conteúdo disponível, e tem ainda uma descrição e pode subscrever outros canais.	
- O conteúdo disponível tem 3 estados: publico, privado e não listado e pode ainda ser de 3 tipos: video, live, reels. 
- Cada conteúdo tem anúncios, mas caso o utilizador seja premium já não tem.

## DER - Diagrama Entidade Relacionamento/Entity Relationship Diagram

### Versão final/Final version

![DER Diagram!](diagramas/DER_Final.jpg "AnImage")

### APFE 

- Mudanças na entidade Premium e na entidade Estado.
- Foram retirados alguns atributos desnecesários.
- Foram alterados alguns atributos.

## ER - Esquema Relacional/Relational Schema

### Versão final/Final Version

![ER Diagram!](diagramas/ER_Final.jpg "AnImage")

### APFE

- Adicionados alguns atributos necessarios para a ligaçaão da base de dados.
- Foram retiradas algumas ligações desnecessárias, por exemplo haviam varias chaves a ir buscar valores diferentes a mesma entidade.


## ​SQL DDL - Data Definition Language

[SQL DDL File](sql/01_ddl.sql "SQLFileQuestion")

## SQL DML - Data Manipulation Language

### Formulário Utilizadores

![Utilizador](screenshots/Utilizadores.png "Utilizadores")

<br>

```c#
//Show data on the form
string query = "SELECT u.Nome_Utilizador, u.Senha, c.Num_Subscritores, c.Num_Conteudo, c.Descrição_Canal " +
                "FROM [p5g2].[Youtube].[Utilizador] u " +
                "INNER JOIN [p5g2].[Youtube].[Canal] c ON u.Nome_Utilizador = c.Nome_Utilizador " +
                "WHERE u.Nome_Utilizador = c.Nome_Utilizador";

//Listar Utilzadores
string query = "SELECT U.Nome_Utilizador, U.Email, U.Nome, U.Data_de_Nascimento, CASE WHEN P.IsPremium = 1 THEN 'Premium' ELSE '' END AS Premium,  P.Data_de_Encerramento, P.Valor_a_pagar FROM[p5g2].[Youtube].[Utilizador] U LEFT JOIN[p5g2].[Youtube].[Premium] P ON U.Nome_Utilizador = P.Nome_Utilizador;";

//submeter Premium
string query = "INSERT INTO Youtube.Premium (Nome_Utilizador, Num_Meses) " +
                "VALUES (@Nome_Utilizador,@meses)";

```
<br>

### Formulário Conteúdo

![Conteudo](screenshots/Conteudo.png "Conteudo")
<br>

```c#

//Adicionar Conteúdo
string query = "INSERT INTO [p5g2].[Youtube].[Conteúdo] (Titulo, Autor, Tipo, Estado, Duracao) VALUES(@Titulo, @autor, @Tipo, @estado, @dura);";

//Listar todos os conteúdos
string query = "SELECT C.Codigo, C.Titulo, C.Autor, C.Tipo, E.state_name AS Estado, C.Duracao, C.Num_Likes, C.Num_Views, C.Data_Pub FROM Youtube.Conteúdo C JOIN Youtube.Estados E ON C.Estado = E.state_id";

//Update ao número de views após visualizaçção do conteúdo
string updateQuery = "UPDATE [Youtube].[Conteúdo] SET Num_Views = Num_Views+1 WHERE Codigo = @Codigo";

//Inserir conteúdo no Historico
string insertQuery = "INSERT INTO [Youtube].[Historico] (Titulo, Codigo, Data_de_Visualizacao) " +
                                         "SELECT Titulo, Codigo, GETDATE() FROM [Youtube].[Conteúdo] WHERE Codigo = @Codigo";

```
<br>

### Formulário Comentário

![Comentário](screenshots/Comentários.png "Comentário")

<br>

```c#
//Inserir comentário num certo 
string query = "INSERT INTO Youtube.Comentários (Autor,Texto,Codigo) " +
                               "VALUES (@Autor, @Texto, @CódigoV)";



```

## Normalização/Normalization

Existe clareza da semantica dos atributos das relações entre entidades.
Redução o número de nulls nos tuplos através criado mais relações para esses atributos.
Uso de chaves primárias e chaves estrangeiras para as relações entre entidades de modo a evitar a duplicação de dados. 

## Índices/Indexes

Índice na coluna "Data_de_Visualizacao" na tabela "Youtube.Histórico":
```sql
CREATE INDEX idx_Data_de_Visualizacao ON Youtube.Histórico (Data_de_Visualizacao);
```
Este indice melhora a ordenação do histórico por data_de_visualização do mais recente para o mais antigo.

<br>

Índice na coluna Nome_Utilizador na tabela Youtube.Utilizador:
```sql
CREATE INDEX idx_Nome_Utilizador ON Youtube.Utilizador (Nome_Utilizador);"
```
Indice que melhora o desempenho na pesquisa de Utilizadores.



## SQL Programming: Stored Procedures, Triggers, UDF

[SQL SPs and Functions File](sql/02_sp_functions.sql "SQLFileQuestion")

[SQL Triggers File](sql/03_triggers.sql "SQLFileQuestion")

## Outras notas/Other notes

### Dados iniciais da dabase de dados/Database init data 

[Indexes File](sql/04_db_init.sql "SQLFileQuestion")


### Apresentação do trabalho em aula

#### Apresentação PowerPoint

[Apresentação](presentation/apresentacaofinal.pptx "PowerPointFile")

#### Apresentação video demo

[Video Demo](presentation/videoapresentacaofinal.mp4 "Mp4File")

Após a apresentação do trabalho feito ocorreram devidas mudanças na interface, devido a criação de triggers, udfs e stored procedure, fazendo com que a demo do video nao esteja atualizada. 







 
