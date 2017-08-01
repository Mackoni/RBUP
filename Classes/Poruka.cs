using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Poruka
{
    public static void PorukaRedirekcija(System.Web.UI.Page instance, string Message, string url)
    {
        instance.Response.Write(@"<script language='javascript'>alert('" + Message + "');document.location.href='" + url + "'; </script>");
    }
}