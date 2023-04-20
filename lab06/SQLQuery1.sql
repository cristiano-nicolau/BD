/****** Script for SelectTopNRows command from SSMS  ******/
Select sum(sales.qty) from  pubs.dbo.publishers
	Inner join titles on titles.pub_id = publishers.pub_id
	Inner join sales on  sales.title_id = titles.title_id


	 
	