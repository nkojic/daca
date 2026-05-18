-- Proširenje tabele Stolovi za dinamički raspored
-- Pokrenuti na bazi AmsterdamSplavNovi

ALTER TABLE dbo.Stolovi ADD PosX FLOAT NOT NULL CONSTRAINT DF_Stolovi_PosX DEFAULT 0;
ALTER TABLE dbo.Stolovi ADD PosY FLOAT NOT NULL CONSTRAINT DF_Stolovi_PosY DEFAULT 0;
ALTER TABLE dbo.Stolovi ADD TipStola NVARCHAR(10) NOT NULL CONSTRAINT DF_Stolovi_TipStola DEFAULT 'square';

-- Postojeći okrugli stolovi (prema Window2.xaml)
UPDATE dbo.Stolovi SET TipStola = 'round'
WHERE BrojStola IN ('R4','R14','R15','R16','R17');
