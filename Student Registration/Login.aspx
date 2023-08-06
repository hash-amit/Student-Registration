<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Student_Registration.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'system-ui';
            background-color: #f1f1f1;
        }

        .fcontainer {
            display: flex;
            flex-direction: column;
            width: 300px;
            margin: 20px auto;
            border-radius: 8px;
            background-color: #ffffff;
            padding: 20px;
            box-shadow: 0px 0px 8px rgba(0, 0, 0, 0.3);
            justify-content: space-around;
        }

        .fitem {
            margin: 3px 0px;
            height: 30px;
            border-radius: 5px;
            display: flex;
            align-items: center;
            padding: 5px;
        }

        .fitem input{
            flex: 1;
            height: 100%;
            padding: 5px;
            border: none;
            border-radius: 5px;
            background-color: #1e90ff2e;
        }

        .fitem select {
            appearance: none;
            -webkit-appearance: none;
            -moz-appearance: none;
            background-image: url('arrow-down.png');
            background-repeat: no-repeat;
            background-position: right 8px center;
            height: 117%;
        }

        .log_btn {
            width: 100%;
            background-color: #1e90ff;
            border: none;
            height: 40px;
            border-radius: 5px;
            font-weight: 600;
            color: #ffffff;
            cursor: pointer;
        }

        .fitem .error {
            color: red;
        }
    </style>

    <div class="fcontainer">
        <div class="fitem">
            <asp:TextBox ID="text_email" runat="server" placeholder="Email Address*" TextMode="Email" CssClass="form-control" required=""></asp:TextBox>
        </div>

        <div class="fitem">
            <asp:TextBox ID="text_pass" runat="server" TextMode="Password" placeholder="Password*" CssClass="form-control" required=""></asp:TextBox>
        </div>

        <div class="fitem">
            <asp:Label ID="lbl_msg" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <asp:Button ID="btn_login" CssClass="log_btn" Text="Login" runat="server" OnClick="btn_login_Click" />
        </div>
    </div>
</asp:Content>
