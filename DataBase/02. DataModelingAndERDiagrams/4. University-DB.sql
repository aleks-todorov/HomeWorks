SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `University-DB` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `University-DB` ;

-- -----------------------------------------------------
-- Table `University-DB`.`Faculties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University-DB`.`Faculties` (
  `ID` INT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  PRIMARY KEY (`ID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University-DB`.`Departments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University-DB`.`Departments` (
  `ID` INT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `FacultyID` INT NULL ,
  PRIMARY KEY (`ID`) ,
  CONSTRAINT `FacultyID`
    FOREIGN KEY ()
    REFERENCES `University-DB`.`Faculties` ()
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University-DB`.`Titles`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University-DB`.`Titles` (
  `Id` INT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  PRIMARY KEY (`Id`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University-DB`.`Professors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University-DB`.`Professors` (
  `ID` INT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(50) NULL ,
  `DepartmentID` INT NULL ,
  `TitleID` INT NULL ,
  PRIMARY KEY (`ID`) ,
  CONSTRAINT `DepartmentID`
    FOREIGN KEY ()
    REFERENCES `University-DB`.`Departments` ()
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `TitleID`
    FOREIGN KEY ()
    REFERENCES `University-DB`.`Titles` ()
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University-DB`.`Courses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University-DB`.`Courses` (
  `ID` INT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `ProffessorID` INT NULL ,
  `DepartmentID` INT NULL ,
  PRIMARY KEY (`ID`) ,
  CONSTRAINT `ProfessorID`
    FOREIGN KEY ()
    REFERENCES `University-DB`.`Professors` ()
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `DepartmentID`
    FOREIGN KEY ()
    REFERENCES `University-DB`.`Departments` ()
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University-DB`.`Student`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University-DB`.`Student` (
  `ID` INT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `FacultyID` INT NULL ,
  PRIMARY KEY (`ID`) ,
  CONSTRAINT `FacultyId`
    FOREIGN KEY ()
    REFERENCES `University-DB`.`Faculties` ()
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University-DB`.`StudentCourses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University-DB`.`StudentCourses` (
  `StudentID` INT NULL ,
  `CourseID` INT NULL ,
  CONSTRAINT `StudentId`
    FOREIGN KEY ()
    REFERENCES `University-DB`.`Student` ()
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `CourseID`
    FOREIGN KEY ()
    REFERENCES `University-DB`.`Courses` ()
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `University-DB` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
