use Cinema_APP
SET IDENTITY_INSERT Movies ON;

INSERT INTO Movies (Id, Name, Description, Status, Actors, Price, Main_Img,Show_Time, CategoryId, CinemaId, Discount, Quantity, Rate)
VALUES (101, 'Kill Bill', 'a girl wake up seeking revenge', 1, 'Quentin Tarantino', 22, 'InTempor.jpeg', '2027-01-25', 3, 10, 0, 10, 9.3);
SET IDENTITY_INSERT Movies OFF;