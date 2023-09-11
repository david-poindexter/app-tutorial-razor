using ToSic.Razor.Blade;
using ToSic.Razor.Html5;
using ToSic.Razor.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Shared / re-used code to create bootstrap tabs
public class BootstrapTabs: Custom.Hybrid.Code14
{
  private const string Indent = "    ";
  private const string IndentLi = "      ";
  private const string IndentBtn = "        ";
  public ITag TabList(string prefix, IEnumerable<string> names, string active = null) {
    // Remember tab names
    _moreTabNames = names.ToArray();
    var tabList = new List<object>();
    foreach (var name in names) {
      var isFirst = tabList.Count == 0;
      var isActive = (active == null && isFirst) || name == active;

      tabList.Add("\n\n" + IndentLi + "<!-- Tab '" + name + "'-->");
      tabList.Add("\n" + IndentLi);
      tabList.Add(TabLi(prefix, name, isFirst, isActive)); // first entry is active = true
    }
    return Tag.RawHtml(
      "\n" + Indent + "<!-- TabList Start '" + prefix + "'-->\n",
      Indent,
      Tag.Ul().Class("nav nav-pills p-3 rounded-top border")
        .Attr("role", "tablist")
        .Wrap(tabList),
      "\n" + Indent + "<!-- TabList End '" + prefix + "'-->\n"
    );
  }

  // WARNING: DUPLICATE CODE BootstrapTabs.cs / SourceCode.cs; keep in sync
  private string Name2TabId(string name) {
    return "-" + name.ToLower()
      .Replace(" ", "-")
      .Replace(".", "-")
      .Replace("/", "-")
      .Replace("\\", "-");
  }

  private ITag TabLi(string prefix, string label, bool isFirst, bool active) {
    return Tag.Li().Class("nav-item").Attr("role", "presentation").Wrap(
      "\n",
      IndentBtn + "<!-- Tab button -->\n",
      IndentBtn,
      TabButton(prefix, label, Name2TabId(label), isFirst, active),
      "\n" + IndentLi
    );
  }

  private ITag TabButton(string prefix, string title, string name, bool isFirst, bool selected) {
    var id = isFirst ? "-default" : name;
    return Tag.Button(title)
      .Class("nav-link " + (selected ? "active" : ""))
      .Id(prefix + "-tab")
      .Attr("data-bs-toggle", "tab")
      .Attr("data-bs-target", "#" + prefix + id)
      .Type("button")
      .Attr("role", "tab")
      .Attr("aria-controls", prefix + id)
      .Attr("aria-selected", selected.ToString().ToLower());
  }

  private Div TabContentGroup() {
    return Tag.Div().Class("tab-content p-3 border border-top-0 bg-light mb-5");
  }

  public dynamic TabContentGroupOpen() {
    _tabContentGroupIsOpen = true;
    return Tag.RawHtml(
      "\n" + Indent + "<!-- TabContentGroupOpen -->\n",
      Indent,
      Tag.Div().Class("tab-content p-3 border border-top-0 bg-light mb-5").TagStart
    );
  }
  private bool _tabContentGroupIsOpen = false;

  public string TabContentGroupClose() {
    var result = _tabContentGroupIsOpen ? "</div>\n": null;
    _tabContentGroupIsOpen = false;
    return result;
  }

  private Div TabContentDiv(string prefix, string id, bool isFirst, bool isActive = false) {
    id = isFirst ? "-default" : id;
    return Tag.Div()
        .Class("tab-pane fade " + (isActive ? "show active" : ""))
        .Id(prefix + id)
        .Attr("role", "tabpanel")
        .Attr("aria-labelledby", prefix + id + "-tab");
  }

  public string TabContentOpen(string prefix, string id, bool isFirst, bool isActive) {
    _tabContentIsOpen = true;
    return "\n" + Indent + "<!-- TabContentOpen -->\n"
      + Indent
      + TabContentDiv(prefix, id, isFirst, isActive).TagStart
      + "\n";
  }
  private bool _tabContentIsOpen = false;
  public string TabContentClose() {
    if (!_tabContentIsOpen)
      return "\n" + Indent + "<!-- TabContentClose - already closed -->\n";
    _tabContentIsOpen = false;
    var result = _tabContentIsOpen ? "</div>": null;
    return "\n" + Indent + "<!-- TabContentClose -->\n"
      + Indent + "</div>" + "\n";
  }

  public ITag TabContent(string prefix, string id, object result, bool isFirst, bool isActive) {
    return Tag.RawHtml(
      "\n" + Indent + "<!-- TabContent '" + prefix +"':'" + id + "' -->\n",
      Indent,
      TabContentDiv(prefix, id, isFirst, isActive).Wrap(result),
      "\n",
      Indent + "<!-- /TabContent '" + prefix +"':'" + id + "' -->\n"
    );
  }

  private string[] _moreTabNames;
  public string GetTabName(int index) {
    var l = Log.Call<string>("index:" + index);
    if (_moreTabNames == null || !_moreTabNames.Any()) return l("no names", "unknown");
    if (_moreTabNames.Length < index + 1) return l("index to high", "unknown");
    var name = _moreTabNames[index];
    Log.Add("name before optimization: '" + name + "'");
    return l(name, name);
  }
}