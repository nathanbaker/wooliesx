#Build Environment
FROM microsoft/dotnet:2.1-sdk as build-env
WORKDIR app

COPY WooliesX.sln ./
COPY Wx.Core/Wx.Core.csproj Wx.Core/
COPY Wx.DevTest/Wx.DevTest.csproj Wx.DevTest/
COPY Wx.Core.Tests/Wx.Core.Tests.csproj Wx.Core.Tests/

RUN dotnet restore

COPY . ./
RUN dotnet publish --configuration Release -o ./out

# Test Runner
FROM build-env AS test-env
RUN dotnet test ./Wx.Core.Tests/Wx.Core.Tests.csproj --logger trx --no-build --configuration Release

# Runtime
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime
WORKDIR app
COPY --from=build-env /app/Wx.DevTest/out/ .
ENTRYPOINT ["dotnet", "Wx.DevTest.dll"]