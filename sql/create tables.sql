create table [User]
(
	UserId int primary key identity,
	FirstName VARCHAR(50) not null,
	LastName  VARCHAR(50) not null,
	UserName  VARCHAR(50) not null,
	Password  VARCHAR(10) not null      
)

create table [Customer]
(
	CustomerId int primary key identity,
	FullName VARCHAR(50) not null,
	DocumentNumber  VARCHAR(8)    
)

create table [Booking]
(
	BookingId int primary key identity,
	RegisterDate  datetime not null,
	Code VARCHAR(50) not null,
	Type VARCHAR(50) not null,
	UserId INT not null,
	CustomerId INT not null

	FOREIGN KEY (UserId) REFERENCES [User](UserId),
	FOREIGN KEY (CustomerId) REFERENCES [Customer](CustomerId)
)