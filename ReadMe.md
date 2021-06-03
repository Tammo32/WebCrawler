
<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
    <a href="#about">About The Project</a>
      <ul>
      <li><a href="#features">Features</a></li>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#get-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation and Deployment</a></li>
        <ul>
          <li><a href="#Clone">Clone the repo</a></li>
          <li><a href="#Check">Check NuGet packages</a></li>
          <li><a href="#Azure">Open your Azure Portal to create the app resouces</a></li>
          <li><a href="#Commands">Commands to set up your resourses</a></li>
          <li><a href="#Deploy">Deploy your cloned repo to Azure</a></li>
          <li><a href="#Key">Setting up Key Vault</a></li>
          <li><a href="#Identity">Create app Identity and register it with Key Vault</a></li>
          <li><a href="#Go">Ready to go!</a></li>
        </ul>
      </ul>
    </li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<h3 id="about">About The Project</h3>

<p>JobSpot was created to help people find jobs more conveiniently by providing a place to search for jobs listed on multiple other job based search engines.</p>
<p>Users sign up for a free account and provided with an easy to fill in search form and immediately start searching for jobs. JobSpot currently scrapes job data from both https://seek.com.au and https://au.indeed.com/ and stores that data into a database so that users can then review their search results later on if they leave and come back later.</p>
<p>Data scraped from these websites include Position titles, description, location, salary and a url link to the website that posted the position, this way credit is given to the website owners the job data was scraped from and users can only apply for the jobs through the respective website the job posting originated from.</p>

<h3 id="features">Some features currently included are:</h3>

<ul>
    <li>Job searching from multiple websites</li>
        <ul>
            <li>Data is currently scraped from seek and indeed</li>
            <li>With room for more websites to be added to the web scraper</li>
        </ul>
    <li>Search Scheduling</li>
        <ul>
            <li>User defined scheduling preferences</li>
            <li>Scheduling system has a administration portal for administrators to monitor and interact with scheduled job searches</li>
            <li>Scheduling system fires an email to the user who created the scheduled job, once a scheduled job has completed</li>
        </ul>
    <li>User Accounts</li>
        <ul>
            <li>User Dashboard</li>
            <li>Users can change their scheduling preferences</li>
            <li>Users can update their email-address and password</li>
            <li>Users can delete their accounts and all data related to the account</li>
        </ul>
    <li>Back-end administration dashboard</li>
        <ul>
            <li>Administrator dashboard</li>
            <li>Admins can disable or delete user accounts</li>
            <li>Admins can delete job listings and related data</li>
        </ul>
</ul>

<h3 id="built-with">Built With</h3>

<ul>
    <li>Microsoft Asp.net core 3.1</li>
    <li>Microsoft SQL Server</li>
    <li>jQuery</li>
    <li>Bootstrap</li>
    <li>Hangfire.io</li>
    <li>Dapper micro ORM</li>
</ul>

<h2 id="get-started">Getting started</h2>

<p>To install the project, follow the recommended instalation instructions below</p>

<h3 id="prerequisites">Prerequisites</h3>
<ul>
    <li>
         <div>
            A Microsoft account OR a phone number, credit card and GitHub account
         </div>
    </li>
    <li>
        <div>
            An Azure account for hosting web applications.
            <pre>https://azure.microsoft.com/en-au/free/dotnet/</pre>
        </div>
    </li>
  <li>
         <div>
            A SendGrid API key - userd for email services.
           <p>You will need an active email account to set this up.</p>
           <pre>https://sendgrid.com/docs/for-developers/sending-email/api-getting-started/</pre>
         </div>
    </li>
  <li>
         <div>
            Social media login API keys - used for third party authentication.
           <p>You will need active social media accounts to set these up. The app currently uses Google, FaceBook and Twitter third party authentication.</p>
         </div>
    </li>
</ul>

