cd Nextodon.Data.PostgreSQL
dotnet ef dbcontext scaffold --force --context MastodonContext --context-dir . --output-dir Models "Host=localhost;Database=mastodon_production;Username=mastodon;Password=1" Npgsql.EntityFrameworkCore.PostgreSQL
cd ..