CREATE DATABASE AutoSkolaTest;
GO

USE AutoSkolaTest;
GO

CREATE TABLE Polaznik (
    IdPolaznik   INT IDENTITY(1,1) PRIMARY KEY,
    Ime          NVARCHAR(100) NOT NULL,
    Prezime      NVARCHAR(100) NOT NULL,
    DatumRodjenja DATE NOT NULL,
    Telefon      NVARCHAR(20) NOT NULL
);

CREATE TABLE Instruktor (
    IdInstruktor     INT IDENTITY(1,1) PRIMARY KEY,
    Ime              NVARCHAR(100) NOT NULL,
    Prezime          NVARCHAR(100) NOT NULL,
    DatumZaposlenja  DATE NOT NULL,
    Telefon          NVARCHAR(20) NOT NULL,
    KorisnickoIme    NVARCHAR(100) NOT NULL,
    Sifra            NVARCHAR(100) NOT NULL
);

CREATE TABLE Automobil (
    IdAutomobil        INT IDENTITY(1,1) PRIMARY KEY,
    Model              NVARCHAR(100) NOT NULL,
    Godiste            INT NOT NULL,
    RegistracioniBroj  NVARCHAR(20) NOT NULL
);

CREATE TABLE KategorijaVozacke (
    IdKategorijaVozacke INT IDENTITY(1,1) PRIMARY KEY,
    Kategorija          NVARCHAR(10) NOT NULL,
    JacinaMotora        NVARCHAR(50) NOT NULL
);

CREATE TABLE EvidencioniObrazac (
    IdObrazac    INT IDENTITY(1,1) PRIMARY KEY,
    DatumPocetka DATE NOT NULL,
    BrojCasova   INT NOT NULL,
    IdInstruktor INT REFERENCES Instruktor(IdInstruktor),
    IdPolaznik   INT REFERENCES Polaznik(IdPolaznik)
);

CREATE TABLE Cas (
    IdCas        INT IDENTITY(1,1) PRIMARY KEY,
    IdObrazac    INT NOT NULL REFERENCES EvidencioniObrazac(IdObrazac),
    Datum        DATE NOT NULL,
    Trajanje     INT NOT NULL,
    IdAutomobil  INT NOT NULL REFERENCES Automobil(IdAutomobil)
);
