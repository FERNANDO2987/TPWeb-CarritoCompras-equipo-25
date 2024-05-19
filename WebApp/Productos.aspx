<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="WebApp.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
             
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-4">
    <div class="row mb-3">
        <div class="col-md-8">
            <input type="text" id="searchInput" class="form-control" placeholder="Buscar productos...">
        </div>
        <div class="col-md-2">
            <select id="priceFilter" class="form-control">
                <option value="">Filtrar por precio</option>
                <option value="low">Menor a Mayor</option>
                <option value="high">Mayor a Menor</option>
            </select>
        </div>
        <div class="col-md-2">
            <button id="searchButton"  class="btn btn-primary" >Buscar</button>
        </div>
    </div>
   <div class="row" id="imageContainer">
        <% foreach (var imagen in Imagenes)
            { %>
        <div class="col-md-4 image-card" data-nombre="<%= imagen.Nombre %>" data-precio="<%= imagen.Precio %>">
            <div class="card">
                <img src="<%= imagen.ImagenURL %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Nombre: <%= imagen.Nombre %></h5>
                    <p class="card-text">Precio: <%= imagen.Precio %></p>
                    <a href="Detalle.aspx?id=<%= imagen.Id %>" class="btn btn-primary">Ver Detalles</a>
                   <a href="Carrito.aspx?id=<%= imagen.Id %>&nombre=<%= imagen.Nombre %>&precio=<%= imagen.Precio %>&imagenURL=<%= imagen.ImagenURL %>" class="btn btn-primary">Agregar al Carrito</a>

                </div>
            </div>
        </div>
        <% } %>
    </div>
</div>



    <script src="Script/Filtro.js"></script>

  
</asp:Content>



