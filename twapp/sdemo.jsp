<%@ page session="false" %>
<%@ taglib prefix="sh" uri="http://struts.apache.org/tags-html" %>
<sh:html xhtml="true" lang="en">
  <head>
    <title>Hello</title>
  </head>
  <body>
    <sh:form action="/sdemo-submit.do">
      Enter a number: <sh:text property="myText"/>
    </sh:form>
  </body>
</sh:html>
