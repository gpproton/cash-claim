// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Axolotl.Response;
using XClaim.Common.Responses;

namespace XClaim.Common.Http.Account; 

public interface IProfileService {
    Task<Response<AuthResponse?>> GetAccountAsync();
    Task<Response<BankAccount?>> GetBankAccountAsync();
    Task<Response<BankAccount?>> UpdateBankAccountAsync(BankAccount account);

    Task<Response<Settings?>> GetSettingAsync();
    Task<Response<Settings?>> UpdateSettingAsync(Settings setting);

    Task<Response<Notification?>> GetNotificationAsync();
    Task<Response<Notification?>> UpdateNotificationAsync(Notification notification);
    Task<bool> SignOutAsync();
}