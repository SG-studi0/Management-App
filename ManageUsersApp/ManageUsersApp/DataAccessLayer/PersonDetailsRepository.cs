using Microsoft.Data.SqlClient;
using Dapper;
using ManageUsersApp.DataAccessLayer;
using ManageUsersApp.Model;
using System.Data.SqlTypes;

namespace ManageUsersApp.DataAccessLayer
{
    public class PersonDetailsRepository 
    {
        private IConfiguration _configuration { get; }
        private string _conn = "";
    
        private SqlMoney outstanding_balance;
        public PersonRepository _personRepository { get; set; }
        
        public PersonDetailsRepository(IConfiguration configuration)
        {
           _personRepository = new PersonRepository(configuration);
            _configuration = configuration;
            _conn = _configuration.GetConnectionString("mydb");
        }

        public object getAccounts(string name, string surname)
        {
         string sql = $@" SELECT ps.name, ps.surname, ac.account_number
                             FROM Persons AS ps 
                             LEFT JOIN Accounts AS ac 
                             ON ps.code = ac.person_code
                             where ps.name = '{name}' 
                             AND ps.surname = '{surname}' ";

            using (SqlConnection con = new SqlConnection(_conn))
            {
                return con.Query(sql);
            }

        }

        public object createAccount(  string id_number , string account_number)
        {
            
            outstanding_balance = SqlMoney.Zero;
 
            string sql = $@"insert into Accounts (person_code,account_number ,outstanding_balance) 
                                  values 
                                  ((SELECT ps.code FROM accounts ac left join Persons ps ON ac.person_code = ps.code where ps.id_number = '{id_number}')
                                  ,'{account_number}','{outstanding_balance}');";

            using (SqlConnection con = new SqlConnection(_conn))
            {
                return con.Query(sql);
            }


        }

        public object updatePersonDetials( string id_number, string name, string surname)
        {
            string sql = $@"Update Persons 
                            set name = '{name}', surname = '{surname}'
                            where id_number = '{id_number}' ";

            using (SqlConnection con = new SqlConnection(_conn))
            {
                return con.Query(sql);
            }

        }
    }
}
