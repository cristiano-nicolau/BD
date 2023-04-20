# BD: Guião 6

## Problema 6.1

### *a)* Todos os tuplos da tabela autores (authors);

```
... Write here your answer ...
SELECT * from pubs.dbo.authors
```

### *b)* O primeiro nome, o último nome e o telefone dos autores;

```
... Write here your answer ...
SELECT au_fname,  au_lname, phone from pubs.dbo.authors

```

### *c)* Consulta definida em b) mas ordenada pelo primeiro nome (ascendente) e depois o último nome (ascendente); 

```
... Write here your answer ...
SELECT au_fname,  au_lname, phone from pubs.dbo.authors
order by au_fname, au_fname

```

### *d)* Consulta definida em c) mas renomeando os atributos para (first_name, last_name, telephone); 

```
... Write here your answer ...
SELECT au_fname as first_name,  au_lname as last_name , phone as telephone from pubs.dbo.authors
order by first_name, last_name

```

### *e)* Consulta definida em d) mas só os autores da Califórnia (CA) cujo último nome é diferente de ‘Ringer’; 

```
... Write here your answer ...
SELECT au_fname as first_name,  au_lname as last_name , phone as telephone from pubs.dbo.authors
Where state='CA' and au_lname <> 'Ringer'
order by first_name, last_name
```

### *f)* Todas as editoras (publishers) que tenham ‘Bo’ em qualquer parte do nome; 

```
... Write here your answer ...
Select * from pubs.dbo.publishers 
Where pub_name like '%Bo%'
```

### *g)* Nome das editoras que têm pelo menos uma publicação do tipo ‘Business’; 

```
... Write here your answer ...
Select * from pubs.dbo.publishers
	Inner join titles on publishers.pub_id = titles.pub_id
	where pubs.dbo.publishers.pub_id = pubs.dbo.titles.pub_id and type='Business'
```

### *h)* Número total de vendas de cada editora; 

```
... Write here your answer ...
select pub_name, sum(qty) as total_sales
from ((publishers join titles on publishers.pub_id = titles.pub_id) join sales on titles.title_id=sales.title_id)
group by pub_name;
    
```

### *i)* Número total de vendas de cada editora agrupado por título; 

```
... Write here your answer ...
select pub_name, title, sum(qty) as title_sales
from ((publishers join titles on publishers.pub_id = titles.pub_id) join sales on titles.title_id=sales.title_id)
group by pub_name, title;
```

### *j)* Nome dos títulos vendidos pela loja ‘Bookbeat’; 

```
... Write here your answer ...
select title
from ((stores join sales on stores.stor_id=sales.stor_id) join titles on sales.title_id=titles.title_id )
where stor_name='Bookbeat';
```

### *k)* Nome de autores que tenham publicações de tipos diferentes; 

```
... Write here your answer ...
select au_fname, au_lname
from ((titles join titleauthor on titles.title_id=titleauthor.title_id) join authors on titleauthor.au_id=authors.au_id)
group by au_fname, au_lname
having count(distinct [type]) > 1;
```

### *l)* Para os títulos, obter o preço médio e o número total de vendas agrupado por tipo (type) e editora (pub_id);

```
... Write here your answer ...
select [type], pub_id, avg(price) as avg_price, sum(qty) as no_sales
from titles join sales on titles.title_id=sales.title_id 
group by [type], pub_id;
```

### *m)* Obter o(s) tipo(s) de título(s) para o(s) qual(is) o máximo de dinheiro “à cabeça” (advance) é uma vez e meia superior à média do grupo (tipo);

```
... Write here your answer ...
select [type], max(advance) as max_advance, avg(advance) as avg_advance
from titles
group by [type]
having max(advance) > 1.5*avg(advance);
```

### *n)* Obter, para cada título, nome dos autores e valor arrecadado por estes com a sua venda;

```
... Write here your answer ...
select title, authors.au_fname, authors.au_lname, price*royalty/100*royaltyper/100 as lucro
from ((titles join titleauthor on titles.title_id=titleauthor.title_id) join authors on titleauthor.au_id=authors.au_id)
group by title, authors.au_fname, authors.au_lname, price*royalty/100*royaltyper/100;

```

### *o)* Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, a faturação total, o valor da faturação relativa aos autores e o valor da faturação relativa à editora;

