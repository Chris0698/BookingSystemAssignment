DROP TABLE IF EXISTS Clients; 

CREATE TABLE Clients (
	ID VARCHAR(10),
	companyName VARCHAR(100),
	companyAddress varchar(256),
	PRIMARY KEY (ID)
); 

INSERT INTO Clients values ('0', 'Cyberdyne Systems', '10 street');
INSERT INTO Clients values ('1', 'S.H.I.E.L.D', '11 street');
INSERT INTO Clients values ('2', 'Black Sun', '12 street');




DROP TABLE IF EXISTS Venues; 
CREATE TABLE Venues (
	ID VARCHAR(10),
	venueName VARCHAR(256),
	venueAddress VARCHAR(256),
	cost decimal,
	PRIMARY KEY (ID)
);



DROP TABLE IF EXISTS Activities;
CREATE TABLE Activities (
	ID VARCHAR(10),
	activityName VARCHAR(100),
	cost decimal,
	PRIMARY KEY (ID)
);

INSERT INTO Activities values ('0', 'Go Kart', 1400);
INSERT INTO Activities values ('1', 'Wall Climbing', 700);
INSERT INTO Activities values ('2', 'Meditation and Mindfulness', 500);
INSERT INTO Activities values ('3', 'Team Building and Problem Solving', 850);
INSERT INTO Activities values ('4', 'Choclate Producing and Marketing', 750);

DROP TABLE IF EXISTS VenueExtrasLink  
CREATE TABLE VenueExtrasLinks (
	ID VARCHAR(10),
	bookingID VARCHAR(10),
	extraID VARCHAR(10),
	FOREIGN KEY (bookingID) REFERENCES Bookings(bookingID),
	FOREIGN KEY (extraID) REFERENCES VenueDecorators(ID),
	PRIMARY KEY (ID)
);

DROP TABLE IF EXISTS VenueDecorators
CREATE TABLE VenueDecorators(
	ID VARCHAR(10),
	name VARCHAR(50),
	cost decimal,
	PRIMARY KEY (ID)
);

INSERT INTO VenueDecorators values ('0', 'Afternoon Refreshments', 15);
INSERT INTO VenueDecorators values ('1', 'Bus Transports', 50);
INSERT INTO VenueDecorators values ('2', 'Evening Meal', 20);
INSERT INTO VenueDecorators values ('3', 'Morning Refreshments', 15);
INSERT INTO VenueDecorators values ('4', 'Mid day Lunch', 30);

INSERT INTO VenueExtrasLinks values ('0', '0', '0');
INSERT INTO VenueExtrasLinks values ('1', '0', '1');
INSERT INTO VenueExtrasLinks values ('2', '2', '4');


INSERT INTO Venues values ('0', 'Go Kart Newcastle', '12 Newcastle Road', 0);
INSERT INTO Venues values ('1', 'Wall Climbing Extreme', '10 A Road, England', 0);
INSERT INTO Venues values ('2', 'The worlds worst choclate experience', '1 St James', 0);
INSERT INTO Venues values ('3', 'Mediation extras', '100 Downsquare Road', 0);
INSERT INTO Venues values ('4', 'Woodland Park', 'County Park Northumberland', 0);

DROP TABLE IF EXISTS Bookings;
CREATE TABLE Bookings (
	bookingID VARCHAR(10),
	bookingType VARCHAR(50) CONSTRAINT ActivityTypeCheck CHECK (bookingType = 'simple' or bookingType = 'facilitated'),
	date varchar(100),
	time varchar(20),
	clientID VARCHAR(10),
	venueID VARCHAR(10),
	activityID VARCHAR(10),
	cost decimal
	PRIMARY KEY (bookingID),
	FOREIGN KEY (clientID) REFERENCES Clients(ID),
	FOREIGN KEY (venueID) REFERENCES Venues(ID),
	FOREIGN KEY (activityID) REFERENCES Activities(ID)
);

INSERT INTO Bookings values ('0', 'simple', '2020-02-09', '10:30', '0', '0', '0', '0', 0);
INSERT INTO Bookings values ('1', 'simple', '2020-02-12', '11:30', '0', '1', '1', '0', 0);
INSERT INTO Bookings values ('2', 'facilitated', '2020-02-09', '10:30', '1', '2', '4', '0', 0);
INSERT INTO Bookings values ('3', 'facilitated', '2020-02-09', '10:30', '2', '3', '2', '0', 0);
INSERT INTO Bookings values ('4', 'facilitated', '2020-02-20', '15:30', '2', '4', '3', '0', 0);