<%--
MenuItem.css.aspx
--%>

<%@ Page ContentType='text/css' Inherits='AqDHome.WebUI.BasePage' %>
<%@ OutputCache Duration='3600' VaryByParam='none' VaryByHeader='User-Agent' %>

table.MenuItemBorder {
  width: 100%;
}

td.MenuItemBorder, td.MenuItemBorder-Hover, td.MenuItemBorder-Selected {
  width: 100%;
  border-style: solid;
  border-width: 1px;
}

td.MenuItemBorder-Selected {
  border-color: rgb(188, 188, 192);
  background-color: rgb(192, 224, 255);
}

td.MenuItemBorder {
  border-color: rgb(239, 239, 222);
  background-image: url(<%# Img["MenuBase-AllBack"] %>);
}

td.MenuItemBorder-Hover {
  border-color: rgb(180, 188, 192);
  background-color: rgb(255, 255, 255);
}

table.MenuItem, table.MenuItem-Hover, table.MenuItem-Selected {
  width: 100%;
  border-style: solid;
  border-width: 1px;
  background-image: url(<%# Img["MenuBase-AllBack"] %>);
}

table.MenuItem-Selected {
  border-color: rgb(180, 188, 192);
}

table.MenuItem, table.MenuItem-Hover {
  cursor: pointer;
}

table.MenuItem {
  border-color: rgb(239, 239, 222);
  <% if (IsIE) { %>
    filter: alpha(opacity=100);
  <% } else { %>
    opacity: 100%;
  <% } %>
}

table.MenuItem-Hover {
  border-color: rgb(255, 255, 255);
  <% if (IsIE) { %>
    filter: alpha(opacity=90);
  <% } else { %>
    opacity: 90%;
  <% } %>
}

td.MenuItem-TopSpacer, img.MenuItem-TopSpacer {
  width: 0px;
  height: 8px;
  font-size: 0pt;
}

td.MenuItem-BottomSpacer, img.MenuItem-BottomSpacer {
  width: 0px;
  height: 8px;
  font-size: 0pt;
}

td.MenuItem-LeftSpacer, img.MenuItem-LeftSpacer {
  width: 8px;
}

td.MenuItem-MiddleSpacer, img.MenuItem-MiddleSpacer {
  width: 12px;
}

td.MenuItem-RightSpacer, img.MenuItem-RightSpacer {
  width: 12px;
}

img.MenuItem-Icon {
  width: 72px;
  height: 72px;
}

td.MenuItem-Name {
  text-align: right;
}

div.MenuItem-Name {
  padding-left: 0.5em;
  padding-right: 0.5em;
  font-family: Arial Narrow, Sans-Serif;
  font-size: 22px;
  font-weight: bolder;
  white-space: nowrap;
}

div.MenuItem-Underline, img.MenuItem-Underline {
  width: 100%;
  height: 8px;
  font-size: 0pt;
  background-image: url(<%# Img["MenuItem-Underline"] %>);
  background-position: bottom left;
  background-repeat: repeat-x;
}

div.MenuItem-Separator, img.MenuItem-Separator {
  width: 0px;
  height: 8px;
  font-size: 0pt;
}
