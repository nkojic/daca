-- Tabela za konfiguraciju aplikacije
-- Pokrenuti na bazi AmsterdamSplavNovi

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Konfiguracija')
BEGIN
    CREATE TABLE dbo.Konfiguracija (
        Kljuc NVARCHAR(50) PRIMARY KEY,
        Vrednost NVARCHAR(200) NOT NULL
    );

    -- Podrazumevano: koristi kartice konobara
    INSERT INTO dbo.Konfiguracija (Kljuc, Vrednost) VALUES ('KoristiKartice', '1');
END
