using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

namespace Makani.Docs;

// src: https://learn.microsoft.com/en-us/archive/msdn-magazine/2019/october/csharp-accessing-xml-documentation-via-reflection
public static class AssemblyExtensions
{
    internal static HashSet<Assembly> loadedAssemblies = new HashSet<Assembly>();

    public static string GetDirectoryPath(this Assembly assembly)
    {
        string codeBase = assembly.CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);
        return Path.GetDirectoryName(path);
    }

    internal static void LoadXmlDocumentation(Assembly assembly)
    {
        if (loadedAssemblies.Contains(assembly))
        {
            return; // Already loaded
        }
        string directoryPath = assembly.GetDirectoryPath();
        string xmlFilePath = Path.Combine(directoryPath, assembly.GetName().Name + ".xml");
        if (File.Exists(xmlFilePath))
        {
            LoadXmlDocumentation(File.ReadAllText(xmlFilePath));
            loadedAssemblies.Add(assembly);
        }
    }

    internal static Dictionary<string, string> loadedXmlDocumentation =
      new Dictionary<string, string>();
    public static void LoadXmlDocumentation(string xmlDocumentation)
    {
        using (XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocumentation)))
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "member")
                {
                    string raw_name = xmlReader["name"];
                    loadedXmlDocumentation[raw_name] = xmlReader.ReadInnerXml();
                }
            }
        }
    }

    public static string GetDocumentation(this MemberInfo memberInfo)
    {
        if (memberInfo.MemberType.HasFlag(MemberTypes.Field))
        {
            return ((FieldInfo)memberInfo).GetDocumentation();
        }
        else if (memberInfo.MemberType.HasFlag(MemberTypes.Property))
        {
            return ((PropertyInfo)memberInfo).GetDocumentation();
        }
        else if (memberInfo.MemberType.HasFlag(MemberTypes.Event))
        {
            return ((EventInfo)memberInfo).GetDocumentation();
        }
        else if (memberInfo.MemberType.HasFlag(MemberTypes.Constructor))
        {
            return ((ConstructorInfo)memberInfo).GetDocumentation();
        }
        else if (memberInfo.MemberType.HasFlag(MemberTypes.Method))
        {
            return ((MethodInfo)memberInfo).GetDocumentation();
        }
        else if (memberInfo.MemberType.HasFlag(MemberTypes.TypeInfo) ||
        memberInfo.MemberType.HasFlag(MemberTypes.NestedType))
        {
            return ((TypeInfo)memberInfo).GetDocumentation();
        }
        else
        {
            return null;
        }
    }

    public static string GetDocumentation(this ParameterInfo parameterInfo)
    {
        string memberDocumentation = parameterInfo.Member.GetDocumentation();
        if (memberDocumentation != null)
        {
            string regexPattern =
              Regex.Escape(@"<param name=" + "\"" + parameterInfo.Name + "\"" + @">") +
              ".*?" +
              Regex.Escape(@"</param>");
            Match match = Regex.Match(memberDocumentation, regexPattern);
            if (match.Success)
            {
                return match.Value;
            }
        }
        return null;
    }
}

public class Utilities
{


}
