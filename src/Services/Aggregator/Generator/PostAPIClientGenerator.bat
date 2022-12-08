cd ..
@RD /S /Q "Aggregator/GraphQL/PostAPIClient"
cd Generator

xcopy /s /i "..\Queries\PostAPIClient" "Generator\GraphQL\PostAPIClient"
cd Generator
dotnet graphql init https://localhost:8046/graphql/ -n PostAPIClient -p ./GraphQL/PostAPIClient
dotnet build
cd..
xcopy /s /i "Generator\GraphQL\PostAPIClient" "..\Aggregator\GraphQL\PostAPIClient"
@RD /S /Q "Generator\GraphQL"
