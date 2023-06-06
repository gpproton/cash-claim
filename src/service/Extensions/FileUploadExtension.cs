// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Net;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using XClaim.Service.Helpers;

namespace XClaim.Service.Extensions;

public static class FileUploadExtension {
    public static WebApplication RegisterFileUploadService(this WebApplication app) {
        FileUploadService? uploadService = app.Services.GetService<FileUploadService>();
        if (uploadService == null) return app;

        string fullUploadPath = uploadService.GetUploadRootPath();
        if (!Directory.Exists(fullUploadPath)) {
            Console.WriteLine("Creating static files directory");
            _ = Directory.CreateDirectory(fullUploadPath);
        }
        _ = app.UseStaticFiles();

        static void OnPrepareResponse(StaticFileResponseContext ctx) {
            if (!ctx.Context.Request.Path.StartsWithSegments("/static")) {
                return;
            }

            ctx.Context.Response.Headers.Add("Cache-Control", "no-store");
            if (ctx.Context.User.Identity == null || ctx.Context.User.Identity.IsAuthenticated) {
                return;
            }

            ctx.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            ctx.Context.Response.ContentLength = 0;
            ctx.Context.Response.Body = Stream.Null;
            // TODO: Use better response
            // JsonSerializer.Serialize(new { Status = 401, Message = "UnAuthorized file access" });
        }

        _ = app.UseStaticFiles(new StaticFileOptions {
            FileProvider = new PhysicalFileProvider(fullUploadPath),
            RequestPath = new PathString("/static"),
            OnPrepareResponse = OnPrepareResponse
        });

        return app;
    }
}