<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="categoria.aspx.cs" Inherits="categoria" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">  


</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">      
    
	<!-- men -->
	<div class="men">
		<!-- container -->
		<div class="container">
			<div class="col-md-9 fashions">
				<div class="title">
					<h3>
                        <asp:Label ID="lblTituloCat" runat="server" Text=""></asp:Label>
					</h3>
				</div>
                <asp:Label ID="lblAnuncio" runat="server" Text=""></asp:Label>
				
			</div>

			<div class="col-md-3 side-bar">
				<div class="categories">
					<h3><asp:Label ID="lblTituloMenuCat" runat="server" Text=""></asp:Label></h3>
					<ul>
                        <asp:Label ID="lblMenuCat" runat="server" Text=""></asp:Label>
					</ul>
				</div>			
			</div>

			<div class="clearfix"> </div>
		</div>
		<!-- //container -->
	</div>
	<!-- //men -->

</asp:Content>

