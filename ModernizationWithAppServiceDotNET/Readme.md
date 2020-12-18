# App Modernization with Azure App Services

## Overview

The **Azure App Service** is a service for hosting web applications, REST APIs and mobile backend. We can develop applications using .NET, .NET Core, Java, Ruby, Node.js, PHP or Python. The Applications will run and scale with ease on the Windows-based environments. For Linux-based environments, the web apps add the power of Microsoft Azure to the applications such as security, load balancing, auto scaling and automated management.

Azure makes it very easy to modernize our application portfolio. With Azure App Service, we can easily migrate our existing .NET applications with very minimal efforts. In this demo, we will showcase different scenarios for migrating an on-premise ASP.NET Web Forms based application to the Azure App Service.

## Key Takeaways

The key takeaways of this demo are:
* When migrating to the cloud, teams want to focus on development and DevOps improvements that increase productivity, agility, flexibility, and operational efficiency.
* Azure App Service allows team to easily migrate our existing .NET applications with very minimal efforts.

## Demo Scenario

This demo is based on SmartHotel360, which is a fictitious smart hospitality company. Due to the complexity of managing the local infrastructure, SmartHotel360 wants to re-host their web app with minimal efforts in Azure and take advantage of the Platform as a Service (PaaS).

There is only one scenario showcased here:
1. A simple web app running on local IIS connected to a local SQL Server database - In this scenario, we will be creating the resources in Azure, publish the website and the database

  ![](Images/SmartHotel360.png)

## Scenario 1 : Publish a simple web app and SQL database in Azure

There are various ways we can create and deploy the Azure resources for our app, i.e., we can create the resources in the Azure Portal or we can use Visual Studio. For this demo, we will use the Visual Studio Publishing Tool.

### Exercise 1: Getting Started

1. You will need **Visual Studio 2017/2019 Community and/or Enterprise** (Snapshot Debugger).

