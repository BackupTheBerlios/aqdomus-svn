<%@ page session="false" %>
<%@ taglib prefix="tf" uri="http://aquila-deus.no-ip.org/taglibs/twapp" %>

<html>
  <head>
    <title>Demo</title>
    <style type="text/css">
      body
      {
        border-width: 0px;
        margin: 0px;
        padding: 0px;
      }
    </style>
  </head>

  <body>
    <h1 style="background: #ccddff">Hello!</h1>
    <tf:myTag repeatTimes="6">
      <jsp:attribute name="lineBegin">
        BEGIN:
      </jsp:attribute>
      <jsp:body>
        This is line ${i}
      </jsp:body>
      <jsp:attribute name="footer">
        FOOTER
      </jsp:attribute>
    </tf:myTag>
  </body>

</html>
