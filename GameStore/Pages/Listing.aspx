<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="GameStore.Pages.Listing" MasterPageFile="~/Store.Master" %>

<%@ Register Src="~/Controls/GamesList.ascx" TagPrefix="uc1" TagName="GamesList" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">     
        <div id="content">
            <uc1:GamesList runat="server" id="GamesList" />      
        </div>
        <div class="pager">
            <asp:Label ID="gamePages" runat="server" />
        </div>
</asp:Content>
   


