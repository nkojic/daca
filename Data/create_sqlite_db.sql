-- SQLite šema baze za Amsterdam Splav aplikaciju
-- Ova skripta se automatski izvršava pri prvom pokretanju ako baza ne postoji

CREATE TABLE IF NOT EXISTS Konobari (
    IdKonobar INTEGER PRIMARY KEY,
    Ime TEXT NOT NULL,
    Kod TEXT DEFAULT '',
    BrojKartice INTEGER,
    aktivan INTEGER DEFAULT 1,
    SifraPartnera TEXT
);

CREATE TABLE IF NOT EXISTS KonobariKodoviKartica (
    IdKod INTEGER PRIMARY KEY,
    Kod TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Stolovi (
    BrojStola TEXT PRIMARY KEY,
    otvoren INTEGER DEFAULT 0,
    Konobar INTEGER DEFAULT 0,
    PosX REAL NOT NULL DEFAULT 0,
    PosY REAL NOT NULL DEFAULT 0,
    TipStola TEXT NOT NULL DEFAULT 'square'
);

CREATE TABLE IF NOT EXISTS KonobariStolovi (
    IDKonobar INTEGER,
    BrojStola TEXT,
    Ime TEXT,
    daliRacun INTEGER DEFAULT 0,
    popust REAL DEFAULT 0,
    IdIme INTEGER DEFAULT 0,
    Korisnik TEXT DEFAULT '',
    IdPromo INTEGER DEFAULT 0,
    vreme TEXT DEFAULT ''
);

CREATE TABLE IF NOT EXISTS KonobStoloviStavke (
    IdKonobar INTEGER NOT NULL,
    BrojStola TEXT NOT NULL,
    Id INTEGER NOT NULL,
    IdArtikal INTEGER NOT NULL,
    DeoPorcije REAL DEFAULT 1,
    Komada REAL DEFAULT 1,
    JedMere TEXT DEFAULT '',
    Cena REAL DEFAULT 0,
    Komentar TEXT DEFAULT '',
    Odneto INTEGER DEFAULT 0,
    ImeArtikal TEXT DEFAULT '',
    Tip TEXT DEFAULT '',
    vreme TEXT DEFAULT '',
    PRIMARY KEY (IdKonobar, BrojStola, Id)
);

CREATE TABLE IF NOT EXISTS Kategorija (
    IdKat INTEGER PRIMARY KEY AUTOINCREMENT,
    Kategorija TEXT NOT NULL,
    aktivna INTEGER DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Kategorija1 (
    IdKat1 INTEGER PRIMARY KEY AUTOINCREMENT,
    IdKat INTEGER NOT NULL,
    PodKat TEXT NOT NULL,
    aktivna INTEGER DEFAULT 1,
    IdGrupniTip INTEGER,
    FOREIGN KEY (IdKat) REFERENCES Kategorija(IdKat)
);

CREATE TABLE IF NOT EXISTS Artikli (
    IdArtikal INTEGER PRIMARY KEY AUTOINCREMENT,
    IdKat1 INTEGER,
    broj INTEGER DEFAULT 0,
    ItemCeo TEXT DEFAULT '',
    Naziv TEXT NOT NULL,
    NazivKasa TEXT DEFAULT '',
    Tip TEXT DEFAULT '',
    ProdajnaJedMere TEXT DEFAULT '',
    meraKupovina TEXT DEFAULT '',
    OdnosKupProd REAL DEFAULT 1,
    Cost REAL DEFAULT 0,
    Price REAL DEFAULT 0,
    OnHand REAL DEFAULT 0,
    aktivan INTEGER DEFAULT 1,
    normativ INTEGER DEFAULT 0,
    daliFaktura INTEGER DEFAULT 1,
    daliProdaja INTEGER DEFAULT 1,
    IdKatKupovina INTEGER DEFAULT 0,
    daliBasta INTEGER DEFAULT 0,
    daliPopis INTEGER DEFAULT 0,
    NabavnaCena REAL DEFAULT 0,
    daliProizvodnja INTEGER DEFAULT 0,
    NabavniPDV REAL DEFAULT 0,
    IdArtikliDodatak INTEGER,
    daliDodatak INTEGER,
    VremeIzmene TEXT,
    Uneo TEXT,
    FOREIGN KEY (IdKat1) REFERENCES Kategorija1(IdKat1)
);

CREATE TABLE IF NOT EXISTS ArtikliKojiImajuPrilog (
    IdArtikal INTEGER PRIMARY KEY
);

CREATE TABLE IF NOT EXISTS ArtikliPrilog (
    IdArtikal INTEGER NOT NULL,
    Naziv TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS ArtikliZaZaposlene (
    IdArtikal INTEGER PRIMARY KEY,
    Naziv TEXT NOT NULL,
    Cena REAL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Ime (
    IdIme INTEGER PRIMARY KEY,
    Ime TEXT NOT NULL,
    IdPotpis INTEGER DEFAULT 0,
    aktivan INTEGER DEFAULT 1
);

CREATE TABLE IF NOT EXISTS tblPotpis (
    IdPotpis INTEGER PRIMARY KEY,
    Ime TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS NarucenoZaglavlje (
    IdZaglavlje INTEGER PRIMARY KEY AUTOINCREMENT,
    vremePlacanja TEXT,
    Iznos REAL DEFAULT 0,
    komentar TEXT DEFAULT '',
    FiskalTekst TEXT DEFAULT '',
    Sto TEXT DEFAULT '',
    Konobar TEXT DEFAULT '',
    Datum TEXT DEFAULT '',
    Popust REAL DEFAULT 0,
    IdPromo INTEGER DEFAULT 0
);

CREATE TABLE IF NOT EXISTS NarucenoStavke (
    IdZaglavlje INTEGER NOT NULL,
    Id INTEGER NOT NULL,
    IdArtikal INTEGER NOT NULL,
    DeoPorcije REAL DEFAULT 1,
    Cena REAL DEFAULT 0,
    Komada REAL DEFAULT 1,
    Komentar TEXT DEFAULT '',
    FOREIGN KEY (IdZaglavlje) REFERENCES NarucenoZaglavlje(IdZaglavlje)
);

CREATE TABLE IF NOT EXISTS NarucenoZNacin (
    IDZaglavlje INTEGER NOT NULL,
    NacinPlacanja TEXT NOT NULL,
    Iznos REAL DEFAULT 0,
    Potpis TEXT DEFAULT '',
    IdIme INTEGER DEFAULT 0,
    FOREIGN KEY (IDZaglavlje) REFERENCES NarucenoZaglavlje(IdZaglavlje)
);

CREATE TABLE IF NOT EXISTS KuhinjaZaglavlje (
    IdZaglavlje INTEGER PRIMARY KEY AUTOINCREMENT,
    vremePlacanja TEXT,
    Iznos REAL DEFAULT 0,
    komentar TEXT DEFAULT '',
    FiskalTekst TEXT DEFAULT '',
    Sto TEXT DEFAULT '',
    Konobar TEXT DEFAULT '',
    Datum TEXT DEFAULT '',
    Popust REAL DEFAULT 0,
    IdPromo INTEGER DEFAULT 0
);

CREATE TABLE IF NOT EXISTS KuhinjaStavke (
    IdZaglavlje INTEGER NOT NULL,
    Id INTEGER NOT NULL,
    IdArtikal INTEGER NOT NULL,
    DeoPorcije REAL DEFAULT 1,
    Cena REAL DEFAULT 0,
    Komada REAL DEFAULT 1,
    Komentar TEXT DEFAULT '',
    FOREIGN KEY (IdZaglavlje) REFERENCES KuhinjaZaglavlje(IdZaglavlje)
);

CREATE TABLE IF NOT EXISTS KuhinjaZNacin (
    IDZaglavlje INTEGER NOT NULL,
    NacinPlacanja TEXT NOT NULL,
    Iznos REAL DEFAULT 0,
    Potpis TEXT DEFAULT '',
    IdIme INTEGER DEFAULT 0,
    FOREIGN KEY (IDZaglavlje) REFERENCES KuhinjaZaglavlje(IdZaglavlje)
);

CREATE TABLE IF NOT EXISTS NarucenoZaposleni (
    IDIme INTEGER NOT NULL,
    IdArtikal INTEGER NOT NULL,
    Cena REAL DEFAULT 0,
    Konobar TEXT DEFAULT ''
);

CREATE TABLE IF NOT EXISTS PasivniElementi (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Tip TEXT NOT NULL,
    Naziv TEXT NOT NULL DEFAULT '',
    PosX REAL NOT NULL DEFAULT 0,
    PosY REAL NOT NULL DEFAULT 0,
    Sirina REAL NOT NULL DEFAULT 0,
    Visina REAL NOT NULL DEFAULT 0,
    Boja TEXT NOT NULL DEFAULT '#E8F4FD'
);

CREATE TABLE IF NOT EXISTS Konfiguracija (
    Kljuc TEXT PRIMARY KEY,
    Vrednost TEXT NOT NULL
);

-- Podrazumevana konfiguracija
INSERT OR IGNORE INTO Konfiguracija (Kljuc, Vrednost) VALUES ('KoristiKartice', '0');
