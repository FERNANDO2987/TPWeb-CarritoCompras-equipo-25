<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebApp.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
    <div class="row">
        <div class="col-md-12">
            <h1>Detalles del Producto</h1>
            <div id="productDetails">
                <% 
                    if (detalleProducto != null)
                    { %>
                        <div class="card">
                            <img src="<%= detalleProducto.ImagenURL %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title">Nombre: <%= detalleProducto.Nombre %></h5>
                                <p class="card-text">Precio: <%= detalleProducto.Precio %></p>
                                <p class="card-text">Descripción: <%= detalleProducto.Descripcion %></p>
                            </div>
                        </div>
                    <% }
                    else
                    { %>
                        <p>Producto no encontrado.</p>
                    <% }
                %>
            </div>
        </div>
    </div>
</div>
</asp:Content>
