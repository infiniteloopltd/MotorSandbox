Motor API Authentication Example

This C# console application demonstrates how to authenticate and send a request to the Motor API using HMAC authentication.

Features

Generates an authenticated URL for the Motor API request

Uses HMAC-SHA256 to sign requests

Fetches data from the Motor API

Prerequisites

.NET Framework or .NET Core

Internet connection for API requests

Installation

Clone the repository:

git clone Motor API Authentication Example

This C# console application demonstrates how to authenticate and send a request to the Motor API using HMAC authentication.

Features

Generates an authenticated URL for the Motor API request

Uses HMAC-SHA256 to sign requests

Fetches data from the Motor API

Prerequisites

.NET Framework or .NET Core

Internet connection for API requests

Installation

Clone the repository:

git clone https://github.com/your-username/motor-api-auth.git
cd motor-api-auth

Open the project in Visual Studio.

Build the solution.

Usage

Update the publicKey and privateKey variables in Program.cs with your API credentials.

Run the application:

dotnet run

The program will output the authenticated API URL and the API response.

Code Explanation

Generating the Authenticated URL

The GenerateUriWithValidAuth function constructs an authenticated request URL using:

The current epoch time

HMAC-SHA256 signature

Query parameters for authentication

Sending the Request

The program uses WebClient to send a GET request to the authenticated URL and prints the response.git
cd motor-api-auth

Open the project in Visual Studio.

Build the solution.

Usage

Update the publicKey and privateKey variables in Program.cs with your API credentials.

Run the application:

dotnet run

The program will output the authenticated API URL and the API response.

Code Explanation

Generating the Authenticated URL

The GenerateUriWithValidAuth function constructs an authenticated request URL using:

The current epoch time

HMAC-SHA256 signature

Query parameters for authentication

Sending the Request

The program uses WebClient to send a GET request to the authenticated URL and prints the response
