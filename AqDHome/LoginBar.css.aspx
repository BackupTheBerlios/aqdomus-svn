<%--
LoginBar.css.aspx
--%>

<%@ Page ContentType='text/css' Inherits='AqDHome.WebUI.BasePage' %>
<%@ OutputCache Duration='3600' VaryByParam='none' %>

div.LoginBar {
  margin-left: 12px;
  margin-top: 6px;
  overflow: hidden;
  white-space: nowrap;
}

span.LoginBar-Auth,
span.LoginBar-User, input.LoginBar-User,
span.LoginBar-Password, input.LoginBar-Password,
input.LoginBar-User-Logon, input.LoginBar-Password-Logon,
a.LoginBar-Submit, span.LoginBar-ErrorLabel {
  color: rgb(128, 132, 136);
  font-family: Arial, Helvetica, Sans-Serif;
  font-size: 7pt;
}

span.LoginBar-Auth {
  font-weight: bolder;
}

input.LoginBar-User, input.LoginBar-Password,
input.LoginBar-User-Logon, input.LoginBar-Password-Logon {
  border-style: solid;
  border-color: rgb(160, 160, 160);
  border-width: 1px;
}

input.LoginBar-User, input.LoginBar-Password {
  color: rgb(24, 28, 32);
  background-color: rgb(255, 255, 255);
}

input.LoginBar-User-Logon, input.LoginBar-Password-Logon {
  color: rgb(255, 255, 255);
  background-color: rgb(224, 228, 232);
}

a.LoginBar-Submit, a.LoginBar-Submit:hover {
  position: relative;
  top: -1px;
  border-style: solid;
  border-color: rgb(160, 160, 160);
  border-width: 1px;
  padding-top: 1px;
  padding-bottom: 1px;
  padding-left: 3px;
  padding-right: 3px;
  font-weight: bolder;
  text-decoration: none;
}

a.LoginBar-Submit {
  color: rgb(128, 128, 128);
  background-color: rgb(224, 228, 232);
}

a.LoginBar-Submit:hover {
  color: rgb(92, 94, 96);
  background-color: rgb(248, 252, 255);
}
