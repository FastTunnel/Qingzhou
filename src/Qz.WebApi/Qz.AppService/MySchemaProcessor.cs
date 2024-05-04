using Swashbuckle.AspNetCore.SwaggerGen;

namespace Qz.Application
{
    public class MySchemaFilter : ISchemaFilter
    {
        public void Apply(Microsoft.OpenApi.Models.OpenApiSchema schema, SchemaFilterContext context)
        {
            foreach (var item in schema.Properties)
            {
                if (item.Value.Type == "integer" && item.Value.Format == "int64")
                {
                    item.Value.Type = "string";
                }
            }
        }
    }

    public class MyParameterFilter : IParameterFilter
    {
        public void Apply(Microsoft.OpenApi.Models.OpenApiParameter parameter, ParameterFilterContext context)
        {
            if (parameter.Schema.Type == "integer" && parameter.Schema.Format == "int64")
            {
                parameter.Schema.Type = "string";
            }
        }
    }
}
