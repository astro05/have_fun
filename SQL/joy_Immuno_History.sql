create database immune_history
drop database immune_history

Alter login sa with password = '123456'
Alter login sa enable


drop table statics_user
drop table disease_type
drop table disease_name
drop table symptom
drop table medicine_generic_name
drop table medicine_local_name
drop table disease_info
drop table treatment_feedback
drop table doc_med_feedback






create table statics_user(
        statics_user_id int not null identity(1,1),
		statics_user_email varchar(255) constraint pk_statics_user_email primary key,
		statics_user_password varchar(255)
    
)

select * from statics_user
update statics_user set statics_user_password='j' where statics_user_email='joyultimates@gmail.com' 



create table disease_type(
        disease_type_id int not null identity(1,1) constraint pk_disease_type_id primary key,
		disease_type varchar(255) constraint uk_disease_type unique
)

select* from disease_type

BULK INSERT immune_history.dbo.disease_type
from 'D:\Resource\AUST\CSE 3.1\CSE 3104 Database Lab\project\immune_history\disease_type.csv'
with(
     FIELDTERMINATOR=',',
	 ROWTERMINATOR='\n',
	 FIRSTROW=2
	 )


create table disease_name(
       disease_id int not null identity(1,1) constraint pk_disease_id primary key,
    	 disease_name varchar(255) constraint uk_disease_name unique not null,
		 disease_type_id int
		 constraint fk_disease_type foreign key(disease_type_id)
	  references disease_type(disease_type_id) default '3'
	
	)

select * from disease_name

--insert into disease_name(disease_name) values ('unknown1')

BULK INSERT immune_history.dbo.disease_name
from 'D:\Resource\AUST\CSE 3.1\CSE 3104 Database Lab\project\immune_history\disease_name.csv'
with(
     FIELDTERMINATOR=',',
	 ROWTERMINATOR='\n',
	 FIRSTROW=2
	 )

create table symptom(
         symptom_id int identity(1,1) constraint pk_symptom_id primary key not null,
		 symptom_name varchar(255) constraint uk_symptom_name unique not null
)

select * from symptom


BULK INSERT immune_history.dbo.symptom
from 'D:\Resource\AUST\CSE 3.1\CSE 3104 Database Lab\project\immune_history\symptom.csv'
with(
     FIELDTERMINATOR=',',
	 ROWTERMINATOR='\n',
	 FIRSTROW=2
	 )

create table medicine_generic_name(
       medicine_generic_id int not null identity(1,1) constraint pk_medicine_generic_id primary key,
       medicine_generic_name varchar(255)  constraint uk_medicine_generic_name unique not null,
	   medicine_generic_note varchar(255) default 'N0 COMMENT'
      )

--alter table medicine_generic_name add medicine_generic_note varchar(255) default 'NO COMMENT'


BULK INSERT immune_history.dbo.medicine_generic_name
from 'D:\Resource\AUST\CSE 3.1\CSE 3104 Database Lab\project\immune_history\medicine_generic_name.csv'
with(
     FIELDTERMINATOR=',',
	 ROWTERMINATOR='\n',
	 FIRSTROW=2
	 )

select * from medicine_generic_name


create table medicine_local_name(
       index_id int IDENTITY(1,1) PRIMARY KEY,
      medicine_generic_id int not null 
	  constraint fk_medicine_local_name foreign key(medicine_generic_id)
	  references medicine_generic_name(medicine_generic_id),
	  medicine_local_name varchar(255)

	  )

BULK INSERT immune_history.dbo.medicine_local_name
from 'D:\Resource\AUST\CSE 3.1\CSE 3104 Database Lab\project\immune_history\medicine_local_name.csv'
with(
     FIELDTERMINATOR=',',
	 ROWTERMINATOR='\n',
	 FIRSTROW=2
	 )


select * from medicine_local_name



create table disease_info(
      index_id int IDENTITY(1,1) PRIMARY KEY,
      disease_id int not null 
	  constraint fk_disease_info foreign key(disease_id)
	  references disease_name(disease_id),
	  disease_type_id int
	  constraint fk_disease_type_id foreign key(disease_type_id)
	  references disease_type(disease_type_id) default 3, 
	  symptom_id int 
	  constraint fk_symptom_id foreign key(symptom_id)
	  references symptom(symptom_id),
	  min_period int default 0,
	  max_period int default 0,
	  medicine_generic_id int 
	  constraint fk_medicine_generic_disease foreign key(medicine_generic_id)
	  references medicine_generic_name(medicine_generic_id) default 1,
	   anti_medicine_generic_name int 
	  constraint fk_anti_medicine_generic_disease foreign key(medicine_generic_id)
	  references medicine_generic_name(medicine_generic_id) default 1

	  )

