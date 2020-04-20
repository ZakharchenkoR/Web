using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Linq;

namespace WebApp.Common
{
    public class AdminAreaAuthorization : IControllerModelConvention
    {
        private readonly string area;
        private readonly string policy;

        public AdminAreaAuthorization(string area, string policy)
        {
            this.area = area;
            this.policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if(controller.Attributes.Any(x => x is AreaAttribute && (x as AreaAttribute).RouteValue.Equals(area, StringComparison.OrdinalIgnoreCase))
                || controller.RouteValues.Any(x => x.Key.Equals(nameof(area), StringComparison.OrdinalIgnoreCase) && x.Value.Equals(area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(policy));
            }
        }
    }
}
