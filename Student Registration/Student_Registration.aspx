<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Student_Registration.aspx.cs" Inherits="Student_Registration.Student_Registration" %>

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
            height:28px;
        }

        table {
            display: flex;
            justify-content: center;
        }

        .fields_name {
            font-weight: 600;
        }

        .reg_btn {
            width: 100px;
            background-color: #1e90ff;
            border: none;
            height: 30px;
            border-radius: 5px;
            font-weight:600;
        }
    </style>
    <table>
        <tr>
            <td class="fields_name">Full Name:* </td>
            <td class="data_field">
                <asp:TextBox ID="text_fname" runat="server" Width="100%"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="fields_name">Email Address:* </td>
            <td class="data_field">
                <asp:TextBox ID="text_email" runat="server" Width="100%"></asp:TextBox></td>
        </tr>

        <tr>
            <td class="fields_name">Gender: </td>
            <td class="data_field">
                <asp:RadioButtonList ID="rbl_gender" runat="server" RepeatColumns="3" Width="103%"></asp:RadioButtonList></td>
        </tr>

        <tr>
            <td class="fields_name">Course:* </td>
            <td class="data_field">
                <asp:DropDownList ID="ddl_course" runat="server" Width="103%"></asp:DropDownList></td>
        </tr>

        <tr>
            <td class="fields_name">Country: </td>
            <td class="data_field">
                <asp:DropDownList ID="ddl_country" runat="server" OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="true" Width="103%"></asp:DropDownList></td>
        </tr>

        <tr>
            <td class="fields_name">State: </td>
            <td class="data_field">
                <asp:DropDownList ID="ddl_state" runat="server" Width="103%"></asp:DropDownList></td>
        </tr>

        <tr>
            <td class="fields_name">Phone: </td>
            <td class="data_field">
                <asp:TextBox ID="text_phone" runat="server" Width="100%"></asp:TextBox></td>
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
                <asp:Button ID="btn_register" CssClass="reg_btn" Text="Register" runat="server" OnClick="btn_register_Click" /></td>
        </tr>
    </table>
</asp:Content>
