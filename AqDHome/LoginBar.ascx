<%--
LoginBar.ascx
--%>

<%@ Control Inherits='AqDHome.WebUI.LoginBar' CodeBehind='LoginBar.ascx.cs' %>
<div class='LoginBar'>
  <span class='LoginBar-Auth'>Administrator</span>
  &nbsp;&nbsp;
  <span class='LoginBar-User'>User:</span>&nbsp;
  <asp:TextBox runat='server' ID='UserTextBox'
    CssClass='LoginBar-User' Columns='8' MaxLength='255'/>
  &nbsp;&nbsp;
  <span class='LoginBar-Password'>Password:</span>&nbsp;
  <asp:TextBox runat='server' ID='PasswordTextBox'
    CssClass='LoginBar-Password' TextMode='Password'
    Columns='12' MaxLength='255'/>
  &nbsp;&nbsp;
  <asp:LinkButton runat='server' ID='LoginButton'
    CssClass='LoginBar-Submit' Text='Login' Visible='false'
    OnClick='LoginButton_Click' AutoPostBack='true'/>
  <asp:LinkButton runat='server' ID='LogoutButton'
    CssClass='LoginBar-Submit' Text='Logout' Visible='false'
    OnClick='LogoutButton_Click' AutoPostBack='true'/>
  &nbsp;
  <asp:Label runat='server' ID='ErrorLabel' Visible='false'
    CssClass='LoginBar-ErrorLabel' Text='Error!'/>
</div>
