<%--
TextBlock.css.aspx
--%>

<%@ Page ContentType='text/css' Inherits='AqDHome.WebUI.BasePage' %>
<%@ OutputCache Duration='3600' VaryByParam='none' %>

table.TextBlock, td.TextBlock-HeaderText, td.TextBlock-Content {
  width: 100%;
}

td.TextBlock-LeftSpacer, img.TextBlock-LeftSpacer,
td.TextBlock-RightSpacer, img.TextBlock-RightSpacer {
  width: 4px;
}

td.TextBlock-HeaderText {
  color: rgb(136, 136, 128);
  font-size: 11pt;
  font-family: Georgia, Lucida Bright, Lucida, Serif;
  font-weight: bold;
  white-space: nowrap;
}

td.TextBlock-Underline, img.TextBlock-Underline {
  width: 100%;
  height: 8px;
  font-size: 0pt;
  background-image: url(<%# Img["TextBlock-HeaderUnderline"] %>);
  background-position: bottom left;
  background-repeat: repeat-x;
}

td.TextBlock-Separator, img.TextBlock-Separator {
  width: 0px;
  height: 4px;
  font-size: 0pt;
}

td.TextBlock-Content {
  color: rgb(128, 128, 128);
  font-size: 10pt;
  font-family: Times New Roman, Apple Garamond, Times, Serif;
  white-space: normal;
  overflow: hidden;
}
