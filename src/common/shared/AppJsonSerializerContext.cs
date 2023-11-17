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
using XClaim.Common.Responses;

namespace XClaim.Common;

[JsonSerializable(typeof(AuthResponse))]
[JsonSerializable(typeof(Bank))]
[JsonSerializable(typeof(BankAccount))]
[JsonSerializable(typeof(Category))]
[JsonSerializable(typeof(ClaimResponse))]
[JsonSerializable(typeof(Comment))]
[JsonSerializable(typeof(Company))]
[JsonSerializable(typeof(Currency))]
[JsonSerializable(typeof(Domain))]
[JsonSerializable(typeof(EventResponse))]
[JsonSerializable(typeof(FileResponse))]
[JsonSerializable(typeof(Notification))]
[JsonSerializable(typeof(Payment))]
[JsonSerializable(typeof(Profile))]
[JsonSerializable(typeof(ProfileTransfer))]
[JsonSerializable(typeof(Server))]
[JsonSerializable(typeof(Settings))]
[JsonSerializable(typeof(Team))]
[JsonSerializable(typeof(User))]
public partial class AppJsonSerializerContext : JsonSerializerContext { }
