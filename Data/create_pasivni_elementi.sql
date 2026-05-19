-- Tabela za pasivne elemente (zone, labele, linije) u rasporedu stolova
-- Pokrenuti na bazi AmsterdamSplavNovi

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PasivniElementi')
BEGIN
    CREATE TABLE dbo.PasivniElementi (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Tip NVARCHAR(10) NOT NULL,          -- 'zona', 'labela', 'linija'
        Naziv NVARCHAR(50) NOT NULL,
        PosX FLOAT NOT NULL DEFAULT 0,
        PosY FLOAT NOT NULL DEFAULT 0,
        Sirina FLOAT NOT NULL DEFAULT 0,
        Visina FLOAT NOT NULL DEFAULT 0,
        Boja NVARCHAR(20) NOT NULL DEFAULT '#E8F4FD'
    );
END
