# BD: Guião 8


## ​8.1. Complete a seguinte tabela.
Complete the following table.

| #    | Query                                                                                                      | Rows  | Cost  | Pag. Reads | Time (ms) | Index used | Index Op.            | Discussion |
| :--- | :--------------------------------------------------------------------------------------------------------- | :---- | :---- | :--------- | :-------- | :--------- | :------------------- | :--------- |
| 1    | SELECT * from Production.WorkOrder                                                                         | 72591 | 0.484 | 531        | 1171      | …          | Clustered Index Scan |            |
| 2    | SELECT * from Production.WorkOrder where WorkOrderID=1234                                                  | 1     | 0.003 | 26         | 14        |            | Clustered Index Seek |            |
| 3.1  | SELECT * FROM Production.WorkOrder WHERE WorkOrderID between 10000 and 10010                               | 11.99 | 0.003 | 26         | 11        |            | Clustered Index Seek |            |
| 3.2  | SELECT * FROM Production.WorkOrder WHERE WorkOrderID between 1 and 72591                                   | 72591 | 0.007 | 554        | 517       |            | Clustered Index Seek |            |
| 4    | SELECT * FROM Production.WorkOrder WHERE StartDate = '2007-06-25'                                          | 72591 | 0.481 | 1348       | 53        |            | Clustered Index Scan |            |
| 5    | SELECT * FROM Production.WorkOrder WHERE ProductID = 757                                                   | 11.4  | 0.037 | 238        | 23        |            | Index Seek           |            |
| 6.1  | SELECT WorkOrderID, StartDate FROM Production.WorkOrder WHERE ProductID = 757                              | 11.4  | 0.037 | 44         | 12        |            | Index Seek           |            |
| 6.2  | SELECT WorkOrderID, StartDate FROM Production.WorkOrder WHERE ProductID = 945                              | 1105  | 0.474 | 554        | 70        |            | Clustered Index Scan |            |
| 6.3  | SELECT WorkOrderID FROM Production.WorkOrder WHERE ProductID = 945 AND StartDate = '2006-01-04'            | 1,796 | 0.473 | 1154       | 82        |            | Clustered Index Scan |            |
| 7    | SELECT WorkOrderID, StartDate FROM Production.WorkOrder WHERE ProductID = 945 AND StartDate = '2006-01-04' | 1,796 | 0.473 | 556        | 28        |            | Clustered Index Scan |            |
| 8    | SELECT WorkOrderID, StartDate FROM Production.WorkOrder WHERE ProductID = 945 AND StartDate = '2006-01-04' | 1,796 | 0.473 | 556        | 27        |            | Clustered Index Scan |            |

## ​8.2.

### a)

```
ALTER TABLE mytemp
ADD CONSTRAINT PK_mytemp_rid PRIMARY KEY CLUSTERED (rid);
``
```

### b)

```
milliseconds used = 3690720

-- Percentagem de fragmentação dos incidices : 99.05%

SELECT 
    dbschemas.[name] as 'Schema',
    dbtables.[name] as 'Table',
    dbindexes.[name] as 'Index',
    indexstats.avg_fragmentation_in_percent 
FROM 
    sys.dm_db_index_physical_stats (DB_ID(), NULL, NULL, NULL, NULL) AS indexstats
    INNER JOIN sys.tables dbtables on dbtables.[object_id] = indexstats.[object_id]
    INNER JOIN sys.schemas dbschemas on dbtables.[schema_id] = dbschemas.[schema_id]
    INNER JOIN sys.indexes AS dbindexes ON dbindexes.[object_id] = indexstats.[object_id]
        AND indexstats.index_id = dbindexes.index_id
WHERE 
    indexstats.database_id = DB_ID() AND
    dbschemas.[name] = 'dbo' AND 
    dbtables.[name] = 'mytemp' AND 
    dbindexes.[name] IS NOT NULL;



-- Percentagem de ocupação das páginas dos índices: 99.30%

SELECT
    OBJECT_NAME(ind.OBJECT_ID) AS TableName,
    ind.name AS IndexName,
    indexstats.avg_fragmentation_in_percent
FROM
    sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, NULL) indexstats
    INNER JOIN sys.indexes ind ON ind.object_id = indexstats.object_id AND ind.index_id = indexstats.index_id
WHERE
    OBJECT_NAME(ind.OBJECT_ID) = 'mytemp' AND ind.name = 'PK_mytemp_rid'

```

### c)

```
... Write here your answer ...
Milliseconds used with fillfactor 65: 90
Milliseconds used with fillfactor 80: 83
Milliseconds used with fillfactor 90: 76
```

### d)

```
... Write here your answer ...

Milliseconds used with identity column: 323687

Milliseconds used with fillfactor 65: 66
Milliseconds used with fillfactor 80: 45
Milliseconds used with fillfactor 90: 47
```

### e)

```
... Write here your answer ...

CREATE INDEX idx_mytemp_at1 ON mytemp (at1);
CREATE INDEX idx_mytemp_at2 ON mytemp (at2);
CREATE INDEX idx_mytemp_at3 ON mytemp (at3);

Milliseconds used: 153346
```

## ​8.3.

```
... Write here your answer ...
 i
CREATE UNIQUE CLUSTERED INDEX idxSnn ON dbo.Company.Employee(ssn);

 ii
CREATE NONCLUSTERED INDEX idxNames ON Employee(Fname,Lname);

 iii
CREATE NONCLUSTERED INDEX idxEmpDep ON Employee(Dno);
CREATE CLUSTERED INDEX idxDep ON Department(Dnumber);

 iv
CREATE CLUSTERED INDEX idxSsn ON Employee(ssn);
CREATE CLUSTERED INDEX idxWorksOn ON Works_on(Essn,Pno);
CREATE NONCLUSTERED INDEX idxProj ON Project(Pnumber);

 v
CREATE UNIQUE CLUSTERED INDEX IdxDep ON Dependent(Essn,Dependent_name);

 vi
CREATE NONCLUSTERED INDEX idxProj ON Project(Dnum);
CREATE UNIQUE CLUSTERED INDEX idcDep ON Department(Dnumber);
```
