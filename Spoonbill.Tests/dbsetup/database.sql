DROP TABLE IF EXISTS PILOT_RATINGS;
DROP TABLE IF EXISTS FLIGHT_CREW;
DROP TABLE IF EXISTS FLIGHT_STRETCHES;
DROP TABLE IF EXISTS FLIGHT_PASSENGERS;
DROP TABLE IF EXISTS FLIGHTS;
DROP TABLE IF EXISTS PLANES;
DROP TABLE IF EXISTS PLANE_MODELS;
DROP TABLE IF EXISTS STRETCHES;
DROP TABLE IF EXISTS MANUFACTURERS;
DROP TABLE IF EXISTS AIRPORTS;
DROP TABLE IF EXISTS CITIES;
DROP TABLE IF EXISTS COUNTIES;
DROP TABLE IF EXISTS STAFF;
DROP TABLE IF EXISTS ADDRESSES;
DROP TABLE IF EXISTS PHONENUMBERS;
DROP TABLE IF EXISTS PERSON;

/* Defines a person - has an id, name, surname, and DoB */
CREATE TABLE PERSON(
                       person_id		int NOT NULL,
                       name			varchar(50) NOT NULL,
                       surname			varchar(50) NOT NULL,
                       date_of_birth   datetime NOT NULL,
                       PRIMARY KEY (person_id)
);

/* Defines a person's address - 1 person can have multiple addresses */
CREATE TABLE ADDRESSES(
                          person_id		int NOT NULL,
                          address			varchar(50) NOT NULL,
                          PRIMARY KEY (person_id, address),
                          FOREIGN KEY (person_id) references PERSON(person_id) ON DELETE CASCADE
);

/* Defines a person's phone number - 1 person can have multiple phone numbers */
CREATE TABLE PHONENUMBERS(
                             person_id		int NOT NULL,
                             phone_number 	varchar(20) NOT NULL,
                             PRIMARY KEY (person_id, phone_number),
                             FOREIGN KEY (person_id) references PERSON(person_id) ON DELETE CASCADE
);

/* Inherits from staff, adds data about the staff member's salary and their job role */
CREATE TABLE STAFF(
                      person_id		int NOT NULL,
                      salary			numeric(8, 2) NOT NULL,
                      role			varchar(50) NOT NULL,
                      PRIMARY KEY (person_id),
                      FOREIGN KEY (person_id) references PERSON(person_id) ON DELETE CASCADE
);

/* Allows for a staff member to have a rating for a specific plane - only meant to be used with staff with the 'pilot' role */
CREATE TABLE PILOT_RATINGS(
                              staff_id		int NOT NULL,
                              rating			varchar(20) NOT NULL,
                              PRIMARY KEY (staff_id, rating),
                              FOREIGN KEY (staff_id) references STAFF(person_id) ON DELETE CASCADE

    /* Unsure how to add a constraint to make sure that only staff with the role pilot can be added - can be done in ui instead */
);

/* Defines in which country a county is present */
CREATE TABLE COUNTIES(
                         county			varchar(50) NOT NULL,
                         country			varchar(50) NOT NULL,
                         PRIMARY KEY (county)
);

/* Defines in which country a county is present */
CREATE TABLE CITIES(
                       city			varchar(50) NOT NULL,
                       county			varchar(50) NOT NULL,
                       PRIMARY KEY (city),
                       FOREIGN KEY (county) references COUNTIES(county)
);

/* Defines plane manufacturers and their location */
CREATE TABLE MANUFACTURERS(
                              manufacturer	varchar(30) NOT NULL,
                              city			varchar(50) NOT NULL,
                              PRIMARY KEY (manufacturer),
                              FOREIGN KEY (city) references CITIES(city)
);

/* Defines models of planes - includes the type rating that pilots must have in order to fly the plane */
CREATE TABLE PLANE_MODELS(
                             model_number	varchar(30) NOT NULL,
                             manufacturer	varchar(30) NOT NULL,
                             type_rating		varchar(20) NOT NULL,
                             PRIMARY KEY (model_number),
                             FOREIGN KEY (manufacturer) references MANUFACTURERS(manufacturer)
);

/* Defines a specific instance of a plane model */
CREATE TABLE PLANES(
                       plane_serial	varchar(30) NOT NULL,
                       model_number	varchar(30) NOT NULL,
                       PRIMARY KEY (plane_serial),
                       FOREIGN KEY (model_number) references PLANE_MODELS(model_number)
);

/* Defines a flight - includes which plane will be used, FLIGHT_STRETCHES defines the flights path */
/* repeat_interval states when this flight should next repeat, if ever */
CREATE TABLE FLIGHTS(
                        flight_id		int NOT NULL,
                        plane_serial	varchar(30) NOT NULL,
                        name			varchar(20) NOT NULL,
                        repeat_interval	varchar(50) NULL,
                        PRIMARY KEY (flight_id),
                        FOREIGN KEY (plane_serial) references PLANES(plane_serial)
);

/* Defines which crew will be on a flight */
CREATE TABLE FLIGHT_CREW(
                            flight_id		int NOT NULL,
                            staff_id		int NOT NULL,
                            PRIMARY KEY (flight_id, staff_id),
                            FOREIGN KEY (flight_id) references FLIGHTS(flight_id) ON DELETE CASCADE,
                            FOREIGN KEY (staff_id) references STAFF(person_id) ON DELETE CASCADE
);

/* Defines which passengers will be on a flight */
CREATE TABLE FLIGHT_PASSENGERS(
                                  flight_id		int NOT NULL,
                                  passenger_id	int NOT NULL,
                                  PRIMARY KEY (flight_id, passenger_id),
                                  FOREIGN KEY (flight_id) references FLIGHTS(flight_id) ON DELETE CASCADE,
                                  FOREIGN KEY (passenger_id) references PERSON(person_id) ON DELETE CASCADE
);

/* Defines the airports that a plane can fly between */
CREATE TABLE AIRPORTS(
                         airport_id		int NOT NULL,
                         city			varchar(50) NOT NULL,
                         PRIMARY KEY (airport_id),
                         FOREIGN KEY (city) references CITIES(city)
);

/* Defines the connections between stops a plane could take on a flight */
CREATE TABLE STRETCHES(
                          stretch_id		int NOT NULL,
                          source_airport	int NOT NULL,
                          dest_airport	int NOT NULL,
                          PRIMARY KEY(stretch_id),
                          FOREIGN KEY (source_airport) references AIRPORTS(airport_id),
                          FOREIGN KEY (dest_airport) references AIRPORTS(airport_id),

    /* Ensure that the stretch is going somewhere */
                          CONSTRAINT CHK_LOCATION CHECK(source_airport != dest_airport)
    );

/* Defines which stretches a plane will take during its flight */
CREATE TABLE FLIGHT_STRETCHES(
                                 flight_id		int NOT NULL,
                                 stretch_id		int NOT NULL,
                                 source_departure_time	datetime NOT NULL,
                                 dest_arrival_time	datetime NOT NULL,
                                 PRIMARY KEY (flight_id, stretch_id),
                                 FOREIGN KEY (flight_id) references FLIGHTS(flight_id) ON DELETE CASCADE,
                                 FOREIGN KEY (stretch_id) references STRETCHES(stretch_id),

    /* Ensure that the plane will arrive after it sets off */
                                 CONSTRAINT CHK_TIME CHECK (dest_arrival_time > source_departure_time)
);