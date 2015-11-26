 $apikey = Read-Host -Prompt 'Ключ Api нугета'
 $version  = Read-Host -Prompt 'Версия пакета'

.\.paket\paket.bootstrapper.exe

foreach ($nugetPackage in Get-ChildItem -Path .\.nuget -Filter "*$version.nupkg" ) {
    .\.paket\paket.exe push url https://barsgroup.myget.org/F/web-svody/api/v2/package/ file $nugetPackage.FullName apikey $apikey
}
