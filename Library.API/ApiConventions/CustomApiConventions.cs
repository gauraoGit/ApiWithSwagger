using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.ApiConventions
{
    public static class CustomApiConventions
    {
        //Added Custom Conventions and applied for Coneventions controler InertTest method based on Prefix match
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Insert(
            [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Any)]
            [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.Any)]
        object model) { }
    }
}
