using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
     public class LoginBL
    {

        public DataTable GirisKontrol(string username,string password)
        {
            DAL.DAL dl = new DAL.DAL();
           dl.InputParametreEkle("@username", username.ToString());
           dl.InputParametreEkle("@password", password.ToString());
            DataTable Sonuc = dl.DTVeriCek("SELECT Count(*) FROM Admin WHERE Username = [@username] AND Password = [@password] ", CommandType.Text);//CommandType.StoredProcedure);
            return Sonuc;

        }
        public String GirişKontrolAdmin(string username, string password)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@username", username.ToString());
            dl.InputParametreEkle("@password", password.ToString());
            String Sonuc = dl.IlkSatırIlkSutun("SELECT Count(*) FROM Admin WHERE Username = [@username] AND Password = [@password] ", CommandType.Text).ToString();
            return Sonuc;
        }
        public DataTable GirisYapaninBilgileri(string username, string password)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@username", username.ToString());
            DataTable Sonuc = dl.DTVeriCek("SELECT * FROM Admin WHERE Username = [@username] ", CommandType.Text);//CommandType.StoredProcedure);
            return Sonuc;
        }
       
    }
}
