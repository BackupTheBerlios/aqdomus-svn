<%--
Default.css.aspx
--%>

<%@ Page ContentType='text/css' Inherits='AqDHome.WebUI.BasePage' %>
<%@ OutputCache Duration='3600' VaryByParam='none' %>

body.Default-Body {
  width: 100%;
  height: 100%;
  background-color: rgb(255, 255, 255);
  color: rgb(128, 128, 128);
}

table.Default-MainPane {
  width: 100%;
  height: 100%;
}

img.Default-VSpacer {
  height: 9pt;
}

img.Default-HSpacer {
  width: 12pt;
}

img.Default-Logo {
  display: block;
}

td.Default-MenuPane {
  height: 100%;
  vertical-align: top;
  white-space: nowrap;
}

img.Default-MenuPaneSpacer {
  display: block;
  width: 160pt;
  height: 0pt;
}

td.Default-ContentPane, table.Default-ContentPane {
  width: 100%;
  height: 100%;
  vertical-align: top;
}

td.Default-ContentPaneHeader {
  height: 50px;
  background-image: url(<%# Img["Default-Header"] %>);
  background-position: top-left;
  background-repeat: repeat-x;
  vertical-align: top;
}

td.Default-ContentPaneTop, img.Default-ContentPaneTop,
td.Default-ContentPaneBottom, img.Default-ContentPaneBottom {
  height: 16px;
  font-size: 0pt;
}

td.Default-ContentPaneLeft, img.Default-ContentPaneLeft,
td.Default-ContentPaneRight, img.Default-ContentPaneRight {
  width: 16px;
  font-size: 0pt;
}

td.Default-ContentPaneEmPage {
  width: 100%;
  vertical-align: top;
}
