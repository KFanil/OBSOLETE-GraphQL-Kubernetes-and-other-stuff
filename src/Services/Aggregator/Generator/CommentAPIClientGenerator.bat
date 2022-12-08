cd ..
@RD /S /Q "Aggregator/GraphQL/CommentAPIClient"
cd Generator

xcopy /s /i "..\Queries\CommentAPIClient" "Generator\GraphQL\CommentAPIClient"
cd Generator
dotnet graphql init https://localhost:7001/graphql/ -n CommentAPIClient -p ./GraphQL/CommentAPIClient
dotnet build
cd..
xcopy /s /i "Generator\GraphQL\CommentAPIClient" "..\Aggregator\GraphQL\CommentAPIClient"
@RD /S /Q "Generator\GraphQL"
