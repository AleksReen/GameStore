<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryLinks.ascx.cs" Inherits="GameStore.Controls.tools.CategoryLinks" %>

<asp:Repeater ID="Repeater" runat="server">
    <ItemTemplate>
        <div>
            <asp:HyperLink
               Text='<%# Eval("Text") %>'
               NavigateUrl='<%# Eval("NavigateUrl") %>' 
               CssClass='<%# Eval("CssClass") %>' 
               runat="server" />
        </div>
    </ItemTemplate>
</asp:Repeater>

  
