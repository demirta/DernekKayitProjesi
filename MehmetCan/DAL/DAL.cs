using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DAL
{
    public class DAL
    {
        public OleDbCommand SorguYaz(string Sorgu, CommandType SorguTipi)
        {
            OleDbCommand cmd = Baglanti.Baglantikablosu.CreateCommand();
            cmd.CommandText = Sorgu;
            cmd.CommandType = SorguTipi;
            return cmd;
        }

        List<OleDbParameter> Parametreler = new List<OleDbParameter>();

        public void InputParametreEkle(string ParametreAdi, object ParametreDegeri)
        {
            
            OleDbParameter parametre = new OleDbParameter();
            parametre.ParameterName = ParametreAdi;
            parametre.Value = ParametreDegeri;
            Parametreler.Add(parametre);
        }

        public void OutputParametreEkle(string ParametreAdi, object ParametreDegeri)
        {
            OleDbParameter parametre = new OleDbParameter();
            parametre.ParameterName = ParametreAdi;
            parametre.Value = ParametreDegeri;
            parametre.Direction = ParameterDirection.Output;
            Parametreler.Add(parametre);
        }
        
        private void ParametreleriSorguyaEkle(OleDbCommand CommandNesnesi)
        {
            CommandNesnesi.Parameters.AddRange(Parametreler.ToArray());
            
        }

        public object ParametreDegeriniGetir(string ParametreAdi)
        {
            foreach(var item in Parametreler)
            {
                if(item.ParameterName == ParametreAdi)
                {
                    return item.Value.ToString();
                }
            }
            return null;
        }
        public int EkleSilGuncelle(string Sorgu, CommandType SorguTipi)
        {
            try 
            { 
                OleDbCommand cmd = SorguYaz(Sorgu, SorguTipi);
                ParametreleriSorguyaEkle(cmd);
                int sonuc = cmd.ExecuteNonQuery(); 
                if(cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Connection.Dispose();
                cmd.Dispose();
                return sonuc;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public object IlkSatırIlkSutun(string Sorgu, CommandType SorguTipi)
        {
            try
            {
                OleDbCommand cmd = SorguYaz(Sorgu, SorguTipi);
                ParametreleriSorguyaEkle(cmd);
                object Sonuc = cmd.ExecuteScalar();
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Connection.Dispose();
                cmd.Dispose();
                return Sonuc;
            }
            catch (Exception)
            {
                throw;
            }
        }
      

        public OleDbDataReader DRVeriCek(string Sorgu, CommandType SorguTipi)
        {
            OleDbCommand cmd = SorguYaz(Sorgu, SorguTipi);
            ParametreleriSorguyaEkle(cmd);
            OleDbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public DataTable DTVeriCek(string Sorgu, CommandType SorguTipi)
        {
            try
            {
                OleDbDataReader dr = DRVeriCek(Sorgu, SorguTipi);
                DataTable dt = new DataTable();
                dt.Load(dr);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}


