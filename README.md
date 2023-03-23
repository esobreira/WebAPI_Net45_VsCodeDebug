# WebAPI_Net45_VsCodeDebug
Projeto .NET Framework 4.5 configurado pra ser depurado pelo Visual Studio Code

Antes de depurar, você precisa:
- Instalar o MSBuild do Visual Studio 2017 (vs_BuildTools-15.9) MSBuild15
- Adicionar as linhas abaixo no applicationhost.config,
logo abaixo do site id 1 de nome "WebSite1" na secao <sites> 

<site name="WebAPI_VSCodeDebug" id="2">
    <application path="/" applicationPool="Clr4IntegratedAppPool">
        <virtualDirectory path="/" physicalPath="C:\Users\ebertks\source\repos\WebAPI_Net45_VsCodeDebug\WebAPI_Net45_VsCodeDebug" />
    </application>
    <bindings>
        <binding protocol="http" bindingInformation="*:44331:localhost" />
        <binding protocol="https" bindingInformation="*:44332:localhost" />
    </bindings>
</site>