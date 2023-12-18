using Dapper;
using ManageUsersApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManageUsersApp.DataAccessLayer
{
    public class PersonRepository
    {
        private IConfiguration _configuration { get; }
        private string _conn = "";

       
        
        public PersonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conn = _configuration.GetConnectionString("mydb");
        }

        
        public dynamic getAllPerson()
        {
            string sql = "SELECT id_number,name,surname FROM PERSONS";

            using (SqlConnection con = new SqlConnection(_conn))
            {
                
            
                return con.Query(sql);
            }

        }
        public dynamic getPersonsId(string id_number, string surname)
        {
            string sql = $@"SELECT id_number,name,surname
                            FROM PERSONS 
                            WHERE id_number = '{id_number}' AND surname = '{surname}' ";

            using (SqlConnection con = new SqlConnection(_conn))
            {
               

               
              return con.Query(sql);
            }

        }

        public dynamic getPersonsAccount(string account_number )
        {
            string sql = $@" SELECT ps.name, ps.surname, ps.id_number, ac.account_number
                             FROM Persons AS ps 
                             LEFT JOIN Accounts AS ac 
                             ON ps.code = ac.person_code
                             where ac.account_number = '{account_number}' ";

            using (SqlConnection con = new SqlConnection(_conn))
            {

                return con.Query(sql);
            }

        }

        public dynamic createPerson(string id_number,string name, string surname , PersonModel person)
        {
            string sql = $@"INSERT INTO Persons (id_number,name,surname) 
                            VALUES ('{id_number}','{name}','{surname}')";
            
            using (SqlConnection con = new SqlConnection(_conn))
            {

                return con.Query(sql);
            }

        }

        internal object createPerson()
        {
            throw new NotImplementedException();
        }
    }
}
