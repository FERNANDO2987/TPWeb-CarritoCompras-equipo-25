<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApp.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/Style/StyleCarrito.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
   

        <div class="container1">
            <h1>Carrito de Compras</h1>

        </div>
        <div id="carrito">
            <asp:Repeater ID="CarritoRepeater" runat="server" OnItemDataBound="CarritoRepeater_ItemDataBound">
                <ItemTemplate>
                    <div class="card mb-3" style="max-width: 540px;">
                        <div class="row no-gutters">
                            <div class="col-md-4">
                                <img src='<%# Eval("ImagenURL") %>' class="card-img" alt='<%# Eval("Nombre") %> Image'>
                            </div>
                            <div class="col-md-8">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                                    <p class="card-text"><small class="text-muted">ID: <%# Eval("Id") %></small></p>
                                    <asp:DropDownList ID="ddlCantidad" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblSubtotal" runat="server" Text='<%# "Subtotal: $" + Eval("Subtotal") %>' CssClass="d-block mt-2"></asp:Label>
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("Id") %>' OnCommand="btnEliminar_Command" CssClass="btn btn-danger mt-2" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>

            </asp:Repeater>
        </div>
        <div class="mt-4">
            <h3>Total a Pagar: $<asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label></h3>
        </div>
    </div>
</asp:Content>
