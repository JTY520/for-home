CREATE TABLE ComplainTable(
  UserId int NOT NULL,
  HouseId  int NOT NULL,
  IsPass bit NOT NULL,
  ComplainReason varchar(200) NOT NULL,
  CONSTRAINT ComplainId PRIMARY KEY (UserId,HouseId)
)