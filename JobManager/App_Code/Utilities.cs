using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobManager.Models;

public static class Utilities
{
    public static string GetString(object obj)
    {
        return (obj != null) ? obj.ToString() : "";
    }
}