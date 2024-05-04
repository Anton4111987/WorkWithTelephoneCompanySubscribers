using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using WorkWithTelephoneCompanySubscribers.Models;

namespace WorkWithTelephoneCompanySubscribers.Data
{
    public class DataService
    {
        private static readonly string connectionString = "Data Source=TelephoneCompany.db";

        public static async Task<IEnumerable<Street>> LoadStreets()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<Street>("SELECT * FROM Streets");
            }
        }

        public static async Task<IEnumerable<Address>> LoadAddresses()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<Address>("SELECT * FROM Addresses");
            }
        }
        public static async Task<IEnumerable<Abonent>> LoadAbonents()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<Abonent>("SELECT * FROM Abonents");
            }
        }

        public static async Task<IEnumerable<PhoneNumber>> LoadPhoneNumbers()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<PhoneNumber>("SELECT * FROM PhoneNumbers");
            }
        }
        public static async Task<IEnumerable<SearchAbonent>> LoadSearchAbonents(string number)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<SearchAbonent>(
                    $@"Select Ab.fio as {nameof(SearchAbonent.FIO)}, Str.Name as {nameof(SearchAbonent.Street)}, Adr.HouseNumber as {nameof(SearchAbonent.HouseNumber)}, PN.number as {nameof(SearchAbonent.PhoneNumber)} 
                    From Streets as Str, Addresses as Adr, Abonents as Ab, PhoneNumbers as PN
                    Where Str.id=Adr.street_Id and Adr.id=Ab.address_Id and Ab.id=PN.abonent_Id and PN.number='{number}'
                    Order by Ab.fio");
            }
        }
        public static async Task<IEnumerable<SearchAbonent>> LoadAllAbonents()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<SearchAbonent>(
                    $@"Select Ab.fio as {nameof(SearchAbonent.FIO)}, Str.Name as {nameof(SearchAbonent.Street)}, Adr.HouseNumber as {nameof(SearchAbonent.HouseNumber)}, PN.number as {nameof(SearchAbonent.PhoneNumber)} 
                    From Streets as Str, Addresses as Adr, Abonents as Ab, PhoneNumbers as PN
                    Where Str.id=Adr.street_Id and Adr.id=Ab.address_Id and Ab.id=PN.abonent_Id
                    Order by Ab.fio");
            }
        }

        public static async Task<IEnumerable<ShowByStreet>> LoadShowByStreets()
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<ShowByStreet>(
                    $@"Select Name as {nameof(ShowByStreet.Name)}, count(id) as {nameof(ShowByStreet.Count)}
                    From Streets
                    group by Name
                    order by Name");
            }
        }
    }
}
