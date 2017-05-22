create table Users(
	userID int ,
	userRole int,
	userName char(20),
	userPassword char(20),
	userMail char(50),
	Primary Key(userID)
)
create table Courses(
	courseID int,
	courseCode char(8),
	courseName char(50),
	department char(50),
	Primary Key(courseID)
)
create table UploadedMaterials(
	materialID int,
	materialType int,
	materialName char(20),
	materialSize char(10),
	materialUrl char(50),
	avgRating float,
	numberOfDownloads int,
	uploadDate date,
	uploadedBy int NOT NULL,
	course int NOT NULL,
	Primary Key(materialID),
	Foreign Key(uploadedBy)
	References Users(userID)
	On delete Cascade,
	Foreign Key(course)
	References Courses(courseID)
	On delete Cascade
)
create table Comments(
	commentID int,
	commentText char(140),
	commentDate date,
	commentedBy int NOT NULL,
	commentedTo int NOT NULL,
	Primary Key(commentID),
	Foreign Key(commentedBy)
	References Users(userID),
	Foreign Key(commentedTo)
	References UploadedMaterials(materialID)

)
create table Announcements(
	announcementID int,
	announcementText char(140),
	announcementDate date,
	announcedBy int,
	Primary Key(announcementID),
	Foreign Key(announcedBy)
	References Users(userID)
	On delete Cascade
)
create table Follows(
	userID int,
	courseID int,
	Primary Key(userID,courseID),
	Foreign Key(userID)
	References Users(userID)
	On delete Cascade,
	Foreign Key(courseID)
	References Courses(courseID)
	On delete Cascade
)
create table Rates(
	userID int,
	materialID int,
	rating float,
	Primary Key(userID,materialID),
	Foreign Key(userID)
	References Users(userID),
	Foreign Key(materialID)
	References UploadedMaterials(materialID)
	On delete Cascade
)

insert into Users values(1,0,'enes','parola123','enes@mail.com')
insert into Users values(2,0,'ismail','ismail1907','ismail@mail.com')
insert into Users values(3,0,'furkan','furkan567','furkan@mail.com')
insert into Users values(4,0,'sercan','sercan123','sercan@mail.com')
insert into Users values(5,0,'ahmet','ahmet.123','ahmet@mail.com')

insert into Courses values(1,'MIS335','Database Systems','Management Information Systems')
insert into Courses values(2,'MIS321','System Analysis and Design','Management Information Systems')
insert into Courses values(3,'MIS331','Data Mining','Management Information Systems')
insert into Courses values(4,'MIS353','Cyber Law','Management Information Systems')
insert into Courses values(5,'TRM437','Airline Management I','Tourism Administration')
insert into Courses values(6,'INTT253','Export Import Management','International Trade')

insert into UploadedMaterials values(1,0,'dersNotlarý.doc','30kb','/ders-notlari',4.5,10,'20161010',3,2)
insert into UploadedMaterials values(2,0,'chapter5.pdf','200kb','/chapter5',4.75,25,'20160913',2,3)
insert into UploadedMaterials values(3,0,'sýnav_sonuclari.xls','180kb','/sinav-sonuc',3.0,30,'20161115',5,6)
insert into UploadedMaterials values(4,0,'cahpter2.pdf','50kb','/chapter2',4.0,15,'20160915',2,1)
insert into UploadedMaterials values(5,0,'sunum.pdf','320kb','/sunum.pdf',4.75,50,'20160915',1,1)

insert into Comments values(1,'Chapter 3 üde yükleyebilirmisin?','20160916',5,4)
insert into Comments values(2,'Çok Teþekkürler','20160913',4,2)

insert into Follows values(1,1)
insert into Follows values(1,2)
insert into Follows values(1,3)
insert into Follows values(1,4)
insert into Follows values(1,5)
insert into Follows values(2,1)
insert into Follows values(2,4)
insert into Follows values(3,5)
insert into Follows values(3,2)
insert into Follows values(4,1)
insert into Follows values(4,2)
insert into Follows values(5,3)
insert into Follows values(5,5)

insert into Announcements values(1,'MIS 335 için ekstra notu olan var mý?','20161011',3)
insert into Announcements values(2,'MIS 331 quiz de hangi konular çýkacak','20160812',5)

insert into Rates values(1,1,5.0)
insert into Rates values(2,2,4.0)
insert into Rates values(3,1,4.0)
insert into Rates values(1,4,3.0)
insert into Rates values(5,1,3.5)
insert into Rates values(4,3,4.5)
insert into Rates values(2,1,3.0)
insert into Rates values(5,2,5.0)