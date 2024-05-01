using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithTelephoneCompanySubscribers.Data
{
    public static class DBUtilities
    {
        public static void FileExists()
        {
            // File.Create("../../../TelephoneCompany.db");
            if (!File.Exists("../../../TelephoneCompany.db"))
            {
                File.Create("../../../TelephoneCompany.db");
                CreateTables();
            }
        }

        public async static void CreateTables()
        {            
            string connectionString = "Data Source=../../../TelephoneCompany.db";
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var createTableStreets = @"CREATE TABLE IF NOT EXISTS Streets (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL
                );";
                 await connection.ExecuteAsync(createTableStreets);
                var createTableAddresses = @"CREATE TABLE IF NOT EXISTS Addresses (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                houseNumber TEXT NOT NULL,
                street_Id INTEGER,
                CONSTRAINT addresses_streets_fk 
                FOREIGN KEY (Street_Id) REFERENCES Streets(id) ON DELETE SET NULL
                );";
                await connection.ExecuteAsync(createTableAddresses);
                var createTableAbonents = @"CREATE TABLE IF NOT EXISTS Abonents (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                fio TEXT NOT NULL,
                address_Id INTEGER,
                CONSTRAINT abonents_addresses_fk 
                FOREIGN KEY (Address_Id) REFERENCES Addresses(id) ON DELETE SET NULL
                );";
                await connection.ExecuteAsync(createTableAbonents);
                var createTablePhoneNumbers = @"CREATE TABLE IF NOT EXISTS PhoneNumbers (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                number TEXT NOT NULL,
                abonent_Id INTEGER,
                CONSTRAINT phoneNumbers_abonents_fk 
                FOREIGN KEY (Abonent_Id) REFERENCES Abonents(id) ON DELETE SET NULL
                );";
                await connection.ExecuteAsync(createTablePhoneNumbers);

                var insertStreets = @"
                INSERT INTO Streets (name)
                VALUES 
                ('ул. Солнечная'),
                ('ул. Южная'),
                ('ул. Ленина'),
                ('ул. Центральная'),
                ('ул. Пушкина'),
                ('ул. Набережная'),
                ('ул. Зеленая'),
                ('ул. Озерная'),
                ('ул. Мира'),
                ('ул. Садовая'),
                ('ул. Ленина'),
                ('ул. Солнечная'),
                ('ул. Садовая'),
                ('ул. Солнечная'),
                ('ул. Зеленая'),
                ('ул. Мира'),
                ('ул. Набережная'),
                ('ул. Пушкина'),
                ('ул. Центральная'),
                ('ул. Пушкина');";
                await connection.ExecuteAsync(insertStreets);
                var insertAddresses = @"
                INSERT INTO Addresses (houseNumber, street_Id)
                VALUES 
                ('43', (SELECT id FROM Streets WHERE Name='ул. Солнечная' Limit 1)),
                ('12', (SELECT id FROM Streets WHERE Name='ул. Южная' Limit 1)),
                ('78', (SELECT id FROM Streets WHERE Name='ул. Ленина' Limit 1)),
                ('56', (SELECT id FROM Streets WHERE Name='ул. Центральная' Limit 1)),
                ('32', (SELECT id FROM Streets WHERE Name='ул. Пушкина' Limit 1)),
                ('87', (SELECT id FROM Streets WHERE Name='ул. Набережная' Limit 1)),
                ('21', (SELECT id FROM Streets WHERE Name='ул. Зеленая' Limit 1)),
                ('64', (SELECT id FROM Streets WHERE Name='ул. Озерная' Limit 1)),
                ('5',  (SELECT id FROM Streets WHERE Name='ул. Мира' Limit 1)),
                ('94', (SELECT id FROM Streets WHERE Name='ул. Садовая' Limit 1)),
                ('76', (SELECT id FROM Streets WHERE Name='ул. Ленина' Limit 1)),
                ('18', (SELECT id FROM Streets WHERE Name='ул. Солнечная' Limit 1)),
                ('39', (SELECT id FROM Streets WHERE Name='ул. Садовая' Limit 1)),
                ('83', (SELECT id FROM Streets WHERE Name='ул. Солнечная' Limit 1)),
                ('25', (SELECT id FROM Streets WHERE Name='ул. Зеленая' Limit 1)),
                ('48', (SELECT id FROM Streets WHERE Name='ул. Мира' Limit 1)),
                ('72', (SELECT id FROM Streets WHERE Name='ул. Набережная' Limit 1)),
                ('14', (SELECT id FROM Streets WHERE Name='ул. Пушкина' Limit 1)),
                ('61', (SELECT id FROM Streets WHERE Name='ул. Центральная' Limit 1)),
                ('36', (SELECT id FROM Streets WHERE Name='ул. Пушкина' Limit 1));";                
                await connection.ExecuteAsync(insertAddresses);
                var insertAbonents = @"
                INSERT INTO Abonents (fio, address_Id)
                VALUES 
                ('Иванов Петр Иванович', (SELECT id FROM Addresses WHERE houseNumber=43 Limit 1)),
                ('Петрова Ольга Сергеевна', (SELECT id FROM Addresses WHERE houseNumber=12 Limit 1)),
                ('Козлов Александр Дмитриевич',  (SELECT id FROM Addresses WHERE houseNumber=78 Limit 1)),
                ('Смирнова Татьяна Алексеевна', (SELECT id FROM Addresses WHERE houseNumber=56 Limit 1)),
                ('Лебедев Иван Владимирович', (SELECT id FROM Addresses WHERE houseNumber=32 Limit 1)),
                ('Новиков Петр Сергеевич', (SELECT id FROM Addresses WHERE houseNumber=87 Limit 1)),
                ('Соколова Анна Ивановна', (SELECT id FROM Addresses WHERE houseNumber=21 Limit 1)),
                ('Попов Дмитрий Александрович', (SELECT id FROM Addresses WHERE houseNumber=64 Limit 1)),
                ('Морозова Елена Анатольевна', (SELECT id FROM Addresses WHERE houseNumber=5 Limit 1)),
                ('Егоров Сергей Дмитриевич', (SELECT id FROM Addresses WHERE houseNumber=94 Limit 1)),
                ('Овечкин Иван Алексеевич', (SELECT id FROM Addresses WHERE houseNumber=76 Limit 1)),
                ('Павлова Ольга Сергеевна',(SELECT id FROM Addresses WHERE houseNumber=18 Limit 1)),
                ('Седов Петр Дмитриевич',  (SELECT id FROM Addresses WHERE houseNumber=39 Limit 1)),
                ('Федорова Татьяна Сергеевна',(SELECT id FROM Addresses WHERE houseNumber=83 Limit 1)),
                ('Беляева Анна Владимировна', (SELECT id FROM Addresses WHERE houseNumber=25 Limit 1)),
                ('Данилов Александр Иванович', (SELECT id FROM Addresses WHERE houseNumber=48 Limit 1)),
                ('Григорьев Игорь Андреевич', (SELECT id FROM Addresses WHERE houseNumber=72 Limit 1)),
                ('Киселева Мария Сергеевна', (SELECT id FROM Addresses WHERE houseNumber=14 Limit 1)),
                ('Александрова Елена Петровна', (SELECT id FROM Addresses WHERE houseNumber=61 Limit 1)),
                ('Гаврилов Сергей Александрович', (SELECT id FROM Addresses WHERE houseNumber=36 Limit 1));";
                await connection.ExecuteAsync(insertAbonents);
                var insertPhoneNumber = @"
                INSERT INTO PhoneNumbers (number, abonent_Id)
                VALUES 
                ('+7-234-567-89-23', (SELECT id FROM Abonents WHERE fio='Иванов Петр Иванович' Limit 1)),
                ('+7-345-678-91-45', (SELECT id FROM Abonents WHERE fio='Петрова Ольга Сергеевна' Limit 1)),
                ('+7-456-789-12-34', (SELECT id FROM Abonents WHERE fio='Козлов Александр Дмитриевич' Limit 1)),
                ('+7-567-891-23-45', (SELECT id FROM Abonents WHERE fio='Смирнова Татьяна Алексеевна' Limit 1)),
                ('+7-678-912-34-56', (SELECT id FROM Abonents WHERE fio='Лебедев Иван Владимирович' Limit 1)),
                ('+7-789-123-45-67', (SELECT id FROM Abonents WHERE fio='Новиков Петр Сергеевич' Limit 1)),
                ('+7-891-234-56-78', (SELECT id FROM Abonents WHERE fio='Соколова Анна Ивановна' Limit 1)),
                ('+7-912-345-67-89', (SELECT id FROM Abonents WHERE fio='Попов Дмитрий Александрович' Limit 1)),
                ('+7-123-456-78-90', (SELECT id FROM Abonents WHERE fio='Морозова Елена Анатольевна' Limit 1)),
                ('+7-891-234-67-89', (SELECT id FROM Abonents WHERE fio='Егоров Сергей Дмитриевич' Limit 1)),
                ('+7-912-345-78-90', (SELECT id FROM Abonents WHERE fio='Овечкин Иван Алексеевич' Limit 1)),
                ('+7-234-567-89-01', (SELECT id FROM Abonents WHERE fio='Павлова Ольга Сергеевна' Limit 1)),
                ('+7-345-678-90-12', (SELECT id FROM Abonents WHERE fio='Седов Петр Дмитриевич' Limit 1)),
                ('+7-456-789-01-23', (SELECT id FROM Abonents WHERE fio='Федорова Татьяна Сергеевна' Limit 1)),
                ('+7-567-890-12-34', (SELECT id FROM Abonents WHERE fio='Беляева Анна Владимировна' Limit 1)),
                ('+7-678-901-23-45', (SELECT id FROM Abonents WHERE fio='Данилов Александр Иванович' Limit 1)),
                ('+7-789-012-34-56', (SELECT id FROM Abonents WHERE fio='Григорьев Игорь Андреевич Limit 1)),
                ('+7-901-234-56-78', (SELECT id FROM Abonents WHERE fio='Киселева Мария Сергеевна' Limit 1)),
                ('+7-123-456-78-90', (SELECT id FROM Abonents WHERE fio='Александрова Елена Петровна' Limit 1)),
                ('+7-987-654-32-10', (SELECT id FROM Abonents WHERE fio='Гаврилов Сергей Александрович' Limit 1));";
                await connection.ExecuteAsync(insertPhoneNumber);

            }

        }
    }
}
