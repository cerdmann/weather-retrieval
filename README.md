# Basic .Net Core Web API Lab

## High Level Objectives
* Learn how to create a Web API with [.NET Core](https://www.microsoft.com/net/core)
* Ensure you have git setup and have a [GitHub](https://github.com) account

## Prerequisites

#### Helpful knowledge:
* .NET Core
* git

#### Your local environment and supporting services:
* Download a code editor:
  * [Atom](https://atom.io/)
  * [Visual Studio Code](https://code.visualstudio.com/)
* Ensure .NET Core is installed on your machine
  * I'm using the 1.1.2 found at https://github.com/dotnet/core/blob/master/release-notes/download-archives/1.1.2-download.md
* [Chrome](https://www.google.com/chrome/)
  * [Postman Plugin](https://www.getpostman.com/docs/introduction)
  * [JSON Formatter Plugin](https://chrome.google.com/webstore/detail/json-formatter/bcjindcccaagfpapjjmafapmmgkkhgoa)
* Login or create a GitHub account at https://github.com

## Initial Project Creation

* Create and change into a new directory

  ```mkdir weather-retrieval && cd weather-retrieval
  ```

* Establish a new web api Project

  ```dotnet new webapi
  ```

* Restore dependencies

  ```dotnet restore
  ```

* Run and browse to your new api

  ```dotnet run
  ```

  http://localhost:5000/api/values

* Open up your folder in the Atom IDE
* Add a .gitignore file
  * Browse to https://www.gitignore.io/
  * In the text box enter the following and hit create:
    * vim
    * macos
    * windows
    * visualstudio
    * visualstudiocode
  * Copy the resulting text from the web page and create a ```.gitignore``` file in your directory
  * Paste the text into the file and save it

* Push your application to Github
  * Login to your Github account and create a new repository called ```weather-retrieval```. Initialize it with a README.md and the appropriate license. Do not add a *.gitignore* as we previously created it
  * We need to ensure line endings are handled appropriately whether you are using windows, linux, or osx
    * At the root of your *Lab* directory, create a new file called ```.gitattributes```
    * Add the following contents to the file:

      ```
      # Handle line endings automatically for files detected as text
      # and leave all files detected as binary untouched.
      * text=auto

      #
      # The above will handle all files NOT found below
      #
      # These files are text and should be normalized (Convert crlf => lf)
      *.css           text
      *.df            text
      *.htm           text
      *.html          text
      *.java          text
      *.js            text
      *.json          text
      *.jsp           text
      *.jspf          text
      *.jspx          text
      *.properties    text
      *.sh            text
      *.tld           text
      *.txt           text
      *.tag           text
      *.tagx          text
      *.xml           text
      *.yml           text

      # These files are binary and should be left untouched
      # (binary is a macro for -text -diff)
      *.class         binary
      *.dll           binary
      *.ear           binary
      *.gif           binary
      *.ico           binary
      *.jar           binary
      *.jpg           binary
      *.jpeg          binary
      *.png           binary
      *.so            binary
      *.war           binary
      ```


* In the root of your application, execute the following command to initialize a git repo: ```git init```

* We will now associate our local git repo with our newly create Github repo and check in our newly created project
  * Grab the https or ssh location from the **Clone or download** button on your Github repo page
  * Execute the following command at the root of your lab directory:

    ```
    git remote add origin [https or ssh location from the last step]
    ```

    i.e.

    ```
    git remote add origin https://github.com/cerdmann/weather-retrieval```

  * Pull the README.md and license file from Github

    ```
    git pull origin master
    ```

    There should be no conflicts to merge.

  * Add our files to the Github repo
    * See the files that you will commit with ```git status```
    * Add the files to your commit with ```git add .``` (You can be more selective. This will add all the files to the commit)
    * Commit the files with ```git commit -m "Initial Commit"```
    * Push the files to Github: ```git push origin master```

* Add new functionality
  * rest goes here