```
... Write here your answer ...
select title, ytd_sales, price*ytd_sales as faturacao, price*ytd_sales*royalty*1/100 as auths_revenue, price*ytd_sales*(100-royalty)*1/100 as publisher_revenue
from titles;
```

### *p)* Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, o nome de cada autor, o valor da faturação de cada autor e o valor da faturação relativa à editora;

```
... Write here your answer ...
select title, ytd_sales, price*ytd_sales as faturacao, concat(au_fname,' ',au_lname) as author , price*ytd_sales*royalty*royaltyper*1/10000 as auth_revenue, price*ytd_sales*(100-royalty)*1/100 as publisher_revenue
from ((titles join titleauthor on titles.title_id=titleauthor.title_id) join authors on titleauthor.au_id=authors.au_id)
order by title;
```

### *q)* Lista de lojas que venderam pelo menos um exemplar de todos os livros;

```
... Write here your answer ...
select stor_name, count(title) as n_titles
from ((stores join sales on stores.stor_id=sales.stor_id) join titles on sales.title_id=titles.title_id)
group by stor_name
having count(title)=(select count(title_id)
						from titles);
```

### *r)* Lista de lojas que venderam mais livros do que a média de todas as lojas;

```
... Write here your answer ...
select stor_name, sum(qty)
from ((stores join sales on stores.stor_id=sales.stor_id) join titles on sales.title_id=titles.title_id)
group by stor_name
having sum(qty)>((select sum(qty) from ((stores join sales on stores.stor_id=sales.stor_id) join titles on sales.title_id=titles.title_id))*1/(select count(distinct stor_name) from stores));

```

### *s)* Nome dos títulos que nunca foram vendidos na loja “Bookbeat”;

```
... Write here your answer ...
(select distinct title
from titles)
except
(select distinct titles.title
from ((titles join sales on titles.title_id=sales.title_id) join stores on sales.stor_id=stores.stor_id)
where stor_name='Bookbeat');

```

### *t)* Para cada editora, a lista de todas as lojas que nunca venderam títulos dessa editora; 

```
... Write here your answer ...
(select pub_name, stor_name
from publishers,stores
group by pub_name, stor_name)
except
(select pub_name, stor_name
from (((publishers join titles on publishers.pub_id=titles.pub_id)
		join sales on titles.title_id=sales.title_id)
		join stores on sales.stor_id=stores.stor_id)
group by pub_name, stor_name)
```

## Problema 6.2

### ​5.1

#### a) SQL DDL Script
 
