/*
 * Global.js.aspx
 */


<%@ Page ContentType='text/javascript' Inherits='AqDHome.WebUI.BasePage' %>
<%@ OutputCache Duration='3600' VaryByParam='none' VaryByHeader='User-Agent' %>


function GetWindowWidth() {
  <% if (IsIE) { %>
    return document.body.clientWidth;
  <% } else { %>
    return window.innerWidth - 30;
  <% } %>
}


function GetWindowHeight() {
  <% if (IsIE) { %>
    return document.body.clientHeight;
  <% } else { %>
    return window.innerHeight - 30;
  <% } %>
}


function GetCookie(name) {
  var cookies = document.cookie.split(";");
  for (var i=0; i<cookies.length; i++) {
    var co = cookies[i];
    if (co.substr(0, name.length+1) == name + "=") {
      return co.substr(name.length+1);
    } else if (co.substr(0, name.length+2) == " " + name + "=") {
      return co.substr(name.length+2);
    }
  }

  return null;
}


function SetCookie(name, value) {
  document.cookie = name + "=" + value;
}


function GetAbsoluteTop(obj) {
  var top = 0;
  for (var p = obj; p; p = p.offsetParent) {
    top += p.offsetTop;
  }

  return top;
}


function GetAbsoluteLeft(obj) {
  var left = 0;
  for (var p = obj; p; p = p.offsetParent) {
    left += p.offsetLeft;
  }

  return left;
}
