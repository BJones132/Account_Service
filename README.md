# Account_Service

## Instructions
Open a powershell in the app directory:<br>
<img width="924" height="455" alt="image" src="https://github.com/user-attachments/assets/d8f341c6-ca58-4c89-a956-f80fa6707d7d" />

Before running, the following environment variables are required. This should be done within the powershell that the service shall be launched from:
```
ENVIRONMENT VARIABLES:
$Env:ASPNETCORE_URLS = "http://<HOST>:<HTTP_PORT>;https://<HOST>:<HTTPS_PORT>"
$Env:ConnectionStrings:financedb = "Server=<SERVER_HOST>;Username=<USERNAME>;Database=<DATABASE>"

EXAMPLE:
$Env:ASPNETCORE_URLS = "http://localhost:5011;https://localhost:5001"
$Env:ConnectionStrings:financedb = "Server=localhost;Username=postgres;Database=finance"
```

Finally, run the Account_Service.exe using powershell:<br>
<img width="621" height="37" alt="image" src="https://github.com/user-attachments/assets/f550f013-eec5-4143-97de-04d661457d6b" />

You will now be able to access the REST API through my main Finance Web App using the urls set using the Environment Variables:<br>
<img width="807" height="690" alt="image" src="https://github.com/user-attachments/assets/f6d33ed7-1731-40bf-a497-65822bc97d0d" />
