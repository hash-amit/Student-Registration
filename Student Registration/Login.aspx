<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Student_Registration.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            margin: 0px;
            padding: 0px;
            font-family: 'system-ui';
        }

        .data_field {
            display: flex;
            justify-content: center;
            height: 28px;
        }

        table {
            display: flex;
            justify-content: center;
        }

        .fields_name {
            font-weight: 600;
        }

        .log_btn {
            width: 100px;
            background-color: #1e90ff;
            border: none;
            height: 30px;
            border-radius: 5px;
            font-weight: 600;
        }
    </style>
    <table>
        <tr>
            <td class="fields_name">Email Address:* </td>
            <td class="data_field">
                <asp:TextBox ID="text_email" TextMode="Email" runat="server" Width="100%"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="fields_name">Password:* </td>
            <td class="data_field">
                <asp:TextBox ID="text_pass" TextMode="Password" runat="server" Width="100%"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="fields_name"></td>
            <td>
                <asp:Label ID="lbl_msg" runat="server" Text="" ForeColor="Red"></asp:Label></td>
        </tr>

        <tr>
            <td></td>
            <td class="data_field">
                <asp:Button ID="btn_login" CssClass="log_btn" Text="Login" runat="server" OnClick="btn_login_Click" /></td>
        </tr>
    </table>
</asp:Content>
