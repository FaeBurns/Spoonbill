drop table if exists FlightPassenger;
drop table if exists FlightPilot;
drop table if exists FlightStaffWorker;
drop table if exists Passengers;
drop table if exists Pilots;
drop table if exists StaffWorkers;
drop table if exists Stops;
drop table if exists Airports;
drop table if exists Flights;
drop table if exists Planes;
drop table if exists PlaneModels;
drop table if exists Manufacturers;
drop table if exists Cities;
drop table if exists Counties;

create table Counties
(
    Name    nvarchar(20) not null,
    Country nvarchar(20) not null,
    constraint PK_Counties
        primary key (Name)
);

create table Cities
(
    Name       nvarchar(50) not null,
    CountyName nvarchar(20) not null,
    constraint PK_Cities
        primary key (Name),
    constraint FK_Cities_Counties_CountyName
        foreign key (CountyName) references Counties
            on delete cascade
);

create table Airports
(
    Name     nvarchar(20) not null,
    CityName nvarchar(50) not null,
    constraint PK_Airports
        primary key (Name),
    constraint FK_Airports_Cities_CityName
        foreign key (CityName) references Cities
            on delete cascade
);

create index IX_Airports_CityName
    on Airports (CityName);

create index IX_Cities_CountyName
    on Cities (CountyName);

create table Manufacturers
(
    Name     nvarchar(50) not null,
    CityName nvarchar(50) not null,
    constraint PK_Manufacturers
        primary key (Name),
    constraint FK_Manufacturers_Cities_CityName
        foreign key (CityName) references Cities
            on delete cascade
);

create index IX_Manufacturers_CityName
    on Manufacturers (CityName);

create table Passengers
(
    Id          int identity,
    Name        nvarchar(20) not null,
    Surname     nvarchar(20) not null,
    PhoneNumber nvarchar(20) not null,
    Address     nvarchar(50) not null,
    constraint PK_Passengers
        primary key (Id)
);

create table Pilots
(
    Id          int identity,
    TypeRating  nvarchar(20)  not null,
    Name        nvarchar(20)  not null,
    Surname     nvarchar(20)  not null,
    PhoneNumber nvarchar(20)  not null,
    Address     nvarchar(50)  not null,
    Salary      decimal(8, 2) not null,
    constraint PK_Pilots
        primary key (Id)
);

create table PlaneModels
(
    ModelNumber      int,
    ManufacturerName nvarchar(50) not null,
    TypeRating       nvarchar(20) not null,
    constraint PK_PlaneModels
        primary key (ModelNumber),
    constraint FK_PlaneModels_Manufacturers_ManufacturerName
        foreign key (ManufacturerName) references Manufacturers
            on delete cascade
);

create index IX_PlaneModels_ManufacturerName
    on PlaneModels (ManufacturerName);

create table Planes
(
    Serial      nvarchar(20) not null,
    ModelNumber int          not null,
    constraint PK_Planes
        primary key (Serial),
    constraint FK_Planes_PlaneModels_ModelNumber
        foreign key (ModelNumber) references PlaneModels
            on delete cascade
);

create table Flights
(
    FlightId      int identity,
    PlaneSerial   nvarchar(20) not null,
    Name          nvarchar(20) not null,
    DepartureTime datetime2    not null,
    ArrivalTime   datetime2    not null,
    constraint PK_Flights
        primary key (FlightId),
    constraint FK_Flights_Planes_PlaneSerial
        foreign key (PlaneSerial) references Planes
            on delete cascade
);

create table FlightPassenger
(
    FlightsFlightId int not null,
    PassengersId    int not null,
    constraint PK_FlightPassenger
        primary key (FlightsFlightId, PassengersId),
    constraint FK_FlightPassenger_Flights_FlightsFlightId
        foreign key (FlightsFlightId) references Flights
            on delete cascade,
    constraint FK_FlightPassenger_Passengers_PassengersId
        foreign key (PassengersId) references Passengers
            on delete cascade
);

create index IX_FlightPassenger_PassengersId
    on FlightPassenger (PassengersId);

create table FlightPilot
(
    AssignedFlightsFlightId int not null,
    PilotsId                int not null,
    constraint PK_FlightPilot
        primary key (AssignedFlightsFlightId, PilotsId),
    constraint FK_FlightPilot_Flights_AssignedFlightsFlightId
        foreign key (AssignedFlightsFlightId) references Flights
            on delete cascade,
    constraint FK_FlightPilot_Pilots_PilotsId
        foreign key (PilotsId) references Pilots
            on delete cascade
);

create index IX_FlightPilot_PilotsId
    on FlightPilot (PilotsId);

create index IX_Flights_PlaneSerial
    on Flights (PlaneSerial);

create index IX_Planes_ModelNumber
    on Planes (ModelNumber);

create table StaffWorkers
(
    Id          int identity,
    Role        nvarchar(20)  not null,
    Name        nvarchar(20)  not null,
    Surname     nvarchar(20)  not null,
    PhoneNumber nvarchar(20)  not null,
    Address     nvarchar(50)  not null,
    Salary      decimal(8, 2) not null,
    constraint PK_StaffWorkers
        primary key (Id)
);

create table FlightStaffWorker
(
    AssignedFlightsFlightId int not null,
    WorkerStaffId           int not null,
    constraint PK_FlightStaffWorker
        primary key (AssignedFlightsFlightId, WorkerStaffId),
    constraint FK_FlightStaffWorker_Flights_AssignedFlightsFlightId
        foreign key (AssignedFlightsFlightId) references Flights
            on delete cascade,
    constraint FK_FlightStaffWorker_StaffWorkers_WorkerStaffId
        foreign key (WorkerStaffId) references StaffWorkers
            on delete cascade
);

create index IX_FlightStaffWorker_WorkerStaffId
    on FlightStaffWorker (WorkerStaffId);

create table Stops
(
    Id          int identity,
    AirportName nvarchar(20) not null,
    [Order]     int          not null,
    FlightId    int,
    constraint PK_Stops
        primary key (Id),
    constraint FK_Stops_Airports_AirportName
        foreign key (AirportName) references Airports
            on delete cascade,
    constraint FK_Stops_Flights_FlightId
        foreign key (FlightId) references Flights
);

create index IX_Stops_AirportName
    on Stops (AirportName);

create index IX_Stops_FlightId
    on Stops (FlightId);