<%--
MenuBase.css.aspx
--%>

<%@ Page ContentType='text/css' Inherits='AqDHome.WebUI.BasePage' %>
<%@ OutputCache Duration='3600' VaryByParam='none' %>

table.MenuBase {
  width: 100%;
  height: 100%;
}

td.MenuBase-Top, td.MenuBase-Middle, td.MenuBase-MidBot, td.MenuBase-Bottom {
  vertical-align: top;
}

td.MenuBase-Top, td.MenuBase-Middle, td.MenuBase-MidBot {
  height: 1px;
}

table.MenuBase-Top, table.MenuBase-Middle, table.MenuBase-MidBot, table.MenuBase-Bottom {
  width: 100%;
}

table.MenuBase-Bottom {
  height: 100%;
}

td.MenuBase-TopLeft, img.MenuBase-TopLeft {
  width: 93px;
  height: 50px;
  font-size: 0pt;
}

td.MenuBase-TopBack {
  width: 100%;
  background-image: url(<%# Img["MenuBase-AllBack"] %>);
}

td.MenuBase-MiddleLeft, img.MenuBase-MiddleLeft {
  width: 3px;
  background-image: url(<%# Img["MenuBase-AllLeft"] %>);
  background-position: top left;
  background-repeat: repeat-y;
  font-size: 0pt;
}

td.MenuBase-MiddleLeftCenter, img.MenuBase-MiddleLeftCenter {
  width: 30px;
  background-image: url(<%# Img["MenuBase-AllBack"] %>);
  font-size: 0pt;
}

td.MenuBase-MiddleCenter {
  width: 100%;
  background-image: url(<%# Img["MenuBase-AllBack"] %>);
  white-space: nowrap;
}

td.MenuBase-MiddleRight, img.MenuBase-MiddleRight {
  width: 24px;
  background-image: url(<%# Img["MenuBase-AllBack"] %>);
  font-size: 0pt;
}

td.MenuBase-MiddleBack {
  width: 100%;
  background-image: url(<%# Img["MenuBase-AllBack"] %>);
}

td.MenuBase-MidBotLeft, img.MenuBase-MidBotLeft {
  width: 93px;
  height: 53px;
  background-image: url(<%# Img["MenuBase-MidbotLeft"] %>);
  background-position: top left;
  background-repeat: repeat-y;
  font-size: 0pt;
}

td.MenuBase-MidBotBack {
  width: 100%;
  background-image: url(<%# Img["MenuBase-AllBack"] %>);
}

td.MenuBase-BottomLeft, img.MenuBase-BottomLeft {
  width: 93px;
  background-image: url(<%# Img["MenuBase-AllLeft"] %>);
  background-position: top right;
  background-repeat: repeat-y;
  font-size: 0pt;
}

td.MenuBase-BottomBack {
  width: 100%;
  background-image: url(<%# Img["MenuBase-AllBack"] %>);
}
