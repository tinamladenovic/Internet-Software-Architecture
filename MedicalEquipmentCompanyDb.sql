INSERT INTO "Accounts"("Id", "Name", "Surname", "Email", "City", "Country", "Phone", "Profession", "UserId", "IsActivate", "Enterprise", "Penalties")
VALUES 
  (1, 'John', 'Doe', 'johndoe@example.com', 'New York', 'USA', '+1234567890', 'Doctor', 1, true, 'Healthcare Clinic', 0),
  (2, 'Alice', 'Smith', 'alice.smith@example.com', 'Los Angeles', 'USA', '+1987654321', 'Nurse', 2, true, 'Community Hospital', 0),
  (3, 'Bob', 'Johnson', 'bjohnson@example.com', 'Chicago', 'USA', '+1122334455', 'Medical Technician', 3, true, 'Medical Center', 0);


INSERT INTO public."Companies"( 
        "Id", "AdministratorIds", "Name", "Street", "City", "Country", "Description", "AverageCompanyRating", "CompanyWorkingHours")
VALUES 
(1, '{1, 2}', 'Medical Supplies Inc.', '123 Main Street', 'New York', 'USA', 'Supplier of medical equipment', 4.5,  '{8, 20}'),
(2, '{5, 6}', 'Healthcare Solutions Ltd.', '456 Oak Avenue', 'Los Angeles','USA', 'Healthcare equipment provider', 4.5, '{6, 18}'),
(3, '{3, 4}', 'MedTech Innovations', '789 Elm Road', 'Chicago','USA', 'Cutting-edge medical technology company', 4.5, '{6, 21}');


INSERT INTO "CompanyAdministratorProfiles"(
    "Id", "UserId", "Name", "Surname", "Email", "CompanyId")
VALUES 
    (1, 1, 'John', 'Doe', 'john.doe@example.com', 1),
    (2, 2, 'Jane', 'Smith', 'jane.smith@example.com', 12),
    (3, 3, 'Michael', 'Johnson', 'michael.johnson@example.com', 3),
    (4, 4, 'Nikolina', 'Ivosevic', 'nikolina.ivosevic@example.com', 3),
    (5, 5, 'Sonja', 'Sekulic', 'sonja.sekulic@example.com', 2),
    (6, 6, 'Tina', 'Mladenovic', 'tina.mladenovic@example.com', 2);

INSERT INTO "CompanyRatings"(
    "Id", "UserId", "CompanyId", "Rating", "Criterias", "Comment")
VALUES 
    (1, 1, 1, 4, '{1, 2, 3}', 'Good service overall'),
    (2, 2, 2, 5, '{1, 3, 4}', 'Excellent company to work with'),
    (3, 3, 3, 3, '{2, 3, 5}', 'Could improve in some areas');

INSERT INTO "CompanyWorkingHours"(
    "Id", "DayOfWeek", "StartTime", "EndTime")
VALUES 
    (1, 1, '2023-11-20 08:00:00-05', '2023-11-20 17:00:00-05'),
    (2, 2, '2023-11-21 09:00:00-05', '2023-11-21 18:00:00-05'),
    (3, 3, '2023-11-22 07:30:00-05', '2023-11-22 16:30:00-05');

 INSERT INTO "Complains"(
	"Id", "UserId", "Text", "Type", "IsResolved", "CreatedAt", "Reply")
VALUES 
	(1, 1, 'Issue with order delivery', 1, false, '2023-11-19 10:00:00', null),
	(2, 2, 'Product quality is poor', 2, false, '2023-11-18 14:30:00', null),
	(3, 3, 'Incorrect billing amount', 1, false, '2023-11-17 09:45:00', null);

INSERT INTO "Discounts"(
	"Id", "ClassId", "DiscountPrecentage")
VALUES 
	(1, 1, 10),
	(2, 2, 15),
	(3, 3, 20);

    INSERT INTO "EquipmentPickups"(
	"Id", "AdministratorId", "CompanyId", "DateAndTime", "Duration", "IsReserved")
VALUES 
	(1, 1, 1, '2023-11-20 10:00:00', 2, false),
	(2, 2, 2, '2023-11-21 14:30:00', 1, true),
	(3, 3, 3, '2023-11-22 09:00:00', 2, false);

