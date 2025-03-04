using ToSic.Razor.Blade;
using ToSic.Sxc.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using AppCode.TutorialSystem.Wrappers;
using AppCode.TutorialSystem.Source;
using AppCode.Data;

namespace AppCode.TutorialSystem.Tabs
{

  public class TabManager
  {
    public TabManager(SourceCode scParent, TutorialSnippet item, Dictionary<string, string> tabs, Wrap sourceWrap = null) {
      ScParent = scParent;
      Log = ScParent.Log;
      Item = item;
      Tabs = tabs ?? new Dictionary<string, string>();
      SourceWrap = sourceWrap;
      ActiveTabName = sourceWrap.TabSelected;
    }
    public readonly Dictionary<string, string> Tabs;
    protected readonly SourceCode ScParent; // also used in Formulas
    private TutorialSnippet Item { get; set; }
    public string ActiveTabName;
    private readonly Wrap SourceWrap;
    private readonly ICodeLog Log;

    #region TabNames

    public List<string> TabNames => _tabNames ??= GetTabNames();
    private List<string> _tabNames;
    protected virtual List<string> GetTabNames() {
      // Logging
      var l = Log.Call<List<string>>();

      // Build Names
      var names = GetTabNamesAndContentBase(useKeys: true)
        .Select(s => s as string)
        .Where(s => s != null)
        .Select(n => {
          // If a known tab identifier, return the nice name
          if (n == Constants.ViewConfigCode) return Constants.ViewConfigTabName;
          if (n == Constants.InDepthField) return Constants.InDepthTabName;
          // if a file, return the file name only (and on csv, fix a workaround to ensure import/export)
          if (n.EndsWith(".csv.txt")) n = n.Replace(".csv.txt", ".csv");
          if (n.StartsWith("file:")) return Text.AfterLast(n, "/") ?? Text.AfterLast(n, ":");
          return n;
        })
        .ToList();
      return l(names, names.Count.ToString()); 
    }

    private List<object> GetTabNamesAndContentBase(bool useKeys)
    {
      // Logging
      var l = Log.Call<List<object>>();
      // Build list
      var list = new List<object>();

      // If we have source-wrap, that determines what tabs to add
      if (SourceWrap != null)
      {
        Log.Add("SourceWrap: " + SourceWrap);
        list.AddRange(SourceWrap.Tabs);
      }

      if (Tabs.Any())
      {
        Log.Add("Tab Count: " + Tabs.Keys.Count());
        if (useKeys)
          list.AddRange(Tabs.Keys);
        else
        {
          if (_replaceTabContents != null)
          {
            list.AddRange(_replaceTabContents);
            // If the tabs have more entries - eg "ViewConfiguration" - then add that at the end as well
            if (Tabs.Values.Count() > _replaceTabContents.Count())
              list.AddRange(Tabs.Values.Skip(_replaceTabContents.Count()));
          }
          else
          {
            Log.Add("Add all Tab Values: " + string.Join(",", Tabs.Values));
            list.AddRange(Tabs.Values);
          }
        }
      }
      // Else custom tabs in configuration
      else if (Item.IsNotEmpty("Tabs"))
      {
        Log.Add("Tabs: " + Item.Tabs);
        list.AddRange(Item.Tabs.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).Select(t => t.Trim()));
      }

      // If we don't have an item, then finish now
      if (Item == null)
        return l(list, list.Count.ToString());

      // Otherwise add some default tabs as needed
      if (Item.IsNotEmpty(Constants.InDepthField))
      {
        Log.Add(Constants.InDepthField);
        list.Add(Constants.InDepthTabName);
      }
      if (Item.IsNotEmpty(Constants.NotesFieldName))
      {
        Log.Add(Constants.NotesFieldName);
        list.Add(Constants.NotesTabName);
      }
      // TODO: OLD / NEW
      if (Item.IsNotEmpty("Tutorials"))
      {
        Log.Add("Tutorials");
        list.Add(Constants.TutorialsTabName);
      }

      return l(list, list.Count.ToString());
    }


    #endregion

    #region TabContents

    /// <summary>
    /// The TabContents is either automatic, or set by the caller.
    /// 
    /// In many cases it's just a reference like "file:abc.cshtml" which will be resolved when showing.
    /// </summary>
    public List<object> TabContents => _tabLabels ??= GetTabContents();
    private List<object> _tabLabels;

    public void ReplaceTabContents(List<object> replacement) {
      var l = Log.Call("replacement: " + (replacement == null ? "null" : "" + replacement.Count()));
      _replaceTabContents = replacement;
      _tabLabels = null;  // Reset so it will be regenerated
      l("ok");
    }
    private List<object> _replaceTabContents;
    protected virtual List<object> GetTabContents()
    {
      var l = Log.Call<List<object>>();
      var list = GetTabNamesAndContentBase(useKeys: false);
      return l(list, "tabContents: " + list.Count);
    }

    #endregion

    #region Debug

    public string TabNamesDebug => string.Join(", ", TabNames);
    public string TabContentsDebug => string.Join(", ", TabContents.Select(tc => Text.Ellipsis(tc.ToString() ?? "", 20)));
    #endregion

  }


}