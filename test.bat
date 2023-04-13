echo off
set url=https://localhost:5003

CALL:curl_test "Dane wizyty o ID 1" GET /visit/1 

CALL:curl_test "Wszystkie wizyty klienta o ID 1" GET /visit/client/1

CALL:curl_test "Wszystkie wizyty mechanika o ID 1" GET /visit/mechanic/1

CALL:curl_test "Wszystkie wizyty mechanika o ID 1 w dniu 01.01.2022" GET /visit/mechanic/1/date/2022/1/1

CALL:curl_test "Zmien status wizyty o ID 1 na 'Trwa' " GET /visit/1/update/Trwa

CALL:curl_test "Dane wizyty o ID 1" GET /visit/1 

EXIT /B 0

:curl_test
echo Nazwa testu: %~1
echo Testowany url: %url%%~3
curl -X %~2 ^
	 %url%%~3 ^
	 -H 'accept: text/json'
echo:
EXIT /B 0