[a) SQL DDL File](ex6_2_1ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex6_2_1_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
select Ssn, Fname, Minit, Lname, Pno
from (Empresa.Employee join Empresa.Works_on on Ssn=Essn);
```

##### *b)* 

```
select E.Fname, E.Minit, E.Lname
from (Empresa.Employee as E join Empresa.Employee as S on E.Super_ssn=S.Ssn)
where S.Fname='Carlos' and S.Minit='D' and S.Lname='Gomes';

```

##### *c)* 

```
select Pname, sum([Hours]) as Total_hours
from (Empresa.Project join Empresa.Works_on on Pnumber=Pno)
group by Pname;

```

##### *d)* 

```
select Fname,Minit,Lname
from ((Empresa.Project join Empresa.Works_on on Pnumber=Pno) join Empresa.Employee on Ssn=Essn)
where Hours>20 and Dno=3;

```

##### *e)* 

```
select Fname,Minit,Lname
from (Empresa.Employee left outer join Empresa.Works_on on Ssn=Essn)
where Essn is null

```

##### *f)* 

```
select Dname, avg(Salary) as Avg_salary
from (Empresa.Department join Empresa.Employee on Dno=Dnumber)
where Sex='F'
group by Dname;

```

##### *g)* 

```
select Fname, Minit, Lname, count(Dependent_name) as DependentsNumber
from (Empresa.Employee join [Empresa.Dependent] on Ssn=Essn)
group by  Fname, Minit, Lname
having count(Dependent_name) > 2;

```

##### *h)* 

```
select Fname, Minit, Lname
from ((Empresa.Employee join Empresa.Department on Ssn=Msr_ssn) left outer join [Empresa.Dependent] on Ssn=Essn)
where Essn is null

```

##### *i)* 

```
select distinct Fname, Minit,Lname,Adress
from (((Empresa.Works_on join Empresa.Employee on Ssn=Essn) join Empresa.Project on Pno=Pnumber) join Empresa.Dept_locations on Dno=Dnumber)
where Plocation='Aveiro' and Dlocation!='Aveiro'

```

### 5.2

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_2_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_2_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
SELECT stock.fornecedor.nome, stock.encomenda.numero, stock.fornecedor.nif, stock.fornecedor.endereco, stock.fornecedor.fax, stock.fornecedor.condpag, stock.fornecedor.tipo
FROM     stock.fornecedor INNER JOIN
                  stock.encomenda ON stock.fornecedor.nif = stock.encomenda.fornecedor
```

##### *b)* 

```
SELECT codProd, AVG(unidades) AS AvgUnidades
FROM     stock.item
GROUP BY codProd
```


##### *c)* 

```
SELECT numEnc, AVG(unidades) AS AvgUnidades
FROM     stock.item
GROUP BY numEnc

```


##### *d)* 

```
SELECT stock.fornecedor.nome, stock.produto.nome AS nomeProduto, SUM(stock.item.unidades) AS Quantidade
FROM     stock.item INNER JOIN
                  stock.produto ON stock.item.codProd = stock.produto.codigo INNER JOIN
                  stock.encomenda ON stock.item.numEnc = stock.encomenda.numero INNER JOIN
                  stock.fornecedor ON stock.encomenda.fornecedor = stock.fornecedor.nif
GROUP BY stock.fornecedor.nome, stock.produto.nome

```

### 5.3

#### a) SQL DDL Script
 
[a) SQL DDL File](ex6_2_3_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex6_2_3_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
SELECT Prescrições.Paciente.numUtente,Prescrições.Paciente.Nome,DataNasc,Endereço
FROM (Prescrições.Paciente LEFT OUTER JOIN Prescrições.prescrição ON Prescrições.Paciente.numUtente=Prescrições.prescrição.numUtente) 
WHERE NumPresc IS NULL;

```

##### *b)* 

```
SELECT Especialidade,count(Especialidade) as NumeroPrescricoes
FROM (Prescrições.Medico JOIN Prescrições.Prescrição ON numSNS != NumMedico)
GROUP BY Especialidade

```


##### *c)* 

```
SELECT Prescrições.Farmacia.Nome,count(Prescrições.Farmacia.Nome) as NumeroPrescricoes
FROM (Prescrições.Farmacia JOIN Prescrições.prescrição ON Prescrições.Farmacia.Nome=Prescrições.prescrição.farmacia)
GROUP BY Prescrições.Farmacia.Nome;

```


##### *d)* 

```
SELECT Nome,Formula,.Prescrições.Farmaco.NumRegFarm
FROM (Prescrições.Farmaco LEFT OUTER JOIN Prescrições.presc_farmaco ON Nome = NomeFarmaco)
Where Prescrições.Farmaco.NumRegFarm = 906 AND NumPresc IS NULL;

```

##### *e)* 

```
SELECT Prescrições.Farmacia.Nome, Prescrições.Farmaceutica.Nome,count(Prescrições.Farmaco.Nome) as NumFarmacos
FROM (Prescrições.Farmaceutica JOIN 
								(Prescrições.Farmaco JOIN
														(Prescrições.presc_farmaco JOIN 
																					(Prescrições.Farmacia JOIN Prescrições.prescrição ON Prescrições.Farmacia.Nome = Prescrições.prescrição.farmacia)
														ON Prescrições.presc_farmaco.NumPresc = Prescrições.prescrição.NumPresc)
								ON Prescrições.Farmaco.Nome = Prescrições.presc_farmaco.NomeFarmaco)	
		ON NumReg = Prescrições.Farmaco.NumRegFarm)
GROUP BY  Prescrições.Farmacia.Nome, Prescrições.Farmaceutica.Nome

```

##### *f)* 

```
SELECT Prescrições.Paciente.Nome,Prescrições.Paciente.NumUtente,count(Prescrições.Medico.NumSNS) AS NumMedicos
FROM Prescrições.Medico JOIN
		(Prescrições.Paciente JOIN Prescrições.prescrição ON Paciente.NumUtente = prescrição.numUtente)
ON Prescrições.Medico.numSNS = Prescrições.prescrição.numMedico
GROUP BY Prescrições.Paciente.Nome,Prescrições.Paciente.NumUtente
HAVING count(Prescrições.Medico.numSNS) > 1

```
