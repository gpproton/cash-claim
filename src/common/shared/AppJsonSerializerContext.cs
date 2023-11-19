// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Text.Json.Serialization;
using Axolotl.Response;
using Microsoft.AspNetCore.Identity.Data;
using XClaim.Common.Responses;

namespace XClaim.Common;

// Bank
[JsonSerializable(typeof(Response<Bank>))]
[JsonSerializable(typeof(PagedResponse<Bank>))]
// Category
[JsonSerializable(typeof(Response<Category>))]
[JsonSerializable(typeof(PagedResponse<Category>))]
// Claim Response
[JsonSerializable(typeof(Response<ClaimResponse>))]
[JsonSerializable(typeof(PagedResponse<ClaimResponse>))]
// Comment
[JsonSerializable(typeof(Response<Comment>))]
[JsonSerializable(typeof(PagedResponse<Comment>))]
// Company
[JsonSerializable(typeof(Response<Company>))]
[JsonSerializable(typeof(PagedResponse<Company>))]
// Currency
[JsonSerializable(typeof(Response<Currency>))]
[JsonSerializable(typeof(PagedResponse<Currency>))]
// Domain
[JsonSerializable(typeof(Response<Domain>))]
[JsonSerializable(typeof(PagedResponse<Domain>))]
// Event Response
[JsonSerializable(typeof(Response<EventResponse>))]
[JsonSerializable(typeof(PagedResponse<EventResponse>))]
// User Identity
[JsonSerializable(typeof(ForgotPasswordRequest))]
// Payment
[JsonSerializable(typeof(Response<Payment>))]
[JsonSerializable(typeof(PagedResponse<Payment>))]
// Team
[JsonSerializable(typeof(Response<Team>))]
[JsonSerializable(typeof(PagedResponse<Team>))]
// User Account
[JsonSerializable(typeof(Response<User>))]
[JsonSerializable(typeof(PagedResponse<User>))]
[JsonSerializable(typeof(Response<BankAccount>))]
[JsonSerializable(typeof(Response<Settings>))]
[JsonSerializable(typeof(PagedResponse<ProfileTransfer>))]
[JsonSerializable(typeof(Response<ProfileTransfer>))]
// Server Options
[JsonSerializable(typeof(Response<Server>))]
[JsonSerializable(typeof(Response<Notification>))]
[JsonSerializable(typeof(PagedResponse<Notification>))]
public partial class AppJsonSerializerContext : JsonSerializerContext { }
