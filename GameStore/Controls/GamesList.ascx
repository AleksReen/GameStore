<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GamesList.ascx.cs" Inherits="GameStore.Controls.tools.GamesList" %>

<asp:Repeater ID="Repeater" ItemType="GameStore.Models.Game" runat="server">
    <ItemTemplate>
        <div class='item'>
            <h3>
                <%# Item.Name %>
            </h3>
            <p>
                <%# Item.Description %>
            </p>
            <h4>
                <%# Item.Price %>p.
            </h4>
            <br />
            <button name='add' type='submit' value='<%# Item.GameId %>'> Добавить в корзину</button>
        </div>
    </ItemTemplate>
</asp:Repeater>
