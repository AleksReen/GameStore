<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="GameStore.Controls.CategoryList" %>

<%@ Register Src="~/Controls/tools/CategoryLinks.ascx" TagPrefix="uc1" TagName="CategoryLinks" %>

<div class="homeLink">
   <asp:HyperLink ID="homeLink" runat="server" />
</div>
<div>
    <uc1:CategoryLinks runat="server" id="CategoryLinks" />
</div>

