<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Student_Registration.aspx.cs" Inherits="Student_Registration.Student_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <table>
            <tr>
                <td>Full Name: </td>
                <td>
                    <asp:TextBox ID="text_fname" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Email Address: </td>
                <td>
                    <asp:TextBox ID="text_email" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Gender: </td>
                <td>
                    <asp:RadioButtonList ID="rbl_gender" runat="server"></asp:RadioButtonList></td>
            </tr>

            <tr>
                <td>Course: </td>
                <td>
                    <asp:DropDownList ID="ddl_course" runat="server"></asp:DropDownList></td>
            </tr>

            <tr>
                <td>Country: </td>
                <td>
                    <asp:DropDownList ID="ddl_country" runat="server" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
            </tr>

            <tr>
                <td>State: </td>
                <td>
                    <asp:DropDownList ID="ddl_state" runat="server"></asp:DropDownList></td>
            </tr>

            <tr>
                <td>Phone: </td>
                <td>
                    <asp:TextBox ID="text_phone" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Password: </td>
                <td>
                    <asp:TextBox ID="text_pass" TextMode="Password" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btn_register" Text="Register" runat="server" OnClick="btn_register_Click" /></td>
            </tr>
        </table>
    </center>
</asp:Content>
