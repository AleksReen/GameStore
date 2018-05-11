<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="GameStore.Pages.Listing" MasterPageFile="~/Store.Master" %>


<asp:Content ContentPlaceHolderID="bodyContent" runat="server">     
        <div id="content">
            <asp:Label ID="gamesTable" runat="server" />            
        </div>
        <div class="pager">
            <asp:Label ID="gamePages" runat="server" />
        </div>
</asp:Content>
   


