# BD: Guião 5


## ​Problema 5.1
 
### *a)*

```
Write here your answer e.g:
π Ssn,Fname,Lname,Pno (employee ⨝ (Essn=Ssn) works_on) 
```


### *b)* 

```
... Write here your answer ...
π Fname,Minit,Lname (employee ⨝ Super_ssn=super.Ssn ( ρ super (π Ssn ((σ (Fname='Carlos'∧ Minit='D'∧ Lname='Gomes') (employee))))))

```


### *c)* 

```
... Write here your answer ...
γ Pname;sum(Hours)->TotalHours (project ⨝ (Pnumber=Pno) works_on)       
```


### *d)* 

```
... Write here your answer ...
π Fname,Minit,Lname (σ Dno=3 (employee ⨝ (Ssn=Essn) (σ Hours>20 ∧ Pname='Aveiro Digital' (project ⨝ (Pnumber=Pno) works_on))))
```


### *e)* 

```
... Write here your answer ...
π Fname,Minit,Lname (σ Essn=null (employee ⨝ (Ssn=Essn works_on)))

```


### *f)* 

```
... Write here your answer ...
γ Dname;avg(Salary)->Avg_Salary (σ Sex='F' (department ⨝ Dno=Dnumber employee))
```


### *g)* 

```
... Write here your answer ...
σ dependents.DependentsNumber > 2 (ρ dependents (γ Fname, Minit, Lname; count(Dependent_name)->DependentsNumber (employee ⨝(Ssn=Essn) dependent)))
```


### *h)* 

```
... Write here your answer ...
π Fname,Minit,Lname (σ Essn=null (dependent ⟖(Essn=Ssn) (ρ managers (employee ⨝(Ssn=Mgr_ssn) department))))
```


### *i)* 

```
... Write here your answer ...
π Fname,Minit,Lname,Address (σ Dlocation≠'Aveiro' (dept_location ⨝(Dnumber=Dno) (σ Plocation='Aveiro' (project ⨝ (Pnumber=Pno) (works_on ⨝ (Ssn=Essn) employee)))))
```


## ​Problema 5.2

### *a)*

```
... Write here your answer ...
π nome (σ numero=null (fornecedor ⟕(nif=fornecedor) encomenda))
```

### *b)* 

```
... Write here your answer ...
γ codProd; avg(unidades)->MediaUnidades (π numEnc,codProd,unidades (item))
```


### *c)* 

```
... Write here your answer ...
γ avg(Variedade)->Media (γ numEnc; count(codProd)->Variedade (π numEnc,codProd (item)))
```


### *d)* 

```
... Write here your answer ...
γ fornecedor, codProd; sum(unidades)->TotalUnidades (  π numEnc,codProd,unidades (item) ⨝ numEnc=numero (π numero,fornecedor (encomenda)))
```


## ​Problema 5.3

### *a)*

```
... Write here your answer ...
σ numPresc=0
(γ paciente.nome;count(numPresc)-> numPresc
(prescricao ⟖ prescricao.numUtente = paciente.numUtente (paciente)))
```

### *b)* 

```
... Write here your answer ...
γ especialidade; count(numPresc)->TotalPresc (π numSNS,especialidade (medico) ⨝ numSNS=numMedico (π numPresc, numMedico (prescricao)))
```


### *c)* 

```
... Write here your answer ...
σ farmacia≠null (γ farmacia; count(numPresc)->TotalPresc (π numPresc,farmacia (prescricao)))
```


### *d)* 

```
... Write here your answer ...
σ numPresc = null (σ numRegFarm = 906 (farmaco) ⟕ nome = nomeFarmaco σ numRegFarm = 906 (presc_farmaco))
```

### *e)* 

```
... Write here your answer ...
γ farmacia.nome, farmaceutica.nome; count(farmaco.nome)->numFarmacos (farmaceutica ⨝(numReg=farmaco.numRegFarm) (farmaco ⨝(farmaco.nome=presc_farmaco.nomeFarmaco) (presc_farmaco ⨝(presc_farmaco.numPresc=prescricao.numPresc) (farmacia ⨝(nome=farmacia) prescricao))))
```

### *f)* 

```
... Write here your answer ...
π paciente.nome,paciente.numUtente (σ numMedicos>1 (γ paciente.nome,paciente.numUtente; count(medico.numSNS)->numMedicos (π paciente.nome,paciente.numUtente,medico.numSNS (medico ⨝(medico.numSNS=prescricao.numMedico) (paciente ⨝(paciente.numUtente=prescricao.numUtente) prescricao)))))
```
