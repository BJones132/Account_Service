# Account_Service
This is a mostly standalone accounts service for use with my "Simple Finance App" project.\
This service is mostly standalone as it relies on an active postgres database server to perform any actions.

## About
This accounts service serves a REST API with three endpoints.\
`/addAccount` which takes a user ID to generate an account registered to the corresponding user on the database.\
`/addBalance/<id>` which takes an account ID in the URL and a decimal amount to add in the body (This number may be negative). The corresponding account is then updated with the amount.\
`/getAccounts/<uid>` which takes a valid user ID in the URL and returns all accounts linked to the corresponding user ID.

## Instructions
### Docker Compose
Docker information can be found [Here](https://www.docker.com/) -- Docker is a requirement for the Docker Compose instructions.

### Step 1
Generate and export a HTTPS certificate in `C:\Users\<CURRENT_USER>\AppData\Roaming\ASP.NET\Https`. This directory may have to be created if it does not exist.\
Generating a certificate can be done in many ways but I will show the `dotnet dev-certs` method.\
First, you will need to open a terminal in `C:\Users\<CURRENT_USER>\AppData\Roaming\ASP.NET\Https`.\
Run the command `dotnet dev-certs https -ep ./Account_Service.pfx -p <PASSWORD>`. Replace <PASSWORD> with a password of your choice. It is recommended to use a powershell new-guid or similar for a secure password.\
Next, Run `dotnet dev-certs https -t` to trust the developer certificate.
For the changes to come into effect, your browser must be restarted. (I recommend completing the next steps and restarting the browser just prior to connection to the API)

### Step 2
Edit the EXAMPLE.env file to match your needs. The FINANCEDB variable needs your postgres hostname/ip address, a username (by default "postgres") and a database name. Depending on how your postgres database was set up, a Password field may need to be added with the corresponding password.\
Select your ASPNETCORE environment. Development or Production.\
Finally, set the CERTIFICATE_PASSWORD to the password you entered in the previous step.\
Ensure that `EXAMPLE.env` is renamed to `.env`.

### Step 3
Open a terminal in the Account_Service folder alongside the compose.yaml and Dockerfile files.\
Run `docker compose up`.\
\
This should build the docker container and allow API requests to be sent to `https://localhost:5001/`. In development mode, you can navigate to `https://localhost:5001/scalar/` to view the endpoints and both development and production mode will show an OpenAPI specification at `https://localhost:5001/openapi/v1.json`.
