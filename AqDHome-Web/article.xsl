<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
  xmlns:webui="http://aqdhome.sourceforge.net/webui"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:include href="webui.xsl"/>

  <xsl:template match="webui:articles">
    <ul class="article-list">
      <xsl:for-each select="webui:at-content">
        <li class="article-list-item">
          <a>
            <xsl:attribute name="href">#<xsl:value-of select="@id"/></xsl:attribute>
            <xsl:value-of select="@name"/>
          </a>
        </li>
      </xsl:for-each>
    </ul>
    <xsl:for-each select="webui:at-content">
      <p class="article-head">
        <xsl:attribute name="id"><xsl:value-of select="@id"/></xsl:attribute>
        <xsl:value-of select="@name"/>
      </p>
      <p class="article-content">
        <xsl:apply-templates/>
      </p>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>
