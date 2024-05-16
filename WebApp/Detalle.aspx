<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebApp.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #imageContainer {
            width: 100%;
            overflow: hidden;
            position: relative;
        }
        #imageContainer img {
            width: 40%;
            height: auto;
            display: none; /* Oculta todas las imágenes por defecto */
            transition: opacity 0.5s ease;
        }
        #imageContainer img:first-child {
            display: block; /* Muestra solo la primera imagen al cargar */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="ProductDetailsPanel" runat="server" Visible="false">
        <h1><asp:Label ID="lblProductName" runat="server" /></h1>
        <p><asp:Label ID="lblProductDescription" runat="server" /></p>
        <div id="imageContainer">
            <asp:Repeater ID="rptImages" runat="server">
                <ItemTemplate>
                    <img src='<%# Container.DataItem %>' alt="Product Image" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- Cambiamos el tipo de botones de "submit" a "button" -->
        <button type="button" id="btnPrev" onclick="showPrevImage()">Previous</button>
        <button type="button" id="btnNext" onclick="showNextImage()">Next</button>
    </asp:Panel>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false" />

    <script src="Script/JavaScriptNavegacion.js"></script>
</asp:Content>
