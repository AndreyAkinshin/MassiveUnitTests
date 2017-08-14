using System.Text;

namespace Generator
{
    public static class UnitTestClassBuilder
    {
        public static string Build(string codeName, int startIndex, int count, string body = "")
        {
            var builder = new StringBuilder();

            builder.AppendLine("using System;");
            builder.AppendLine("using Xunit;");
            builder.AppendLine("");
            builder.AppendLine("// ReSharper disable once CheckNamespace");
            builder.AppendLine("namespace UnitTestNamespace" + codeName);
            builder.AppendLine("{");

            {
                builder.AppendLine("  public class UnitTestClass" + codeName);
                builder.AppendLine("  {");

                {
                    for (var i = startIndex; i < startIndex + count; i++)
                    {
                        var index = i.ToString().PadLeft(6, '0');
                        builder.AppendLine($"    [Fact] public void Test{index}() {{ {body} }}");
                    }
                }

                builder.AppendLine("  }");
            }

            builder.AppendLine("}");

            return builder.ToString();
        }
    }
}