select * from disease_info

BULK INSERT immune_history.dbo.disease_info
from 'D:\Resource\AUST\CSE 3.1\CSE 3104 Database Lab\project\immune_history\disease_info.csv'
with(
     FIELDTERMINATOR=',',
	 ROWTERMINATOR='\n',
	 FIRSTROW=2
	 )
	 

create table treatment_feedback(
        treatment_feedback_id int not null identity(1,1) PRIMARY KEY,
		consult_id int NOT NULL
		constraint fk_consult_treatment foreign key(consult_id)
	  references consult(consult_id),
	  success_rate float
  
)

BULK INSERT immune_history.dbo.treatment_feedback
from 'D:\Resource\AUST\CSE 3.1\CSE 3104 Database Lab\project\immune_history\treatment_feedback.csv'
with(
     FIELDTERMINATOR=',',
	 ROWTERMINATOR='\n',
	 FIRSTROW=2
	 )


select * from treatment_feedback


create table doc_med_feedback(
          
          doc_med_feedback_id int not null identity(1,1) PRIMARY KEY,
		  age int not null,
		  medicine_generic_name varchar(255),
		  med_success_rate float

)


BULK INSERT immune_history.dbo.doc_med_feedback
from 'D:\Resource\AUST\CSE 3.1\CSE 3104 Database Lab\project\immune_history\doc_med_feedback.csv'
with(
     FIELDTERMINATOR=',',
	 ROWTERMINATOR='\n',
	 FIRSTROW=2
	 )


select * from doc_med_feedback

















----------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------

--- add new drug----------------------
insert into medicine_generic_name(medicine_generic_name,medicine_generic_note) values(UPPER('TEST'),UPPER('TEST'))

---------------------------------------------

--show disease list-------------

select disease_id,disease_name,disease_type
from disease_name
left join disease_type on disease_name.disease_type_id = disease_type.disease_type_id


--search disease list-------------

select disease_id,disease_name,disease_type
from disease_name
left join disease_type on disease_name.disease_type_id = disease_type.disease_type_id
where disease_id LIKE '%A%'
  OR  disease_name LIKE '%a%'
  OR  disease_type LIKE '%A%'



--show total disease ---------------------

select COUNT(medicine_generic_id) from medicine_generic_name

--show drug list--------------------------------

select * from medicine_generic_name

--search drug list -----------------------

select * from medicine_generic_name
where medicine_generic_id LIKE '%a%'
 OR   medicine_generic_name LIKE '%A%'
 OR  medicine_generic_note LIKE  '%a%'

--show total drug-----------
select COUNT(disease_id) from disease_name



--- show disease info Collective -----------------------------


