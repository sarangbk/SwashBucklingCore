using System;
using System.Collections.Generic;
using Swashbuckle.SwaggerGen;

namespace SwashBucklingCore
{
    public class ConsumesJsonFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Consumes == null)
                operation.Consumes = new List<string>();

            operation.Consumes.Add("application/json");
        }
    }
}
