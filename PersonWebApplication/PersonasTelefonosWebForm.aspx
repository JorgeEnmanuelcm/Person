<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PersonasTelefonosWebForm.aspx.cs" Inherits="PersonWebApplication.PersonasTelefonosWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-default">
        <div class="panel-body">
            Registro Personas
        </div>
    </div> 

                <%--PersonaId--%>
                <div class="form-group">
                    <label for="PersonaIdTextBox" class="col-md-3 control-label input-sm">Persona Id: </label>
                    <div class="col-xs-8">
                         <asp:TextBox ID="PersonaIdTextBox" runat="server" CssClass="form-control" placeholder="Persona Id"></asp:TextBox><br/><br/>
                   </div>
                    </div>
                     <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click1" /> 
                <br/><br/>

                <%--Nombres--%>
                    <div class="form-group">
                    <label for="NombresTextBox" class="col-md-3 control-label input-sm">Nombres: </label>
                    <div class="col-xs-8">
                         <asp:TextBox ID="NombresTextBox" runat="server" CssClass="form-control " placeholder="Nombres"></asp:TextBox><br/><br/>
                   </div>
                    </div>
                    
                <%--Sexo--%>
                    <div class="form-group">
                    <label for="SexoTextBox" class="col-md-3 control-label input-sm">Sexo: </label>
                     <div class="col-md-8">
                        <asp:RadioButtonList ID="SexoRadioButtonList" runat="server" RepeatDirection="Horizontal" Width="400px">
                            <asp:ListItem Selected="True">Masculino</asp:ListItem>
                            <asp:ListItem>Femenino</asp:ListItem>
                        </asp:RadioButtonList><br/><br/>
                    </div>
                    </div>
                
                <%--TipoTelefono--%>
                    <div class="form-group">
                   <label for="TipoTelefonoTextBox" class="col-md-3 control-label input-sm">Tipo Telefono: </label>
                    <div class="col-md-8">
                        <%--<asp:DropDownList ID="TipoTelefonoDropDownList" runat="server" Class="form-control input-sm"></asp:DropDownList><br/><br/>--%>
                        <asp:TextBox ID="TipoTelefonoTextBox" runat="server" CssClass="form-control " placeholder="Tipo Telefono"></asp:TextBox><br/><br/>
                   </div>
                    </div>

                 <%--Telefono--%>
                    <div class="form-group">
                    <label for="TelefonoTextBox" class="col-md-3 control-label input-sm">Telefono: </label>
                    <div class="col-xs-8">
                         <asp:TextBox ID="TelefonoTextBox" runat="server" CssClass="form-control " placeholder="Telefono"></asp:TextBox><br/><br/>
                   </div>
                    </div>
                
                <%--Agregar--%>
                    <div class="container">
                        <asp:Button ID="AgregarButton" runat="server" class="btn btn-info btn-block" Text="Agregar" OnClick="AgregarButton_Click" />   
                    </div>
                <br/><br/>

                <%--DataGriew--%>
                     <asp:GridView ID="PersonasGridView" runat="server" AutoGenerateColumns="False">
                         <Columns>
                             <asp:BoundField HeaderText="TipoTelefono" ReadOnly="True" />
                             <asp:BoundField HeaderText="Telefono" ReadOnly="True" />
                         </Columns>
                    </asp:GridView>
            
            <br/><br/>

             <%--Botones--%>
               <div class="panel-footer">
                 <div class="text-center">
                   <div class="form-group" style="display: inline-block">
                      <asp:Button Text="Nuevo" class ="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click"  />
                      <%--<asp:Button Text="Guardar" class ="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click"  />--%>
                      <asp:Button Text="Eliminar" class ="btn btn-danger btn-sm" runat="server" ID="EliminarButton"  />
                   </div>
                   </div>
                </div>
                
</asp:Content>
