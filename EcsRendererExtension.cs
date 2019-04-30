﻿using System.Net;
using System.Threading.Tasks;

namespace Red.EcsRenderer
{
    public static class EcsRendererExtension
    {
        /// <summary>
        ///     Renders an ecs page file to HTML and sends it
        /// </summary>
        /// <param name="response">The instance of the response</param>
        /// <param name="pageFilePath">The path of the ecs file to be rendered</param>
        /// <param name="parameters">The parameter collection used when rendering the template</param>
        /// <param name="status">The status code for the response</param>
        public static async Task<HandlerType> RenderPage(this Response response, string pageFilePath, RenderParams parameters, HttpStatusCode status = HttpStatusCode.OK)
        {
            var page = response.Context.Plugins.Get<EcsPageRenderer>().Render(pageFilePath, parameters);
            return await response.SendString(page, "application/html", status: status);
        }

    }
}
