<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryLinks.ascx.cs" Inherits="GameStore.Controls.tools.CategoryLinks" %>

<asp:Repeater ItemType="HyperLink" ID="Repeater" runat="server">
    <ItemTemplate>
        <div>
            <asp:HyperLink
               Text='<%# Item.Text %>'
               NavigateUrl='<%# Item.NavigateUrl %>' 
               CssClass='<%# Item.CssClass %>' 
               runat="server" />
        </div>
    </ItemTemplate>
</asp:Repeater>

  
