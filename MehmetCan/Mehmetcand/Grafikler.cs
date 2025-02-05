using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using BL;

namespace MehmetCan
{
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }
        string[] iller = {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya",
            "Artvin", "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur",
            "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ",
            "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari",
            "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri",
            "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraş",
            "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt",
            "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van",
            "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak",
            "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
        };
        string[] sehirler = new string[81];
        double[] sayilar = new double[81];
        private void Grafikler_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            zedGraphControl2.Visible = false;

            UyeBL uyeBL = new UyeBL();


            for (int i = 0; i < iller.Length; i++)
            {
                double sayi = double.Parse(uyeBL.GrafikSehir(iller[i]));
                if (sayi != 0.0)
                {
                    sayilar[i] = sayi;
                    sehirler[i] = iller[i];
                }

            }
            /////////GRAPH1
            ///

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "İllere Göre Üye Grafiği (Bar)";
            myPane.XAxis.Title.Text = "İller";
            myPane.YAxis.Title.Text = "Üye Sayısı";

            // Bar grafik oluştur
            BarItem bar = myPane.AddBar("Üye Sayısı", null, sayilar, System.Drawing.Color.Blue);
            // İl adlarını barların altına yerleştir
            for (int i = 0; i < sehirler.Length; i++)
            {
                if (sayilar[i] != 0.0)
                {
                    //TextObj text = new TextObj(sehirler[i], i + 1, sayilar[i]);
                    TextObj text = new TextObj(sehirler[i] + ": " + sayilar[i].ToString(), i + 1, sayilar[i]);
                    text.Location.AlignH = AlignH.Center;
                    text.Location.AlignV = AlignV.Bottom;
                    text.FontSpec.Angle = 90; // İl adını dikey olarak yazdır
                    myPane.GraphObjList.Add(text);
                }
            }

            // İl adlarını x eksenine yerleştir
            myPane.XAxis.Scale.TextLabels = sehirler;
            myPane.XAxis.Type = AxisType.Text;

            // ZedGraphControl'u yeniden çiz
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

            /////////GRAPH2
            graph2ciz(zedGraphControl2);
        }

        void graph2ciz(ZedGraphControl zedGraphControl2)
        {
            GraphPane myPane = zedGraphControl2.GraphPane;
            myPane.Title.Text = "İllere Göre Üye Grafiği (Pasta)";

            // Yuvarlak grafik verilerini oluştur
            double[] values = { 30, 20, 50 }; // Değerlerinizi istediğiniz gibi ayarlayın
            string[] labels = { "Kategori 1", "Kategori 2", "Kategori 3" };



            // Yuvarlak grafik öğesini oluşturun
            PieItem[] pieItem = myPane.AddPieSlices(sayilar, sehirler);
            for (int i = 0; i < sayilar.Count(); i++)
            {
                if (pieItem[i].Value != 0)
                {
                    pieItem[i].LabelType = PieLabelType.Name_Value;
                }
                else
                {
                    pieItem[i].LabelType = PieLabelType.None;
                }


            }
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                zedGraphControl1.Visible = true;
                zedGraphControl2.Visible = false;
            }
            else
            {
                zedGraphControl1.Visible = false;
                zedGraphControl2.Visible = true;
            }
        }
    }
}
