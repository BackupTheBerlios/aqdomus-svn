package twapp;

import java.lang.*;
import java.io.*;
import java.util.*;
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;


public class MyTag extends SimpleTagSupport
{

  private Integer repeatTimes = null;

  private JspFragment lineBegin = null;

  private JspFragment footer = null;


  public int getRepeatTimes()
  {
    return this.repeatTimes;
  }


  public void setRepeatTimes(int newRepeatTimes)
  {
    this.repeatTimes = new Integer(newRepeatTimes);
  }


  public void setFooter(JspFragment newFooter)
  {
    this.footer = newFooter;
  }


  public void setLineBegin(JspFragment newLineBegin)
  {
    this.lineBegin = newLineBegin;
  }


  public void doTag() throws JspException, IOException
  {
    if (this.repeatTimes == null)
      throw new IllegalArgumentException("repeatTimes is not set,");

    JspFragment jspBody = this.getJspBody();
    JspContext jspCtx = this.getJspContext();
    JspWriter jspCtxWtr = jspCtx.getOut();
    int r = this.repeatTimes.intValue();

    for (int i=0; i<r; i++)
    {
      if (this.lineBegin != null)
        this.lineBegin.invoke(jspCtxWtr);

      // repeatTimes is for <jsp:body> only
      if (jspBody != null)
      {
        jspCtx.setAttribute("i", i);
        jspBody.invoke(jspCtxWtr);
        jspCtx.removeAttribute("i");
      }

      jspCtxWtr.println("<br/>");
    }

    if (this.footer != null)
      this.footer.invoke(jspCtxWtr);

    return;
  }


}
