package twapp;

import java.lang.*;
import java.io.*;
import java.util.*;
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;

public class PictureListingTag extends SimpleTagSupport
{

  private String path = "";

  private JspFragment nameOut = null;


  public String getPath()
  {
    return this.path;
  }


  public void setPath(String newPath)
  {
    if (newPath == null)
      throw new IllegalArgumentException("path can't be null.");

    this.path = newPath;
  }


  public void setNameOut(JspFragment newNameOut)
  {
    this.nameOut = newNameOut;
  }


  public void doTag() throws JspException, IOException
  {
    if (this.path == null)
      throw new IllegalStateException("path is not set yet.");

    File file = new File(this.path);
    if (file.exists() == false)
      throw new IllegalArgumentException(
        "The file \"" + path
        + "\" specified in path doesn't exist.");
    if (file.isDirectory() == false)
      throw new IllegalArgumentException(
        "The file \"" + path
        + "\" specified in path is not a directory.");


    String[] pictList = file.list();

    JspFragment jspBody = this.getJspBody();
    JspContext jspCtx = this.getJspContext();
    JspWriter jspWtr = jspCtx.getOut();
    if (jspBody != null)
    {
      for (String pictPath: pictList)
      {
        if (this.nameOut != null)
          this.nameOut.invoke(jspWtr);

        jspCtx.setAttribute("pictPath",
                            this.path + File.separator + pictPath);
        jspBody.invoke(jspWtr);
      }
    }
  }


}
