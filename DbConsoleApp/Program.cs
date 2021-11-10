using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int j = 0, i = 0, k = 0;
            string sarakeNimi = "", sarakeArvo = "";
            string connStr = "Server=DESKTOP-4BCAT9M\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "123";
            while (sql.ToUpper() != "X")
            {
                Console.Write("SQL> ");
                //sql = Console.ReadLine();
                sql = Console.ReadLine();
                if (sql == "") continue;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable schemaTable = reader.GetSchemaTable();
                foreach (DataRow rivi in schemaTable.Rows)
                {
                    foreach (DataColumn column in schemaTable.Columns)
                    {
                        if (column.ColumnName == "ColumnName")
                        {
                            j++;
                            sarakeNimi = rivi[column].ToString();
                            sarakeNimi = (sarakeNimi.PadRight(15).Substring(0, 15) + "|");
                            Console.Write(sarakeNimi);
                        }
                    }
                }
                Console.WriteLine();
                while (reader.Read())
                {
                    i++;
                    for (k = 0; k < j; k++)
                    {
                        sarakeArvo = reader.GetValue(k).ToString();
                        sarakeArvo = (sarakeArvo.PadRight(15).Substring(0, 15) + "|");
                        if (k < j - 1)
                        {
                            Console.Write(sarakeArvo);
                        }
                        else
                            Console.WriteLine(sarakeArvo);
                    }
                }
                Console.ReadLine();
                reader.Close();
                cmd.Dispose();
                schemaTable.Dispose();
                j = 0;
                i = 0;
            }
            // resurssien vapautus
            conn.Dispose();
        }
    }
}
