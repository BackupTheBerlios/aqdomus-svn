package twapp;

import java.lang.*;
import java.io.*;
import java.sql.*;
import javax.naming.*;
import javax.servlet.*;
import javax.servlet.http.*;
import javax.sql.*;
import org.apache.commons.dbcp.*;


public class DbPoolServlet extends HttpServlet
{

  BasicDataSource ds;


  public void init() throws ServletException
  {
    super.init();

    try
    {
      String jndiName = "jdbc-sqlserver";

      this.ds = new BasicDataSource();
      this.ds.setDriverClassName("net.sourceforge.jtds.jdbc.Driver");
      this.ds.setUrl("jdbc:jtds:sqlserver://localhost;namedpipe=true");
      this.ds.setUsername("pubs");
      this.ds.setPassword("puuu");

      Context env = (Context) new InitialContext().lookup("java:comp/env");
      env.bind(jndiName, ds);
    }
    catch (NamingException e)
    {
      throw new ServletException(e);
    }
  }


  public void destroy()
  {
    try
    {
      if (this.ds != null)
        this.ds.close();
    }
    catch (Exception e)
    {
    }
  }


}
