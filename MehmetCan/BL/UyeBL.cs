using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAL;
using Microsoft.Win32;
using System.Data.OleDb;

namespace BL
{
    public class UyeBL
    {
        public int AddUser(string TcNo, string Ad, string Soyad, string Sehir, string Email, string KanGrubu, string TelefonNo)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@TcNo", TcNo);
            dl.InputParametreEkle("@Ad", Ad);
            dl.InputParametreEkle("@Soyad", Soyad);
            dl.InputParametreEkle("@Sehir", Sehir);
            dl.InputParametreEkle("@Email", Email);
            dl.InputParametreEkle("@KanGrubu", KanGrubu);
            dl.InputParametreEkle("@TelefonNo", TelefonNo);
            dl.InputParametreEkle("@Status", "Aktif");
            int Sonuc = dl.EkleSilGuncelle("Insert INTO DernekUyeleri (TcNo,Ad,Soyad,Sehir,Email,KanGrubu,TelefonNo,Status) Values([@TcNo],[@Ad],[@Soyad],[@Sehir],[@Email],[@KanGrubu],[@Status],[@TelefonNo])", System.Data.CommandType.Text);
            return Sonuc;
        }
        public int UyeEkleBorcBaslangic(string TcNo, string mail)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@TcNo", TcNo);
            dl.InputParametreEkle("@Borc", "0");
            dl.InputParametreEkle("@Mail", mail);

            int Sonuc = dl.EkleSilGuncelle("Insert INTO DernekUyeBorc (TcNo,Borc,Mail) Values([@TcNo],[@Borc],[@Mail])", System.Data.CommandType.Text);
            return Sonuc;
        }
        public int AidatBelirle(string Ocak, string Subat, string Mart, string Nisan, string Mayis, string Haziran, string Temmuz, string Agustos, string Eylul, string Ekim,
            string Kasim, string Aralik)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Ocak", Ocak);
            dl.InputParametreEkle("@Subat", Subat);
            dl.InputParametreEkle("@Mart", Mart);
            dl.InputParametreEkle("@Nisan", Nisan);
            dl.InputParametreEkle("@Mayis", Mayis);
            dl.InputParametreEkle("@Haziran", Haziran);
            dl.InputParametreEkle("@Temmuz", Temmuz);
            dl.InputParametreEkle("@Agustos", Agustos);
            dl.InputParametreEkle("@Eylul", Eylul);
            dl.InputParametreEkle("@Ekim", Ekim);
            dl.InputParametreEkle("@Kasim", Kasim);
            dl.InputParametreEkle("@Aralik", Aralik);
            int Sonuc = dl.EkleSilGuncelle("Update DernekAylikAidat Set Ocak=[@Ocak], Subat=[@Subat], Mart=[@Mart], Nisan=[@Nisan], Mayis=[@Mayis], Haziran=[@Haziran]" +
                ", Temmuz=[@Temmuz], Agustos=[@Agustos],Eylul=[@Eylul], Ekim=[@Ekim], Kasim=[@Kasim], Aralik=[@Aralik] where Sene='2024'", System.Data.CommandType.Text);
            return Sonuc;
        }


        //Üye kalıcı olarak silinmez üyelik duruma pasife çekilir.
        public int UyeSil(string id)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@TcNo", id.ToString());
            int Sonuc = dl.EkleSilGuncelle("Update DernekUyeleri Set Status= 'Pasif' where TcNo = [@TcNo]", System.Data.CommandType.Text);
            return Sonuc;
        }
        public int UyelikPasifYap(string TcNo)
        {
            DAL.DAL dl = new DAL.DAL();

            dl.InputParametreEkle("@TcNo", TcNo);

            int Sonuc = dl.EkleSilGuncelle("UPDATE DernekUyeleri SET Status = 'Pasif' WHERE TcNo = [@TcNo] ", System.Data.CommandType.Text);
            return Sonuc;
        }
        public int UyeBorcEkle(string TcNo, string borc)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Borc", borc);
            dl.InputParametreEkle("@TcNo", TcNo);

            int Sonuc = dl.EkleSilGuncelle("UPDATE DernekUyeBorc SET Borc = [@borc] WHERE TcNo = [@TcNo] ", System.Data.CommandType.Text);
            return Sonuc;
        }

        public int UyelikAktifYap(string TcNo)
        {
            DAL.DAL dl = new DAL.DAL();

            dl.InputParametreEkle("@TcNo", TcNo);

            int Sonuc = dl.EkleSilGuncelle("UPDATE DernekUyeleri SET Status = 'Aktif' WHERE TcNo = [@TcNo] ", System.Data.CommandType.Text);
            return Sonuc;
        }
        public DataTable GetAidats()
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Sene", "2024");
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekAylikAidat Where Sene = [@Sene]", CommandType.Text);
            return Sonuc;
        }
        public DataTable GetUyeAktif()
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Status", "Aktif");
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekUyeleri Where Status = [@Status]", CommandType.Text);
            return Sonuc;
        }
        public DataTable GetUyePasif()
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Status", "Pasif");
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekUyeleri Where Status = [@Status]", CommandType.Text);
            return Sonuc;
        }
        public DataTable BorclulariGetirFilter(string TcNo)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Borc", "0");
            dl.InputParametreEkle("@TcNo", TcNo);
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekUyeBorc Where  Borc <> [@Borc] and TcNo Like '%'+[@TcNo]+'%' ", CommandType.Text);
            return Sonuc;
        }
        public DataTable GetBorc()
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Borc", "0");
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekUyeBorc Where Borc <> [@Borc]", CommandType.Text);
            return Sonuc;
        }
        public DataTable BorcVeriAl(string TcNo)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@TcNo", TcNo);
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekUyeBorc Where TcNo = [@TcNo]", CommandType.Text);
            return Sonuc;
        }
        public DataTable UyeleriGetirAktifFilter(string TcNo)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Status", "Aktif");
            dl.InputParametreEkle("@TcNo", TcNo);
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekUyeleri Where Status = [@Status] and TcNo Like '%'+[@TcNo]+'%'", CommandType.Text);
            return Sonuc;
        }
        public DataTable UyeleriGetirPasifFilter(string TcNo)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Status", "Pasif");
            dl.InputParametreEkle("@TcNo", TcNo);
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekUyeleri Where Status = [@Status] and TcNo Like '%'+[@TcNo]+'%'", CommandType.Text);
            return Sonuc;
        }
        public DataTable UyeleriGetirSehir(string Sehir)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Sehir", Sehir);
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekUyeleri Where Sehir = [@Sehir]", CommandType.Text);
            return Sonuc;
        }
        public DataTable UyeleriGetirKanGrubu(string KanGrubu)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@KanGrubu", KanGrubu);
            DataTable Sonuc = dl.DTVeriCek("Select * from DernekUyeleri Where KanGrubu = [@KanGrubu]", CommandType.Text);
            return Sonuc;
        }

        public String GrafikSehir(string sehir)
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Sehir", sehir);
            String Sonuc = dl.IlkSatırIlkSutun("SELECT COUNT(Sehir) FROM DernekUyeleri WHERE Sehir = [@Sehir] ", CommandType.Text).ToString();
            return Sonuc;
        }
        public String UyeSayisi()
        {
            DAL.DAL dl = new DAL.DAL();
            dl.InputParametreEkle("@Status", "Deneme");
            String Sonuc = dl.IlkSatırIlkSutun("SELECT COUNT(*) FROM DernekUyeleri WHERE Status <> [@Status] ", CommandType.Text).ToString();
            return Sonuc;
        }
    }
}
