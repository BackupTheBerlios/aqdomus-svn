<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
  xmlns:webui="http://aqdhome.sourceforge.net/webui"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" indent="yes"/>
  <xsl:strip-space elements="*"/>
  <xsl:include href="webui.xsl"/>

  <xsl:template match="webui:code-frame">
    <table cellpadding="0" cellspacing="0" class="code">

      <tr>
        <td colspan="2" style="background-color: white; text-align: center;">
          <img>
            <xsl:attribute name="src">
              img/code-title-<xsl:value-of select="@linkbase"/>.png</xsl:attribute>
          </img>
        </td>
      </tr>
      <tr>
        <td colspan="2" style="height: 25px; background-image: url(img/header-splitter-bottom.png);"></td>
      </tr>

      <tr>
        <td class="menu">

          <img>
            <xsl:choose>
              <xsl:when test="@menu=''">
                <xsl:attribute name="src">
                  img/code-menu-intro_sel.png</xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name="src">
                  img/code-menu-intro.png</xsl:attribute>
                <xsl:attribute name="onclick">
                  window.location = 'code-<xsl:value-of select="@linkbase"/>.xml';
                </xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
          </img>
          <br/>

          <img>
            <xsl:choose>
              <xsl:when test="@menu='userguide'">
                <xsl:attribute name="src">
                  img/code-menu-userguide_sel.png</xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name="src">
                  img/code-menu-userguide.png</xsl:attribute>
                <xsl:attribute name="onclick">
                  window.location = 'code-<xsl:value-of select="@linkbase"/>_userguide.xml';
                </xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
          </img>
          <br/>

          <img>
            <xsl:choose>
              <xsl:when test="@menu='refdoc'">
                <xsl:attribute name="src">
                  img/code-menu-refdoc_sel.png</xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name="src">
                  img/code-menu-refdoc.png</xsl:attribute>
                <xsl:attribute name="onclick">
                  window.location = 'code-<xsl:value-of select="@linkbase"/>_refdoc.xml';
                </xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
          </img>
          <br/>

          <img>
            <xsl:choose>
              <xsl:when test="@menu='download'">
                <xsl:attribute name="src">
                  img/code-menu-download_sel.png</xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name="src">
                  img/code-menu-download.png</xsl:attribute>
                <xsl:attribute name="onclick">
                  window.location = 'code-<xsl:value-of select="@linkbase"/>_download.xml';
                </xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
          </img>
          <br/>

          <img>
            <xsl:choose>
              <xsl:when test="@menu='lastcode'">
                <xsl:attribute name="src">
                  img/code-menu-lastcode_sel.png</xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name="src">
                  img/code-menu-lastcode.png</xsl:attribute>
                <xsl:attribute name="onclick">
                  window.location = 'http://cvs.sourceforge.net/viewcvs.py/aqdhome/<xsl:value-of select="@linkbase"/>/';
                </xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
          </img>
          <br/>

        </td>
        <td class="content">
          <xsl:apply-templates/>
        </td>
      </tr>
    </table>
  </xsl:template>

  <xsl:template match="webui:code-head">
    <div class="code-head">
      <xsl:apply-templates/>
    </div>
  </xsl:template>

  <xsl:template match="webui:ol">
    <ol class="code-ol">
      <xsl:apply-templates/>
    </ol>
  </xsl:template>

  <xsl:template match="webui:ul">
    <ul class="code-ul">
      <xsl:apply-templates/>
    </ul>
  </xsl:template>

  <xsl:template match="webui:li">
    <li class="code-li">
      <xsl:apply-templates/>
    </li>
  </xsl:template>

  <xsl:template match="webui:li-p">
    <li class="code-li-para">
      <p>
        <xsl:apply-templates/>
      </p>
    </li>
  </xsl:template>

  <xsl:template match="webui:para">
    <p class="code-para">
      <xsl:apply-templates/>
    </p>
  </xsl:template>

</xsl:stylesheet>