select 
       DISTINCT  difo2.disease_id,
       
	   (select disease_name from disease_name where disease_name.disease_id = difo2.disease_id) as diseaseName,

	   STUFF((select DISTINCT ','+  (select disease_type from disease_type where disease_type.disease_type_id = difo1.disease_type_id)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS dis_type,

	   STUFF((select DISTINCT ','+  CAST(AVG(min_period) AS NVARCHAR)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS dis_min_period,
		
	   STUFF((select DISTINCT ','+  CAST(AVG(max_period) AS NVARCHAR)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS dis_max_period,

       STUFF((select DISTINCT ','+ (select symptom_name from symptom where symptom.symptom_id = difo1.symptom_id)
	          from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS symptom_list,

       STUFF((select DISTINCT ','+  (select medicine_generic_name from medicine_generic_name where medicine_generic_name.medicine_generic_id = difo1.medicine_generic_id)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS med_generic_name,
	   
	   STUFF((select DISTINCT ','+  (select medicine_generic_name from medicine_generic_name where medicine_generic_name.medicine_generic_id = difo1.anti_medicine_generic_name)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS antimed_generic_name
	   
	   
from disease_info difo2
group by disease_id,min_period,max_period
	               
	   
------------------------------------------------------------------------------------	   
	
---search disease info collective ---------------------------------------------


--------TRAIL-------------
select disease_info.disease_id,disease_name.disease_name,disease_name.disease_type_id,min_period,max_period,
       symptom.symptom_name,medicine_generic_name.medicine_generic_name
      
 from disease_info 
							 
 JOIN disease_name ON disease_name.disease_id = disease_info.disease_id
 JOIN disease_type ON disease_type.disease_type_id = disease_info.disease_type_id
 JOIN symptom ON symptom.symptom_id = disease_info.symptom_id
 JOIN medicine_generic_name ON medicine_generic_name.medicine_generic_id = disease_info.medicine_generic_id
     

where    disease_info.disease_id LIKE '%A%'
         OR min_period LIKE '%A%'
  	     OR max_period LIKE '%A%'
		 OR disease_name.disease_name LIKE '%A%'
         OR disease_type.disease_type LIKE '%A%'
		 OR symptom.symptom_name LIKE '%A%'
         OR medicine_generic_name.medicine_generic_name LIKE '%A%'

--------------------------------------


WITH diseaseInfo_collective (disId,diseaseName,dis_type,dis_min_period,
                  dis_max_period,symptom_list,med_generic_name,antimed_generic_name) AS(
select 
       DISTINCT  difo2.disease_id as disId,
       
	   (select disease_name from disease_name where disease_name.disease_id = difo2.disease_id) as diseaseName,

	   STUFF((select DISTINCT ','+  (select disease_type from disease_type where disease_type.disease_type_id = difo1.disease_type_id)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS dis_type,

	   STUFF((select DISTINCT ','+  CAST(AVG(min_period) AS NVARCHAR)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS dis_min_period,
		
	   STUFF((select DISTINCT ','+  CAST(AVG(max_period) AS NVARCHAR)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS dis_max_period,

       STUFF((select DISTINCT ','+ (select symptom_name from symptom where symptom.symptom_id = difo1.symptom_id)
	          from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS symptom_list,

       STUFF((select DISTINCT ','+  (select medicine_generic_name from medicine_generic_name where medicine_generic_name.medicine_generic_id = difo1.medicine_generic_id)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS med_generic_name,
	   
	   STUFF((select DISTINCT ','+  (select medicine_generic_name from medicine_generic_name where medicine_generic_name.medicine_generic_id = difo1.anti_medicine_generic_name)
              from disease_info difo1
			  where difo1.disease_id = difo2.disease_id
			  FOR XML PATH('')),1,1,'') AS antimed_generic_name
	   
	   
from disease_info difo2
group by disease_id,min_period,max_period

)
select disId,diseaseName,dis_type,dis_min_period,
dis_max_period,symptom_list,med_generic_name,antimed_generic_name 
from diseaseInfo_collective 
where disId LIKE '%1%'	 
   OR diseaseName LIKE '%a%'
   OR dis_type LIKE '%a%'
   OR dis_min_period LIKE '%a%'
   OR dis_max_period LIKE '%a%'
   OR symptom_list LIKE '%a%'
   OR med_generic_name LIKE '%a%'
   OR antimed_generic_name LIKE '%a%'


--------------------------------------------------------------	
	
	
	
	 
----show disease info indivudual -------------------------


select 
         difo2.disease_id,
       
	   (select disease_name from disease_name where disease_name.disease_id = difo2.disease_id) as diseaseName,

	   (select disease_type from disease_type where disease_type.disease_type_id = difo2.disease_type_id) as dis_type,
              
	    difo2.min_period,

		difo2.max_period,
	   
       (select symptom_name from symptom where symptom.symptom_id = difo2.symptom_id) as symp,
	   
       (select medicine_generic_name from medicine_generic_name where medicine_generic_name.medicine_generic_id = difo2.medicine_generic_id) as med_generic_name,
       
	  (select medicine_generic_name from medicine_generic_name where medicine_generic_name.medicine_generic_id = difo2.anti_medicine_generic_name) as antimed_generic_name
             
	   
from disease_info difo2
          


-------------------------------------------------------------------------


-------search disease info individual --------------------------------



WITH diseaseInfo_individual (disId,diseaseName,dis_type,dis_min_period,
                  dis_max_period,symptom_list,med_generic_name,antimed_generic_name) AS(
select 
         difo2.disease_id as disId,
       
	   (select disease_name from disease_name where disease_name.disease_id = difo2.disease_id) as diseaseName,

	   (select disease_type from disease_type where disease_type.disease_type_id = difo2.disease_type_id) as dis_type,
              
	    difo2.min_period as dis_min_period,

		difo2.max_period as dis_max_period,
	   
       (select symptom_name from symptom where symptom.symptom_id = difo2.symptom_id) as symptom_list,
	   
       (select medicine_generic_name from medicine_generic_name where medicine_generic_name.medicine_generic_id = difo2.medicine_generic_id) as med_generic_name,
       
	  (select medicine_generic_name from medicine_generic_name where medicine_generic_name.medicine_generic_id = difo2.anti_medicine_generic_name) as antimed_generic_name
             
	   
from disease_info difo2
          
)
select disId,diseaseName,dis_type,dis_min_period,
dis_max_period,symptom_list,med_generic_name,antimed_generic_name 
from diseaseInfo_individual 
where disId LIKE '%1%'	 
   OR diseaseName LIKE '%a%'
   OR dis_type LIKE '%a%'
   OR dis_min_period LIKE '%a%'
   OR dis_max_period LIKE '%a%'
   OR symptom_list LIKE '%a%'
   OR med_generic_name LIKE '%a%'
   OR antimed_generic_name LIKE '%a%'


--------------------------------------------------------------------------



----- show medicine collective ---------------------------

select  
        DISTINCT medicine_generic_name.medicine_generic_id,
		 
	    medicine_generic_name,
        
		STUFF((select DISTINCT ','+ medicine_local_name.medicine_local_name
              from medicine_local_name
			  where medicine_local_name.medicine_generic_id = medicine_generic_name.medicine_generic_id
			  FOR XML PATH('')),1,1,'') AS med_local,
 
        medicine_generic_note

from medicine_generic_name
left join medicine_local_name
on medicine_generic_name.medicine_generic_id = medicine_local_name.medicine_generic_id


-----------------------------------------------------------------------


-- search medicine collective----------------------------

with medicine_collective(med_generic_id,med_generic_name,med_local,med_generic_note)AS(
select  
        DISTINCT medicine_generic_name.medicine_generic_id as med_gemeric_id,
		 
	    medicine_generic_name as med_generic_name,
        
		STUFF((select DISTINCT ','+ medicine_local_name.medicine_local_name
              from medicine_local_name
			  where medicine_local_name.medicine_generic_id = medicine_generic_name.medicine_generic_id
			  FOR XML PATH('')),1,1,'') AS med_local,
 
        medicine_generic_note as med_generic_note

from medicine_generic_name
left join medicine_local_name
on medicine_generic_name.medicine_generic_id = medicine_local_name.medicine_generic_id
)
select * from medicine_collective
where med_generic_id LIKE '%a%'
   OR med_generic_name LIKE '%A%'
   OR med_local LIKE '%A%'
   OR med_generic_note LIKE '%A%'


---------------------------------------



----- show  medicine individual ---------------------------------

select  
        medicine_generic_name.medicine_generic_id,
		medicine_generic_name,
        medicine_local_name.medicine_local_name,
        medicine_generic_note

from medicine_generic_name
left join medicine_local_name
on medicine_generic_name.medicine_generic_id = medicine_local_name.medicine_generic_id



----------------------------------------------------------

----search medicine individual -------------------------


with medicine_individual (med_generic_id,med_generic_name,med_local_name,med_generic_note) AS(
select  
        medicine_generic_name.medicine_generic_id as med_generic_id,
		medicine_generic_name as med_generic_name,
        medicine_local_name.medicine_local_name as med_local_name,
        medicine_generic_note as med_generic_note

from medicine_generic_name
left join medicine_local_name
on medicine_generic_name.medicine_generic_id = medicine_local_name.medicine_generic_id
)
select * from medicine_individual
where med_generic_id LIKE '%a%'
   OR med_generic_name LIKE '%a%'
   OR med_local_name LIKE '%a%'
   OR med_generic_note LIKE '%a%'




--------------------------------------------


-----------show treatment progress normaly----------------
 
select treatment_feedback_id,consult_id, success_rate,
       ROUND( AVG(success_rate) OVER(ORDER BY success_rate),3) AS average_success_rate
from treatment_feedback
where consult_id =1
--GROUP BY consult_id
--HAVING consult_id = 1 

---show treatment progress precisely-------
        
select treatment_feedback_id,consult_id, success_rate,
        ROUND(AVG(success_rate) OVER(ORDER BY treatment_feedback_id
        ROWS BETWEEN 1 PRECEDING AND 1 FOLLOWING),3) AS average_success_rate
from treatment_feedback
where consult_id =1


-----------------------------------------------


-----Medicine success rate----------------


Select [medicine_generic_name], [20], [30], [40]
from 
(
   Select medicine_generic_name,age,med_success_rate from doc_med_feedback
) as SourceTable
Pivot
(
 AVG(med_success_rate)
 for age in ([20],[30],[40])
) as PivotTable



SELECT medicine_generic_name, COUNT(*) AS patient_number,
        AVG(med_success_rate) AS Avg_rate,
        MIN(med_success_rate) AS Min_rate,
		MAX(med_success_rate) AS Max_rate
FROM doc_med_feedback
GROUP BY medicine_generic_name


-------------------------------------------------	  