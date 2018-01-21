using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DataAccess
{
    public class ExecutiveDataAccess
    {

        public List<DatabaseTables.LotNumbers> GetLotNumbers()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {//Grab all Unique Lot Numbers that aren't complete and Master Review has not been requested/In Progress
                return connection.Query<DatabaseTables.LotNumbers>(
                    $"SELECT DISTINCT LotNumbers.JobWOR " +
                    $", LotNumbers.Lot " +
                    $", LotNumbers.Customer " +
                    $", LotNumbers.PartID " +
                    $"FROM LotNumbers " +
                    $"INNER JOIN LotStatus " +
                    $"ON LotStatus.LotID = LotNumbers.LotID " +
                    $"WHERE LotStatus.JobComplete = 'False' " +
                    $"ORDER BY LotNumbers.JobWOR, LotNumbers.Lot").ToList();
            }
        }

        public void setSuperHot(string JobWOR, string Lot)
        {

            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ JobWOR }' AND Lot=' { Lot }'").ToList();

                //2. Change SuperHot = True where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotStatus SET SuperHot = 'True' WHERE LotID='{ LotID[0] }'");

            }
        }

        public void resetSuperHot(string JobWOR, string Lot)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ JobWOR }' AND Lot=' { Lot }'").ToList();

                //2. Change SuperHot = True where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotStatus SET SuperHot = 'False' WHERE LotID='{ LotID[0] }'");

            }
        }

    }
}
