<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="Student_Registration.Change_Password" %>
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
            width:350px;
        }

        table {
            display: flex;
            justify-content: center;
        }

        .fields_name {
            font-weight: 600;
        }

        .chng_btn {
            width: 140px;
            background-color: #1e90ff;
            border: none;
            height: 30px;
            border-radius: 5px;
            font-weight: 600;
        }
    </style>
    <table>
        <tr>
            <td class="fields_name">Current Password:* </td>
            <td class="data_field">
                <asp:TextBox ID="text_current_pass" TextMode="Password" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fields_name">New Password:* </td>
            <td class="data_field">
                <asp:TextBox ID="text_new_pass" TextMode="Password" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fields_name">Confirm Password:* </td>
            <td class="data_field">
                <asp:TextBox ID="text_confirm_pass" TextMode="Password" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fields_name"></td>
            <td>
                <asp:Label ID="lbl_msg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <tr>
            <td></td>
            <td class="data_field">
                <asp:Button ID="btn_change_pass" CssClass="chng_btn" Text="Change Password" runat="server" OnClick="btn_change_pass_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
