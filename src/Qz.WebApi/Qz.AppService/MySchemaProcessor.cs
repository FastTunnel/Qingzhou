using NJsonSchema;
using NJsonSchema.Generation;

namespace Qz.Application
{
    public class MySchemaProcessor : ISchemaProcessor
    {
        public void Process(SchemaProcessorContext context)
        {
            if (context.Schema.Properties.Count > 0)
            {
                foreach (var item in context.Schema.Properties)
                {
                    if (item.Value.Type == JsonObjectType.Integer && item.Value.Format == "int64")
                    {
                        item.Value.Type = JsonObjectType.String;
                    }
                }
            }
        }
    }
}
