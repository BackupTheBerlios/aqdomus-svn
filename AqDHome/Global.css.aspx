<%--
Global.css.aspx
--%>

<%@ Page ContentType='text/css' Inherits='AqDHome.WebUI.BasePage' %>
<%@ OutputCache Duration='3600' VaryByParam='none' VaryByHeader='User-Agent' %>

body {
  cursor: default;
  font-family: Arial;
  font-size: 8pt;
  <% if (IsIE) { %>
    scrollbar-face-color: rgb(232, 236, 232);
    scrollbar-arrow-color: rgb(0, 0, 0);
    scrollbar-track-color: rgb(240, 244, 240);
    scrollbar-shadow-color: rgb(232, 236, 232);
    scrollbar-highlight-color: rgb(232, 236, 232);
    scrollbar-3dlight-color: rgb(216, 220, 216);
    scrollbar-darkshadow-Color: rgb(216, 220, 216);
  <% } %>
}

body form {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body h1 {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body h2 {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body h3 {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body h4 {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body h5 {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body h6 {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body img {
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body p {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body pre {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

body table {
  cursor: default;
  <% if (IsIE) { %>
    filter: basicimage(opacity=100);
  <% } %>
}

* {
  margin: 0pt;
  border-style: none;
  border-width: 0pt;
  padding: 0pt;
}

a {
  cursor: pointer;
}

table {
  border-collapse: separate;
}

ul, ol {
  <% if (IsIE) { %>
    padding-left: 1.4em;
  <% } else { %>
    padding-left: 1em;
  <% } %>
}
