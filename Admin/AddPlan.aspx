<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="AddPlan.aspx.cs" Inherits="SocialPanel.Admin.AddPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="content" class="span10">
        <!-- content starts -->
        <div>
            <ul class="breadcrumb">
                <li><a href="#">Home</a> <span class="divider">/</span> </li>
                <li><a href="#">Plan</a> </li>
            </ul>
        </div>
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header well" data-original-title>
                    <h2>
                        <i class="icon-edit"></i>Add Plan</h2>
                    <div class="box-icon">
                        <%--<a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>--%>
                        <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                        <%--<a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>--%>
                    </div>
                </div>
                <div class="box-content">
                    <div class="form-horizontal">
                        <fieldset>
                            <legend>Add Multiple Accounts</legend>
                            
                            
                            <div class="control-group">
                                <label class="control-label" for="focusedInput">
                                    Plan Name</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtPlanName" runat="server" CssClass="input-xlarge focused" placeholder="Enter Plan Name"></asp:TextBox>
                                    <span class="help-inline">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPlanName"
                                            ErrorMessage="Please Enter Url" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator></span>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label" for="focusedInput">
                                    Like Amount</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtLikeAmount" TextMode="Number" CssClass="input-xlarge focused" placeholder="Enter LKike Amount"
                                        runat="server"></asp:TextBox>
                                    <span class="help-inline">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLikeAmount"
                                            ErrorMessage="Please Enter Amount" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator></span>
                                </div>
                            </div>
                           <div class="control-group">
                                <label class="control-label" for="focusedInput">
                                    Max Count</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtMaxCount" TextMode="Number" CssClass="input-xlarge focused" placeholder="Enter Max Count"
                                        runat="server"></asp:TextBox>
                                    <span class="help-inline">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMaxCount"
                                            ErrorMessage="Please Enter Max Count" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator></span>
                                </div>
                            </div>
                            <div class="control-group error">
                                <label class="control-label" for="inputError">
                                    <asp:Label ID="lblErrorMessage" runat="server" CssClass="control-label" for="inputError"></asp:Label></label>
                                <asp:HiddenField ID="hfUser" runat="server" />
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnSubmit" runat="server" Text="Save" 
                                    CssClass="btn btn-primary" onclick="btnSubmit_Click"/>
                                <asp:Button ID="btnReset" runat="server" CssClass="btn"
                                    Text="Reset" onclick="btnReset_Click" />
                            </div>
                        </fieldset>
                    </div>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
            <!-- content ends -->
        </div>
    </div>
</asp:Content>
