<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHotel.Registration._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <<div class="row">
        <div id="search">         
         <asp:TextBox ID="txtSearchMaster" runat="server"></asp:TextBox>
         <!-- <asp:Button class="sh-button btn" ID="btnSearch1" runat="server" Text="Search" onserverclick="BtnSearch_Click" OnClick="BtnSearch_Click" />
         <button class="sh-button btn" id="MainContent_btnSearch" >Search</button> -->
         <input type="button" class="sh-button btn" id="MainContent_btnSearch"  value="Search" onclick="GetCustomers()" />
         <script src="Scripts/jquery-1.10.2.min.js"></script>
         <script language="javascript" type="text/javascript">
            function GetCustomers() {
                window.location.href = "Default.aspx?srch="+  $("#MainContent_txtSearchMaster").val();
              return;              
            }
        </script>
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="RegistrationGrid" runat="server"
            OnSelectedIndexChanged="RegistrationGrid_SelectedIndexChanged"
            OnRowDataBound="RegistrationGrid_RowDataBound"
            DataKeyNames="Id,Type"
            AutoGenerateColumns="false"
            ShowHeader="true">
            <Columns>
                <asp:BoundField DataField="Id" Visible="false" />
                <asp:BoundField DataField="Type" Visible="false" />
                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                <asp:BoundField DataField="Passport" HeaderText="Passport" />
                <asp:BoundField DataField="CustomerId" HeaderText="Customer Id" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Type" HeaderText="Operation" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="row">
        <asp:Label ID="NoBookingsLabel" Visible="false" runat="server" Text="Sorry :( No bookings found under this guest. Please enter other customer names to search for bookings."></asp:Label>
    </div>
</asp:Content>
