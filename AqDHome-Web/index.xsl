<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
  xmlns:webui="http://aqdhome.sourceforge.net/webui"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:include href="webui.xsl"/>

  <xsl:template match="webui:front">
    <table class="front-top" cellpadding="0" cellspacing="0">
      <tr>
        <td class="front-top-left">
          <div class="front-top-left">
            <xsl:apply-templates select="webui:front-intro"/>
          </div>
        </td>
        <td class="front-top-right">
          <img src="img/spacer.png"/>
          <div class="front-top-right">
            <xsl:apply-templates select="webui:front-menu"/>
          </div>
        </td>
      </tr>
    </table>
    <div class="front-middle">
      <img src="img/front-middle-left.png"/>
      <div class="front-middle-content">
        <xsl:apply-templates select="webui:front-code"/>
      </div>
    </div>
    <div class="front-bottom">
      <img src="img/front-bottom-right.png"/>
    </div>
  </xsl:template>

  <xsl:template match="webui:front-intro">
    <div class="front-green-text">
      <xsl:apply-templates/>
    </div>
  </xsl:template>

  <xsl:template match="webui:front-menu">
    <table class="front-blue" cellpadding="0" cellspacing="0">
      <xsl:for-each select="item">
        <tr>
          <td>
            <a class="front-blue-item-name">
              <xsl:attribute name="href">
                <xsl:value-of select="@link"/>
              </xsl:attribute>
              <div>
                <xsl:value-of select="@name"/>
                <div>
                  <xsl:value-of select="@name"/>
                  <div>
                    <xsl:value-of select="@name"/>
                  </div>
                </div>
              </div>
            </a>
            <p class="front-blue-item-text">
              <xsl:apply-templates/>
            </p>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>

  <xsl:template match="webui:front-code">
    <table class="front-red" cellpadding="0" cellspacing="0">
      <tr>
        <td class="front-red-spacer">
          <img src="img/spacer.png"/>
        </td>
        <xsl:for-each select="item">
          <td class="front-red-item-name">
            <a class="front-red-item-name">
              <xsl:attribute name="href">
                <xsl:value-of select="@link"/>
              </xsl:attribute>
              <div>
                <xsl:value-of select="@name"/>
                <div onmouseover="this.style.textDecoration = 'underline';"
                  onmouseout="this.style.textDecoration = 'none';">
                  <xsl:value-of select="@name"/>
                  <div onmouseover="this.style.textDecoration = 'underline';"
                    onmouseout="this.style.textDecoration = 'none';">
                    <xsl:value-of select="@name"/>
                  </div>
                </div>
              </div>
            </a>
          </td>
          <td class="front-red-spacer">
            <img src="img/spacer.png"/>
          </td>
        </xsl:for-each>
      </tr>
      <tr>
        <td></td>
        <xsl:for-each select="item">
          <td class="front-red-item-text">
            <xsl:apply-templates/>
          </td>
          <td></td>
        </xsl:for-each>
      </tr>
    </table>
  </xsl:template>

</xsl:stylesheet>
