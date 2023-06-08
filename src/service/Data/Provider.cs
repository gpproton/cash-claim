// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace XClaim.Service.Data;

public record Provider(string Name, string Assembly) {
    public static readonly Provider Sqlite = new (nameof(Sqlite), typeof(Entity.Sqlite.Marker).Assembly.GetName().Name!);
    public static readonly Provider Postgres = new (nameof(Postgres), typeof(Entity.Postgres.Marker).Assembly.GetName().Name!);
    public static readonly Provider Mysql = new (nameof(Mysql), typeof(Entity.Mysql.Marker).Assembly.GetName().Name!);
}