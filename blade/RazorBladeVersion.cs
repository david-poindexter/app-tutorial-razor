using System;
using System.Diagnostics;
using System.Reflection;
using System.IO;

public class RazorBladeVersion: Custom.Hybrid.Code12
{

  public Version GetRazorBladeVersion() {
    var div = ToSic.Razor.Blade.Tag.Div();
    var version = Assembly.GetAssembly(div.GetType()).GetName().Version; //.ToString(4);
    return version;
  }

  public double VersionDouble() {
    var verInfo = GetRazorBladeVersion();
    if(verInfo == null) return 0;

    var major = verInfo.Major;
    var minor = verInfo.Minor;
    return Convert.ToDouble(major + "." + minor.ToString("D2"));
  }

  public string VersionInfo(double version, double expected) {
    var cls = expected <= version ? "secondary" : "danger";
    return "<span class='badge badge-" + cls + "'>v" + expected.ToString("0.00") + "</span>";
  }
}
