<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div class="container mt-4">
        <div class="row">
            <div class="col-md-6">
                <label for="dropdownCategorias" class="form-label">Selecciona una categoría:</label>
                <asp:DropDownList ID="DropDownListCategorias" runat="server" CssClass="form-select" aria-label="Selecciona una categoría"></asp:DropDownList>
            </div>
        </div>
    </div>

</asp:Content>
