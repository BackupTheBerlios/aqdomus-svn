<%--
MenuItem.ascx
--%>

<%@ Control Inherits='AqDHome.WebUI.MenuItem' CodeBehind='MenuItem.ascx.cs' %>
<table class='MenuItemBorder' cellpadding='0' cellspacing='0'>
  <tr>
    <td class='<%# BorderClassNormal %>'
      onmouseover='className="<%# BorderClassHover %>"; MenuItem_MOver(this);'
      onmouseout='className="<%# BorderClassNormal %>"; MenuItem_MOut(this);'
      onclick='<%# GoToItemLink %>'>
      <table class='<%# ClassNormal %>' cellpadding='0' cellspacing='0'
        onmouseover='className="<%# ClassHover %>";'
        onmouseout='className="<%# ClassNormal %>";'>
        <tr>
          <td class='MenuItem-TopSpacer'>
            <img class='MenuItem-TopSpacer' src='<%# ImgSpacer %>'/>
          </td>
        </tr>
        <tr>
          <td class='MenuItem-LeftSpacer'>
            <img class='MenuItem-LeftSpacer' src='<%# ImgSpacer %>'/>
          </td>
          <td class='MenuItem-Icon'>
            <img class='MenuItem-Icon' src='<%# ItemIconPath %>'/>
          </td>
          <td class='MenuItem-MiddleSpacer'>
            <img class='MenuItem-MiddleSpacer' src='<%# ImgSpacer %>'/>
          </td>
          <td class='MenuItem-Name'>
            <div class='MenuItem-Name'><%# ItemName %></div>
            <div class='MenuItem-Underline'>
              <img class='MenuItem-Underline' src='<%# ImgSpacer %>'/>
            </div>
          </td>
          <td class='MenuItem-RightSpacer'>
            <img class='MenuItem-RightSpacer' src='<%# ImgSpacer %>'/>
          </td>
        </tr>
        <tr>
          <td class='MenuItem-BottomSpacer'>
            <img class='MenuItem-BottomSpacer' src='<%# ImgSpacer %>'/>
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
<div class='MenuItem-Separator'>
  <img class='MenuItem-Separator' src='<%# ImgSpacer %>'/>
</div>
