# PushApp
PUSHAPP

PushApp is a workflow automation application.  Simply put, it copies files from one folder to another.  The intent is:

1.	Reduce the number of steps required to copy data.
2.	Eliminate errors when copying data manually.

EPIC
The user wants to copy image files generated by a scanning workstation to an image editing workstation.  The user wants to simplify that copy process.  The user doesn’t want to have to use Windows Explorer to manually Copy/Move files.  The user does not use the scanning workstation frequently so they may be prone to making mistakes.  The file management features in the scanning application are clumsy and have limited capability.

SCANNING WORK STATION
A legacy film scanning application (2005) creates files in a specific location on the file system. The application is not compatible with current Windows 7/10.  The application must run on Win XP.  The user has purchased a Laptop PC and installed XP to support the application. The source code for the legacy application is not available. 

The laptop must not be updated with new drivers.  Changes will cause the legacy application to fail.  The legacy application will function with .NET 4.0 installed.

This laptop must not be connected to the internet directly but must be able to connect to the edit workstation.  

EDIT WORKSTATION
The edit workstation is a Win 7/10 PC.  A second Ethernet card provides a link to the scanning workstation.  This P2P network is in a different domain so the scanning workstation is protected.

Comments:  This is un-factored code.  There are many duplicate blocks of code that will be refactored before release.  There are many constant values related to configuration that will be removed.  This code has not been heavy tested but does work properly in XP.  This code is available to review and comment.  This code is not ready for release.

-------------------------------------------------------------------------------

##FEATURE BRANCH - Redesign MainForm Status UI

description_here

-------------------------------------------------------------------------------

###USER STORY

######title of story here

-------------------------------------------------------------------------------

######narritive of story here

-------------------------------------------------------------------------------

###USER STORY

######title of story here

-------------------------------------------------------------------------------

######narritive of story here

-------------------------------------------------------------------------------

###USER STORY

######title of story here

-------------------------------------------------------------------------------

######narritive of story here

-------------------------------------------------------------------------------
