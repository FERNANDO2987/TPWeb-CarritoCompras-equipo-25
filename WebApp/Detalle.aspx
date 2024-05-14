<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebApp.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
   <div class="container mt-4">
        <div class="row">
            <% foreach (var imagen in Imagenes) { %>
                <div class="col-md-4">
                    <div class="card">
                        <img src="<%= imagen.ImagenURL %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">Nombre: <%= imagen.Nombre %></h5>
                            <p class="card-text">Precio: <%= imagen.Precio %></p>
                            <a href="Productos.aspx#" class="btn btn-primary">Ver Detalles</a>
                        </div>
                    </div>
                </div>
            <% } %>
        </div>
    </div>

</asp:Content>
