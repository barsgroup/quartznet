 $buildconfig = Read-Host -Prompt '������������ ������ D - Debug (�� ���������), R - Release'

 if ($buildconfig -eq "D" -or $buildconfig -eq ""){
    $buildconfig = "Debug"
 }
 elseif ($buildconfig -eq "R"){
    $buildconfig = "Release"
 }


.\.paket\paket.bootstrapper.exe
.\.paket\paket.exe pack output .\.nuget buildconfig $buildconfig
