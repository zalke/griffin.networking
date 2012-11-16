﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Griffin.Networking.Http.Server
{
    /// <summary>
    /// A http module
    /// </summary>
    /// <remarks>
    /// Each method will be invoked in all methods before continuing. i.e. the <c>BegingRequest</c> method will be invoked in
    /// all modules before the next method is invoked (which typically is <c>RouteRequest</c>).
    /// <para>Abort
    /// means only that the current method will be aborted for the modules. (EndRequest will still be invoked if you trigger
    /// abort in any of the methods</para></remarks>
    public interface IHttpModule
    {
        /// <summary>
        /// Invoked before anything else
        /// </summary>
        /// <param name="context">HTTP context</param>
        /// <remarks>
        /// <para>The first method that is exeucted in the pipeline.</para>
        /// Try to avoid throwing exceptions if you can. Let all modules have a chance to handle this method. You may break the processing in any other method than the Begin/EndRequest methods.</remarks>
        void BeginRequest(IRequestContext context);

        /// <summary>
        /// End request is typically used for post processing. The response should already contain everything required.
        /// </summary>
        /// <param name="context">HTTP context</param>
        /// <remarks>
        /// <para>The last method that is executed in the pipeline.</para>
        /// Try to avoid throwing exceptions if you can. Let all modules have a chance to handle this method. You may break the processing in any other method than the Begin/EndRequest methods.</remarks>
        void EndRequest(IRequestContext context);
    }
}
