<%--
TextBlock.ascx
--%>

<%@ Control Inherits='AqDHome.WebUI.TextBlock' CodeBehind='TextBlock.ascx.cs' %>
<table class='TextBlock' cellpadding='0' cellspacing='0'>
  <tr>
    <td class='TextBlock-LeftSpacer'>
      <img class='TextBlock-LeftSpacer' src='<%# ImgSpacer %>'/>
    </td>
    <td class='TextBlock-HeaderText'>
      <%# Header %>
    </td>
    <td class='TextBlock-RightSpacer'>
      <img class='TextBlock-RightSpacer' src='<%# ImgSpacer %>'/>
    </td>
  </tr>
  <tr>
    <td class='TextBlock-HeaderUnderline' colspan='3'>
      <img class='TextBlock-Underline' src='<%# ImgSpacer %>'/>
    </td>
  </tr>
  <tr>
    <td class='TextBlock-Separator' colspan='3'>
      <img class='TextBlock-Separator' src='<%# ImgSpacer %>'/>
    </td>
  </tr>
  <tr>
    <td></td>
    <td class='TextBlock-Content'>
      <asp:PlaceHolder runat='server' ID='ChildrenHolder'/>
    </td>
    <td></td>
  </tr>
</table>
<asp:PlaceHolder runat='server' ID='EndMarker'/>
