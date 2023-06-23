using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OtoServisPro.Views.Shared
{
    public partial class RaporPdf : System.Web.Mvc.ViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int isemriid = Convert.ToInt32(ViewBag.IsemriId);
                    Repository<Islem> rpIslem = new Repository<Islem>();
                    Repository<HaritaIletisim> rpIletisim = new Repository<HaritaIletisim>();
                    var islemler = rpIslem.Get(x => x.IsemriId == isemriid).Tolist();
                    var detay = rpIslem.Get(x => x.IsemriId == isemriid, includeProperties: "Muster,Model").FirstOrDefault();

                    ReportParameter[] prm = nem ReportParemeter[13];
                    prm[0] = new ReportParameter("Unvan", rpIletisim.Get.FirstOrDefault().Unvan);
                    prm[1] = new ReportParameter("Iletisim", Regex.Replace(rpIletisim.Get().FirstOrDefault().Iletisim, "<.*?>", string.Empty) );
                    prm[2] = new ReportParameter("AdSoyad",detay.Musteri.AdSoyad);
                    prm[3] = new ReportParameter("Marka", detay.Model.Marka.MarkaAd);
                    prm[4] = new ReportParameter("Model", detay.Model.ModelAd);
                    prm[5] = new ReportParameter("Plaka", detay.Plaka);
                    prm[6] = new ReportParameter("AracKm", detay.AracKm.ToString());
                    prm[7] = new ReportParameter("SaseNo", detay.SaseNo);
                    prm[8] = new ReportParameter("ModelYil", detay.ModelYil.ToString());
                    prm[9] = new ReportParameter("Telefon", detay.Musteri.Telefon);
                    prm[10] = new ReportParameter("Adres", detay.Musteri.Adres);
                    prm[11] = new ReportParameter("OdemeSekli", detay.OdemeSekli);
                    prm[12] = new ReportParameter("AlinanUcret", OdemeSekli.AlinanUcret.ToString());

                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("/RaporDizayn/RaporSonuc.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rds = new ReportDataSource("dsIslemler", islemler);
                    ReportViewer1.LocalReport.SetParameters(prm);
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                }
                catch (Exception)
                {
                    throw;
                }

            }
    }
}