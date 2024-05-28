CREATE TABLE `cashflowdb`.`users` (
  `Id` BIGINT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(245) NOT NULL,
  `Email` VARCHAR(255) NOT NULL,
  `Password` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE);
