<%--
MenuPane.ascx
--%>

<%@ Control Inherits='AqDHome.WebUI.MenuPane' CodeBehind='MenuPane.ascx.cs' %>
<%@ Register Tagprefix='my' Tagname='MenuBase' Src='MenuBase.ascx' %>
<%@ Register Tagprefix='my' Tagname='MenuItem' Src='MenuItem.ascx' %>
<my:MenuBase runat='server'>
  <my:MenuItem runat='server' ItemID='HomePage'
    ItemName='Home Page'/>
  <my:MenuItem runat='server' ItemID='MyDocs'
    ItemName='Folder<br/>Documents'/>
  <my:MenuItem runat='server' ItemID='MyPics'
    ItemName='Folder<br/>Pictures'/>
  <my:MenuItem runat='server' ItemID='MyWebs'
    ItemName='Folder<br/>WebLinks'/>
  <my:MenuItem runat='server' ItemID='SystemCC'
    ItemName='System<br/>Configure'/>
</my:MenuBase>
