package twapp;

import java.lang.*;
import java.io.*;
import java.sql.*;
import javax.naming.*;
import javax.servlet.*;
import javax.servlet.http.*;
import javax.sql.*;


public class DbTestServlet extends HttpServlet
{


  private final String DATASOURCE_NAME = "jdbc-sqlserver";

  private DataSource dataSrc;


  public void init() throws ServletException
  {
    super.init();

    try
    {
      Context env = (Context) new InitialContext().lookup("java:comp/env");
      this.dataSrc = (DataSource) env.lookup(DATASOURCE_NAME);
    }
    catch (NamingException e)
    {
      throw new ServletException(e);
    }
  }


  protected void doGet(HttpServletRequest req, HttpServletResponse resp)
    throws ServletException, IOException
  {

    ServletOutputStream out = resp.getOutputStream();

    try
    {
      Connection conn = this.dataSrc.getConnection();
      Statement stat = conn.createStatement();
      ResultSet res = stat.executeQuery("SELECT payterms FROM sales");
      while (res.next() == true)
      {
        out.println(res.getString(1));
      }
      conn.close();
    }
    catch (SQLException e)
    {
      throw new ServletException(e);
    }

    out.println("Hello World!");

    return;
  }


}
