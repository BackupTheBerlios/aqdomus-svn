<%--
HomePage.ascx
--%>

<%@ Control Inherits='AqDHome.WebUI.HomePage' CodeBehind='HomePage.ascx.cs' %>
<%@ Register Tagprefix='my' Tagname='SimpleLink' Src='SimpleLink.ascx' %>
<%@ Register Tagprefix='my' Tagname='TextBlock' Src='TextBlock.ascx' %>
<my:TextBlock runat='server' Header='Project Description'>
  AqDHome is a web-based personal storage system for people to store, backup,
  and share their files.
  <br/><br/>
  <ul>
    <li><b>Project:</b> <my:SimpleLink runat="server" LinkUrl='http://sourceforge.net/projects/aqdhome/'/></li>
    <li><b>Source code:</b> <my:SimpleLink runat="server" LinkUrl='http://cvs.sourceforge.net/viewcvs.py/aqdhome/'/></li>
    <li><b>License:</b> GPL</li>
    <li><b>Database:</b> Firebird (prototyping)</li>
  </ul>
</my:TextBlock>
<br/><br/>
<my:TextBlock runat='server' Header='Web-Site Info'>
  <ul>
    <li><b>CPU:</b> AMD Duron 700MHz</li>
    <li><b>RAM:</b> 256MB, 100MHz</li>
    <li><b>Location:</b> Taiwan, Taipei</li>
    <li><b>OS:</b> Windows XP, .NET v1.1.4322 SP1</li>
    <li><b>Database:</b> MSDE 2000A, MySQL 4.1, Firebird 1.5</li>
    <li><b>Network:</b> ADSL 2Mbps/256Kbps</li>
  </ul>
</my:TextBlock>
