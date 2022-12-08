cd ..
@RD /S /Q "Aggregator/GraphQL/AuthorAPIClient"
cd Generator

xcopy /s /i "..\Queries\AuthorAPIClient" "Generator\GraphQL\AuthorAPIClient"
cd Generator
dotnet graphql init https://localhost:5001/graphql/ -n AuthorAPIClient -p ./GraphQL/AuthorAPIClient
dotnet build
cd..
xcopy /s /i "Generator\GraphQL\AuthorAPIClient" "..\Aggregator\GraphQL\AuthorAPIClient"
@RD /S /Q "Generator\GraphQL"
