using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace Web
{
    /// <summary>
    /// This class is used for enum values documentation in Swagger.
    /// </summary>
    public class ApplyDocumentVendorExtensions : IDocumentFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiExplorer"></param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            foreach (var schemaDictionaryItem in swaggerDoc.definitions)
            {
                var schema = schemaDictionaryItem.Value;
                foreach (var propertyDictionaryItem in schema.properties)
                {
                    var property = propertyDictionaryItem.Value;
                    var propertyEnums = property.@enum;
                    if (propertyEnums != null && propertyEnums.Count > 0)
                    {
                        var enumDescriptions = new List<string>();
                        for (int i = 0; i < propertyEnums.Count; i++)
                        {
                            var enumOption = propertyEnums[i];
                            enumDescriptions.Add(string.Format("{0} = {1} ", (int)enumOption, Enum.GetName(enumOption.GetType(), enumOption)));
                        }
                        property.description += string.Format(" ({0})", string.Join(", ", enumDescriptions.ToArray()));
                    }
                }
            }
        }
    }
}