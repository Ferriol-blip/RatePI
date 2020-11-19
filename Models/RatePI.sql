-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`PROYECTOSINTEGRADOS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`PROYECTOSINTEGRADOS` (
  `idProyecto` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) UNIQUE NOT NULL,
  `Descripcion` VARCHAR(45) NOT NULL,
  `CicloFormativo` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idProyecto`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`INTEGRANTES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`INTEGRANTES` (
  `idIntegrante` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(45) UNIQUE NOT NULL,
  `idProyecto_fk` INT NOT NULL,
  `Proyecto` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idIntegrante`),
  CONSTRAINT `fk_INTEGRANTES_PROYECTOSINTEGRADOS`
    FOREIGN KEY (`idProyecto_fk`)
    REFERENCES `mydb`.`PROYECTOSINTEGRADOS` (`idProyecto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ASISTENTES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`ASISTENTES` (
  `idAsistente` INT NOT NULL AUTO_INCREMENT,
  `Email` VARCHAR(45) UNIQUE NOT NULL,
  `NombreProyect` VARCHAR(45) NOT NULL,
  `PuntuacionCei` INT(1) NOT NULL,
  `PuntuacionPdi` INT(1) NOT NULL,
  `PuntuacionComunicacion` INT(1) NOT NULL,
  `idProyecto_fk` INT NOT NULL,
  PRIMARY KEY (`idAsistente`),
  CONSTRAINT `fk_ASISTENTES_PROYECTOSINTEGRADOS1`
    FOREIGN KEY (`idProyecto_fk`)
    REFERENCES `mydb`.`PROYECTOSINTEGRADOS` (`idProyecto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`CATEGORIAS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`CATEGORIAS` (
  `idCategoria` INT NOT NULL AUTO_INCREMENT,
  `idProyecto_fk` INT NOT NULL,
  `Categoria` VARCHAR(45) NOT NULL,
  `PuntuacionTotal` INT NOT NULL,
  `Proyecto` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idCategoria`),
  CONSTRAINT `fk_CATEGORIAS_PROYECTOSINTEGRADOS1`
    FOREIGN KEY (`idProyecto_fk`)
    REFERENCES `mydb`.`PROYECTOSINTEGRADOS` (`idProyecto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Data for table `mydb`.`PROYECTOSINTEGRADOS`
-- -----------------------------------------------------

USE `mydb`;
INSERT INTO `mydb`.`PROYECTOSINTEGRADOS` (`idProyecto`, `Nombre`, `Descripcion`, `CicloFormativo`) VALUES (1, 'Pro1', 'Cosas', 'DAM');
INSERT INTO `mydb`.`PROYECTOSINTEGRADOS` (`idProyecto`, `Nombre`, `Descripcion`, `CicloFormativo`) VALUES (2, 'Pro2', 'CosasWeb', 'DAW');




-- -----------------------------------------------------
-- Data for table `mydb`.`INTEGRANTES`
-- -----------------------------------------------------

USE `mydb`;
INSERT INTO `mydb`.`INTEGRANTES` (`idIntegrante`, `Nombre`, `Email`, `idProyecto_fk`, `Proyecto`) VALUES (1, 'Jose', 'jose@email', 1, 'pro1');
INSERT INTO `mydb`.`INTEGRANTES` (`idIntegrante`, `Nombre`, `Email`, `idProyecto_fk`, `Proyecto`) VALUES (2, 'Rafa', 'rafa@email', 2, 'pro2');




-- -----------------------------------------------------
-- Data for table `mydb`.`ASISTENTES`
-- -----------------------------------------------------

USE `mydb`;
INSERT INTO `mydb`.`ASISTENTES` (`idAsistente`, `Email`, `NombreProyect`, `PuntuacionCei`, `PuntuacionPdi`, `PuntuacionComunicacion`, `idProyecto_fk`) VALUES (1, 'algo@email', 'pro1', 2, 2, 2, 1);
INSERT INTO `mydb`.`ASISTENTES` (`idAsistente`, `Email`, `NombreProyect`, `PuntuacionCei`, `PuntuacionPdi`, `PuntuacionComunicacion`, `idProyecto_fk`) VALUES (2, 'me@email', 'pro2', 1, 1, 1, 2);




-- -----------------------------------------------------
-- Data for table `mydb`.`CATEGORIAS`
-- -----------------------------------------------------

USE `mydb`;
INSERT INTO `mydb`.`CATEGORIAS` (`idCategoria`, `idProyecto_fk`, `Categoria`, `PuntuacionTotal`, `Proyecto`) VALUES (1, 1, 'creatividad', 2, 'pro1');
INSERT INTO `mydb`.`CATEGORIAS` (`idCategoria`, `idProyecto_fk`, `Categoria`, `PuntuacionTotal`, `Proyecto`) VALUES (2, 1, 'implementacion', 2, 'pro1');
INSERT INTO `mydb`.`CATEGORIAS` (`idCategoria`, `idProyecto_fk`, `Categoria`, `PuntuacionTotal`, `Proyecto`) VALUES (3, 1, 'comunicacion', 2, 'pro1');
INSERT INTO `mydb`.`CATEGORIAS` (`idCategoria`, `idProyecto_fk`, `Categoria`, `PuntuacionTotal`, `Proyecto`) VALUES (4, 2, 'creatividad', 1, 'pro2');
INSERT INTO `mydb`.`CATEGORIAS` (`idCategoria`, `idProyecto_fk`, `Categoria`, `PuntuacionTotal`, `Proyecto`) VALUES (5, 2, 'implementacion', 1, 'pro2');
INSERT INTO `mydb`.`CATEGORIAS` (`idCategoria`, `idProyecto_fk`, `Categoria`, `PuntuacionTotal`, `Proyecto`) VALUES (6, 2, 'comunicacion', 1, 'pro2');