INSERT INTO "EquipmentReservations"(
	"Id", "UserId", "CompanyId", "ReservationDate", "ReservationStatus", "ReservedEquipment", "EquipmentCount", "EquipmentPickup")
VALUES 
	(1, 1, 1, '2023-11-20', 1, '{101, 102}', '{2, 1}', 1),
	(2, 2, 2, '2023-11-21', 1, '{103}', '{3}', 2),
	(3, 3, 3, '2023-11-22', 0, '{104, 105, 106}', '{1, 1, 1}', 3);

INSERT INTO "Equipments"(
    "Id", "Name", "Type", "Description", "QuantityInStock", "Price", "CompanyId")
VALUES 
    (1, 'Stethoscope', 'Medical', 'A medical instrument for listening to the action of someone heart or breathing', 50, 29.99, 1),
    (2, 'Wheelchair', 'Medical', 'A chair built on wheels for people who are sick or disabled', 30, 199.99, 2),
    (3, 'Surgical Mask', 'Medical', 'A protective mask worn by medical staff', 1000, 1.99, 3),
    (4, 'Stethoscope', 'Medical', 'A medical instrument for listening to the action of someone heart or breathing', 50, 29.99, 2),
    (5, 'Wheelchair', 'Medical', 'A chair built on wheels for people who are sick or disabled', 30, 199.99, 3),
    (6, 'Surgical Mask', 'Medical', 'A protective mask worn by medical staff', 1000, 1.99, 1),
    (7, 'Stethoscope', 'Medical', 'A medical instrument for listening to the action of someone heart or breathing', 50, 29.99, 3),
    (8, 'Wheelchair', 'Medical', 'A chair built on wheels for people who are sick or disabled', 30, 199.99, 1),
    (9, 'Surgical Mask', 'Medical', 'A protective mask worn by medical staff', 1000, 1.99, 2);

INSERT INTO "LoyaltyClassEntries"(
    "Id", "ClassId", "Scale")
VALUES 
    (1, 101, 5),
    (2, 102, 10),
    (3, 103, 15);

INSERT INTO "LoyaltyPrograms"(
    "Id", "UserId", "Points", "PointsCategory")
VALUES 
    (1, 1, 500, 1),
    (2, 2, 750, 1),
    (3, 3, 300, 2);

INSERT INTO "People"(
    "Id", "UserId", "Name", "Surname", "Email")
VALUES 
    (1, 1, 'John', 'Doe', 'johndoe@example.com'),
    (2, 2, 'Jane', 'Smith', 'jane.smith@example.com'),
    (3, 3, 'Michael', 'Johnson', 'bob.johnson@example.com'),
    (4, 4, 'Nikolina', 'Ivosevic', 'nikolina.ivosevic@example.com'),
    (5, 5, 'Sonja', 'Sekulic', 'sonja.sekulic@example.com'),
    (6, 6, 'Tina', 'Mladenovic', 'tina.mladenovic@example.com'),
    (7, 7, 'System', 'Administrator', 'sadmin@example.com'),
    (8, 8, 'Registered', 'User', 'reguser@example.com');


INSERT INTO "Replies"(
    "Id", "UserId", "Text", "CreatedAt")
VALUES 
    (1, 1, 'Thank you for your feedback.', '2023-11-20 10:30:00-05'),
    (2, 2, 'We apologize for the inconvenience.', '2023-11-21 09:45:00-05'),
    (3, 3, 'Your issue has been resolved.', '2023-11-22 11:15:00-05');

INSERT INTO "Users"(
    "Id", "Email", "Password", "Role", "IsActive")
VALUES 
    (1, 'john.doe@example.com', 'john', 0, true),
    (2, 'jane.smith@example.com', 'jane', 0, true),
    (3, 'michael.johnson@example.com', 'michael', 0, true),
    (4, 'nikolina.ivosevic@example.com', 'nikolina', 0, true),
    (5, 'sonja.sekulic@example.com', 'sonja', 0, true),
    (6, 'tina.mladenovic@example.com', 'tina', 0, true),
    (7, 'sadmin@example.com', 'sadmin', 1, true),
    (8, 'reguser@example.com', 'reguser', 2, true);

