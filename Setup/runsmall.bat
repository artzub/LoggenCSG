del setup.exe
pushd debug
del arch.7z
..\..\7z\7zr a ..\arch.7z setup.exe setup.msi -m0=BCJ2 -m1=LZMA:d25:fb255 -m2=LZMA:d19 -m3=LZMA:d19 -mb0:1 -mb0s1:2 -mb0s2:3 -mx
::setup.exe setup.msi
popd
copy /b ..\7z\7zSD.sfx + config.txt + arch.7z LoggenCSG.exe
del arch.7z


