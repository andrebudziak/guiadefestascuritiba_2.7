using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private int vTipoCategoria = 0, ht = 0;
    private WebService ws = new WebService();
    DataTable tabela = new DataTable();
    private DataSet dadosBanner = new DataSet();
    private DataSet dadosBannerTopo = new DataSet();
    PagedDataSource pds = new PagedDataSource();

    private void Page_PreInit(object sender, EventArgs e)
    {
        Session["menu"] = "0";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //CarregaLayout();

            CarregaSlideGrande();
            CarregaMenu();

            //banner lateral direito
            CarregaPublicidadeLateral();

        }
    }

    private void GerMenu(GridView grd, string op)
    {
        DataSet dados = ws.montamenu(op);
        grd.DataSource = dados;
        grd.DataBind();   
    }

    private void CarregaSlideGrande()
    {

        string script = "", foto, link = "";
        Int32 n = 0;
        //banner 730X220
        DataSet dadosT = new DataSet();
        dadosBanner = ws.montaBannerPermuta(1);

        script = "";
        script += "<div  id='top' class='callbacks_container'>";
        script += "<ul class='rslides' id='slider3'>";

        foreach (DataRow tRow in dadosBanner.Tables[0].Rows)
        {
            foto = Page.ResolveUrl("~/banners/" + tRow["descricao"].ToString());
            dadosT = ws.ConsultaAnuncioCliente(Convert.ToInt32(tRow["codigo_cliente"].ToString()));
            link = "http://" + dadosT.Tables[0].Rows[0]["site"].ToString();


            script += "<li>";
            n++;
            if (n == 1)
            {
                script += "   <div class='banner-bg' style='background:url(" + foto + ") no-repeat 0px 0px;'>";
            }
            if (n == 2)
            {
                script += "   <div class='banner-bg banner-img2' style='background:url(" + foto + ") no-repeat 0px 0px;'>";
            }
            if (n == 3)
            {
                script += "   <div class='banner-bg banner-img' style='background:url(" + foto + ") no-repeat 0px 0px;'>";
                n = 0;
            }
            script += "      <div class='container'>";
            script += "         <div class='banner-info'>";
            script += "            <a href='" + link + "' target='_new'>ACESSE</a>";
            script += "         </div>";
            script += "      </div>";
            script += "   </div>";
            script += "</li>";

        }

        script += "</ul>";
        script += "</div>";

        lblSlide.Text = script;
    
    }

    private void CarregaPublicidadeLateral()
    {
        string script = "", foto, link = ""; 

        DataSet dadosBanner = ws.montabannerlateral("2");
        foreach (DataRow tRow in dadosBanner.Tables[0].Rows)
        {
            script += "";
            foto = Page.ResolveUrl("~/banners/" + tRow["miniatura"].ToString());
            link = Page.ResolveUrl("~/detalhe_banner.aspx?id_banner=" + tRow["codigo"].ToString());
            
            script += "<div class='col-md-4 bottom-grid'>";
            script += "<img src='"+foto+"' alt='' />";
            script += "<div class='bottom-grid-info'>";
            script += "<a href='"+link+"'>ACESSE</a>";
            script += "<p>Promoção</p>";
            script += "</div>";
            script += "</div>";


        }
        lblBannerLateral.Text = script;
    }

    private void CarregaMenu()
    {
        UrlRewrite urlr = new UrlRewrite();
        string script = string.Empty;
        DataSet dadosLocal = ws.montamenu("1");
        foreach (DataRow tRow in dadosLocal.Tables[0].Rows)
        {
            script += "<li><a href='/Categoria/" + urlr.RemoveSpecialCharacters(tRow["descricao"].ToString()) + "'>" + tRow["descricao"].ToString() + "</a></li>";
        }
        lblLocal.Text = script;
        script = string.Empty;

        DataSet dadosDecoracao = ws.montamenu("2");
        foreach (DataRow tRow in dadosDecoracao.Tables[0].Rows)
        {
            script += "<li><a href='/Categoria/" + urlr.RemoveSpecialCharacters(tRow["descricao"].ToString()) + "'>" + tRow["descricao"].ToString() + "</a></li>";
        }
        lblDecoracao.Text = script;
        script = string.Empty;

        DataSet dadosAlimentacao = ws.montamenu("3");
        foreach (DataRow tRow in dadosAlimentacao.Tables[0].Rows)
        {
            script += "<li><a href='/Categoria/" + urlr.RemoveSpecialCharacters(tRow["descricao"].ToString()) + "'>" + tRow["descricao"].ToString() + "</a></li>";
        }
        lblAlimentacao.Text = script;
        script = string.Empty;

        DataSet dadosDiversao = ws.montamenu("4");
        foreach (DataRow tRow in dadosDiversao.Tables[0].Rows)
        {
            script += "<li><a href='/Categoria/" + urlr.RemoveSpecialCharacters(tRow["descricao"].ToString()) + "'>" + tRow["descricao"].ToString() + "</a></li>";
        }
        lblDiversao.Text = script;
        script = string.Empty;

        DataSet dadosServico = ws.montamenu("5");
        foreach (DataRow tRow in dadosServico.Tables[0].Rows)
        {
            script += "<li><a href='/Categoria/" + urlr.RemoveSpecialCharacters(tRow["descricao"].ToString()) + "'>" + tRow["descricao"].ToString() + "</a></li>";
        }
        lblServico.Text = script;
        script = string.Empty;

        DataSet dadosTipo = ws.montamenu("6");
        foreach (DataRow tRow in dadosTipo.Tables[0].Rows)
        {
            script += "<li><a href='/Categoria/" + urlr.RemoveSpecialCharacters(tRow["descricao"].ToString()) + "'>" + tRow["descricao"].ToString() + "</a></li>";
        }
        lblTipo.Text = script;
        script = string.Empty;
    }


    private void CarregaLayout()
    {


    }


}