2. Go to Team Explorer and clone the git repo from **[here](https://servicescode.visualstudio.com/DevOps-Dojo/_git/DevOps-Dojo-Booking)**.
    
    ![](Images/GitCloning.png)

    **OR**

3. Go to Team Explorer and Click on Manage Connections and Connect to a project.
   
   ![](Images/ManageConnectionsGit.png)

4. Connect with the highlighted repo named "DevOps-Dojo-Booking" under servicescode.visualstudio.com

    ![](Images/RepoConnection.png)

3. Open the solution called **SmartHotel360.Registration**.

    >**Talk Track**: In this demonstration, we will look at the example of SmartHotel360, a fictitious hospitality company planning to use the Microsoft Azure App Service to re-host its web application to Azure.

### Exercise 2: Running App locally using SQL Server

1. You will need **SQL Server 2017** to run the application locally.

2. Go to Web.config in the solution explorer as shown below:
   ![](Images/35-WebConfig.png)

3. Update the username with value 'sa' and password with 'devadmin@123' as shown below:
   ![](Images/36-WebConfigCredentialsUpdate.png)

4. Right click the solution 'SmartHotel360.Registration' and Clean solution.
   ![](Images/37-CleanSolution.png) 

5. Build the solution and Run. You should be able to see Home page of Smart hotel in default browser.

### Exercise 3: Checkin application with association to Requirements

  1. Connect to Team Explorer in Visual studio.
  
  2. Click on Work Items assigned to you as shown below.
	![](Images/39-WorkItems.png)

  3. Note down the highlighted work item ID as shown below. It is required in Step 5.
	![](Images/40-NoteWorkItemId.png)

  4. Click on the home icon as highlighted below and updated comment for the staged changes if there are any.
	![](Images/38-TeamExplorerStagedChanges.png)

  5. Add a related work item as shown below by updating the work item id in the textbox.
	![](Images/41-AddWorkItem.png)

  6. You can add multiple work items by separating task ids using comma "," as shown below. Then click on "Add".
	![](Images/42-AddMultipleWorkItems.png)

  7. Check-in and push your staged changes/ changes in your feature branch. Then create a pull request for merge into master trunk.
	![](Images/43-CreatePullRequest.png)

  8. Update the reviewers, description and title as shown below. Then click on Create as shown below:
	![](Images/44-PullRequestDescription.png)

  9. Once the build and release succeeds, then reviewers can approve the pull request.
	![](Images/45-PullRequest.png)

  10. Once approved and all pre-reqs succeed, you can complete the pull request by clicking on Complete pull request by doing a squash merge. This will merge your code in master trunk.
	![](Images/46-CompletePullRequest.png)
   
### Exercise 4: Deploy to Azure

1. Right-click on the web project in the Visual Studio and select the **Publish** option.
    ![](Images/2-rightclickpublish.png)

    >**Talk Track**: We will cover only one scenario showing how we can migrate an on-premises ASP.NET Web Forms application to the Azure App Service. In the first scenario, the app is a simple web app running on a local IIS and is connected to a local SQL Server database.

1. Select the **App Service** on the left menu and click on the **Create New** option to create a new App Service. If an app service already exists and needs to be used, click the **Select Existing** option. Click the **Publish** button.
    ![](Images/3-newprofile.png)

    >**Talk Track**: On the Publish screen, we have options to publish apps to local development environments, Azure VMs and App Service targets. We can choose an existing profile to publish, if we have already created the resources. Since we are publishing this app for the first time, we will need to create a new profile along with the Azure resources required to run the application.


1. Provide a name in the **App Name** field, select the **Azure subscription**, select or create a new **Resource Group** and then select or create a new **Hosting Plan**. Please see the resources tab for Azure credentials that you can use.

    The following information is used here-
    ```
    App Name: SmartHotel360Registration
    Subscription: Azure Hero Solutions Subscription
    Resource Group (New): SmartHotel360Registration
    Hosting Plan (New):
        - App Service Plan: SmartHotel360RegistrationPlan
        - Location: Central US
        - Size: S1 (Minimum Size)
    ```
    ![](Images/4-newprofile.png)

1. Since this app connects to a database, click on the **Create a SQL Database** option,  create a new SQL Server and provide the credentials (username and password) for the SQL Server. Provide the **database name** and use the default name for the connection string **DefaultConnection**. Click on the **OK** button and then click on the **Create** option. This tool will connect to Azure and provision the resources required to publish the web project in the App Service.

    >**Talk Track**: In this demo, sample data generators are being used so that the blank database will be populated automatically when the website is loaded for the first time.

    ![](Images/5-ConfigureSQLDatabase.png)

### Exercise 4: Exploring the Azure App Service

1. Once the app is deployed in the Azure App Service, the website will open automatically.

    ![](Images/6-AzureWebsite.png)

   > **Talk Track**: From the URL, we can see that the web app is now live and no longer running locally. Here, we can see information of the registered customers and the status whether they are checked-in or checked-out of the hotel.

1. Launch the **Microsoft Edge** browser to view the Azure portal homepage.

    ![](Images/7-Azure.png)

1. Open the **Resource Group** that was created from the Visual Studio Publishing Tool to see the created resources.

    ![](Images/8-AzureResources.png)

1. Select the App Service, in this case, it will be the App Service **SmartHotel360Registration**.

#### Global scale with high availability

1. Under the **Settings** option in the App Service menu, choose the **Scale Up (App Service Plan)** option to see the different tiers available for this App service.

    ![](Images/9-ScaleUp.png)

    >**Talk Track**: One of the challenges is managing the infrastructure and setting up the scalability needed for our apps. Businesses should run without system failures, no matter how much they grow. With the App Services, we can scale up or down, manually or automatically. Our applications can be hosted anywhere in the Microsoft's global datacenter infrastructure and the App Service SLA promises high availability.

1. Select the **Scale Out (App Service Plan)** option in the left menu and click on the **Enable autoscale** option.  Provide an auto scale setting name and create a rule. In this scenario, use the default rule configured - If the CPU percentage is greater than 70%, add an additional instance. Click the **OK** button. We can define up to 10 maximum instances. Click on the **Save** button and our application is now set for auto scale.

    ![](Images/10-ScaleOut.png)

    >**Talk Track**: With this feature, we can increase the number of VM instances that run our application. The number of instances we can have, depends on our pricing tier. Let us configure a new autoscaling profile.

    >**Talk Track**: Here, we will use the default rule which states that if the CPU percentage is greater than 70%, it will add an additional instance.

#### Security and compliance

   The Azure App Service is ISO, SOC and PCI compliant which is a requirement for App Modernization as it requires security and compliance. Create IP address restrictions, manage service identities, add custom domains and SSL for the apps. We can create restorable archive copies of our apps content, configuration and database.

1. Click on the **Authentication / Authorization** option to setup identity provider or anonymous access.

    ![](Images/11-Authentication.png)

    >**Talk Track**: We can choose to authenticate users with the Azure Active Directory, or via other platforms such as Google, Facebook, Twitter and Microsoft.

1. Click on the **Backups** option to configure the Snapshot and Backup configuration.

    ![](Images/12-Backups.png)

    >**Talk Track**: Here we can take a snapshot of an OS or data disk VHD for backup or to troubleshoot VM issues. A snapshot is a full, read-only copy of a VHD. Here we can also backup and restore our data in Azure. Azure Backup replaces our existing on-premises or off-site backup solutions with a cloud-based solution which is reliable, secure and cost-competitive.

1. Click on the **SSL settings** option to setup the certificates and TLS.

    ![](Images/13-SSL.png)

    >**Talk Track**: Here we can configure the transport security layer (TLS), specify the certificates to be used when responding to requests to host a specific hostname over HTTPS and more.

#### DevOps optimization

Setting up a Continuous Integration and Continuous Deployment (CI/CD) with Visual Studio Team Services, GitHub, Bitbucket, Git, FTP, Dropbox or OneDrive has never been easier. The Azure App Services will setup the right configuration for our build definitions from the source control for our Azure App Service using the Build Provider.

1. We can also setup the CI/CD pipeline in Deployment options or Deployment Center. Here we can find multiple source controls and build providers.

   ![](Images/14-DeploymentCenter.png)

### Exercise 5: Application Insights

Monitoring is a big part of App Modernization - understanding which features are the most used, which pages are the most visited or what is causing the most failures will help the development team to focus more on those elements. Application Insights is an extensible Application Performance Management (APM) service for web developers on multiple platforms. Use it to monitor the live web application. It will automatically detect performance anomalies. It includes powerful analytics tools to help us diagnose issues and to understand what users do with our apps.

1. To add Application Insights to our apps, we can either use the option in the left menu of the App Service or we can use Visual Studio. Just right-click on the web project and select the **Configure Application Insights** option.

    ![](Images/15-ConfigureAppInsights.png)

    >**Talk Track**: Application Insights is an extensible Application Performance Management (APM) service that includes powerful analytics tools to help us diagnose issues and understand what customers actually do with our app. It works for apps on a wide variety of platforms, whether hosted on-premises or in the cloud. Firstly, we will need to include the Microsoft Application Insights Snapshot Collector NuGet package in our app by adding it to the code.

1. Click on the **Update SDK** button to make sure that the SDK is updated and then click on the **Start Free** button. Provide the resource name and click the **Configure Settings** button to specify the Resource Group and Location. Click on the **Register** button.  Now let us re-publish the app with the profile which we have already created.

    ![](Images/16-RegisterAppInsights.png)

1. When the application is re-published, we see that the live data is being received from our app in Azure App Service. Also, in the Azure Portal, we can see a new Application Insight resource which will show the metrics of the app including Failures, Performance Availability, etc. We can also configure alerts, export options and Work Items creation.

    ![](Images/17-AzureAppInsights.png)

### Exercise 6: Snapshot Debugger for .NET

1. Right-click on the web project and select the **Manage NuGet Package** option. Type **Microsoft.ApplicationInsights.SnapshotCollector** under the **Browse** tab and click on the *Install* option to include it in our web project.

    ![](Images/18-NugetPackage.png)

     > **Talk Track**: Debugging apps can be difficult especially if the app is running on production. With the Snapshot Debugger, we can take a snapshot of our in-production apps. The debugger lets us see exactly what went wrong, without impacting traffic of our production application. The Snapshot Debugger can help us dramatically reduce the time taken to resolve issues that occur in production environments.

1. Let us introduce a bug in the code. Open the file **Checkin.aspx.cs**, comment the **line 19** and uncomment **line 20**. So, the code will look like this:

    ```
    //int.TryParse(Request.QueryString["registration"], out int registrationId);
    int.TryParse(Request.QueryString["registrationId"], out int registrationId);
    ```

   This will throw an ArgumentException in the line 23, so a new exception will be stored in the Application Insights and we will be able to download the snapshot for that exception.

    ![](Images/19-CheckIn.png)

1. Let us re-publish the web project with the profile created. Once the website is running, click on the **CheckIn** option in the web page and notice the ArgumentException exception for the error that we just created.

    ![](Images/20-ArgumentException.png)

1. In the Application Insights Service in Azure Portal, navigate to the **Failures** and open the exception with the error **System.ArgumentException**.

    ![](Images/21-AppInsightException.png)

    >**Talk Track**: Here, we can track all the metrics associated with our app, including failures and performance availability. We can also configure alerts, work items, and more. Let us review the exceptions.

1. Click the **Open debug snapshot** option and then click on the **Download Snapshot** option.

    ![](Images/22-DownloadSnapshot.png)

1. Open **Visual Studio Enterprise 2017** and open the solution **SmartHotel360.Registration**. Open the file that was downloaded and then click on the **Debug with Managed Only** option. This will set the Visual Studio in debug mode and then click the **Continue Debugging** option to see when the Argument Exception was thrown.

    ![](Images/23-SnapshotDebugging.png)

   > **Talk Track**: The snapshot or the dump file, contains both Snappoints and Logpoints. We can use **Snappoints** and **Logpoints** to make it easy to debug in production. Snappoints are like breakpoints that allow us to take snapshots of a system when a given line is executed, but without noticeably pausing the execution of the application. Logpoints work in the same way, except that they allow us to inject custom logging into production apps on the fly.

1. Use the **Cloud Explorer** and navigate to the App Services in Azure. Right-click on the website and select the **create a snappoint** option which will debug the App Services remotely without affecting its runtime. However, we may need to reset the App Service to enable the snappoint.

    ![](Images/24-AttachSnapshotDebuger.png)

## Summary

Azure App Service enables us to modernize our app portfolio in a very easy and painless way. We can build and host web applications in the programming language of our choice without managing the infrastructure. It offers auto-scaling and high availability, supports both Windows and Linux, and enables automated deployments from GitHub, Visual Studio Team Services or any other repositories. Get started [here with Azure App Service](https://azure.microsoft.com/services/app-service).
