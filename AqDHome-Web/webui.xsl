<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
  xmlns:webui="http://aqdhome.sourceforge.net/webui"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/webui:page">
    <html>
      <head>
        <meta http-equiv="cache-control" content="no-cache"/>
        <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
        <link rel="stylesheet" type="text/css" href="webui.css"/>
        <link rel="stylesheet" type="text/css">
          <xsl:attribute name="href"><xsl:value-of select="@css"/>.css</xsl:attribute>
        </link>
        <title>AqDHome - <xsl:value-of select="@description"/></title>
      </head>
      <body>
        <table class="header" cellpadding="0" cellspacing="0">
          <tr>
            <td class="logo-repeat"></td>
            <td class="logo">
              <img class="logo" src="img/logo.png"/>
            </td>
          </tr>
          <tr><td class="header-splitter" colspan="2"></td></tr>
        </table>
        <xsl:apply-templates/>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="*">
    <xsl:copy>
      <xsl:copy-of select="@*"/>
      <xsl:apply-templates/>
    </xsl:copy>
  </xsl:template>

</xsl:stylesheet>