<h3 id="installation">Installation and Deployment</h3>
<ol>
    <li>
        <div>
          <h4 id="Clone">Clone the repo</h4>
            <pre>git clone https://github.com/Tammo32/WebCrawler.git</pre>
        </div>
    </li>
    <li>
        <h4 id="Check">Check to make sure the following NuGet packages are installed</h4>
        Packages for JobSpotApplication
        <ul>
            <li><pre>Azure.Extensions.AspNetCore.Configuration.Secrets v1.0.2</pre></li>
            <li><pre>Azure.Identity v1.3.0</pre></li>
            <li><pre>Azure.Security.KeyVault.Secrets v4.1.0</pre></li>
            <li><pre>Hangfire.AspNetCore v1.7.22</pre></li>
            <li><pre>Hangfire.SqlServer v1.7.22</pre></li>
            <li><pre>Hangfire.Core v1.7.22</pre></li>
            <li><pre>Microsoft.AspNet.Mvc v5.2.7</pre></li>
            <li><pre>Microsoft.AspNetCore.Authentication.Facebook v3.1.0</pre></li>
            <li><pre>Microsoft.AspNetCore.Authentication.Google v3.1.0</pre></li>
            <li><pre>Microsoft.AspNetCore.Authentication.Twitter v3.1.0</pre></li>
            <li><pre>Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore v3.1.12</pre></li>
            <li><pre>Microsoft.AspNetCore.Identity.EntityFrameworkCore v3.1.13</pre></li>
            <li><pre>Microsoft.AspNetCore.Identity.UI v3.1.13</pre></li>
            <li><pre>Microsoft.EntityFrameworkCore.Proxies v3.1.14</pre></li>
            <li><pre>Microsoft.EntityFrameworkCore.SqlServer v3.1.13</pre></li>
            <li><pre>Microsoft.EntityFrameworkCore.Tools v3.1.13</pre></li>
            <li><pre>Microsoft.jQuery.Unobtrusive.Ajax v3.2.6</pre></li>
            <li><pre>Microsoft.VisualStudio.Web.CodeGeneration.Design v3.1.5</pre></li>
            <li><pre>SendGrid v9.22.0</pre></li>
        </ul>
        Packages for JobSpotApplication.Tests
        <ul>
            <li><pre>coverlet.collector v1.3.0</pre></li>
            <li><pre>Microsoft.NET.Test.Sdk v16.7.1</pre></li>
            <li><pre>xunit v2.4.1</pre></li>
            <li><pre>xunit.runner.visualstudio v2.4.3</pre></li>
        </ul>
        Packages for WebScraper
        <ul>
            <li><pre>Dapper v2.0.90</pre></li>
            <li><pre>HtmlAgilityPack v1.11.33</pre></li>
            <li><pre>System.Configuration.ConfigurationManager v5.0.0</pre></li>
            <li><pre>System.Data.SqlClient v4.8.2</pre></li>
        </ul>
        Packages for WebScraperDebugger
        <ul>
            <li><pre>Debugger currently has no installed packages</pre></li>
        </ul>
    </li>
    <li>
      <div>
        <h4 id="Azure">Open your Azure Portal to create the app resouces needed</h4>
        <pre>https://portal.azure.com/</pre>
        Run the cloud shell app
        <img width="754" alt="AzureBanner" src="https://user-images.githubusercontent.com/22534994/118344529-a6d56e00-b56d-11eb-83f4-908e82750d7c.PNG">
     </li>
     <li>
        <h4 id="Commands">Once cloud shell is running, use the following commands to set up your resourses</h4>
        This command will show a list of service locations, take a note of one that is in your region.
        <pre>az appservices list-locations --sku FREE</pre>
        This command will create a resouce in which all the services are stored to host the project. Replace <code>&ltYour Resouce Name&gt</code> and <code>&ltYour Location&gt</code> with a researce name and loaction of your choice.
        <pre>az group create --name &ltYour Resource Name&gt --location "&ltYour Location&gt"</pre>
        This command will create an SQL server and link it to your resoure group. Replace <code>&ltYour Unique DB Server Name&gt</code> with a globaly unique name, the prompt will tell you if the name already exists. Allowable characters are <code>0</code> -&gt <code>1</code> <code>a</code> -&gt <code>z</code>. Also, make sure to use the name of the <b>resource name</b> previously created and set the DB <b>user name</b> and <b>password</b> to your choosing.
        <pre>az sql server create --name &ltYour Unique DB Server Name&gt --resource-group &ltYour Resource Name&gt --location "&ltYour Location&gt" --admin-user &ltdb-username&gt --admin-password &ltdb-password&gt</pre>
        This command set's a fire wall rule so that only this app can access your database. Only replace <code>&ltYour Resource Name&gt</code> and <code>&ltYour Unique DB Server Name&gt</code> with names chosen in the previous step.
       <pre>az sql server firewall-rule create --resource-group &ltYour Resource Name&gt --server &ltYour Unique DB Server Name&gt --name AllowAzureIps --start-ip-address 0.0.0.0 --end-ip-address 0.0.0.0</pre>
        This command with generate the actual database. <b>Remember to change the placeholder variables with your chosen names.</b>
       <pre>az sql db create --resource-group &ltYour Resource Name&gt --server &ltYour Unique DB Server Name&gt --name &ltYour DB Name&gt --service-objective S0</pre>
        This command will promt you to enter the user name and password created in the previous steps. After entering your credentuals, you will be shown the DB connection string. Copy the connection string and paste it into the appsettings.json files for both the JobSpotAplication and WebScraper projects. This string is placed after the <code>"DefaultConnection" :</code> and <code>"HangfireConnection" :</code> connection string names.
       <pre>az sql db show-connection-string --client ado.net --server &ltYour Unique DB Server Name&gt --name &ltYour DB Name&gt</pre>
       </div>
    </li>
    <li>
      <div>
       <h4 id="Deploy">Deploy your cloned repo to Azure</h4>
        Use the following command to allow git deplyment from your local repository. Set the placholder <b>username</b> and <b>password</b> with a unique user name and password of your choice. <b>Take note and keep them safe.</b>
        <pre>az webapp deployment user set --user-name &ltYour Unique Username&gt --password &ltpassword&gt</pre>
        This command creates a plan to serve the app from your resouce. In this case the hosting plan is free for 12 months.
        <pre>az appservice plan create --name &ltYour App Services Plan&gt --resource-group &ltYour Resource Name&gt --sku FREE</pre>
        This command creates and empty application within your resource and associtates it with your plan / payment structure, in this case its free. The app name must also be unique within Azure. 
        <pre>az webapp create --resource-group &ltYour Resource Name&gt --plan &ltYour App Services Plan&gt --name &ltYour Unique App Name&gt --runtime "DOTNETCORE|3.1" --deployment-local-git</pre>
        <p>The output will show a configeration file, take note of the line:</p>
        <pre>"deploymentLocalGitUrl": "https://&ltYour Unique Username&gt@&ltYour Unique App Name&gt.scm.azurewebsites.net/&ltYour Unique App Name&gt.git"</pre>
        Use the following command to connect the app to the database. Replace &ltDefault Connection String&gt with the one that was copied into the appsetting.json files earlier.
        <pre>az webapp config connection-string set --resource-group &ltYour Resource Name&gt --name &ltYour Unique App Name&gt --settings MyDbConnection="&ltDefault Connection String&gt" --connection-string-type SQLAzure</pre>
        Next, open git bash again to the folder where your local repository is stored and run the folling commands to add Azure to the local git repository.
        <pre>git remote add azure https://&ltYour Unique Username&gt@&ltYour Unique App Name&gt.scm.azurewebsites.net/&ltYour Unique App Name&gt.git</pre>
        Finally, run the following command to push the app to your live server.
        <pre>git push azure master</pre>
      </div>
    </li>
    <li>
  <h4 id="Key">Setting Up Key Vault</h4>
    <p>Key Vault is used to store user secrets in Azure. Back in the Azure portal</p>
    <pre>https://portal.azure.com/#home</pre>
    Click on the Key Vault icon to create a new resource.
    <img width="533" alt="AzureKeyVault" src="https://user-images.githubusercontent.com/22534994/118383497-69401600-b63d-11eb-9cbd-b8dc60aad7b4.PNG">
    <p>Click new and follow the prompts to setup the resource. <b>Note that the keys cannot be added until after the "create and review step.</b></p>
    <img width="769" alt="NewKeyVault" src="https://user-images.githubusercontent.com/22534994/118383577-50843000-b63e-11eb-9157-b7e8651b6927.PNG">
    <p>Once the resource has been created, click the Key Vault line of the Recent resouce table.</p>
    <img width="681" alt="RecentResource" src="https://user-images.githubusercontent.com/22534994/118383669-3f87ee80-b63f-11eb-8dd1-1fb53a3da987.PNG">
    <p>Then, click the Key vault hamburger menu and move down and click the "Secrets" item.</p>
    <img width="281" alt="AddSecrets" src="https://user-images.githubusercontent.com/22534994/118383710-968dc380-b63f-11eb-9a5c-1aefb77e5ced.PNG">
     <p>Click "Generate/Import, add the key name ie "Authentication--Facebook--AppId" and the key value, then click save. Continue for each key / value pair. You should end up with a list of 8 key / value pairs for this app, two for each third party authentication and two for the email sender service.</p>
     </li>
     <li>
      <h4 id="Identity">Create app Identity and register it with Key Vault</h4>
      <p>Back on the Azure portal home page, click the App Service line from the Recent resources table.</p>
      <p>From the App Services hamburger menu, select Itendity.</p>
  <img width="225" alt="AppID" src="https://user-images.githubusercontent.com/22534994/118384355-9f34c880-b644-11eb-8fc9-3b3aaf783bc4.PNG">
      <p>Under "System Assigned" select status "on". This will register the app with Azure Active Directory and make it discoverable to the Key Vault.</p>
  <img width="413" alt="StatusOn" src="https://user-images.githubusercontent.com/22534994/118384494-8d075a00-b645-11eb-9f0d-045686ac025a.PNG">
      <p>Navigate back the Key Vault resource and from the hamburger menu, sellect "Access Control"</p>
  <img width="291" alt="AccessControll" src="https://user-images.githubusercontent.com/22534994/118384585-4f570100-b646-11eb-99bc-9ef7fd9ee159.PNG">
      <p>Click add, select "App Service" from the drop down menu, and type the application name into the search box. Select the application from the search reults and save. The app should now have access to Key Vault.</p>
  <img width="791" alt="AddRoleAssignment" src="https://user-images.githubusercontent.com/22534994/118384656-fcca1480-b646-11eb-9d27-9ce2df67138d.PNG">
  </li>
  <li><h4 id="Go"><p><b>You should now be all set-up and ready to go! Navigate to the URL and try it out.</b></p></h4>
     </li>
</ol>

<h2 id="license">License</h2>
<p>Please see: https://creativecommons.org/licenses/by/4.0/</p>

<h2 id="contact">Contact</h2>
<ul>
    <li>Michael Tamasaukas - s3562292@student.rmit.edu.au</li>
    <li>Wade Stephenson - s3749078@student.rmit.edu.au</li>
    <li>Craig Ryan - s3555490@student.rmit.edu.au</li>
    <li>John Jairo Caicedo Gomez - s3551566@student.rmit.edu.au</li>
    <li>Thomas Kauran - s3305113@student.rmit.edu.au</li>
</ul>
