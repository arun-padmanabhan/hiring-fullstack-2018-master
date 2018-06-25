# Full stack programming task #

Expected duration:  24 hours
Payment :			$2,000 + GST

Growing Data's key strength is our ability to take large, complex data sets, transform them and build simple interactive interfaces on top of them.  As such, we want to test your ability to both deal with large data sets, and create web based interfaces.


# Task Brief #
The task is designed so that you can showcase not only your skills and knowledge, but also your ability to learn and be productive with unfamiliar technologies.  We do not expect that you are proficient with these technologies, but we do expect that with a small amount of time you can be productive with them.

At the very least this project is a good (paid) way for you to learn more about:
    * React.js
    * DotNet Core
    * ASP.Net Core
    * Google Cloud Storage 
	* Google Cloud SQL

## Phase 1: SQL Extractor
Build a .Net Core Console application that connects to a PostgreSQL Server database, and copies data from table to Google Cloud Storage as tab seperated volumes (TSV).

The following command:

    dotnet run public.Actor

(executed within the ./DataLoadReadReview.Load directory)

Should connect to the database, query the provided table and copy the output to the Google Cloud Storage Bucket, with a file name that looks like:

        "{table_name}_{CurrentDate:yyyy-MM-dd}.tsv"

## Phase 2: .Net Core API Based SqlExtractor
Create a .Net Core API project which has the following end points:

    GET /api/extract/{dbName}/{tableName}

Which will copy the {tableName} from {dbName} to Google Cloud Storage and return the full url of the tsv file, and a status code in Json format (including human readable error messages)

    GET /api/list-tables/{dbName}

Which will list all the tables in the database in JSON format

The .Net Core API should be launched with:

    dotnet run

(executed within the ./DataLoadReadReview.Api directory)

Which will make the http server available at http://localhost:5001, which should mean that opening a browser to:

http://localhost:5001/api/list-tables/{dbName}

Should provide me with a list of tables in the database, in JSON format.


## Phase 3: React.js interfaces
Using React.js, from within the DataLoadReadReview.Web, build a basic web based interface so that viewing:

    http://localhost:5002/{dbName}

Will show a list of tables in the database given by {dbName}.

The .Net Core Website should be launched with:

    dotnet run

(executed within the ./DataLoadReadReview.Web directory)

Each list item should also have a button to call the API to extract the table to Google Cloud Storage, and provide the user with feedback.


## Phase 4: Extra credit
* Modify the SQL Extractor to be able to "stream" large tables to Google Cloud Storage, without storing the file locally.  Imagine that you have a table with 100 billion rows, and therefore saving the TSV file to the local disk (or memory) is unworkable.  You therefore need a way to stream data directly to Google Cloud Storage.  

* Make the web interface pretty

* Add end points detailing meta-data from Google Cloud Storage (whether a file exists for the given table, number of rows, file size, last write time, etc) 

 
# Getting Started #
We have created a repository at:
    https://bitbucket.org/growingdata/hiring-fullstack

Which contains boilerplate code to get you up and running.  For ease of development, we recommend that you install Visual Studio 2017, the community (free) version is available at:
    https://www.visualstudio.com/downloads/

The repository / solution is broken down into 3 projects, which correspond to the 3 phases of the task:

The DataLoadReadReview.Load project has some very basic and very crude code to illustrate Goolge Clould Platform access via the APIs to get you up and running. Additionally the tools folder in the root of the repo contains a BAT file (GCP.Client.Secret.Candidate.Task.bat) that opens a proxy the the Google Clould SQL server on port 5701.

## DataLoadReadReview.Load ##
Console application for you to build the functionality that actually connects to a database and dumps the output to Google Cloud Storage.

## DataLoadReadReview.Api ##
The ASP.Net Core application which will host the http server for the API project.

## DataLoadReadReview.Web ##
The ASP.Net Core application React.js which you will build your user interface in. The following post by Microsoft should come in handy is you are new to React.js - https://docs.microsoft.com/en-us/aspnet/core/spa/react?view=aspnetcore-2.1&tabs=visual-studio

Each Project has a configuration file appsettings.json, we recommend you store the credentials you received per e-mail in them. When you run each of the applications, we recommend the configuration values should be outputted to the console.