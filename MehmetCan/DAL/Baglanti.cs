using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace DAL
{
    static class Baglanti
    {
        
        //static  SqlConnection baglanti;
        //static public SqlConnection Baglantikablosu
        static OleDbConnection baglanti;
        static public OleDbConnection Baglantikablosu
        {
            get 
            {
                if(baglanti != null)
                {
                    baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/DernekProjeMehmet.accdb;Persist Security Info=True;");//(Provider());
                    if (baglanti.State== System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    return baglanti;
                }
                else
                {
                    baglanti= new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/DernekProjeMehmet.accdb; Persist Security Info=True;");
                    if (baglanti.State== System.Data.ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    return baglanti;
                }
            }
            set
            {
                baglanti= value;
            }
        }
        static private string Provider()
        {
            return "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DernekSistemi.accdb";
            //return ConfigurationManager.AppSettings["BaglantiCumlesi"];
        }
    }
}
