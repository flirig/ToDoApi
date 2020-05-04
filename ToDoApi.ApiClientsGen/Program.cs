using System;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace ToDoApi.ApiClientsGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = OpenApiDocument.FromUrlAsync("https://localhost:5001/swagger/v1/swagger.json").Result;
            var className = $"{document.Info.Title}{document.Info.Version}Client";
            var nameSpace = "ToDoApi.ApiClients";
            var settings = new CSharpClientGeneratorSettings
            {
                ClassName = className,
                InjectHttpClient = true,
                UseBaseUrl = false,
                CSharpGeneratorSettings =
                    {
                        Namespace = nameSpace,
                        GenerateDataAnnotations = false,
                    }
            };
            var generator = new CSharpClientGenerator(document, settings);
            var code = generator.GenerateFile();
            var savePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), nameSpace, $"{className}.cs");
            File.WriteAllText(savePath, code);
        }
    }
}
