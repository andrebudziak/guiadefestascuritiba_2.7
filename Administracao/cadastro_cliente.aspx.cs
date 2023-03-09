﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracao_cadastro_cliente : System.Web.UI.Page
{
    WebService ws = new WebService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblHash.Visible = false;
            if (Session["hash"] != null)
            {
                lblHash.Text = Session["hash"].ToString();
                lblCodigo.Text = "0";
            }
            else
            {
                // Response.Redirect("login.aspx");
                lblCodigo.Text = "0";

            }
        }
    }

    protected void btnIncluir_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.Insert();
        ObjectDataSource1.Select();

        string myScript = @"alert('Registro Incluido!');";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clientscript", "<script language='JavaScript'>" + myScript + "</script>", false);

    }

    protected void grdDados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = e.RowIndex;
        int codigo = Convert.ToInt32(((Label)grdDados.Rows[index].FindControl("lblCodigo")).Text);
        lblCodigo.Text = codigo.ToString();
    }

    protected void grdDados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            WebControl wc = ((WebControl)e.CommandSource);
            GridViewRow row = ((GridViewRow)wc.NamingContainer);

            lblCodigo.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblCodigo")).Text;

            txtRazaoSocial.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblRazaoSocial")).Text;
            txtNomeFantasia.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblNomeFantasia")).Text;
            txtCNPJ.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblCnpj")).Text;
            txtCPF.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblCpf")).Text;
            txtRg.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblRg")).Text;
            txtCep.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblCep")).Text;
            txtBairro.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblBairro")).Text;
            txtCidade.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblCidade")).Text;
            txtEndereco.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblEndereco")).Text;
            txtTelefone.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblTelefone")).Text;
            txtEmail.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblEmail")).Text;
            txtResponsavel.Text = ((Label)grdDados.Rows[row.RowIndex].FindControl("lblResponsavel")).Text;

        }
    }

    protected void grdDados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }

    protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.InputParameters["codigo"] = lblCodigo.Text;
        lblCodigo.Text = "0";
    }

    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        if (lblCodigo.Text == "0")
            e.InputParameters["codigo"] = 0;
        else
            e.InputParameters["codigo"] = Convert.ToInt32(lblCodigo.Text);

        e.InputParameters["razao_social"] = txtRazaoSocial.Text;
        e.InputParameters["nome_fantasia"] = txtNomeFantasia.Text;
        e.InputParameters["cnpj"] = txtCNPJ.Text;
        e.InputParameters["cpf"] = txtCPF.Text;
        e.InputParameters["rg"] = txtRg.Text;
        e.InputParameters["cep"] = txtCep.Text;
        e.InputParameters["bairro"] = txtBairro.Text;
        e.InputParameters["cidade"] = txtCidade.Text;
        e.InputParameters["endereco"] = txtEndereco.Text;
        e.InputParameters["telefone"] = txtTelefone.Text;
        e.InputParameters["email"] = txtEmail.Text;
        e.InputParameters["responsavel"] = txtResponsavel.Text;

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        ObjectDataSource1.Insert();
        ObjectDataSource1.Select();

        string myScript = @"alert('Registro Salvo!');";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clientscript", "<script language='JavaScript'>" + myScript + "</script>", false);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");

    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["codigo"] = "0";
        if (txtPesquisa.Text == "")
            e.InputParameters["nome"] = "0";
        else
            e.InputParameters["nome"] = txtPesquisa.Text;
    }

    protected void btnPesquisar_Click1(object sender, EventArgs e)
    {
        if (txtPesquisa.Text != "")
        {
            grdDados.DataBind();
            ObjectDataSource1.Select();
        }
        else
        {
            string myScript = @"alert('Digite um valor no campo pesquisa!');";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clientscript", "<script language='JavaScript'>" + myScript + "</script>", false);
        }


    }

    protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        txtPesquisa.Text = "";
        grdDados.DataBind();
        ObjectDataSource1.Select();

    }
}