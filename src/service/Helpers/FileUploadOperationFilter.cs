// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace XClaim.Service.Helpers {
    public class FileUploadOperationFilter : IOperationFilter {
        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            const string fileUploadMime = "multipart/form-data";
            if (operation.RequestBody == null ||
                !operation.RequestBody.Content.Any(x =>
                    x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase))) {
                return;
            }

            string? name = context.ApiDescription.ActionDescriptor.DisplayName;
            operation.Parameters.Clear();

            if (context.ApiDescription.ParameterDescriptions[0].Type == typeof(IFormFile)) {
                return;
            }

            OpenApiMediaType? uploadFileMediaType = new OpenApiMediaType() {
                Schema = new OpenApiSchema() {
                    Type = "object",
                    Properties = {
                        ["files"] = new OpenApiSchema() {
                            Type = "array",
                            Items = new OpenApiSchema() {
                                Type = "string",
                                Format = "binary"
                            }
                        }
                    },
                    Required = new HashSet<string>() { "files" }
                }
            };

            operation.RequestBody = new OpenApiRequestBody {
                Content = { ["multipart/form-data"] = uploadFileMediaType }
            };
        }
    }
}