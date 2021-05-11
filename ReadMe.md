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
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
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

<p>To install the project, follow the simple instructions provided below</p>

<h3 id="prerequisites">Prerequisites</h3>
<ul>
    <li>
        <div>
            Create an azure web server
            <pre>Link here</pre>
        </div>
    </li>
</ul>

<h3 id="installation">Installation</h3>
<ol>
    <li>
        <div>
            Clone the repo
            <pre>git clone https://github.com/Tammo32/WebCrawler.git</pre>
        </div>
    </li>
    <li>
        Check to make sure the following NuGet packages are installed
        <h4>Packages for JobSpotApplication</h4>
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
        <h4>Packages for JobSpotApplication.Tests</h4>
        <ul>
            <li><pre>coverlet.collector v1.3.0</pre></li>
            <li><pre>Microsoft.NET.Test.Sdk v16.7.1</pre></li>
            <li><pre>xunit v2.4.1</pre></li>
            <li><pre>xunit.runner.visualstudio v2.4.3</pre></li>
        </ul>
        <h4>Packages for WebScraper</h4>
        <ul>
            <li><pre>Dapper v2.0.90</pre></li>
            <li><pre>HtmlAgilityPack v1.11.33</pre></li>
            <li><pre>System.Configuration.ConfigurationManager v5.0.0</pre></li>
            <li><pre>System.Data.SqlClient v4.8.2</pre></li>
        </ul>
        <h4>Packages for WebScraperDebugger</h4>
        <ul>
            <li><pre>Debugger currently has no installed packages</pre></li>
        </ul>
    </li>
</ol>

<h2 id="usage">Usage</h2>
<p>Demonstrate how the project is used, include screenshots and step by step instructions here.</p>

<h2 id="license">License</h2>
<p></p>

<h2 id="contact">Contact</h2>
<ul>
    <li>Michael Tamasaukas - s3562292@student.rmit.edu.au</li>
    <li>Wade Stephenson - email</li>
    <li>Craig Ryan - email</li>
    <li>John Jairo Caicedo Gomez - email</li>
    <li>Thomas Kauran - s3305113@student.rmit.edu.au</li>
</ul>
