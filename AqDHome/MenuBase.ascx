<%--
MenuBase.ascx
--%>

<%@ Control Inherits='AqDHome.WebUI.MenuBase' CodeBehind='MenuBase.ascx.cs' %>
<table class='MenuBase' cellpadding='0' cellspacing='0'>
  <tr><td class='MenuBase-Top'>
      <table class='MenuBase-Top' cellpadding='0' cellspacing='0'>
        <tr>
          <td class='MenuBase-TopLeft'>
            <img class='MenuBase-TopLeft'
              src='<%# Img["MenuBase-TopLeft"] %>'/>
          </td>
          <td class='MenuBase-TopBack'>
          </td>
        </tr>
      </table>
  </td></tr>
  <tr><td class='MenuBase-Middle'>
      <table class='MenuBase-Middle' cellpadding='0' cellspacing='0'>
        <tr>
          <td class='MenuBase-MiddleLeft'>
            <img class='MenuBase-MiddleLeft' src='<%# ImgSpacer %>'/>
          </td>
          <td class='MenuBase-MiddleLeftCenter'>
            <img class='MenuBase-MiddleLeftCenter' src='<%# ImgSpacer %>'/>
          </td>
          <td class='MenuBase-MiddleCenter'>
            <asp:PlaceHolder runat='server' ID='ChildrenHolder'/>
          </td>
          <td class='MenuBase-MiddleRight'>
            <img class='MenuBase-MiddleRight' src='<%# ImgSpacer %>'/>
          </td>
        </tr>
      </table>
  </td></tr>
  <tr><td class='MenuBase-MidBot'>
      <table class='MenuBase-MidBot' cellpadding='0' cellspacing='0'>
        <tr>
          <td class='MenuBase-MidBotLeft'>
            <img class='MenuBase-MidBotLeft'
              src='<%# Img["MenuBase-MidBotLeft"] %>'/>
          </td>
          <td class='MenuBase-MidBotBack'>
            <img class='MenuBase-MidBotBack' src='<%# ImgSpacer %>'/>
          </td>
        </tr>
      </table>
  </td></tr>
  <tr><td class='MenuBase-Bottom'>
      <table class='MenuBase-Bottom' cellpadding='0' cellspacing='0'>
        <tr>
          <td class='MenuBase-BottomLeft'>
            <img class='MenuBase-BottomLeft' src='<%# ImgSpacer %>'/>
          </td>
          <td class='MenuBase-BottomBack'>
            <img class='MenuBase-BottomBack' src='<%# ImgSpacer %>'/>
          </td>
        </tr>
      </table>
  </td></tr>
</table>
<asp:PlaceHolder runat='server' ID='EndMarker'/>
