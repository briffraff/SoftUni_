FOR /F "tokens=*" %%G IN ('DIR /B /AD /S *') DO RMDIR /S /Q "%%G"
forfiles -p "C:\Users\Public\Documents\Simulatron" -s -m *.json* /D -0 /C "cmd /c del @path"