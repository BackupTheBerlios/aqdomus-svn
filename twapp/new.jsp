<%@ page session="false" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jstl/core" %>

Hello World!

<c:forEach var="th" items="${header}">
  ${th}
  <br/>
</c:forEach>
${header["User-Agent"]}
