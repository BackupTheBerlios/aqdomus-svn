<%--
Default.aspx
--%>

<%@ Page Inherits='AqDHome.WebUI.DefaultPage' CodeBehind='Default.aspx.cs' %>
<%@ Register Tagprefix='my' Tagname='LoginBar' Src='LoginBar.ascx' %>
<%@ Register Tagprefix='my' Tagname='MenuPane' Src='MenuPane.ascx' %>
<?xml version='1.0' encoding='utf-8'?>
<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN'
'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
<html>
  <head>
    <link rel='stylesheet' type='text/css' href='Global.css.aspx'/>
    <link rel='stylesheet' type='text/css' href='Default.css.aspx'/>
    <asp:PlaceHolder runat='server' ID='StylesheetLinkHolder'/>
    <script type='text/javascript' src='Global.js.aspx'></script>
    <asp:PlaceHolder runat='server' ID='JavascriptLinkHolder'/>
    <title>AqDHome</title>
  </head>
  <body class='Default-Body'>
    <form runat='server'>
      <table class='Default-MainPane' cellpadding='0' cellspacing='0'>
        <tr>
          <td class='Default-ContentPane'>
            <table class='Default-ContentPane' cellpadding='0' cellspacing='0'>
              <tr>
                <td class='Default-ContentPaneHeader' colspan='3'>
                  <my:LoginBar runat='server'/>
                </td>
              </tr>
              <tr>
                <td class='Default-ContentPaneTop' colspan='3'>
                  <img src='<%# ImgSpacer %>' class='Default-ContentPaneTop'/>
                </td>
              </tr>
              <tr>
                <td class='Default-ContentPaneLeft'>
                  <img class='Default-ContentPaneLeft' src='<%# ImgSpacer %>'/>
                </td>
                <td class='Default-ContentPaneEmPage'>
                  <asp:PlaceHolder runat='server' ID='EmPageHolder'/>
                </td>
                <td class='Default-ContentPaneRight'>
                  <img class='Default-ContentPaneRight'
                    src='<%# ImgSpacer %>'/>
                </td>
              </tr>
              <tr>
                <td class='Default-ContentPaneBottom' colspan='3'>
                  <img src='<%# ImgSpacer %>'
                    class='Default-ContentPaneBottom'/>
                </td>
              </tr>
            </table>
          </td>
          <td class='Default-MenuPane'>
            <img src='<%# ImgSpacer %>' class='Default-MenuPaneSpacer'/>
            <my:MenuPane runat='server'/>
          </td>
        </tr>
      </table>
    </form>
  </body>
</html>
